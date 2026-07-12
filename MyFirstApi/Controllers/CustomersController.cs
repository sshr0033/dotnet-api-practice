using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _db;
    public CustomersController(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _db.Customers.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>>GetById(int id)
    {
        var customer  = await _db.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = customer.Id}, customer);
    }

}
