namespace Transporturi.Entitati
{
    public class Sofer
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string CategoriiPermis { get; set; }
        public int Kilometri { get; set; }

        public Sofer()
        {
            Nume = string.Empty;
            CategoriiPermis = string.Empty;
        }

        public string ConversieLaSirPentruFisier()
        {
            return $"{Id};{Nume};{CategoriiPermis};{Kilometri}";
        }

        public string Info()
        {
            return $"ID: {Id}, Nume: {Nume}, Categorii permis: {CategoriiPermis}, Kilometri: {Kilometri}";
        }
    }
}