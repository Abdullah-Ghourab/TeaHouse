using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeaHouse.Core.mapping;
using TeaHouse.Data;
using TeaHouse.Models;

namespace TeaHouse.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;
        public ProductsController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                // Add more profiles if you have multiple
            });

            // Create the IMapper instance
            _mapper = config.CreateMapper();
        }


            
        public async Task<ActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            var viewModel = _mapper.Map<List<ProductViewModel>>(products);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View("Form",new ProductFormViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductFormViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Form");
        }
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();  
            }
            var model = _mapper.Map<ProductFormViewModel>(product);
            return View("Form",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductFormViewModel model)
        {
            if (ModelState.IsValid) {
                var product = await _context.Products.FindAsync(model.Id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                product.Title = model.Title;
                product.Price = model.Price;
                product.Description = model.Description;
                product.LastUpdatedOn = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Form", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ToggleStatus(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            product.IsDeleted = !product.IsDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}