using System.ComponentModel.DataAnnotations.Schema; // For schema-related attributes like ForeignKey and NotMapped
using System.ComponentModel.DataAnnotations; // For validation and display attributes
using Microsoft.AspNetCore.Mvc.Rendering; // For creating dropdown lists in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a Branch entity in the system
    public class Branch
    {
        [Key] // Specifies that this property is the primary key for the entity
        [MaxLength(255)] // Sets the maximum length of the BranchId to 255 characters
        public string BranchId { get; set; } = Guid.NewGuid().ToString(); // Unique identifier for the branch, initialized with a GUID

        [Required] // Specifies that this property is mandatory
        [MaxLength(40)] // Sets the maximum length of the BranchName to 40 characters
        public string BranchName { get; set; } // Name of the branch

        [MaxLength(255)] // Sets the maximum length of the ManagerId to 255 characters
        public string? ManagerId { get; set; } // Identifier for the branch manager, nullable

        [DataType(DataType.Date)] // Specifies that this property should be treated as a date type in the UI
        public DateTime? ManagerStartDate { get; set; } // Start date of the branch manager, nullable

        [ForeignKey("ManagerId")] // Specifies that this property is a foreign key referencing ManagerId
        public virtual Employee? Manager { get; set; } // Navigation property to the associated manager

        public ICollection<Employee>? Employees { get; set; } // Collection of employees belonging to the branch
        public ICollection<Client>? Clients { get; set; } // Collection of clients associated with the branch
        public ICollection<BranchSupplier>? BranchSuppliers { get; set; } // Collection of suppliers linked to the branch

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the branch was created, initialized to the current time in "E. Africa Standard Time"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the branch was last updated

        [NotMapped] // Indicates that this property should not be mapped to a database column
        public List<SelectListItem>? EmployeeOptions { get; set; } // List of employee options for use in dropdowns (not persisted to the database)

        // Constructor to initialize UpdatedAt with the same value as CreatedAt
        public Branch()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
