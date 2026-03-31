using System.Collections.Generic;
using System.IO;
using Transporturi.Entitati;

namespace Transporturi.StocareDate
{
    public class AdministrareSoferi_FisierText
    {
        private string numeFisier;

        public AdministrareSoferi_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public void AdaugaSofer(Sofer sofer)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(sofer.ConversieLaSirPentruFisier());
            }
        }

        public List<Sofer> GetSoferi()
        {
            List<Sofer> soferi = new List<Sofer>();

            if (!File.Exists(numeFisier))
            {
                return soferi;
            }

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;

                while ((linie = sr.ReadLine()) != null)
                {
                    string[] date = linie.Split(';');

                    Sofer s = new Sofer();
                    s.Id = int.Parse(date[0]);
                    s.Nume = date[1];
                    s.CategoriiPermis = date[2];
                    s.Kilometri = int.Parse(date[3]);

                    soferi.Add(s);
                }
            }

            return soferi;
        }

        public bool ModificaSoferDupaId(int idCautat, Sofer soferNou)
        {
            List<Sofer> soferi = GetSoferi();
            bool modificat = false;

            for (int i = 0; i < soferi.Count; i++)
            {
                if (soferi[i].Id == idCautat)
                {
                    soferi[i] = soferNou;
                    modificat = true;
                    break;
                }
            }

            if (modificat)
            {
                using (StreamWriter sw = new StreamWriter(numeFisier, false))
                {
                    foreach (Sofer s in soferi)
                    {
                        sw.WriteLine(s.ConversieLaSirPentruFisier());
                    }
                }
            }

            return modificat;
        }
    }
}