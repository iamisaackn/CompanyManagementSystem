using AspNetCore.Reporting; // Provides functionalities for generating and managing reports
using FastReport; // A reporting library used to create, load, and export reports
using Microsoft.AspNetCore.Mvc; // Provides functionalities for building MVC controllers

namespace CompanyManagementSystem.Controllers
{
    // Controller for handling report-related functionalities
    public class ReportsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment; // Provides access to the web hosting environment

        // Constructor to inject the IWebHostEnvironment dependency
        public ReportsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // Action method to render the default view for the ReportsController
        public IActionResult Index()
        {
            return View(); // Returns the "Index" view to the user
        }

        // Action method to generate a report and return it as a file
        public FileResult Generate()
        {
            // Enable FastReport's web mode to ensure compatibility with web applications
            FastReport.Utils.Config.WebMode = true;

            // Create a new instance of a FastReport report
            Report rep = new Report();

            // Define the path to the report template file ("Employee.frx")
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Employee.frx");

            // Load the report template from the specified path
            rep.Load(path);

            // Add your report generation logic here (e.g., populating the report with data)

            // Return the generated report file as a FileResult
            return File(/* Your report file bytes here */ "application/pdf", "report.pdf");
        }
    }
}
