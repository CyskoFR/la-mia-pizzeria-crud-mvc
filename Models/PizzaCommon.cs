using la_mia_pizzeria.Models;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class PizzaCommon
    {
        public Pizza Pizza { get; set; }

        public List<Category> Categories { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public PizzaCommon()
        {
            Pizza = new Pizza();
            Categories = new List<Category>();
            Ingredients = new List<Ingredient>();
        }
    }
}
