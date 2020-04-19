using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODULE5_TP2.Models;
using MODULE5_TP2_BO;

namespace MODULE5_TP2.Controllers
{
    public class PizzaController : Controller
    {
        static List<Ingredient> ingredientsDisponibles = Utils.FakeDbPizza.Instance.IngredientsDisponibles;
        static List<Pate> patesDisponibles = Utils.FakeDbPizza.Instance.PatesDisponibles;
        static List<Pizza> listePizzas = Utils.FakeDbPizza.Instance.Pizzas;
        // GET: Pizza
        public ActionResult Index()
        {
            return View(listePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = listePizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM pizzaVm = new PizzaVM() { Pizza = new Pizza(), Ingredients = ingredientsDisponibles, Pates = patesDisponibles };
            return View(pizzaVm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM pizzaVm)
        {
            try
            {
                // TODO: Add insert logic here
                Pizza pizza = pizzaVm.Pizza;
                pizza.Ingredients = pizzaVm.Ingredients;
                /*pizza.Pate = pizzaVm.Pates;*/
                // Dans Liste pizza ou dans FakeDb directement ?
                listePizzas.Add(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
