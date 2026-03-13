using System;

namespace FirmaTransport
{
    class Masina
    {
        public string numar;
        public string marca;
        public int anFabricatie;
        public int kilometri;

        public void Afiseaza()
        {
            Console.WriteLine("Numar: " + numar);
            Console.WriteLine("Marca: " + marca);
            Console.WriteLine("An fabricatie: " + anFabricatie);
            Console.WriteLine("Kilometri: " + kilometri);
        }
    }
}
