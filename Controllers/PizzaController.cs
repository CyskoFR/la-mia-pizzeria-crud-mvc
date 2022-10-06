using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria.Models;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaContext context = new PizzeriaContext();
        public ActionResult Index()
        {
            PizzeriaContext db = new PizzeriaContext();

            return View(db.Pizzas.ToList());
        }

        public ActionResult Show(int id)
        {
            PizzeriaContext db = new PizzeriaContext();

            return View(db.Pizzas.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza formData)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizzaCreate = new Pizza();
                pizzaCreate.Name = formData.Name;
                pizzaCreate.Description = formData.Description;
                pizzaCreate.Picture = formData.Picture;
                pizzaCreate.Price = formData.Price;

                context.Pizzas.Add(pizzaCreate);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            PizzeriaContext db = new PizzeriaContext();

            return View(db.Pizzas.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Pizza pizzaEdit = context.Pizzas.Where(pizza => pizza.Id == id).First();

            pizzaEdit.Name = formData.Name;
            pizzaEdit.Description = formData.Description;
            pizzaEdit.Picture = formData.Picture;
            pizzaEdit.Price = formData.Price;

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
