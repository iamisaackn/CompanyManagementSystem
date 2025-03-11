using System.ComponentModel.DataAnnotations.Schema; // Provides attributes for configuring database schema mappings
using System.ComponentModel.DataAnnotations; // Provides attributes for validation and metadata
using Microsoft.AspNetCore.Mvc.Rendering; // Used for creating dropdown options in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a Sale entity in the system
    public class Sale
    {
        [Key] // Specifies this property as the primary key for the Sale entity
        public string SaleId { get; set; } = Guid.NewGuid().ToString();
        // Unique identifier for the sale, initialized with a globally unique identifier (GUID)

        [Required] // Indicates that this property is mandatory
        [ForeignKey("Employee")] // Specifies that this property is a foreign key referencing the Employee entity
        public string EmpId { get; set; } // Identifier for the employee associated with the sale

        [Required] // Indicates that this property is mandatory
        [ForeignKey("Client")] // Specifies that this property is a foreign key referencing the Client entity
        public string ClientId { get; set; } // Identifier for the client associated with the sale

        [Required] // Indicates that this property is mandatory
        public string ProductType { get; set; } // Type of product involved in the sale

        [Required] // Indicates that this property is mandatory
        public double Cost { get; set; } // Total cost of the sale

        public Employee? Employee { get; set; } // Navigation property to the associated Employee entity
        public Client? Client { get; set; } // Navigation property to the associated Client entity

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the sale was created, initialized to the current time in "E. Africa Standard Time"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the sale was last updated

        [NotMapped] // Specifies that this property should not be mapped to a database column
        public List<SelectListItem>? EmployeeOptions { get; set; }
        // List of employee options for use in dropdowns (not persisted in the database)

        [NotMapped] // Specifies that this property should not be mapped to a database column
        public List<SelectListItem>? ClientOptions { get; set; }
        // List of client options for use in dropdowns (not persisted in the database)

        [NotMapped] // Specifies that this property should not be mapped to a database column
        public List<SelectListItem>? ProductOptions { get; set; }
        // List of product options for use in dropdowns (not persisted in the database)

        // Constructor to initialize the UpdatedAt property with the same value as CreatedAt
        public Sale()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
