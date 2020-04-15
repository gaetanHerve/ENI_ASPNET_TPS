namespace MODULE2_TP1
{
    internal class Carre : Forme
    {
        public int Longueur { get; set; }

        public override string ToString()
        {
            string strDimensions = $"Rectangle de longueur={this.Longueur}";
            string strAire = $"Aire = {CalculerAireQuadrilatere(Longueur, Longueur)}";
            string strPerimetre = $"Périmètre = {CalculerPerimetreQuadrilatere(Longueur, Longueur)}";
            return strDimensions + "\n" + strAire + "\n" + strPerimetre + "\n";
        }
    }
}