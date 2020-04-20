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
        static int idPizza = 1;
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
                Pizza pizza = new Pizza() { Id = idPizza, Nom = pizzaVm.Pizza.Nom};
                pizza.Pate = patesDisponibles.FirstOrDefault(p => p.Id == pizzaVm.IdPate);
                pizza.Ingredients = ingredientsDisponibles.Where(i => pizzaVm.IdIngredients.Contains(i.Id)).ToList();
                listePizzas.Add(pizza);
                idPizza++;
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
            Pizza pizza = listePizzas.FirstOrDefault(p => p.Id == id);
            List<int> idIngredients = new List<int>();

            foreach (Ingredient ingredient in pizza.Ingredients)
            {
                idIngredients.Add(ingredient.Id);
            }

            PizzaVM pizzaVm = new PizzaVM()
            {
                Pizza = pizza,
                IdPate = pizza.Pate.Id,
                IdIngredients = idIngredients,
                Ingredients = ingredientsDisponibles,
                Pates = patesDisponibles
            };
            return View(pizzaVm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PizzaVM pizzaVm)
        {
            try
            {
                Pizza pizza = listePizzas.FirstOrDefault(p => p.Id == id);
                pizza.Nom = pizzaVm.Pizza.Nom;
                pizza.Ingredients = ingredientsDisponibles.Where(i => pizzaVm.IdIngredients.Contains(i.Id)).ToList();
                pizza.Pate = patesDisponibles.FirstOrDefault(p => p.Id == pizzaVm.IdPate);
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
            Pizza pizza = listePizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pizza pizza)
        {
            try
            {
                listePizzas.Remove(listePizzas.FirstOrDefault(p => p.Id == id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
