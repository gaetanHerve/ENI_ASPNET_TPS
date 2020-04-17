using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODULE5_TP2_BO;

namespace MODULE5_TP2.Utils
{
    public class FakeDbPizza
    {
        private static FakeDbPizza _instance;
        static readonly object instanceLock = new object();

        private FakeDbPizza()
        {
            ingredientsDisponibles = this.GetIngredients();
            patesDisponibles = this.GetPates();
        }

        public static FakeDbPizza Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new FakeDbPizza();
                    }
                }
                return _instance;
            }
        }

        private List<Ingredient> ingredientsDisponibles;
        private List<Pate> patesDisponibles;
        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
            set { pizzas = value; }
        }

        public List<Ingredient> IngredientsDisponibles
        {
            get { return ingredientsDisponibles; }
        }
        public List<Pate> PatesDisponibles
        {
            get { return patesDisponibles; }
        }

        private List<Ingredient> GetIngredients()
        {
            var i = 1;
            return new List<Ingredient>
            {
                new Ingredient{Id=i++,Nom="Mozzarella"},
                new Ingredient{Id=i++,Nom="Jambon"},
                new Ingredient{Id=i++,Nom="Tomate"},
                new Ingredient{Id=i++,Nom="Oignon"},
                new Ingredient{Id=i++,Nom="Cheddar"},
                new Ingredient{Id=i++,Nom="Saumon"},
                new Ingredient{Id=i++,Nom="Champignon"},
                new Ingredient{Id=i++,Nom="Poulet"}
            };
        }

        private List<Pate> GetPates()
        {
            var i = 1;
            return new List<Pate>
            {
                new Pate{ Id=i++,Nom="Pate fine, base crême"},
                new Pate{ Id=i++,Nom="Pate fine, base tomate"},
                new Pate{ Id=i++,Nom="Pate épaisse, base crême"},
                new Pate{ Id=i++,Nom="Pate épaisse, base tomate"}
            };
        }
    }
}