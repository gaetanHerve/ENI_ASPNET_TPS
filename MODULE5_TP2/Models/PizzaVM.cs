using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [DisplayName("Ingrédients")]
   /*     [MaxLength(5)]
        [MinLength(2)]*/
        public List<int> IdIngredients { get; set; }

        [Required]
        [DisplayName("Pates")]
        public int IdPate { get; set; }

        public Pizza GetPizzaFromPizzaVm()
        {
            // A Coder pour factorisation code
            // plutôt une propriété en readonly
            Pizza pizza = this.Pizza;
            return pizza;
        }
    }
}