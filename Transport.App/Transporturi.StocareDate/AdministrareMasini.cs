using System.Collections.ObjectModel;
using System.Linq;
using Transporturi.Entitati;

namespace Transporturi.StocareDate
{
    public class AdministrareMasini : ICrudMasini
    {
        private ObservableCollection<Masina> masini;

        public AdministrareMasini()
        {
            masini = new ObservableCollection<Masina>();
        }

        public void Create(Masina masina)
        {
            masini.Add(masina);
        }

        public ObservableCollection<Masina> Read()
        {
            return masini;
        }

        public bool Update(string numarVechi, Masina masinaNoua)
        {
            Masina? masinaGasita = Find(numarVechi);

            if (masinaGasita == null)
            {
                return false;
            }

            masinaGasita.Numar = masinaNoua.Numar;
            masinaGasita.Marca = masinaNoua.Marca;
            masinaGasita.AnFabricatie = masinaNoua.AnFabricatie;
            masinaGasita.Kilometri = masinaNoua.Kilometri;
            masinaGasita.Culoare = masinaNoua.Culoare;
            masinaGasita.Optiuni = masinaNoua.Optiuni;

            return true;
        }

        public bool Delete(string numar)
        {
            Masina? masinaGasita = Find(numar);

            if (masinaGasita == null)
            {
                return false;
            }

            masini.Remove(masinaGasita);
            return true;
        }

        public Masina? Find(string numar)
        {
            return masini.FirstOrDefault(m => m.Numar == numar);
        }

        public void AdaugaMasina(Masina m)
        {
            Create(m);
        }

        public ObservableCollection<Masina> GetMasini()
        {
            return Read();
        }

        public Masina? CautaDupaNumar(string numar)
        {
            return Find(numar);
        }

        public ObservableCollection<Masina> GetMasiniDupaCuloare(CuloareMasina culoare)
        {
            return new ObservableCollection<Masina>(
                masini.Where(m => m.Culoare == culoare)
            );
        }
    }
}