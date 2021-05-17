using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            _context.Items.FirstOrDefault();
            return View("Item/Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.Find(id);

            if(item.Id == id)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            return View("Index");
        }
    }
}
