using System.ComponentModel.DataAnnotations.Schema; // Provides attributes for customizing the database schema
using System.ComponentModel.DataAnnotations; // Provides attributes for validation and display metadata
using Microsoft.AspNetCore.Mvc.Rendering; // Used to create lists for dropdown options in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a relationship between a branch and its supplier
    public class BranchSupplier
    {
        [MaxLength(255)] // Specifies the maximum length for the BranchId property in the database
        [ForeignKey("Branch")] // Defines BranchId as a foreign key referencing the Branch entity
        public string BranchId { get; set; } // Identifier for the associated branch

        [MaxLength(40)] // Specifies the maximum length for the SupplierName property
        public string SupplierName { get; set; } // Name of the supplier

        [MaxLength(40)] // Specifies the maximum length for the SupplyType property
        public string SupplyType { get; set; } // Type of supply provided by the supplier

        public Branch? Branch { get; set; } // Navigation property to the associated branch

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the record was created, initialized to the current time in "E. Africa Standard Time"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the record was last updated

        [NotMapped] // Specifies that this property should not be mapped to a database column
        public List<SelectListItem>? BranchOptions { get; set; } // List of branch options for use in dropdowns (not persisted to the database)

        // Constructor to initialize UpdatedAt with the same value as CreatedAt
        public BranchSupplier()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
