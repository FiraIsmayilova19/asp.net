using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using CI.CD.TestingTask.Models;

[TestFixture]
public class ProductServiceTest
{
    private AppDbContext _context = null!;
    private IProductRepository _repository = null!;
    private IProductService _service = null!;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new AppDbContext(options);
        _repository = new ProductRepository(_context);
        _service = new ProductService(_repository);
    }

    [Test]
    public async Task AddAsync_Product()
    {
        var product = new Product { Name = "Test Product", Price = 99m };

        await _service.AddAsync(product);

        var result = await _context.Products.FirstOrDefaultAsync(p => p.Name == "Test Product");
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Price, Is.EqualTo(99m));
    }

    [Test]
    public async Task GetByIdAsync_Return_Correct_Product()
    {
        var product = new Product { Name = "Test", Price = 25m };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = await _service.GetByIdAsync(product.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Name, Is.EqualTo("Test"));
    }

    [Test]
    public async Task GetAllAsync_Return_All_Products()
    {
        _context.Products.AddRange(
            new Product { Name = "P1", Price = 10 },
            new Product { Name = "P2", Price = 20 }
        );
        await _context.SaveChangesAsync();

        var result = await _service.GetAllAsync();

        
        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task UpdateAsync_Change_Product()
    {
         
        var product = new Product { Name = "Old", Price = 10 };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

     
        product.Name = "New";
        product.Price = 50;
        await _service.UpdateAsync(product);

        var updated = await _context.Products.FindAsync(product.Id);

      
        Assert.That(updated!.Name, Is.EqualTo("New"));
        Assert.That(updated.Price, Is.EqualTo(50));
    }

    [Test]
    public async Task DeleteAsync_Remove_Product()
    {
     
        var product = new Product { Name = "DeleteMe", Price = 5 };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

      
        await _service.DeleteAsync(product.Id);
        var deleted = await _context.Products.FindAsync(product.Id);

     
        Assert.That(deleted, Is.Null);
    }
}
