using CompanyManagementSystem.Data; // Provides access to the application's database context
using CompanyManagementSystem.Models; // Includes models used in the application
using CompanyManagementSystem.Views.Shared.Components.SearchBar; // Namespace for custom SearchBar components
using FastReport; // FastReport library for creating and exporting reports
using Microsoft.AspNetCore.Hosting; // Used for accessing hosting environment details
using Microsoft.AspNetCore.Http; // Provides HTTP-related functionality
using Microsoft.AspNetCore.Mvc; // Enables MVC pattern functionality
using Microsoft.AspNetCore.Mvc.Rendering; // Used for generating dropdown lists in views

namespace CompanyManagementSystem.Controllers
{
    // Controller for managing audit logs in the system
    public class AuditLogsController : Controller
    {
        private readonly ApplicationDbContext _db; // Reference to the application's database context
        private readonly PageSize _pageSize; // Utility for managing page size options
        private readonly IWebHostEnvironment _webHostEnvironment; // Provides access to hosting environment details

        // Constructor to initialize database context, page size, and web host environment
        public AuditLogsController(ApplicationDbContext db, PageSize pageSize, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _pageSize = pageSize;
            _webHostEnvironment = webHostEnvironment;
        }

        // Action to display a paginated and optionally filtered list of audit logs
        public IActionResult Index(int pg = 1, string SearchText = "", int pageSize = 5, string SortBy = "", string direction = "down")
        {
            List<AuditLogs> auditLogs;

            // Filter audit logs based on search text if provided
            if (SearchText != "" && SearchText != null)
            {
                auditLogs = _db.AuditLogs
                    .Where(log => log.TableName.Contains(SearchText) || log.ActionType.Contains(SearchText))
                    .ToList();
            }
            else
            {
                // Retrieve all audit logs if no search text is provided
                auditLogs = _db.AuditLogs.ToList();
            }

            // Sort audit logs based on the specified column and direction
            switch (SortBy)
            {
                case "ActionType":
                    if (direction == "down")
                        auditLogs = auditLogs.OrderByDescending(log => log.ActionType).ToList();
                    else if (direction == "up")
                        auditLogs = auditLogs.OrderBy(log => log.ActionType).ToList();
                    break;
                case "TableName":
                    if (direction == "down")
                        auditLogs = auditLogs.OrderByDescending(log => log.TableName).ToList();
                    else if (direction == "up")
                        auditLogs = auditLogs.OrderBy(log => log.TableName).ToList();
                    break;
                default:
                    if (direction == "down")
                        auditLogs = auditLogs.OrderByDescending(log => log.Timestamp).ToList();
                    else if (direction == "up")
                        auditLogs = auditLogs.OrderBy(log => log.Timestamp).ToList();
                    break;
            }

            // Define columns available for sorting
            List<SelectListItem> tableColumns = new List<SelectListItem>
            {
                new SelectListItem { Text = "ActionType" },
                new SelectListItem { Text = "TableName" },
                new SelectListItem { Text = "TimeStamp" },
            }.ToList();
            ViewBag.TableColumns = tableColumns;

            // Set default page number if the specified one is less than 1
            if (pg < 1) pg = 1;

            // Pagination logic
            int recsCount = auditLogs.Count(); // Total number of records
            var pager = new Pager(recsCount, pg, pageSize); // Create a pager instance
            int recSkip = (pg - 1) * pageSize; // Calculate records to skip
            var data = auditLogs.Skip(recSkip).Take(pager.PageSize).ToList(); // Retrieve the current page's records

            // Configure search pager for use in the view
            SPager SearchPager = new SPager(recsCount, pg, pageSize)
            { Action = "index", Controller = "auditlogs", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            // Pass page size options to the view
            this.ViewBag.PageSizes = _pageSize.GetSize(pageSize);

            // Return the paginated and filtered audit log data to the view
            return View(data);
        }

        /// <summary>
        /// Generate a PDF report of audit logs
        /// </summary>
        /// <returns>PDF file result</returns>
        public FileResult Generate()
        {
            // Enable FastReport's web mode
            FastReport.Utils.Config.WebMode = true;

            // Create a new report instance
            Report rep = new Report();

            // Load the report template from the file system
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Logs.frx");
            rep.Load(path);

            // Retrieve audit logs data and register it as the report's data source
            var logs = _db.AuditLogs.OrderByDescending(u => u.Timestamp).ToList();
            rep.RegisterData(logs, "AuditRef");

            // Prepare the report for export
            if (rep.Report.Prepare())
            {
                try
                {
                    // Configure PDF export settings
                    FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport
                    {
                        ShowProgress = false,
                        Subject = "Subject Report",
                        Title = "AuditTrails Report"
                    };

                    // Export the prepared report to a memory stream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    rep.Report.Export(pdfExport, ms);
                    rep.Dispose(); // Release report resources
                    pdfExport.Dispose(); // Release PDF export resources
                    ms.Position = 0; // Reset the memory stream position

                    // Return the generated PDF file as a FileResult
                    return File(ms, "application/pdf", "AuditTrailsReport.pdf");
                }
                catch (Exception e)
                {
                    // Handle exceptions during report generation
                    return null;
                }
            }
            else
            {
                // Return null if the report fails to prepare
                return null;
            }
        }
    }
}
