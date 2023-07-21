using AutoMapper;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeaHouse.Core.mapping;
using TeaHouse.Data;
using TeaHouse.Models;

namespace TeaHouse.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        MappingProfile _mapper = new MappingProfile();
        // GET: Categories
        public async Task<ActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var viewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return View(categories);
        }
        public ActionResult Create()
        {
            return View("Form");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Title = model.Title,
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View("Form");
        }
    }
}