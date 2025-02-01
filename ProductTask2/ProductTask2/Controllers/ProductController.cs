using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProductTask2.Data;
using ProductTask2.Entites;

namespace ProductTask2.Controllers
{
    public class ProductController : Controller
    {

       
            private readonly ProductDbContext _context;
            public ProductController(ProductDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                var productList = new List<Product>();
            foreach (var product in _context.Products)
            {
                productList.Add(product);
            }
            return View(productList);
            }
        public IActionResult Delete(int id)
        {
            var item = _context.Products.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
                TempData["Message"] = $"{item.Name} deleted successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product model, IFormFile uploadedFile)
        {
            string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(uploadedFile.FileName)}";
            string fullPath = Path.Combine(imagesFolder, uniqueFileName);

            using (var memoryStream = new MemoryStream())
            {
                await uploadedFile.CopyToAsync(memoryStream);
                await System.IO.File.WriteAllBytesAsync(fullPath, memoryStream.ToArray());
            }

            model.Imagelink = $"/images/{uniqueFileName}";
            _context.Products.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _context.Products.FirstOrDefault(p => p.Id == id);
            return View(item);

        }
        [HttpPost]
        public IActionResult Update(Product product, IFormFile uploadedFile)
        {
            string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(uploadedFile.FileName)}";
            string fullPath = Path.Combine(imagesFolder, uniqueFileName);

            using (var memoryStream = new MemoryStream())
            {
                 uploadedFile.CopyToAsync(memoryStream);
                 System.IO.File.WriteAllBytesAsync(fullPath, memoryStream.ToArray());
            }

            product.Imagelink = $"/images/{uniqueFileName}";
            _context.Products.Update(product);
            _context.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
    
