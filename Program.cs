using FirmaTransport;

class Program
{
    static void Main(string[] args)
    {
        Sofer s = new Sofer();
        s.id = 1;
        s.nume = "Popescu";
        s.categoriiPermis = new string[] { "B", "C" };
        s.kilometri = 2000;

        Masina m = new Masina();
        m.numar = "SV10ABC";
        m.marca = "Mercedes";
        m.anFabricatie = 2018;
        m.kilometri = 150000;

        Traseu t = new Traseu();
        t.plecare = "Suceava";
        t.destinatie = "Cluj";
        t.distanta = 280;

        s.Afiseaza();
        m.Afiseaza();
        t.Afiseaza();
    }
}
