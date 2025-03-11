using System.ComponentModel.DataAnnotations; // Provides attributes for validation and metadata
using System.ComponentModel.DataAnnotations.Schema; // Provides attributes for configuring database schema

namespace CompanyManagementSystem.Models
{
    // Represents a Product entity in the system
    public class Product
    {
        // Unique identifier for the product, initialized with a globally unique identifier (GUID)
        public string ProductId { get; set; } = Guid.NewGuid().ToString();

        [Required] // Specifies that this property is mandatory
        public string Name { get; set; } = string.Empty; // Name of the product, initialized to an empty string

        public string? Description { get; set; } = string.Empty; // Optional description of the product, initialized to an empty string

        public string? ProductImage { get; set; } = string.Empty; // Optional property to store the product image's file path or URL, initialized to an empty string

        [NotMapped] // Indicates that this property should not be mapped to a database column
        public IFormFile? ImageFile { get; set; } // Optional property to handle the image file uploaded by the user (not persisted in the database)

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time"));
        // Timestamp for when the product was created, initialized to the current time in the "E. Africa Standard Time" time zone

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss zzz}", ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime UpdatedAt { get; set; } // Timestamp for when the product was last updated

        // Constructor to initialize the UpdatedAt property with the same value as CreatedAt
        public Product()
        {
            UpdatedAt = CreatedAt;
        }
    }
}
