using System; // Provides basic system functionalities
using System.Collections.Generic; // Used for collections such as List
using System.Linq; // Provides LINQ functionalities for querying data
using System.Threading.Tasks; // Enables asynchronous programming
using Microsoft.AspNetCore.Mvc; // Provides MVC controller functionalities
using Microsoft.AspNetCore.Mvc.Rendering; // Used to create dropdown lists in views
using Microsoft.EntityFrameworkCore; // Enables database interaction through Entity Framework Core
using CompanyManagementSystem.Data; // Provides access to the application's database context
using CompanyManagementSystem.Models; // Includes models used in the application
using CompanyManagementSystem.Views.Shared.Components.SearchBar; // Namespace for custom SearchBar components
using Microsoft.AspNetCore.Authorization; // Enables authorization functionalities
using Microsoft.CodeAnalysis.Operations; // Provides Roslyn-based operations

namespace CompanyManagementSystem.Controllers
{
    [Authorize(Roles = "Admin, Employee")] // Restricts access to Admin and Employee roles only
    public class BranchSuppliersController : Controller
    {
        private readonly ApplicationDbContext _db; // Application's database context
        private readonly Audit _audit; // Utility for logging audit trails

        // Constructor to initialize the database context and audit utility
        public BranchSuppliersController(ApplicationDbContext db, Audit audit)
        {
            _db = db;
            _audit = audit;
        }

        // Method to generate a list of page size options for pagination dropdown
        private List<SelectListItem> GetPageSizes(int selectedPageSize = 10)
        {
            var pagesSizes = new List<SelectListItem>();

            // Add page size "5" with selected flag if it matches the selectedPageSize
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
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString())); // Add without selection
            }
            return pagesSizes;
        }

        // Action method to display a paginated list of branch suppliers with search functionality
        public IActionResult Index(int pg = 1, string SearchText = "", int pageSize = 5)
        {
            List<BranchSupplier> branchSuppliers;

            // Filter branch suppliers based on search text if provided
            if (SearchText != "" && SearchText != null)
            {
                branchSuppliers = _db.BranchesSupplier
                    .Where(cat => cat.SupplierName.Contains(SearchText))
                    .ToList();
            }
            else
            {
                // Retrieve all branch suppliers ordered by last updated date
                branchSuppliers = _db.BranchesSupplier.OrderByDescending(branch => branch.UpdatedAt).ToList();
            }

            // Setup pagination
            if (pg < 1) pg = 1; // Ensure the page number is valid
            int recsCount = branchSuppliers.Count(); // Count total records
            var pager = new Pager(recsCount, pg, pageSize); // Create a pager instance
            int recSkip = (pg - 1) * pageSize; // Calculate the records to skip
            var data = branchSuppliers.Skip(recSkip).Take(pager.PageSize).ToList(); // Get the current page data

            // Configure the search pager for the view
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            { Action = "index", Controller = "branchsuppliers", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            // Pass page size options to the view
            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            // Return the list of branch suppliers to the view
            return View(data);
        }

        // Action to display the view for adding a new branch supplier
        public IActionResult Add()
        {
            ViewBag.Action = "Add"; // Specify the action type for the view
            var model = new BranchSupplier(); // Create a new BranchSupplier model instance

            // Retrieve branches for dropdown options
            var branches = _db.Branches.ToList();

            // Populate the BranchOptions dropdown with branch data
            model.BranchOptions = branches.Select(b => new SelectListItem
            {
                Value = b.BranchId,
                Text = b.BranchName
            }).ToList();

            return View(model); // Return the model to the view
        }

        [HttpPost] // Specifies that this action handles HTTP POST requests
        public IActionResult Add(BranchSupplier branchSupplier)
        {
            if (branchSupplier == null)
            {
                return NotFound(); // Return 404 if the supplier is null
            }

            // Validate the model
            if (ModelState.IsValid)
            {
                // Add the new branch supplier to the database
                _db.BranchesSupplier.Add(branchSupplier);
                _db.SaveChanges();

                // Log the creation action in the audit trail
                _audit.LogAudit("Create", "branchessupplier", $"{branchSupplier.BranchId} - {branchSupplier.SupplierName}", User.Identity.Name, _db);

                // Display success message and redirect to the Index action
                TempData["AlertMessage"] = "Supplier Created Successfully...";
                return RedirectToAction(nameof(Index));
            }

            return View(branchSupplier); // Return to the view if validation fails
        }

        // Action to display the view for editing an existing branch supplier
        public IActionResult Edit(string id, string supplierName)
        {
            ViewBag.Action = "Edit"; // Specify the action type for the view

            // Find the branch supplier by its branch ID and supplier name
            var supplier = _db.BranchesSupplier.Find(id, supplierName);
            if (supplier == null)
            {
                return NotFound(); // Return 404 if the supplier is not found
            }

            // Populate branch dropdown options
            var branches = _db.Branches.ToList();
            supplier.BranchOptions = branches.Select(b => new SelectListItem
            {
                Value = b.BranchId,
                Text = b.BranchName,
            }).ToList();

            return View(supplier); // Return the supplier model to the view
        }

        [HttpPost] // Specifies that this action handles HTTP POST requests
        public IActionResult Edit(BranchSupplier supplier)
        {
            // Find the supplier to update using its branch ID and supplier name
            var supplierToUpdate = _db.BranchesSupplier.Find(supplier.BranchId, supplier.SupplierName);

            if (supplierToUpdate == null)
            {
                return NotFound(); // Return 404 if the supplier is not found
            }

            // Update the supplier properties
            supplierToUpdate.SupplyType = supplier.SupplyType;
            supplierToUpdate.UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));

            // Validate the model
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the changes to the database
                    _db.SaveChanges();

                    // Log the update action in the audit trail
                    _audit.LogAudit("Update", "branchessupplier", $"{supplier.BranchId} - {supplier.SupplierName}", User.Identity.Name, _db);

                    // Display success message and redirect to the Index action
                    TempData["AlertMessage"] = "Supplier Updated Successfully...";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception or handle appropriately
                    Console.WriteLine($"Error updating supplier: {ex.Message}");
                    throw; // Re-throw the exception
                }
            }

            // Return to the view if validation fails
            return View(supplier);
        }

        // Action to delete a branch supplier
        public IActionResult Delete(string branchId, string supplierName)
        {
            try
            {
                // Find the branch supplier by its branch ID and supplier name
                var record = _db.BranchesSupplier.Find(branchId, supplierName);
                if (record != null)
                {
                    // Remove the branch supplier from the database
                    _db.BranchesSupplier.Remove(record);
                    _db.SaveChanges();

                    // Log the deletion action in the audit trail
                    _audit.LogAudit("Delete", "branchessupplier", $"{branchId} - {supplierName}", User.Identity.Name, _db);

                    // Display success message
                    TempData["AlertMessage"] = "Supplier Deleted Successfully...";
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle appropriately
                Console.WriteLine($"Error deleting supplier: {ex.Message}");
                throw; // Re-throw the exception
            }

            // Redirect to the Index action
            return RedirectToAction(nameof(Index));
        }
    }
}
