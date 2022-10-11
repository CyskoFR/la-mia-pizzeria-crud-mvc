using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public List<Pizza> Pizzas { get; set; }
    }
}
