namespace Transporturi.Entitati
{
    public class Masina
    {
        public string Numar { get; set; }
        public string Marca { get; set; }
        public int AnFabricatie { get; set; }
        public int Kilometri { get; set; }

        public CuloareMasina Culoare { get; set; }
        public OptiuniMasina Optiuni { get; set; }

        public Masina()
        {
            Numar = string.Empty;
            Marca = string.Empty;
        }

        public string ConversieLaSirPentruFisier()
        {
            return $"{Numar};{Marca};{AnFabricatie};{Kilometri};{Culoare};{Optiuni}";
        }

        public string Info()
        {
            return $"Nr: {Numar}, Marca: {Marca}, An: {AnFabricatie}, Km: {Kilometri}, Culoare: {Culoare}, Optiuni: {Optiuni}";
        }
    }
}