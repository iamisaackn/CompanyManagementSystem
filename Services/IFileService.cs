namespace CompanyManagementSystem.Services
{
    // Definition of the IFileService interface for file operations
    public interface IFileService
    {
        // Method declaration for saving an image file
        // It returns a tuple containing an integer (status) and a string (message or file name)
        public Tuple<int, string> SaveImage(IFormFile imageFile);

        // Method declaration for deleting an image file
        // It returns a boolean indicating success or failure
        public bool DeleteImage(string imageFileName);
    }
}

