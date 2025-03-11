namespace CompanyManagementSystem.Models
{
    // Represents a utility class for handling pagination in the application
    public class Pager
    {
        // Total number of items to be paginated
        public int TotalItems { get; private set; }

        // The current page number being displayed
        public int CurrentPage { get; private set; }

        // The number of items displayed per page
        public int PageSize { get; private set; }

        // The total number of pages required to display all items
        public int TotalPages { get; private set; }

        // The starting page number for the pagination display
        public int StartPage { get; private set; }

        // The ending page number for the pagination display
        public int EndPage { get; private set; }

        // Default constructor (does nothing in this case)
        public Pager() { }

        // Constructor to initialize pagination details
        public Pager(int totalItems, int page, int pageSize = 10)
        {
            // Calculate the total number of pages using ceiling to round up
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            // Set the current page to the specified page number
            int currentPage = page;

            // Determine the start and end pages for pagination display
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            // Adjust start and end pages if startPage is less than or equal to zero
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            // Adjust start and end pages if endPage exceeds totalPages
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9; // Ensure pagination display is limited to 10 pages
                }
            }

            // Assign calculated values to the respective properties
            TotalItems = totalItems;
            CurrentPage = currentPage;
            StartPage = startPage;
            EndPage = endPage;
            TotalPages = totalPages;
            PageSize = pageSize;
        }
    }
}


