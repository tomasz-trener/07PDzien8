using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaZawodnicy.ViewModels
{
    public class ZawodnikVM : INotifyPropertyChanged
    {
        public int? Id { get; set; }

        private string imie;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Imie { 
            get 
            { 
                return imie;
            }

            set
            {
                imie = value;
                OnPropertyChanged();
                // poinformuj innych o zmianie
            }
        }

        private string nazwisko;

        public string Nazwisko {
            get
            {
                return nazwisko;
            }
            set
            {
                nazwisko = value;
                OnPropertyChanged();
                // poinformuj innych o zmianie
            }
        }
        public string Kraj { get; set; }

        public DateTime? DataUrodzenia { get; set; }

        public int? Wzrost { get; set; }
        public int? Waga { get; set; }

        public string PodstawoweDane {  get { return Imie + " " + Nazwisko + " " + Kraj; } }

        private void OnPropertyChanged([CallerMemberName]string name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
