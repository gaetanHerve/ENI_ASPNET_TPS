using System;

namespace MODULE2_TP1_reloaded.BO
{
    public abstract class Forme
    {
        public double CalculerAireQuadrilatere(int largeur, int longueur)
        {
            return largeur * longueur;
        }
        public double CalculerPerimetreQuadrilatere(int largeur, int longueur)
        {
            return (largeur * 2) + (longueur * 2);
        }
        public double CalculerAireCercle(int rayon)
        {
            return Math.Pow(rayon, 2) * Math.PI;
        }

        public double CalculerPerimetreCercle(int rayon)
        {
            return (rayon * 2) * Math.PI;
        }

        public double CalculerAireTriangle(int a, int b, int c)
        {
            double s = (a + b + c) / 2.0;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public double CalculerPerimetreTriangle(int a, int b, int c)
        {
            return a + b + c;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}