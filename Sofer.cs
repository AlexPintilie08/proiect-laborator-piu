using System;

namespace FirmaTransport
{
    class Sofer
    {
        public int id;
        public string nume;
        public string[] categoriiPermis;
        public int kilometri;

        public void Afiseaza()
        {
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Nume: " + nume);

            Console.Write("Categorii permis: ");
            for (int i = 0; i < categoriiPermis.Length; i++)
            {
                Console.Write(categoriiPermis[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Kilometri: " + kilometri);
        }
    }
}
