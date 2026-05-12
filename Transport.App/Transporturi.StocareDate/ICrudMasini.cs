using System.Collections.ObjectModel;
using Transporturi.Entitati;

namespace Transporturi.StocareDate
{
    public interface ICrudMasini
    {
        void Create(Masina masina);

        ObservableCollection<Masina> Read();

        bool Update(string numarVechi, Masina masinaNoua);

        bool Delete(string numar);

        Masina? Find(string numar);
    }
}