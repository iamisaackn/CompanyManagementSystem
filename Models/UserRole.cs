using Microsoft.AspNetCore.Mvc.Rendering; // Provides support for creating dropdown lists in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a model for managing user roles in the system
    public class UserRole
    {
        // Holds the details of the application user
        public ApplicationUser applicationUser { get; set; }

        // List of available roles for the application, used for dropdown selection in the UI
        public List<SelectListItem>? ApplicationRoles { get; set; }

        // Holds the role selected by the user
        public string SelectedRole { get; set; }
    }
}
