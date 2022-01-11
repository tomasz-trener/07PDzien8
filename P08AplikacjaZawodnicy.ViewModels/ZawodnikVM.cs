using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P08AplikacjaZawodnicy.ViewModels
{
    public class ZawodnikVM : ViewModelBase, INotifyPropertyChanged
    {
        public int? Id { get; set; }

        private string imie;

  
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

        string kraj;
        public string Kraj
        {
            get
            {
                return kraj;
            }
            set
            {
                kraj = value;
                OnPropertyChanged();
                // poinformuj innych o zmianie
            }
        }

        private DateTime? dataUrodzenia;

        public DateTime? DataUrodzenia
        {
            get
            {
                return dataUrodzenia;
            }
            set
            {
                dataUrodzenia = value;
                OnPropertyChanged();
                // poinformuj innych o zmianie
            }
        }

        private int? wzrost;
        public int? Wzrost {
            get
            {
                return wzrost;
            }
            set
            {
                wzrost = value;
                OnPropertyChanged();
                // poinformuj innych o zmianie
            }
        }

        private int? waga;
        public int? Waga
        {
            get
            {
                return waga;
            }
            set
            {
                waga = value;
                OnPropertyChanged();
                // poinformuj innych o zmianie
            }
        }

        public string PodstawoweDane {  get { return Imie + " " + Nazwisko + " " + Kraj; } }

        
    }
}
