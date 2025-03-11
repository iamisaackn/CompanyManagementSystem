using CompanyManagementSystem.Models; // Includes models used in the application
using Microsoft.AspNetCore.Authorization; // Enables role-based authorization for controllers
using Microsoft.AspNetCore.Mvc; // Provides functionalities for building MVC controllers
using System.Diagnostics; // Provides tools for working with processes, event logs, and performance counters

namespace CompanyManagementSystem.Controllers
{
    [Authorize(Roles = "Employee")] // Restricts access to this controller's actions to users with the "Employee" role
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger instance for logging messages and errors

        // Constructor to inject the logger dependency
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action to render the Index view (typically the homepage)
        public IActionResult Index()
        {
            return View(); // Returns the "Index" view to the user
        }

        // Action to render the Privacy view
        public IActionResult Privacy()
        {
            return View(); // Returns the "Privacy" view to the user
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // Disables caching for the Error action to ensure the most recent error details are shown
        public IActionResult Error()
        {
            // Returns the "Error" view with an ErrorViewModel containing the current request ID
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
