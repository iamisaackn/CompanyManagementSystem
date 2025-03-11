namespace CompanyManagementSystem.Models
{
    // Represents a model for handling error information in the application
    public class ErrorViewModel
    {
        // Property to store the unique identifier for the request, nullable
        public string? RequestId { get; set; }

        // Read-only property to determine if the RequestId should be shown
        // Returns true if the RequestId is not null or empty
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
