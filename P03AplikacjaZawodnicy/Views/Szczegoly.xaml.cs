using P03AplikacjaZawodnicy.Operations;
using P03AplikacjaZawodnicy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P03AplikacjaZawodnicy.Views
{
    public enum TrybOkienka
    {
        Tworzenie,
        Edycja,
        Usuwanie
    }


    /// <summary>
    /// Interaction logic for Szczegoly.xaml
    /// </summary>
    public partial class Szczegoly : Window
    {
        private ZawodnikVM zawodnik;
        TrybOkienka trybOkienka;
        public Szczegoly()
        {
            InitializeComponent();
        }

        public Szczegoly(ZawodnikVM zaznaczony, TrybOkienka trybOkienka) : this()
        {
            this.trybOkienka = trybOkienka;
            zawodnik = zaznaczony;

            // bindowanie zawodnika z całym okienkiem, dzięki temu moge korzystać z bindowania w xaml
            this.DataContext = zawodnik;

            // tradycyjne podejscie
            //txtImie.Text = zaznaczony.Imie;
            //txtNazwisko.Text = zaznaczony.Nazwisko;
            //txtKraj.Text = zaznaczony.Kraj;
            //txtWaga.Text = zaznaczony.Waga.ToString();
            //txtWzrost.Text = zaznaczony.Wzrost.ToString();
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            //tradycyjne podjescie
            //ZawodnikVM zawodnik = new ZawodnikVM();
            //zawodnik.Imie = txtImie.Text;
            //zawodnik.Nazwisko = txtNazwisko.Text;
            //zawodnik.Kraj= txtKraj.Text;
            //zawodnik.DataUrodzenia = dpDataUr.SelectedDate;
            //zawodnik.Waga= Convert.ToInt32(txtWaga.Text);
            //zawodnik.Wzrost = Convert.ToInt32(txtWzrost.Text);

            ZawodnicyOperation zo = new ZawodnicyOperation();

            if (trybOkienka== TrybOkienka.Tworzenie)
            {
                zo.DodajZawodnika(zawodnik);
            }else if (trybOkienka== TrybOkienka.Edycja)
            {
                zawodnik.Id = this.zawodnik.Id;
                zo.EdytujZawodnika(zawodnik);
            }
            else
            {
                throw new Exception("nieznany tryb okienka");
            }

           
        }
    }
}
