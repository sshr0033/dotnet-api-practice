using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

[ApiController]
[Route("api/{controller}")]
public class ProductsController: ControllerBase
{
    private readonly AppDbContext _db;

    public ProductsController(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _db.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();

        }
        return Ok(product);
        
    }

    [HttpPost]
    public async Task<ActionResult<Product> >Create(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<Product>>> ListAllProducts()
    {
        var products =  await _db.Products.ToListAsync();
        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }



}
