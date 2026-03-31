using System.Collections.Generic;
using System.IO;
using Transporturi.Entitati;

namespace Transporturi.StocareDate
{
    public class AdministrareMasini_FisierText
    {
        private string numeFisier;

        public AdministrareMasini_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public void AdaugaMasina(Masina masina)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(masina.ConversieLaSirPentruFisier());
            }
        }

        public List<Masina> GetMasini()
        {
            List<Masina> masini = new List<Masina>();

            if (!File.Exists(numeFisier))
            {
                return masini;
            }

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;

                while ((linie = sr.ReadLine()) != null)
                {
                    string[] date = linie.Split(';');

                    Masina m = new Masina();
                    m.Numar = date[0];
                    m.Marca = date[1];
                    m.AnFabricatie = int.Parse(date[2]);
                    m.Kilometri = int.Parse(date[3]);
                    m.Culoare = (CuloareMasina)System.Enum.Parse(typeof(CuloareMasina), date[4]);
                    m.Optiuni = (OptiuniMasina)System.Enum.Parse(typeof(OptiuniMasina), date[5]);

                    masini.Add(m);
                }
            }

            return masini;
        }

        public bool ModificaMasinaDupaNumar(string numarCautat, Masina masinaNoua)
        {
            List<Masina> masini = GetMasini();
            bool modificat = false;

            for (int i = 0; i < masini.Count; i++)
            {
                if (masini[i].Numar == numarCautat)
                {
                    masini[i] = masinaNoua;
                    modificat = true;
                    break;
                }
            }

            if (modificat)
            {
                using (StreamWriter sw = new StreamWriter(numeFisier, false))
                {
                    foreach (Masina m in masini)
                    {
                        sw.WriteLine(m.ConversieLaSirPentruFisier());
                    }
                }
            }

            return modificat;
        }
    }
}