using System.Collections.Generic;
using System.Linq;
using Transporturi.Entitati;

namespace Transporturi.StocareDate
{
    public class AdministrareMasini
    {
        private List<Masina> masini;

        public AdministrareMasini()
        {
            masini = new List<Masina>();
        }

        public void AdaugaMasina(Masina m)
        {
            masini.Add(m);
        }

        public List<Masina> GetMasini()
        {
            return masini;
        }

        public Masina CautaDupaNumar(string numar)
        {
            return masini.FirstOrDefault(m => m.Numar == numar);
        }

        public List<Masina> GetMasiniDupaCuloare(CuloareMasina culoare)
        {
            return masini.Where(m => m.Culoare == culoare).ToList();
        }
    }
}