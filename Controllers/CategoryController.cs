using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ProductContext _context;

        public CategoryController(ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {

            return View(await _context.Categories.ToListAsync());
        }

        //GET:
        public IActionResult Create()
        {
            return View();
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "unable to save saves");
            }
            return View(category);
        }
    }
}