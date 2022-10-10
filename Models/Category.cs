using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
        }

        public List<Pizza> Pizzas { get; set; }
    }
}
