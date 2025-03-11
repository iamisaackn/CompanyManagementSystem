using CompanyManagementSystem.Controllers; // Importing the namespace for controller-related operations
using CompanyManagementSystem.Data; // Importing the namespace for database context
using Microsoft.AspNetCore.Identity; // Importing Identity namespace for managing user identities

namespace CompanyManagementSystem.Models
{
    // Class to handle logging of audit trails for various actions in the system
    public class Audit
    {
        // Public method to log audit data
        // Calls the private LogAuditTrail method to perform the actual logging
        public void LogAudit(string actionType, string tableName, string entityId, string userId, ApplicationDbContext db)
        {
            LogAuditTrail(actionType, tableName, entityId, userId, db);
        }

        // Private method to handle the creation and storage of audit log entries
        private void LogAuditTrail(string actionType, string tableName, string entityId, string userId, ApplicationDbContext db)
        {
            // Create a new instance of the AuditLogs class with provided details
            var auditLog = new AuditLogs
            {
                UserId = userId, // ID of the user performing the action
                ActionType = actionType, // Type of action being logged (e.g., Create, Update, Delete)
                TableName = tableName, // Name of the table affected by the action
                Timestamp = DateTime.Now, // Timestamp of when the action occurred
                EntityId = entityId // Identifier of the entity being affected
            };

            // Add the audit log entry to the database context
            db.AuditLogs.Add(auditLog);

            // Save the changes to the database to persist the audit log
            db.SaveChanges();
        }
    }
}
