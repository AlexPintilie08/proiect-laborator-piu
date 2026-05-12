using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

            dpDataAngajare.SelectedDate = DateTime.Today;
            dpDataActualizare.SelectedDate = DateTime.Today;
        }

        private void BtnAdauga_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            txtNume.Background = Brushes.White;
            txtCategorii.Background = Brushes.White;
            txtKilometri.Background = Brushes.White;
            txtMesaj.Text = "";

            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                txtNume.Background = Brushes.LightPink;
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCategorii.Text))
            {
                txtCategorii.Background = Brushes.LightPink;
                valid = false;
            }

            if (!int.TryParse(txtKilometri.Text, out int kilometri) ||
                kilometri < KM_MIN ||
                kilometri > KM_MAX)
            {
                txtKilometri.Background = Brushes.LightPink;
                valid = false;
            }

            if (lstTipSofer.SelectedItem == null)
            {
                txtMesaj.Foreground = Brushes.Red;
                txtMesaj.Text = "Alege tipul șoferului.";
                return;
            }

            if (!valid)
            {
                txtMesaj.Foreground = Brushes.Red;
                txtMesaj.Text = "Date invalide!";
                return;
            }

            string tipSofer = ((ListBoxItem)lstTipSofer.SelectedItem).Content.ToString();
            DateTime dataAngajare = dpDataAngajare.SelectedDate ?? DateTime.Today;

            Sofer sofer = new Sofer
            {
                Id = soferi.Count + 1,
                Nume = txtNume.Text,
                CategoriiPermis = txtCategorii.Text,
                Kilometri = kilometri
            };

            soferi.Add(sofer);

            ActualizeazaSurseDate();
            AfiseazaLista(soferi);

            txtMesaj.Foreground = Brushes.Green;
            txtMesaj.Text = $"Șofer adăugat: {sofer.Nume}, tip: {tipSofer}, data: {dataAngajare.ToShortDateString()}";
        }

        private void CmbSoferi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSoferi.SelectedItem is Sofer sofer)
            {
                txtNumeModifica.Text = sofer.Nume;
                txtCategoriiModifica.Text = sofer.CategoriiPermis;
                txtKilometriModifica.Text = sofer.Kilometri.ToString();
                dpDataActualizare.SelectedDate = DateTime.Today;
            }
        }

        private void BtnActualizeaza_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSoferi.SelectedItem is not Sofer soferSelectat)
            {
                txtMesaj.Foreground = Brushes.Red;
                txtMesaj.Text = "Selectează un șofer pentru modificare.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeModifica.Text) ||
                string.IsNullOrWhiteSpace(txtCategoriiModifica.Text) ||
                !int.TryParse(txtKilometriModifica.Text, out int kilometriNoi) ||
                kilometriNoi < KM_MIN ||
                kilometriNoi > KM_MAX)
            {
                txtMesaj.Foreground = Brushes.Red;
                txtMesaj.Text = "Date invalide la modificare.";
                return;
            }

            soferSelectat.Nume = txtNumeModifica.Text;
            soferSelectat.CategoriiPermis = txtCategoriiModifica.Text;
            soferSelectat.Kilometri = kilometriNoi;

            DateTime dataActualizare = dpDataActualizare.SelectedDate ?? DateTime.Today;

            ActualizeazaSurseDate();
            AfiseazaLista(soferi);

            txtMesaj.Foreground = Brushes.Green;
            txtMesaj.Text = $"Șofer modificat la data {dataActualizare.ToShortDateString()}.";
        }

        private void BtnCauta_Click(object sender, RoutedEventArgs e)
        {
            string cautare = txtCautare.Text.ToLower();

            List<Sofer> rezultate = soferi
                .Where(s => s.Nume.ToLower().Contains(cautare))
                .ToList();

            AfiseazaLista(rezultate);
        }

        private void BtnAfiseazaToti_Click(object sender, RoutedEventArgs e)
        {
            AfiseazaLista(soferi);
        }

        private void AfiseazaLista(List<Sofer> lista)
        {
            lstSoferi.Items.Clear();

            foreach (Sofer s in lista)
            {
                lstSoferi.Items.Add($"{s.Id} | {s.Nume} | {s.CategoriiPermis} | {s.Kilometri} km");
            }
        }

        private void ActualizeazaSurseDate()
        {
            cmbSoferi.ItemsSource = null;
            cmbSoferi.ItemsSource = soferi;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}