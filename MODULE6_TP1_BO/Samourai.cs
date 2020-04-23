using System.Collections.Generic;

namespace MODULE6_TP1_BO
{
    public class Samourai : Recordable
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtsMartiaux { get; set; } = new List<ArtMartial>();
        public int Potentiel { get; set; }
    }
}
