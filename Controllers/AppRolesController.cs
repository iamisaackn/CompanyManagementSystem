using Microsoft.AspNetCore.Identity; // Provides identity-related functionality, such as managing roles and users
using Microsoft.AspNetCore.Mvc; // Provides functionality to build MVC web applications
using Microsoft.EntityFrameworkCore; // Enables database queries using Entity Framework Core

namespace CompanyManagementSystem.Controllers
{
    // Controller to manage application roles
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager; // RoleManager service for managing IdentityRole entities

        // Constructor to inject the RoleManager dependency
        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // Action to display the list of roles
        public IActionResult Index()
        {
            var roles = _roleManager.Roles; // Retrieve all roles using RoleManager
            return View(roles); // Pass the roles to the view
        }

        [HttpGet] // Indicates that this action responds to HTTP GET requests
        public IActionResult Create()
        {
            return View(); // Return the view for creating a new role
        }

        [HttpPost] // Indicates that this action responds to HTTP POST requests
        public async Task<IActionResult> Create(IdentityRole model)
        {
            // Check if the role with the specified name already exists
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                // Create the role if it does not exist
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }

            // Redirect back to the Index action after creating the role
            return RedirectToAction("Index");
        }

        // Action to delete a role by its ID
        public async Task<IActionResult> Delete(string Id)
        {
            // Find the role by its ID
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                // Return a 404 error if the role is not found
                return NotFound();
            }

            // Attempt to delete the role
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                // If successful, set a success message and redirect to the Index action
                TempData["AlertMessage"] = "Role deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            // If deletion fails, add error messages to the model state
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // If deletion fails, return the Index view with the updated list of roles
            return View("Index", await _roleManager.Roles.ToListAsync());
        }
    }
}


