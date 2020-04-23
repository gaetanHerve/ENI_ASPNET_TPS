using MODULE6_TP1_BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MODULE6_TP1.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        [Display(Name = "Arme")]
        public List<Arme> ArmesDisponibles { get; set; }
        public int? IdArme { get; set; }
        [Display(Name = "Arts martiaux")]
        public List<ArtMartial> ArtsDisponibles { get; set; }
        public List<int> IdsSelectedArts { get; set; } = new List<int>();
    }
}