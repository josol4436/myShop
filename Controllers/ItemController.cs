using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.ViewModels;
using MyShop.DAL;

namespace MyShop.Controllers;

// Controller for managing shop items (CRUD and list views)
public class ItemController : Controller
{
    // Database context injected via dependency injection
    private readonly IItemRepository _itemRepository;
    public ItemController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    // GET: /Item/Table - show items in a table view using ItemsViewModel
    public async Task<IActionResult> Table()
    {
        var items = await _itemRepository.GetAll();
        var itemsViewModel = new ItemsViewModel(items, "Table");
        return View(itemsViewModel);
    }
    // GET: /Item/Grid - show items in a grid view using ItemsViewModel
    public async Task<IActionResult> Grid()
    {
        var items = await _itemRepository.GetAll();
        var itemsViewModel = new ItemsViewModel(items, "Grid");
        return View(itemsViewModel);
    }
    // GET: /Item/Details/{id} - show details for a single item or return 404
    public async Task<IActionResult> Details(int id)
    {
        var item = await _itemRepository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    // GET: /Item/Create - show create form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Item/Create - create new item when form is submitted
    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        if(ModelState.IsValid)
        {
            await _itemRepository.Create(item);
            return RedirectToAction(nameof(Table));
        }
        return View(item);
    }

    // GET: /Item/Update/{id} - show edit form for an existing item
    [HttpGet]
    public async Task<IActionResult> Update(int id) {
        var item = await _itemRepository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    // POST: /Item/Update - save updates to an item
    [HttpPost]
    public async Task<IActionResult> Update(Item item)
    {
        if (ModelState.IsValid)
        {
            await _itemRepository.Update(item);
            return RedirectToAction(nameof(Table));
        }
        return View(item);
    }

    // GET: /Item/Delete/{id} - show confirmation page
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _itemRepository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    // POST: /Item/DeleteConfirmed - perform deletion
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _itemRepository.Delete(id);
        return RedirectToAction(nameof(Table));
    }

    // Helper: returns a hard-coded list of sample items (used for demo or fallback)
    public List<Item> GetItems()
    {
        var items = new List<Item>();
        items.Add(new Item
        {
            ItemId = 1,
            Name = "Pizza",
            Price = 60,
            Description = "Classic Italian pizza with tomato sauce, cheese, and your choice of toppings.",
            ImageUrl = "/images/pizza.jpg"
        });

        items.Add(new Item
        {
            ItemId = 2,
            Name = "Fish and Chips",
            Price = 55,
            Description = "Crispy battered fish served with golden fries and tartar sauce.",
            ImageUrl = "/images/fishandchips.jpg"
        });

        items.Add(new Item
        {
            ItemId = 3,
            Name = "Tacos",
            Price = 40,
            Description = "Mexican-style tacos with seasoned meat, fresh vegetables, and salsa.",
            ImageUrl = "/images/tacos.jpg"
        });

        items.Add(new Item
        {
            ItemId = 4,
            Name = "Fried Chicken Leg",
            Price = 15,
            Description = "Juicy fried chicken leg with a crispy golden coating.",
            ImageUrl = "/images/chickenleg.jpg"
        });

        items.Add(new Item
        {
            ItemId = 5,
            Name = "French Fries",
            Price = 20,
            Description = "Golden and crispy French fries, perfect as a side or snack.",
            ImageUrl = "/images/frenchfries.jpg"
        });

        items.Add(new Item
        {
            ItemId = 6,
            Name = "Ribs",
            Price = 75,
            Description = "Tender pork ribs glazed with a smoky barbecue sauce.",
            ImageUrl = "/images/ribs.jpg"
        });

        items.Add(new Item
        {
            ItemId = 7,
            Name = "Coke",
            Price = 15,
            Description = "Refreshing cold Coca-Cola soft drink.",
            ImageUrl = "/images/coke.jpg"
        });

        items.Add(new Item
        {
            ItemId = 8,
            Name = "Cider",
            Price = 25,
            Description = "Chilled apple cider, sweet and crisp.",
            ImageUrl = "/images/cider.jpg"
        });
        return items;
    }
}