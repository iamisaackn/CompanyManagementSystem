namespace CompanyManagementSystem.Services
{
    public class FileService : IFileService
    {
        // Store a reference to the web host environment to access web-specific resources
        IWebHostEnvironment environment;

        // Constructor to initialize the web host environment dependency
        public FileService(IWebHostEnvironment env)
        {
            environment = env;
        }

        // Method to save an image file on the server
        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                // Get the root path of the web application
                var wwwPath = this.environment.WebRootPath;

                // Define the directory to save the uploaded images
                var path = Path.Combine(wwwPath, "Uploads");

                // Create the directory if it doesn't already exist
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Get the file extension of the uploaded image
                var ext = Path.GetExtension(imageFile.FileName);

                // List of allowed image file extensions
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

                // Check if the uploaded file has an allowed extension
                if (!allowedExtensions.Contains(ext))
                {
                    // Return an error message if the extension is not allowed
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                // Generate a unique string for the file name
                string uniqueString = Guid.NewGuid().ToString();

                // Create the complete file name with the unique string and the extension
                var newFileName = uniqueString + ext;

                // Combine the directory path and the new file name
                var fileWithPath = Path.Combine(path, newFileName);

                // Create a file stream to write the uploaded file to the server
                var stream = new FileStream(fileWithPath, FileMode.Create);

                // Copy the contents of the uploaded file to the created file stream
                imageFile.CopyTo(stream);

                // Close the file stream after writing is complete
                stream.Close();

                // Return success with the new file name
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                // Return error in case of any exception
                return new Tuple<int, string>(0, "Error has occurred");
            }
        }

        // Method to delete an image file from the server
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                // Get the root path of the web application
                var wwwPath = this.environment.WebRootPath;

                // Define the complete path of the image file to be deleted
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);

                // Check if the file exists at the specified path
                if (System.IO.File.Exists(path))
                {
                    // Delete the file if it exists
                    System.IO.File.Delete(path);
                    return true;
                }

                // Return false if the file does not exist
                return false;
            }
            catch (Exception ex)
            {
                // Return false in case of any exception
                return false;
            }
        }
    }
}
