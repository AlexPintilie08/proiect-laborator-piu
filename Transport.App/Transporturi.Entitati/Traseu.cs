namespace Transporturi.Entitati
{
    public class Traseu
    {
        public string Plecare { get; set; }
        public string Destinatie { get; set; }
        public int Distanta { get; set; }

        public Traseu()
        {
            Plecare = string.Empty;
            Destinatie = string.Empty;
        }

        public string Info()
        {
            return $"Plecare: {Plecare}, Destinatie: {Destinatie}, Distanta: {Distanta}";
        }
    }
}
