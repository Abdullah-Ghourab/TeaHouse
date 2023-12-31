﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public CategoriesController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                // Add more profiles if you have multiple
            });

            // Create the IMapper instance
            _mapper = config.CreateMapper();

        }
        // GET: Categories
        public async Task<ActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var viewModel = _mapper.Map<List<CategoryViewModel>>(categories);
            return View(viewModel);
        }
        public ActionResult Create()
        {
            return View("Form",new CategoryFormViewModel());
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
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) {
                return HttpNotFound();
            }
            var model = _mapper.Map<CategoryFormViewModel>(category);
            return View("Form",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit (CategoryFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await _context.Categories.FindAsync(model.Id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                category.Title = model.Title;
                category.LastUpdatedOn = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Form",model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ToggleStatus(int id) { 
            var category = await _context.Categories.FindAsync(id);
            if (category == null) {
                return HttpNotFound();
            }
            category.IsDeleted = !category.IsDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        
        }

    }
}