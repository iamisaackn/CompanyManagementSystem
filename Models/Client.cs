using System.ComponentModel.DataAnnotations.Schema; // Provides attributes for configuring database schema
using System.ComponentModel.DataAnnotations; // Provides attributes for validation and display metadata
using Microsoft.AspNetCore.Mvc.Rendering; // Used to create dropdown options in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a client entity in the system
    public class Client
    {
        [Key] // Specifies that this property is the primary key for the entity
        [MaxLength(255)] // Sets the maximum length for the ClientId field in the database
        public string ClientId { get; set; } = Guid.NewGuid().ToString();
        // Unique identifier for the client, initialized with a globally unique identifier (GUID)

        [MaxLength(40)] // Sets the maximum length for the ClientName field
        public string ClientName { get; set; } // Name of the client

        [MaxLength(255)] // Sets the maximum length for the BranchId field
        [ForeignKey("Branch")] // Specifies that this property is a foreign key referencing the Branch entity
        public string BranchId { get; set; } // Identifier for the associated branch

        public Branch? Branch { get; set; } // Navigation property to the associated branch
        public ICollection<Employee>? Employees { get; set; } // Collection of employees associated with the client

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the client record was created, initialized to the current time in "E. Africa Standard Time"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the client record was last updated

        [NotMapped] // Specifies that this property should not be mapped to a database column
        public List<SelectListItem>? BranchOptions { get; set; } // List of branch options for use in dropdowns (not persisted to the database)

        // Constructor to initialize the UpdatedAt property with the same value as CreatedAt
        public Client()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
