﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODULE5_TP2_BO;

namespace MODULE5_TP2.Models
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
        public List<int> IdIngredients { get; set; }
        public int IdPate { get; set; }

        public Pizza GetPizzaFromPizzaVm()
        {
            // A Coder pour factorisation code
            Pizza pizza = this.Pizza;
            return pizza;
        }
    }
}