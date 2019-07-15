using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ProductContext _context;
        // GET: Category/list

        public CategoryController(ProductContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> List()
        {

            return View(await _context.Categories.ToListAsync());
        }
    }
}