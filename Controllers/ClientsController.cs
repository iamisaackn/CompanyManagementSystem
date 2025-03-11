using System; // Provides basic system functionalities
using System.Collections.Generic; // Enables usage of collection classes like List
using System.Linq; // Facilitates LINQ queries for data manipulation
using System.Threading.Tasks; // Enables asynchronous programming
using Microsoft.AspNetCore.Mvc; // Provides MVC controller functionalities
using Microsoft.AspNetCore.Mvc.Rendering; // Used to create dropdown lists in views
using Microsoft.EntityFrameworkCore; // Enables interaction with the database via Entity Framework Core
using CompanyManagementSystem.Data; // Access to the application's database context
using CompanyManagementSystem.Models; // Contains models used in the application
using CompanyManagementSystem.Views.Shared.Components.SearchBar; // Namespace for custom SearchBar components
using Microsoft.AspNetCore.Authorization; // Allows role-based authorization

namespace CompanyManagementSystem.Controllers
{
    [Authorize(Roles = "Admin, Employee")] // Restricts access to Admin and Employee roles
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _db; // Database context for managing clients
        private readonly Audit _audit; // Utility for logging audit trails

        // Constructor to inject database context and audit service
        public ClientsController(ApplicationDbContext db, Audit audit)
        {
            _db = db;
            _audit = audit;
        }

        // Generate a list of page size options for pagination dropdowns
        private List<SelectListItem> GetPageSizes(int selectedPageSize = 10)
        {
            var pagesSizes = new List<SelectListItem>();

            // Add page size "5" with a selected flag if it matches the selectedPageSize
            if (selectedPageSize == 5)
                pagesSizes.Add(new SelectListItem("5", "5", true));
            else
                pagesSizes.Add(new SelectListItem("5", "5"));

            // Add page sizes from "10" to "100" in increments of 10
            for (int lp = 10; lp <= 100; lp += 10)
            {
                if (lp == selectedPageSize)
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true)); // Mark as selected
                }
                else
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString()));
                }
            }
            return pagesSizes;
        }

        // Action to display a paginated list of clients with search functionality
        public IActionResult Index(int pg = 1, string SearchText = "", int pageSize = 5)
        {
            List<Client> clients;

            // Filter clients based on search text if provided
            if (SearchText != "" && SearchText != null)
            {
                clients = _db.Clients
                    .Where(cat => cat.ClientName.Contains(SearchText))
                    .ToList();
            }
            else
            {
                // Retrieve all clients ordered by last updated date
                clients = _db.Clients.OrderByDescending(client => client.UpdatedAt).ToList();
            }

            // Set default page if invalid
            if (pg < 1) pg = 1;

            // Pagination setup
            int recsCount = clients.Count(); // Total number of records
            var pager = new Pager(recsCount, pg, pageSize); // Create a pager instance
            int recSkip = (pg - 1) * pageSize; // Calculate records to skip
            var data = clients.Skip(recSkip).Take(pager.PageSize).ToList(); // Get the current page data

            // Configure search pager for the view
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            { Action = "index", Controller = "clients", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            // Pass page size options to the view
            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            // Return the list of clients to the view
            return View(data);
        }

        // Action to display the form for adding a new client
        public IActionResult Add()
        {
            ViewBag.Action = "Add"; // Specify the action type for the view
            var model = new Client(); // Create a new Client model instance

            // Retrieve branches for dropdown options
            var branches = _db.Branches.ToList();

            // Populate BranchOptions dropdown with branch data
            model.BranchOptions = branches.Select(b => new SelectListItem
            {
                Value = b.BranchId,
                Text = b.BranchName
            }).ToList();

            return View(model); // Return the model to the view
        }

        [HttpPost] // Handles HTTP POST requests
        public IActionResult Add(Client client)
        {
            if (client == null)
            {
                return NotFound(); // Return 404 if the client is null
            }

            // Validate the model state
            if (ModelState.IsValid)
            {
                // Add the new client to the database
                _db.Clients.Add(client);
                _db.SaveChanges();

                // Log the creation action in the audit trail
                _audit.LogAudit("Create", "clients", client.ClientId, User.Identity.Name, _db);

                // Display success message and redirect to the Index action
                TempData["AlertMessage"] = "Client Created Successfully...";
                return RedirectToAction(nameof(Index));
            }

            // Return to the view if validation fails
            return View(client);
        }

        // Action to display the form for editing an existing client
        public IActionResult Edit(string id)
        {
            ViewBag.Action = "Edit"; // Specify the action type for the view

            // Find the client by its ID
            var client = _db.Clients.Find(id);
            if (client == null)
            {
                return NotFound(); // Return 404 if the client is not found
            }

            // Populate BranchOptions dropdown with branch data
            var branches = _db.Branches.ToList();
            client.BranchOptions = branches.Select(b => new SelectListItem
            {
                Value = b.BranchId,
                Text = b.BranchName
            }).ToList();

            return View(client); // Return the client model to the view
        }

        [HttpPost] // Handles HTTP POST requests
        public IActionResult Edit(Client client)
        {
            // Retrieve the client to update from the database
            var clientToUpdate = _db.Clients.Find(client.ClientId);

            if (clientToUpdate == null)
            {
                return NotFound(); // Return 404 if the client is not found
            }

            // Update client properties
            clientToUpdate.ClientName = client.ClientName;
            clientToUpdate.BranchId = client.BranchId;
            clientToUpdate.UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));

            // Validate the model state
            if (ModelState.IsValid)
            {
                try
                {
                    // Save changes to the database
                    _db.SaveChanges();

                    // Log the update action in the audit trail
                    _audit.LogAudit("Update", "clients", client.ClientId, User.Identity.Name, _db);

                    // Display success message and redirect to the Index action
                    TempData["AlertMessage"] = "Client Updated Successfully...";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log and handle exceptions
                    Console.WriteLine($"Error updating client: {ex.Message}");
                    throw; // Re-throw the exception to propagate it
                }
            }

            // Return to the view with validation errors if the model state is invalid
            return View(client);
        }

        // Action to delete a client
        public IActionResult Delete(string clientid)
        {
            try
            {
                // Find the client by its ID
                var client = _db.Clients.Find(clientid);
                if (client != null)
                {
                    // Remove the client from the database
                    _db.Clients.Remove(client);
                    _db.SaveChanges();

                    // Log the deletion action in the audit trail
                    _audit.LogAudit("Delete", "clients", clientid, User.Identity.Name, _db);

                    // Display success message
                    TempData["AlertMessage"] = "Client Deleted Successfully...";
                }
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.WriteLine($"Error deleting client: {ex.Message}");
                throw; // Re-throw the exception
            }

            // Redirect to the Index action
            return RedirectToAction(nameof(Index));
        }
    }
}
