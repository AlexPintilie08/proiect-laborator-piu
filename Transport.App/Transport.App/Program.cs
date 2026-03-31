using System;
using System.Collections.Generic;
using Transporturi.Entitati;
using Transporturi.StocareDate;

namespace Transporturi.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdministrareSoferi adminSoferi = new AdministrareSoferi();
            AdministrareMasini adminMasini = new AdministrareMasini();

            AdministrareSoferi_FisierText adminSoferiFisier =
                new AdministrareSoferi_FisierText("soferi.txt");

            AdministrareMasini_FisierText adminMasiniFisier =
                new AdministrareMasini_FisierText("masini.txt");

            Console.Write("Cati soferi vrei sa introduci? ");
            int nrSoferi = int.Parse(Console.ReadLine());

            for (int i = 0; i < nrSoferi; i++)
            {
                Sofer s = new Sofer();

                Console.WriteLine($"\nSoferul {i + 1}:");

                Console.Write("Id: ");
                s.Id = int.Parse(Console.ReadLine());

                Console.Write("Nume: ");
                s.Nume = Console.ReadLine();

                Console.Write("Categorii permis: ");
                s.CategoriiPermis = Console.ReadLine();

                Console.Write("Kilometri: ");
                s.Kilometri = int.Parse(Console.ReadLine());

                adminSoferi.AdaugaSofer(s);
                adminSoferiFisier.AdaugaSofer(s);
            }

            Console.Write("\nCate masini vrei sa introduci? ");
            int nrMasini = int.Parse(Console.ReadLine());

            for (int i = 0; i < nrMasini; i++)
            {
                Masina m = new Masina();

                Console.WriteLine($"\nMasina {i + 1}:");

                Console.Write("Numar: ");
                m.Numar = Console.ReadLine();

                Console.Write("Marca: ");
                m.Marca = Console.ReadLine();

                Console.Write("An fabricatie: ");
                m.AnFabricatie = int.Parse(Console.ReadLine());

                Console.Write("Kilometri: ");
                m.Kilometri = int.Parse(Console.ReadLine());

                Console.WriteLine("Culoare masina:");
                Console.WriteLine("0 - Necunoscuta");
                Console.WriteLine("1 - Alb");
                Console.WriteLine("2 - Negru");
                Console.WriteLine("3 - Rosu");
                Console.WriteLine("4 - Albastru");
                Console.WriteLine("5 - Gri");
                Console.Write("Alege culoarea: ");
                m.Culoare = (CuloareMasina)int.Parse(Console.ReadLine());

                m.Optiuni = OptiuniMasina.Niciuna;

                Console.Write("Are aer conditionat? (da/nu): ");
                string raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    m.Optiuni |= OptiuniMasina.AerConditionat;
                }

                Console.Write("Are navigatie? (da/nu): ");
                raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    m.Optiuni |= OptiuniMasina.Navigatie;
                }

                Console.Write("Are cutie automata? (da/nu): ");
                raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    m.Optiuni |= OptiuniMasina.CutieAutomata;
                }

                Console.Write("Are senzori parcare? (da/nu): ");
                raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    m.Optiuni |= OptiuniMasina.SenzoriParcare;
                }

                adminMasini.AdaugaMasina(m);
                adminMasiniFisier.AdaugaMasina(m);
            }

            Console.WriteLine("\n=== SOFERI DIN MEMORIE ===");
            foreach (Sofer s in adminSoferi.GetSoferi())
            {
                Console.WriteLine(s.Info());
            }

            Console.WriteLine("\n=== MASINI DIN MEMORIE ===");
            foreach (Masina m in adminMasini.GetMasini())
            {
                Console.WriteLine(m.Info());
            }

            Console.WriteLine("\n=== SOFERI CITITI DIN FISIER ===");
            foreach (Sofer s in adminSoferiFisier.GetSoferi())
            {
                Console.WriteLine(s.Info());
            }

            Console.WriteLine("\n=== MASINI CITITE DIN FISIER ===");
            foreach (Masina m in adminMasiniFisier.GetMasini())
            {
                Console.WriteLine(m.Info());
            }

            Console.Write("\nIntrodu numele soferului cautat: ");
            string numeCautat = Console.ReadLine();

            Sofer soferGasit = adminSoferi.CautaDupaNume(numeCautat);

            if (soferGasit != null)
            {
                Console.WriteLine("Sofer gasit:");
                Console.WriteLine(soferGasit.Info());
            }
            else
            {
                Console.WriteLine("Soferul nu a fost gasit.");
            }

            Console.Write("\nIntrodu numarul masinii cautate: ");
            string numarCautat = Console.ReadLine();

            Masina masinaGasita = adminMasini.CautaDupaNumar(numarCautat);

            if (masinaGasita != null)
            {
                Console.WriteLine("Masina gasita:");
                Console.WriteLine(masinaGasita.Info());
            }
            else
            {
                Console.WriteLine("Masina nu a fost gasita.");
            }

            Console.WriteLine("\nAlege o culoare pentru filtrare:");
            Console.WriteLine("0 - Necunoscuta");
            Console.WriteLine("1 - Alb");
            Console.WriteLine("2 - Negru");
            Console.WriteLine("3 - Rosu");
            Console.WriteLine("4 - Albastru");
            Console.WriteLine("5 - Gri");
            Console.Write("Culoare: ");
            CuloareMasina culoareCautata = (CuloareMasina)int.Parse(Console.ReadLine());

            List<Masina> masiniDupaCuloare = adminMasini.GetMasiniDupaCuloare(culoareCautata);

            Console.WriteLine($"\n=== MASINI DE CULOAREA {culoareCautata} ===");
            foreach (Masina m in masiniDupaCuloare)
            {
                Console.WriteLine(m.Info());
            }

            Console.Write("\nIntrodu numarul minim de kilometri pentru soferi: ");
            int kmMinim = int.Parse(Console.ReadLine());

            List<Sofer> soferiFiltrati = adminSoferi.GetSoferiCuMultiKm(kmMinim);

            Console.WriteLine($"\n=== SOFERI CU CEL PUTIN {kmMinim} KM ===");
            foreach (Sofer s in soferiFiltrati)
            {
                Console.WriteLine(s.Info());
            }

            Console.Write("\nVrei sa modifici un sofer din fisier? (da/nu): ");
            string modificareSofer = Console.ReadLine();

            if (modificareSofer.ToLower() == "da")
            {
                Console.Write("Id-ul soferului de modificat: ");
                int idModificat = int.Parse(Console.ReadLine());

                Sofer soferNou = new Sofer();

                Console.Write("Id nou: ");
                soferNou.Id = int.Parse(Console.ReadLine());

                Console.Write("Nume nou: ");
                soferNou.Nume = Console.ReadLine();

                Console.Write("Categorii permis noi: ");
                soferNou.CategoriiPermis = Console.ReadLine();

                Console.Write("Kilometri noi: ");
                soferNou.Kilometri = int.Parse(Console.ReadLine());

                bool rezultat = adminSoferiFisier.ModificaSoferDupaId(idModificat, soferNou);

                if (rezultat)
                    Console.WriteLine("Sofer modificat cu succes in fisier.");
                else
                    Console.WriteLine("Soferul nu a fost gasit in fisier.");
            }

            Console.Write("\nVrei sa modifici o masina din fisier? (da/nu): ");
            string modificareMasina = Console.ReadLine();

            if (modificareMasina.ToLower() == "da")
            {
                Console.Write("Numarul masinii de modificat: ");
                string numarModificat = Console.ReadLine();

                Masina masinaNoua = new Masina();

                Console.Write("Numar nou: ");
                masinaNoua.Numar = Console.ReadLine();

                Console.Write("Marca noua: ");
                masinaNoua.Marca = Console.ReadLine();

                Console.Write("An fabricatie nou: ");
                masinaNoua.AnFabricatie = int.Parse(Console.ReadLine());

                Console.Write("Kilometri noi: ");
                masinaNoua.Kilometri = int.Parse(Console.ReadLine());

                Console.WriteLine("Culoare masina:");
                Console.WriteLine("0 - Necunoscuta");
                Console.WriteLine("1 - Alb");
                Console.WriteLine("2 - Negru");
                Console.WriteLine("3 - Rosu");
                Console.WriteLine("4 - Albastru");
                Console.WriteLine("5 - Gri");
                Console.Write("Alege culoarea: ");
                masinaNoua.Culoare = (CuloareMasina)int.Parse(Console.ReadLine());

                masinaNoua.Optiuni = OptiuniMasina.Niciuna;

                Console.Write("Are aer conditionat? (da/nu): ");
                string raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    masinaNoua.Optiuni |= OptiuniMasina.AerConditionat;
                }

                Console.Write("Are navigatie? (da/nu): ");
                raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    masinaNoua.Optiuni |= OptiuniMasina.Navigatie;
                }

                Console.Write("Are cutie automata? (da/nu): ");
                raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    masinaNoua.Optiuni |= OptiuniMasina.CutieAutomata;
                }

                Console.Write("Are senzori parcare? (da/nu): ");
                raspuns = Console.ReadLine();
                if (raspuns.ToLower() == "da")
                {
                    masinaNoua.Optiuni |= OptiuniMasina.SenzoriParcare;
                }

                bool rezultat = adminMasiniFisier.ModificaMasinaDupaNumar(numarModificat, masinaNoua);

                if (rezultat)
                    Console.WriteLine("Masina modificata cu succes in fisier.");
                else
                    Console.WriteLine("Masina nu a fost gasita in fisier.");
            }

            Console.WriteLine("\n=== SOFERI DIN FISIER DUPA MODIFICARE ===");
            foreach (Sofer s in adminSoferiFisier.GetSoferi())
            {
                Console.WriteLine(s.Info());
            }

            Console.WriteLine("\n=== MASINI DIN FISIER DUPA MODIFICARE ===");
            foreach (Masina m in adminMasiniFisier.GetMasini())
            {
                Console.WriteLine(m.Info());
            }
        }
    }
}