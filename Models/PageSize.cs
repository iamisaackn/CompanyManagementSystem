using Microsoft.AspNetCore.Mvc.Rendering; // Used for creating dropdown options in the UI

namespace CompanyManagementSystem.Models
{
    // Represents a utility class for generating page size options
    public class PageSize
    {
        /// <summary>
        /// Get a list of page sizes.
        /// Calls the private method GetPageSizes to generate the list.
        /// </summary>
        /// <param name="selectedPageSize">The currently selected page size (default is 10).</param>
        /// <returns>A list of SelectListItem representing available page sizes.</returns>
        public List<SelectListItem> GetSize(int selectedPageSize = 10)
        {
            // Delegate the task to the private method to generate the page size list
            return GetPageSizes(selectedPageSize);
        }

        /// <summary>
        /// Generates a list of available page sizes with the selected page size marked as selected.
        /// </summary>
        /// <param name="selectedPageSize">The currently selected page size.</param>
        /// <returns>A list of SelectListItem containing page sizes.</returns>
        private List<SelectListItem> GetPageSizes(int selectedPageSize = 10)
        {
            // Create a list to store the page size options
            var pagesSizes = new List<SelectListItem>();

            // Add the page size "5" to the list and mark it as selected if it matches the selectedPageSize
            if (selectedPageSize == 5)
                pagesSizes.Add(new SelectListItem("5", "5", true)); // Mark "5" as selected
            else
                pagesSizes.Add(new SelectListItem("5", "5")); // Do not mark "5" as selected

            // Loop to add page sizes from "10" to "100" in increments of 10
            for (int lp = 10; lp <= 100; lp += 10)
            {
                // Mark the current page size as selected if it matches the selectedPageSize
                if (lp == selectedPageSize)
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true)); // Mark as selected
                }
                else
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString())); // Add without marking as selected
                }
            }

            // Return the complete list of page size options
            return pagesSizes;
        }
    }
}
