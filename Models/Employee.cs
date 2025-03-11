using System.ComponentModel.DataAnnotations.Schema; // Provides attributes to define database schema configurations
using System.ComponentModel.DataAnnotations; // Provides attributes for validation and metadata
using Microsoft.AspNetCore.Mvc.Rendering; // Used for creating dropdown options in the UI

namespace CompanyManagementSystem.Models
{
    // Represents an Employee entity in the system
    public class Employee
    {
        [Key] // Specifies this property as the primary key for the Employee entity
        [MaxLength(255)] // Sets a maximum length of 255 characters for the EmpId field in the database
        public string EmpId { get; set; } = Guid.NewGuid().ToString();
        // Unique identifier for the employee, initialized with a globally unique identifier (GUID)

        [ForeignKey("User")] // Specifies that this property is a foreign key referencing the User entity
        [Required] // Indicates that this field is mandatory
        public string UserId { get; set; } // Foreign key to the ApplicationUser table (AspNetUsers)
        public virtual ApplicationUser? User { get; set; } // Navigation property to the related ApplicationUser entity

        [Required] // Indicates that this field is mandatory
        [MaxLength(40)] // Sets a maximum length of 40 characters for the FirstName field
        public string FirstName { get; set; } // Employee's first name

        [Required] // Indicates that this field is mandatory
        [MaxLength(40)] // Sets a maximum length of 40 characters for the LastName field
        public string LastName { get; set; } // Employee's last name

        [Required] // Indicates that this field is mandatory
        [DataType(DataType.Date)] // Specifies that this field should be treated as a date
        public DateTime BirthDay { get; set; } // Employee's date of birth

        [Required] // Indicates that this field is mandatory
        [MaxLength(1)] // Sets a maximum length of 1 character for the Sex field
        public string Sex { get; set; } // Employee's gender (e.g., M, F, etc.)

        [Required] // Indicates that this field is mandatory
        public int Salary { get; set; } // Employee's salary

        public virtual Employee? Supervisor { get; set; } // Navigation property to the employee's supervisor

        [MaxLength(255)] // Sets a maximum length of 255 characters for the SupervisorId field
        [ForeignKey("Supervisor")] // Specifies that this property is a foreign key referencing the Supervisor entity
        public string? SupervisorId { get; set; } // Identifier for the employee's supervisor

        public Branch? Branch { get; set; } // Navigation property to the branch the employee belongs to

        [MaxLength(255)] // Sets a maximum length of 255 characters for the BranchId field
        [ForeignKey("Branch")] // Specifies that this property is a foreign key referencing the Branch entity
        public string? BranchId { get; set; } // Identifier for the branch the employee belongs to

        public ICollection<Client>? Clients { get; set; } // Collection of clients associated with the employee

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the employee record was created, initialized to the current time in "E. Africa Standard Time"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the employee record was last updated

        [NotMapped] // Indicates that this property is not mapped to a database column
        public string? SelectedSex { get; set; } // Placeholder for the selected gender option (for UI purposes)

        [NotMapped] // Indicates that this property is not mapped to a database column
        public List<SelectListItem>? SexOptions { get; set; } // Dropdown options for gender (for UI purposes)

        [NotMapped] // Indicates that this property is not mapped to a database column
        public List<SelectListItem>? SupervisorOptions { get; set; } // Dropdown options for supervisors (for UI purposes)

        [NotMapped] // Indicates that this property is not mapped to a database column
        public List<SelectListItem>? BranchOptions { get; set; } // Dropdown options for branches (for UI purposes)

        [NotMapped] // Indicates that this property is not mapped to a database column
        public List<SelectListItem>? UserOptions { get; set; } // Dropdown options for users (for UI purposes)

        [NotMapped] // Indicates that this property is not mapped to a database column
        public List<SelectListItem>? FirstNames { get; set; } // Placeholder for first names (for UI purposes)

        [NotMapped] // Indicates that this property is not mapped to a database column
        public List<SelectListItem>? LastNames { get; set; } // Placeholder for last names (for UI purposes)

        // Constructor to initialize the UpdatedAt property with the same value as CreatedAt
        public Employee()
        {
            UpdatedAt = CreatedAt;
        }
    }
}

