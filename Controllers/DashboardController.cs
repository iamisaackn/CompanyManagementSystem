using CompanyManagementSystem.Data; // Provides access to the application's database context
using FastReport; // Used for generating reports
using Microsoft.AspNetCore.Hosting; // Allows access to the web hosting environment details
using Microsoft.AspNetCore.Mvc; // Provides functionalities for building MVC controllers
using Microsoft.EntityFrameworkCore; // Enables interaction with the database via Entity Framework Core

namespace CompanyManagementSystem.Controllers
{
    // Controller for handling dashboard-related functionalities
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db; // Database context for accessing application data
        private readonly IWebHostEnvironment _webHostEnvironment; // Provides access to the hosting environment

        // Constructor to initialize the database context and web host environment
        public DashboardController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // Action to render the dashboard view
        public IActionResult Index()
        {
            // Dictionary to hold counts for various items in the system
            var itemCounts = new Dictionary<string, int>();

            // Count the total number of employees
            int employeeCount = _db.Employees.Count();
            itemCounts.Add("Employees", employeeCount);

            // Count the total number of products
            int productCount = _db.Products.Count();
            itemCounts.Add("Products", productCount);

            // Count the total number of sales
            int saleCount = _db.Sales.Count();
            itemCounts.Add("Sales", saleCount);

            // Count the total number of clients
            int clientCount = _db.Clients.Count();
            itemCounts.Add("Clients", clientCount);

            // Count the total number of branch suppliers
            int branchSupplierCount = _db.BranchesSupplier.Count();
            itemCounts.Add("Branch Suppliers", branchSupplierCount);

            // Count the total number of branches
            int branchCount = _db.Branches.Count();
            itemCounts.Add("Branches", branchCount);

            // Retrieve recent employees, branches, branch suppliers, clients, and sales
            var recentEmployees = _db.Employees.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentBranches = _db.Branches.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentBranchesSuppliers = _db.BranchesSupplier.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentClients = _db.Clients.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentSales = _db.Sales.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();

            // Pass data to the view using ViewBag
            ViewBag.ItemCounts = itemCounts;
            ViewBag.recentEmployees = recentEmployees;
            ViewBag.recentBranches = recentBranches;
            ViewBag.recentBranchesSuppliers = recentBranchesSuppliers;
            ViewBag.recentSales = recentSales;
            ViewBag.recentClients = recentClients;

            // Render the dashboard view
            return View();
        }

        // Action to generate a PDF report for the dashboard
        public FileResult Generate()
        {
            FastReport.Utils.Config.WebMode = true; // Enable FastReport's web mode
            Report rep = new Report(); // Create a new FastReport instance

            // Load the report template from the file system
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Dashboard.frx");
            rep.Load(path);

            // Dictionary to hold counts for various items in the system
            var itemCounts = new Dictionary<string, int>();

            // Count the total number of employees
            int employeeCount = _db.Employees.Count();
            itemCounts.Add("Employees", employeeCount);

            // Count the total number of products
            int productCount = _db.Products.Count();
            itemCounts.Add("Products", productCount);

            // Count the total number of sales
            int saleCount = _db.Sales.Count();
            itemCounts.Add("Sales", saleCount);

            // Count the total number of clients
            int clientCount = _db.Clients.Count();
            itemCounts.Add("Clients", clientCount);

            // Count the total number of branch suppliers
            int branchSupplierCount = _db.BranchesSupplier.Count();
            itemCounts.Add("Branch Suppliers", branchSupplierCount);

            // Count the total number of branches
            int branchCount = _db.Branches.Count();
            itemCounts.Add("Branches", branchCount);

            //// Count the total number of audit logs
            //int auditLogCount = _db.AuditLogs.Count();
            //itemCounts.Add("Audit Logs", auditLogCount);


            // Retrieve recent employees, branches, branch suppliers, clients, and sales
            var recentEmployees = _db.Employees.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentBranches = _db.Branches.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentBranchesSuppliers = _db.BranchesSupplier.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentClients = _db.Clients.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            var recentSales = _db.Sales.OrderByDescending(u => u.UpdatedAt).Take(5).ToList();
            //var recentAuditLogs = _db.AuditLogs.OrderByDescending(log => log.Timestamp).Take(5).ToList();

            // Register data sources for the report
            rep.RegisterData(itemCounts, "ItemRef");
            rep.RegisterData(recentEmployees, "EmployeesRef");
            rep.RegisterData(recentBranches, "BranchesRef");
            rep.RegisterData(recentBranchesSuppliers, "SuppliersRef");
            rep.RegisterData(recentClients, "ClientsRef");
            rep.RegisterData(recentSales, "SalesRef");
            //ViewBag.RecentAuditLogs = recentAuditLogs;

            // Prepare the report
            if (rep.Report.Prepare())
            {
                // Configure PDF export settings
                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport
                {
                    ShowProgress = false,
                    Subject = "Subject Report",
                    Title = "Employee Report"
                };

                // Export the report to a memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                rep.Report.Export(pdfExport, ms);
                rep.Dispose(); // Dispose the report object
                pdfExport.Dispose(); // Dispose the PDF export object
                ms.Position = 0; // Reset the memory stream position

                // Return the PDF file as a FileResult
                return File(ms, "application/pdf", "DashboardReport.pdf");
            }
            else
            {
                // Return null if the report preparation fails
                return null;
            }
        }
    }
}
