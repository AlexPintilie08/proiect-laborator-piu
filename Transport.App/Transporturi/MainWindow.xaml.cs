using System.Windows;
using System.Windows.Media;
using Transporturi.Entitati;

namespace Transporturi
{
    public partial class MainWindow : Window
    {
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

            int kilometri;

            if (!int.TryParse(txtKilometri.Text, out kilometri) ||
                kilometri < KM_MIN ||
                kilometri > KM_MAX)
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

            Sofer s = new Sofer
            {
                Id = 1,
                Nume = txtNume.Text,
                CategoriiPermis = txtCategorii.Text,
                Kilometri = kilometri
            };

            txtMesaj.Foreground = Brushes.Green;
            txtMesaj.Text = $"Șofer adăugat: {s.Nume}";
        }
    }
}