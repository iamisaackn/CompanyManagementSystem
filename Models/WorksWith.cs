using System.ComponentModel.DataAnnotations.Schema; // Provides attributes for configuring database schema mappings
using System.ComponentModel.DataAnnotations; // Provides attributes for validation and metadata
using Microsoft.AspNetCore.Mvc.Rendering; // Used to generate dropdown options in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a relationship between an employee and a client, tracking total sales
    public class WorksWith
    {
        [MaxLength(255)] // Specifies the maximum length of the EmpId column in the database
        [ForeignKey("Employee")] // Defines EmpId as a foreign key referencing the Employee entity
        public string EmpId { get; set; } // Identifier for the employee involved in the relationship

        [MaxLength(255)] // Specifies the maximum length of the ClientId column in the database
        [ForeignKey("Client")] // Defines ClientId as a foreign key referencing the Client entity
        public string ClientId { get; set; } // Identifier for the client involved in the relationship

        public double TotalSales { get; set; } // The total sales associated with this employee-client relationship

        public Employee? Employee { get; set; } // Navigation property to the associated Employee entity
        public Client? Client { get; set; } // Navigation property to the associated Client entity

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the relationship was created, initialized to the current time in "E. Africa Standard Time"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the relationship was last updated

        [NotMapped] // Indicates this property is not mapped to the database
        public List<SelectListItem>? EmployeeOptions { get; set; }
        // List of employee options for use in dropdowns (not persisted in the database)

        [NotMapped] // Indicates this property is not mapped to the database
        public List<SelectListItem>? ClientOptions { get; set; }
        // List of client options for use in dropdowns (not persisted in the database)

        // Constructor to initialize UpdatedAt with the same value as CreatedAt
        public WorksWith()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
