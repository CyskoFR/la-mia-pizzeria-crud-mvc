using la_mia_pizzeria.Models;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.EntityFrameworkCore;

public class PizzeriaContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeria;Integrated Security=True");
    }
}