using System;

namespace FirmaTransport
{
    class Traseu
    {
        public string plecare;
        public string destinatie;
        public int distanta;

        public void Afiseaza()
        {
            Console.WriteLine("Plecare: " + plecare);
            Console.WriteLine("Destinatie: " + destinatie);
            Console.WriteLine("Distanta: " + distanta + " km");
        }
    }
}
