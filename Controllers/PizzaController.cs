using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria.Models;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
