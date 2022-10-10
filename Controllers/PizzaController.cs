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
            List<Pizza> pizzas = context.Pizzas.Include("Category").ToList();

            return View("Index", pizzas);
        }

        public ActionResult Show(int id)
        {
            Pizza pizzaFound = context.Pizzas.Include("Category").Where(pizza => pizza.Id == id).FirstOrDefault();

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

            return View(pizzasCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzasCategories formData)
        {
            Pizza pizzaCreate = new Pizza();
            pizzaCreate.Name = formData.Pizza.Name;
            pizzaCreate.Description = formData.Pizza.Description;
            pizzaCreate.Picture = formData.Pizza.Picture;
            pizzaCreate.Price = formData.Pizza.Price;

            context.Pizzas.Add(pizzaCreate);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Pizza pizzaEdit = context.Pizzas.Where(pizza => pizza.Id == id).First();

            PizzasCategories pizzasCategories = new PizzasCategories();

            pizzasCategories.Pizza = pizzaEdit;
            pizzasCategories.Categories = context.Categories.ToList();

            return View(pizzasCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzasCategories formData)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Pizza pizzaEdit = context.Pizzas.Where(pizza => pizza.Id == id).First();

            //pizzaEdit.Name = formData.Pizza.Name;
            //pizzaEdit.Description = formData.Pizza.Description;
            //pizzaEdit.Picture = formData.Pizza.Picture;
            //pizzaEdit.Price = formData.Pizza.Price;

            //PizzasCategories pizzasCategories = new PizzasCategories();

            //pizzasCategories.Categories = context.Categories.ToList();

            formData.Pizza.Id = id;
            context.Pizzas.Update(formData.Pizza);

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
            Pizza pizzaEdit = context.Pizzas.Where(pizza => pizza.Id == id).First();

            context.Pizzas.Remove(pizzaEdit);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
