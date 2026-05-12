using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Transporturi.Entitati;

namespace Transporturi
{
    public partial class MainWindow : Window
    {
        private List<Sofer> soferi = new List<Sofer>();

        private const int KM_MIN = 0;
        private const int KM_MAX = 1000000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdauga_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            txtNume.Background = Brushes.White;
            txtTelefon.Background = Brushes.White;
            txtCategorii.Background = Brushes.White;
            txtKilometri.Background = Brushes.White;

            txtMesaj.Text = "";

            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                txtNume.Background = Brushes.LightPink;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                txtTelefon.Background = Brushes.LightPink;
                valid = false;
            }

            int km;

            if (!int.TryParse(txtKilometri.Text, out km) ||
                km < KM_MIN ||
                km > KM_MAX)
            {
                txtKilometri.Background = Brushes.LightPink;
                valid = false;
            }

            if (!valid)
            {
                txtMesaj.Foreground = Brushes.Red;
                txtMesaj.Text = "Date invalide!";
                return;
            }

            string tipAngajat = rbIntern.IsChecked == true
                ? "Intern"
                : "Extern";

            string beneficii = "";

            if (cbBonus.IsChecked == true)
                beneficii += "Bonus ";

            if (cbAsigurare.IsChecked == true)
                beneficii += "Asigurare";

            Sofer s = new Sofer
            {
                Id = soferi.Count + 1,
                Nume = txtNume.Text,
                CategoriiPermis = txtCategorii.Text,
                Kilometri = km
            };

            soferi.Add(s);

            lstSoferi.Items.Add(
                $"{s.Id} | {s.Nume} | {tipAngajat} | {beneficii}");

            txtMesaj.Foreground = Brushes.Green;
            txtMesaj.Text = "Șofer adăugat!";
        }

        private void BtnCauta_Click(object sender, RoutedEventArgs e)
        {
            string cautare = txtCautare.Text.ToLower();

            var rezultate = soferi
                .Where(s => s.Nume.ToLower().Contains(cautare))
                .ToList();

            lstSoferi.Items.Clear();

            foreach (var s in rezultate)
            {
                lstSoferi.Items.Add(
                    $"{s.Id} | {s.Nume} | {s.CategoriiPermis}");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}