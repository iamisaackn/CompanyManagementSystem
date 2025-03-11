using CompanyManagementSystem.Data; // Provides access to the application's database context
using CompanyManagementSystem.Models; // Includes models used in the application
using CompanyManagementSystem.Views.Shared.Components.SearchBar; // Namespace for custom SearchBar components
using Microsoft.AspNetCore.Authorization; // Enables authorization functionalities
using Microsoft.AspNetCore.Mvc; // Enables MVC functionalities
using Microsoft.AspNetCore.Mvc.Rendering; // Used to generate dropdown options in views

namespace CompanyManagementSystem.Controllers
{
    [Authorize(Roles = "Admin, Employee")] // Restricts access to actions in this controller to users with Admin or Employee roles
    public class BranchController : Controller
    {
        private readonly ApplicationDbContext _db; // Database context for accessing branch data
        private readonly Audit _audit; // Utility for logging audit trails

        // Constructor to initialize database context and audit service
        public BranchController(ApplicationDbContext db, Audit audit)
        {
            _db = db;
            _audit = audit;
        }

        // Method to get a list of page sizes for pagination dropdown
        private List<SelectListItem> GetPageSizes(int selectedPageSize = 10)
        {
            var pagesSizes = new List<SelectListItem>();

            // Add page size 5 and mark it as selected if it matches selectedPageSize
            if (selectedPageSize == 5)
                pagesSizes.Add(new SelectListItem("5", "5", true));
            else
                pagesSizes.Add(new SelectListItem("5", "5"));

            // Add page sizes from 10 to 100 in increments of 10
            for (int lp = 10; lp <= 100; lp += 10)
            {
                if (lp == selectedPageSize)
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true)); // Mark as selected
                }
                else
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString()));
            }

            return pagesSizes;
        }

        // Action to display a list of branches with pagination and search functionality
        public IActionResult Index(int pg = 1, string SearchText = "", int pageSize = 5)
        {
            List<Branch> branches;

            // Filter branches based on search text if provided
            if (SearchText != "" && SearchText != null)
            {
                branches = _db.Branches
                    .Where(cat => cat.BranchName.Contains(SearchText))
                    .ToList();
            }
            else
            {
                // Get all branches ordered by the last updated date
                branches = _db.Branches.OrderByDescending(branch => branch.UpdatedAt).ToList();
            }

            // Set default page number if invalid
            if (pg < 1) pg = 1;

            // Pagination setup
            int recsCount = branches.Count(); // Total number of records
            var pager = new Pager(recsCount, pg, pageSize); // Create pager instance
            int recSkip = (pg - 1) * pageSize; // Calculate records to skip
            var data = branches.Skip(recSkip).Take(pager.PageSize).ToList(); // Get the current page data

            // Configure the search pager for the view
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            { Action = "index", Controller = "branch", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            // Pass page size options to the view
            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            // Return the branch data to the view
            return View(data);
        }

        // Action to display the view for adding a new branch
        public IActionResult Add()
        {
            ViewBag.Action = "Add"; // Set the action type for the view
            var model = new Branch(); // Create a new Branch model instance

            // Get the list of employees for the dropdown options
            var employees = _db.Employees.ToList();

            // Populate the EmployeeOptions dropdown in the model
            model.EmployeeOptions = employees.Select(e => new SelectListItem
            {
                Value = e.EmpId,
                Text = $"{e.FirstName} {e.LastName}"
            }).ToList();

            return View(model);
        }

        [HttpPost] // Indicates that this action responds to HTTP POST requests
        public IActionResult Add(Branch branch)
        {
            // Check if the branch object is null
            if (branch == null)
            {
                return NotFound();
            }

            // Validate the model state
            if (ModelState.IsValid)
            {
                // Add the new branch to the database and save changes
                _db.Branches.Add(branch);
                _db.SaveChanges();

                // Log the creation action in the audit trail
                _audit.LogAudit("Create", "branches", branch.BranchId, User.Identity.Name, _db);

                // Show success message and redirect to the Index action
                TempData["AlertMessage"] = "Branch Created Successfully...";
                return RedirectToAction(nameof(Index));
            }

            // If model state is invalid, return the same view with the branch data
            return View(branch);
        }

        // Action to edit an existing branch
        public IActionResult Edit(string id)
        {
            ViewBag.Action = "Edit"; // Set the action type for the view

            // Find the branch to edit by its ID
            var branch = _db.Branches.Find(id);
            if (branch == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Get the list of employees for the dropdown options
            var employees = _db.Employees.ToList();

            // Populate the EmployeeOptions dropdown in the branch model
            branch.EmployeeOptions = employees.Select(e => new SelectListItem
            {
                Value = e.EmpId,
                Text = $"{e.FirstName} {e.LastName}"
            }).ToList();

            return View(branch); // Return the branch model to the view
        }

        [HttpPost] // Indicates that this action responds to HTTP POST requests
        public IActionResult Edit(Branch branch)
        {
            // Retrieve the branch to update from the database
            var branchToUpdate = _db.Branches.Find(branch.BranchId);

            // Check if the branch exists
            if (branchToUpdate == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Update the branch's properties
            branchToUpdate.BranchName = branch.BranchName;
            branchToUpdate.ManagerId = branch.ManagerId;
            branchToUpdate.ManagerStartDate = branch.ManagerStartDate;
            branchToUpdate.UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));

            // Validate the model state
            if (ModelState.IsValid)
            {
                try
                {
                    // Save changes to the database
                    _db.SaveChanges();

                    // Log the update action in the audit trail
                    _audit.LogAudit("Update", "branches", branch.BranchId, User.Identity.Name, _db);

                    // Show success message and redirect to the Index action
                    TempData["AlertMessage"] = "Branch Updated Successfully...";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log any exceptions
                    Console.WriteLine($"Error updating branch: {ex.Message}");
                    throw; // Re-throw the exception
                }
            }

            // If model state is invalid, return the same view with the branch data
            return View(branch);
        }

        // Action to delete a branch
        public IActionResult Delete(string branchId)
        {
            try
            {
                // Find the branch to delete by its ID
                var branch = _db.Branches.Find(branchId);
                if (branch != null)
                {
                    // Remove the branch from the database
                    _db.Branches.Remove(branch);
                    _db.SaveChanges();

                    // Log the deletion action in the audit trail
                    _audit.LogAudit("Delete", "branches", branchId, User.Identity.Name, _db);

                    // Show success message
                    TempData["AlertMessage"] = "Branch Deleted Successfully...";
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"Error deleting branch: {ex.Message}");
                throw; // Re-throw the exception
            }

            // Redirect to the Index action
            return RedirectToAction(nameof(Index));
        }
    }
}
