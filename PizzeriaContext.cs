using la_mia_pizzeria.Models;
using Microsoft.EntityFrameworkCore;

public class PizzeriaContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeria;Integrated Security=True");
    }
}