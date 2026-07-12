using Microsoft.EntityFrameworkCore;

namespace MyFirstApi.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public bool isActive{get; set;}
}