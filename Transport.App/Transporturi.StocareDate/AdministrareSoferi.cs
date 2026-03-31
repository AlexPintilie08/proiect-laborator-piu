using System.Collections.Generic;
using System.Linq;
using Transporturi.Entitati;

namespace Transporturi.StocareDate
{
    public class AdministrareSoferi
    {
        private List<Sofer> soferi;

        public AdministrareSoferi()
        {
            soferi = new List<Sofer>();
        }

        public void AdaugaSofer(Sofer s)
        {
            soferi.Add(s);
        }

        public List<Sofer> GetSoferi()
        {
            return soferi;
        }

        public Sofer CautaDupaNume(string nume)
        {
            return soferi.FirstOrDefault(s => s.Nume == nume);
        }

        public List<Sofer> GetSoferiCuMultiKm(int kmMinim)
        {
            return soferi.Where(s => s.Kilometri >= kmMinim).ToList();
        }
    }
}