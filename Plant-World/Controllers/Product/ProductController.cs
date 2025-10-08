using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_World.Models;
using Plant_World.ViewModels;
using System.Threading.Tasks;

namespace Plant_World.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
            return View(products);
        }

        // GET: HomeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = _context.Categories.ToList(),
                Product = new Models.Product()
            };

            return View(viewModel);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormViewModel viewModel, IFormFile? mainImageFile)
        {
            //if (ModelState.IsValid) 
            //{
                var product = viewModel.Product;
                product.CategoryId = viewModel.CategoryId;

                if (mainImageFile != null && mainImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await mainImageFile.CopyToAsync(fileStream);
                    }

                    product.MainImageUrl = "/uploads/" + uniqueFileName;
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Product created successfully!";
                TempData["AlertType"] = "success";
                return RedirectToAction(nameof(Index));
            //}

            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }

        // GET: HomeController/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductFormViewModel
            {
                Product = product,
                CategoryId = product.CategoryId,
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel viewModel, IFormFile? mainImageFile)
        {
            if (id != viewModel.Product.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = viewModel.Product.Name;
                product.Description = viewModel.Product.Description;
                product.Price = viewModel.Product.Price;
                product.CategoryId = viewModel.CategoryId;

                if (mainImageFile != null && mainImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await mainImageFile.CopyToAsync(fileStream);
                    }

                    product.MainImageUrl = "/uploads/" + uniqueFileName;
                //}

                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Product updated successfully!";
                TempData["AlertType"] = "success";
                return RedirectToAction(nameof(Index));
            }

            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }

        // GET: HomeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: HomeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            // حذف الصورة من الفولدر كمان لو موجودة
            if (!string.IsNullOrEmpty(product.MainImageUrl))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", product.MainImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            TempData["AlertMessage"] = "Product deleted successfully!";
            TempData["AlertType"] = "danger";

            return RedirectToAction(nameof(Index));
        }
    }
}
