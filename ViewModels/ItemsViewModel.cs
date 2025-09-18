using MyShop.Models;

namespace MyShop.ViewModels
{
    // Simple view model to pass item list and current view name to views
    public class ItemsViewModel
    {
        // Collection of items to display
        public IEnumerable<Item> Items;
        // Name of the current view (e.g., "Table" or "Grid")
        public string? CurrentViewName;

        public ItemsViewModel(IEnumerable<Item> items, string? currentViewName)
        {
            Items = items;
            CurrentViewName = currentViewName;
        }
    }
}
