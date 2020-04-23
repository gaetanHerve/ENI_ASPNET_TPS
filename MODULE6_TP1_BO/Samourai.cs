using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MODULE6_TP1_BO
{
    public class Samourai : Recordable
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        [Display(Name = "Arts martiaux maîtrisés")]
        public virtual List<ArtMartial> ArtsMartiaux { get; set; } = new List<ArtMartial>();
        public int Potentiel
        {
            get
            {
                int potentiel = Force;
                if (Arme != null)
                {
                    potentiel += Arme.Degats;
                }
                potentiel *= (ArtsMartiaux.Count + 1);
                return potentiel;
            }
        }
    }
}
