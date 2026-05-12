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
            AnFabricatie = 0;
            Kilometri = 0;
            Culoare = CuloareMasina.Necunoscuta;
            Optiuni = OptiuniMasina.Niciuna;
        }

        public string ConversieLaSirPentruFisier()
        {
            return $"{Numar};{Marca};{AnFabricatie};{Kilometri};{Culoare};{Optiuni}";
        }

        public string Info()
        {
            return $"{Numar} - {Marca} - {AnFabricatie} - {Kilometri} km - {Culoare} - {Optiuni}";
        }

        public override string ToString()
        {
            return $"{Numar} | {Marca} | {AnFabricatie} | {Kilometri} km";
        }
    }
}