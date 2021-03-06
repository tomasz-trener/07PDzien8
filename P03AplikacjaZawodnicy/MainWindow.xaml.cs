using P03AplikacjaZawodnicy.Operations;
using P03AplikacjaZawodnicy.Views;
using P08AplikacjaZawodnicy.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P03AplikacjaZawodnicy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, RoutedEventArgs e)
        {
            ZawodnicyOperation zo = new ZawodnicyOperation();
            var zawodnicy = zo.PodajZawodnikow();

            // sposób bez bindowania danych
            //foreach (var z in zawodnicy) 
            //{
            //    lbDane.Items.Add(z.PodstawoweDane);
            //}

            lbDane.ItemsSource = zawodnicy;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Szczegoly frmSzczegoly = new Szczegoly();
            frmSzczegoly.Show();
        }

        private void btnEdytuj_Click(object sender, RoutedEventArgs e)
        {
            var zaznaczony = (ZawodnikVM)lbDane.SelectedItem;
           // MessageBox.Show(zaznaczony.Id.ToString());
            Szczegoly frmSzczegoly = new Szczegoly(zaznaczony, TrybOkienka.Edycja);
            frmSzczegoly.Show();
        }

        private void btnWykres_Click(object sender, RoutedEventArgs e)
        {
            Wykresy w = new Wykresy();
            w.Show();
        }
    }
}
