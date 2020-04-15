namespace MODULE2_TP1
{
    internal class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override string ToString()
        {
            string strDimensions = $"Rectangle de longueur={this.Longueur} et largeur={this.Largeur}";
            string strAire = $"Aire = {CalculerAireQuadrilatere(Largeur, Longueur)}";
            string strPerimetre = $"Périmètre = {CalculerPerimetreQuadrilatere(Largeur, Longueur)}";
            return strDimensions + "\n" + strAire + "\n" + strPerimetre + "\n";
        }
    }
}