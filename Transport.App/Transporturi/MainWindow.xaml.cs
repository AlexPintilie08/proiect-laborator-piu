using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Transporturi.Entitati;
using Transporturi.StocareDate;

namespace Transporturi
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private AdministrareMasini adminMasini;

        private Masina masinaCurenta;
        private Masina masinaSelectata;
        private string mesaj;

        public ObservableCollection<Masina> Masini { get; set; }

        public ObservableCollection<CuloareMasina> Culori { get; set; }

        public Masina MasinaCurenta
        {
            get => masinaCurenta;
            set
            {
                masinaCurenta = value;
                OnPropertyChanged();
            }
        }

        public Masina MasinaSelectata
        {
            get => masinaSelectata;
            set
            {
                masinaSelectata = value;

                if (value != null)
                {
                    MasinaCurenta = new Masina
                    {
                        Numar = value.Numar,
                        Marca = value.Marca,
                        AnFabricatie = value.AnFabricatie,
                        Kilometri = value.Kilometri,
                        Culoare = value.Culoare,
                        Optiuni = value.Optiuni
                    };
                }

                OnPropertyChanged();
            }
        }

        public string Mesaj
        {
            get => mesaj;
            set
            {
                mesaj = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            adminMasini = new AdministrareMasini();

            Masini = adminMasini.Read();

            Culori = new ObservableCollection<CuloareMasina>
            {
                CuloareMasina.Alb,
                CuloareMasina.Negru,
                CuloareMasina.Rosu
            };

            MasinaCurenta = new Masina();

            DataContext = this;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            adminMasini.Create(new Masina
            {
                Numar = MasinaCurenta.Numar,
                Marca = MasinaCurenta.Marca,
                AnFabricatie = MasinaCurenta.AnFabricatie,
                Kilometri = MasinaCurenta.Kilometri,
                Culoare = MasinaCurenta.Culoare,
                Optiuni = MasinaCurenta.Optiuni
            });

            Mesaj = "Mașină adăugată.";

            MasinaCurenta = new Masina();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (MasinaSelectata == null)
            {
                Mesaj = "Selectează o mașină.";
                return;
            }

            bool rezultat = adminMasini.Update(
                MasinaSelectata.Numar,
                MasinaCurenta
            );

            Mesaj = rezultat
                ? "Mașină modificată."
                : "Modificare eșuată.";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MasinaSelectata == null)
            {
                Mesaj = "Selectează o mașină.";
                return;
            }

            bool rezultat = adminMasini.Delete(
                MasinaSelectata.Numar
            );

            Mesaj = rezultat
                ? "Mașină ștearsă."
                : "Ștergere eșuată.";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    }
}