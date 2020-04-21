using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODULE5_TP2.Models;
using MODULE5_TP2.Utils;
using MODULE5_TP2_BO;

namespace MODULE5_TP2.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDbPizza.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM pizzaVm = new PizzaVM() { Pizza = new Pizza(), Ingredients = FakeDbPizza.Instance.IngredientsDisponibles, Pates = FakeDbPizza.Instance.PatesDisponibles };
            return View(pizzaVm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM pizzaVm)
        {
            try
            {
                if (ModelState.IsValid && ValidateVM(pizzaVm))
                {
                    if (ModelState.IsValid && IsNameUnique(pizzaVm) && IsIngredientListUnique(pizzaVm))
                    {
                        Pizza pizza = new Pizza();
                        pizza.Id = FakeDbPizza.Instance.Pizzas.Count == 0 ? 1 : FakeDbPizza.Instance.Pizzas.Max(x => x.Id) + 1;
                        pizza.Nom = pizzaVm.Pizza.Nom;
                        pizza.Pate = FakeDbPizza.Instance.PatesDisponibles.FirstOrDefault(p => p.Id == pizzaVm.IdPate);
                        pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles.Where(i => pizzaVm.IdIngredients.Contains(i.Id)).ToList();
                        FakeDbPizza.Instance.Pizzas.Add(pizza);
                        return RedirectToAction("Index");
                    }
                }
                pizzaVm.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles;
                pizzaVm.Pates = FakeDbPizza.Instance.PatesDisponibles;
                return View(pizzaVm);
            }
            catch
            {
                /*PizzaVM pizzaBCKP = new PizzaVM() { Pizza = new Pizza(), Ingredients = FakeDbPizza.Instance.IngredientsDisponibles, Pates = FakeDbPizza.Instance.PatesDisponibles };*/
                pizzaVm.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles;
                pizzaVm.Pates = FakeDbPizza.Instance.PatesDisponibles;
                return View(pizzaVm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
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
                Ingredients = FakeDbPizza.Instance.IngredientsDisponibles,
                Pates = FakeDbPizza.Instance.PatesDisponibles
            };


            return View(pizzaVm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PizzaVM pizzaVm)
        {
            try
            { 
                if (ModelState.IsValid && IsNameUnique(pizzaVm) && IsIngredientListUnique(pizzaVm))
                {
                    Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
                    pizza.Nom = pizzaVm.Pizza.Nom;
                    pizza.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles.Where(i => pizzaVm.IdIngredients.Contains(i.Id)).ToList();
                    pizza.Pate = FakeDbPizza.Instance.PatesDisponibles.FirstOrDefault(p => p.Id == pizzaVm.IdPate);
                    return RedirectToAction("Index");
                }
                pizzaVm.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles;
                pizzaVm.Pates = FakeDbPizza.Instance.PatesDisponibles;
                return View(pizzaVm);

            }
            catch
            {
                pizzaVm.Ingredients = FakeDbPizza.Instance.IngredientsDisponibles;
                pizzaVm.Pates = FakeDbPizza.Instance.PatesDisponibles;
                return View(pizzaVm);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pizza pizza)
        {
            try
            {
                FakeDbPizza.Instance.Pizzas.Remove(FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private bool ValidateVM(PizzaVM vm)
        {
            bool result = true;
            return result;
        }

        private bool IsNameUnique(PizzaVM vm)
        {
            // TODO : Dans le cas d'un edit, Retirer la pizza que l'on édite de la liste des pizzas comparer
            bool result = !FakeDbPizza.Instance.Pizzas.Any(p => p.Nom == vm.Pizza.Nom);
            if (!result)
                ModelState.AddModelError("", "Il existe déjà une pizza portant ce nom");
            return result;
        }

        private bool IsIngredientListUnique(PizzaVM vm)
        {
            // TODO : Dans le cas d'un edit, Retirer la pizza que l'on édite de la liste des pizzas comparer
            bool result = true;

            foreach (var pizza in FakeDbPizza.Instance.Pizzas)
            {
                if (pizza.Ingredients.Select(i => i.Id).SequenceEqual(vm.IdIngredients))
                {
                    result = false;
                    ModelState.AddModelError("", "Il existe déjà une pizza composée de ces ingrédients");
                    break;
                }
            }
            return result;
        }

    }
}
