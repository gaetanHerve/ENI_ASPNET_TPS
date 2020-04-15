namespace MODULE2_TP1_reloaded.BO
{
    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override string ToString()
        {
            string strCote = $"Triangle de côté A={this.A}, B={this.B}, C={this.C}";
            string strAire = $"Aire = {CalculerAireTriangle(A, B, C)}";
            string strPerimetre = $"Périmètre = {CalculerPerimetreTriangle(A, B, C)}";
            return strCote + "\n" + strAire + "\n" + strPerimetre + "\n";
        }
    }
}