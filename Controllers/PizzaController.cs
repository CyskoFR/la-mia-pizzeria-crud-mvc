using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria.Models;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public PizzaController()
        {

        }

        PizzeriaContext context = new PizzeriaContext();

        public ActionResult Index()
        {
            List<Pizza> pizzas = context.Pizzas.Include("Category").Include("Ingredients").ToList();

            return View("Index", pizzas);
        }

        public ActionResult Show(int id)
        {
            Pizza pizzaFound = context.Pizzas.Include("Category").Include("Ingredients").Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizzaFound == null)
            {
                return NotFound($"La pizza con id {id} non è stata trovata");
            }
            else
            {
                return View("Show", pizzaFound);
            }
        }

        public ActionResult Create()
        {
            PizzasCategories pizzasCategories = new PizzasCategories();

            pizzasCategories.Categories = new PizzeriaContext().Categories.ToList();
            pizzasCategories.Ingredients = new PizzeriaContext().Ingredients.ToList();

            return View(pizzasCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzasCategories formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = context.Categories.ToList();
                formData.Ingredients = context.Ingredients.ToList();
                return View("Create", formData);
            }

            //Pizza pizzaCreate = new Pizza();

            //pizzaCreate.Name = formData.Pizza.Name;
            //pizzaCreate.Description = formData.Pizza.Description;
            //pizzaCreate.Picture = formData.Pizza.Picture;
            //pizzaCreate.Price = formData.Pizza.Price;

            formData.Pizza.Ingredients = new List<Ingredient>();

            foreach(int ingredientId in formData.SelectedIngredientsId)
            {
                Ingredient ingredient = context.Ingredients.Where(ingredient => ingredient.Id == ingredientId).FirstOrDefault();
                formData.Pizza.Ingredients.Add(ingredient);
            }

            context.Pizzas.Add(formData.Pizza);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Pizza pizzaEdit = context.Pizzas.Include("Category").Include("Ingredients").Where(pizza => pizza.Id == id).FirstOrDefault();

            PizzasCategories pizzasCategories = new PizzasCategories();

            pizzasCategories.Pizza = pizzaEdit;
            pizzasCategories.Categories = context.Categories.ToList();
            pizzasCategories.Ingredients = context.Ingredients.ToList();

            return View(pizzasCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzasCategories formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Categories = context.Categories.ToList();
                formData.Ingredients = context.Ingredients.ToList();
                return View("Edit", formData);
            }

            Pizza pizzaEdit = context.Pizzas.Where(pizza => pizza.Id == id).Include("Ingredients").FirstOrDefault();

            pizzaEdit.Name = formData.Pizza.Name;
            pizzaEdit.Description = formData.Pizza.Description;
            pizzaEdit.Picture = formData.Pizza.Picture;
            pizzaEdit.Price = formData.Pizza.Price;
            pizzaEdit.CategoryId = formData.Pizza.CategoryId;
            pizzaEdit.Ingredients = context.Ingredients.Where(ingredient => formData.SelectedIngredientsId.Contains(ingredient.Id)).ToList<Ingredient>();

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Pizza pizza = context.Pizzas.Where(pizza => pizza.Id == id).First();

            if (pizza == null)
            {
                return View("Error");
            }

            context.Pizzas.Remove(pizza);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
