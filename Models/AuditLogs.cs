using Microsoft.AspNetCore.Mvc.Rendering; // Importing the namespace for generating select list items used in dropdowns
using System.ComponentModel.DataAnnotations.Schema; // Importing attributes for database schema-related functionalities

namespace CompanyManagementSystem.Models
{
    // Class representing audit logs to track system activities
    public class AuditLogs
    {
        // Unique identifier for the audit log entry, generated using a globally unique identifier (GUID)
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // ID of the user performing the action
        public string UserId { get; set; }

        // Type of action performed, e.g., Create, Update, Delete
        public string ActionType { get; set; }

        // Name of the table on which the action was performed
        public string TableName { get; set; }

        // Timestamp of when the action occurred
        public DateTime Timestamp { get; set; }

        // Identifier of the specific entity being affected by the action
        public string EntityId { get; set; }

        // Property to hold a list of table column options for display in a dropdown menu
        // NotMapped attribute specifies that this property should not be mapped to a database column
        [NotMapped]
        public List<SelectListItem>? TableColumns { get; set; }
    }
}
