using la_mia_pizzeria_crud_mvc.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(25, ErrorMessage = "Il nome non può avere più di 25 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(300, ErrorMessage = "La descrizione non può avere più di 300 caratteri")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public double Price { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        public Pizza()
        {
        
        }

        public Pizza(int id, string name, string description, string picture, double price, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Picture = picture;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
