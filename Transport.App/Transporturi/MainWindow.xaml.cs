using System.Windows;
using Transporturi.Entitati;

namespace Transporturi.WPF
{
    public partial class MainWindow : Window
    {
        private Sofer sofer;

        public MainWindow()
        {
            InitializeComponent();

            sofer = new Sofer
            {
                Id = 1,
                Nume = "Popescu Ion",
                CategoriiPermis = "B, C, E",
                Kilometri = 120000
            };

            AfiseazaSofer();
        }

        private void AfiseazaSofer()
        {
            TxtId.Text = $"ID: {sofer.Id}";
            TxtNume.Text = $"Nume: {sofer.Nume}";
            TxtCategorii.Text = $"Categorii permis: {sofer.CategoriiPermis}";
            TxtKilometri.Text = $"Kilometri: {sofer.Kilometri}";
        }

        private void BtnActualizeaza_Click(object sender, RoutedEventArgs e)
        {
            sofer.Kilometri += 1000;
            AfiseazaSofer();
        }
    }
}