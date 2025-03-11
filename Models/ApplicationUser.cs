using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagementSystem.Models
{
    // A custom application user class that extends the IdentityUser class
    public class ApplicationUser : IdentityUser
    {
        // Property to store the user's first name
        public string Firstname { get; set; }

        // Property to store the user's last name
        public string Lastname { get; set; }

        // Nullable property to store the user's profile picture URL or path
        public string? ProfilePicture { get; set; }

        // Property to store the creation timestamp of the user
        // Default value is set to the current time in the "E. Africa Standard Time" time zone
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));

        // Property to store the last updated timestamp of the user
        // DisplayFormat attribute is used to customize the format when displaying or editing
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; }

        // Constructor to initialize the UpdatedAt property with the same value as CreatedAt
        public ApplicationUser()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
