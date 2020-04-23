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
        private int potentiel;
        public int Potentiel
        {
            get
            {
                potentiel = Force;
                if (Arme != null)
                {
                    potentiel += Arme.Degats;
                }
                potentiel *= (ArtsMartiaux.Count + 1);
                return potentiel;
            }
            set{ potentiel = value; }
        }
    }
}
