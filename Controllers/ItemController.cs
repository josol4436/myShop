using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.ViewModels;

namespace MyShop.Controllers;

public class ItemController : Controller
{

    public IActionResult Table()
    {
        var items = GetItems();
        var itemsViewModel = new ItemsViewModel(items, "Table");
        return View(itemsViewModel);
    }
    public IActionResult Grid()
    {
        var items = GetItems();
        var itemsViewModel = new ItemsViewModel(items, "Grid");
        return View(itemsViewModel);
    }

    public IActionResult Details(int id)
    {
        var items = GetItems();
        var item = items.FirstOrDefault(i => i.ItemId == id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
    
    
    /*public IActionResult Table()
    {
        var items = GetItems();
        ViewBag.CurrentViewName = "Table";
        return View(items);
    }
    public IActionResult Grid()
    {
        var items = GetItems();
        ViewBag.CurrentViewName = "Grid";
        return View(items);
    }*/

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