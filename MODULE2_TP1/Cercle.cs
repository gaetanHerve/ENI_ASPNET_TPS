using System;

namespace MODULE2_TP1
{
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override string ToString()
        {
            string strRayon = $"Cercle de rayon {Rayon}";
            string strAire = $"Aire = {CalculerAireCercle(Rayon)}";
            string strPerimetre = $"Périmètre = {CalculerPerimetreCercle(Rayon)}";
            return strRayon + "\n" + strAire + "\n" + strPerimetre + "\n";
        }
    }
}