using Newtonsoft.Json;
using P03AplikacjaZawodnicy.Domain;
using P03AplikacjaZawodnicy.Repositories;
using P03AplikacjaZawodnicy.Tools;
using P05Biblioteka;
using P08AplikacjaZawodnicy.ViewModels;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaZawodnicy.Operations
{
    public class ZawodnicyOperation
    {
        ZawodnicyRepository zawodnicyRepository = new ZawodnicyRepository();
        public ZawodnikVM[] PodajZawodnikow()
        {
            var zawodnicy = zawodnicyRepository.PodajZawodnikow();

            return zawodnicy.Select(x => new ZawodnikVM()
            {

                Id = x.id_zawodnika,
                Imie = x.imie,
                Nazwisko = x.nazwisko,
                Kraj = x.kraj,
                DataUrodzenia = x.data_ur,
                Waga = x.waga,
                Wzrost = x.wzrost
            }).ToArray();
        }

        public void DodajZawodnika(ZawodnikVM zv)
        {
            var z = KonwertujZawodnikVMnaZawodnik(zv);
            zawodnicyRepository.DodajZawodnika(z);
        }

        public ZawodnikVM PodajZawodnika(int id)
        {
            var x= zawodnicyRepository.PodajZawodnika(id);
            return new ZawodnikVM()
            {
                Id = x.id_zawodnika,
                Imie = x.imie,
                Nazwisko = x.nazwisko,
                Kraj = x.kraj,
                DataUrodzenia = x.data_ur,
                Waga = x.waga,
                Wzrost = x.wzrost
            };
        }

        public void EdytujZawodnika(ZawodnikVM zv)
        {
            var z = KonwertujZawodnikVMnaZawodnik(zv);
            zawodnicyRepository.EdytujZawodnika(z);
        }

        public void UsunZawodnika(ZawodnikVM zv)
        {
            var z = KonwertujZawodnikVMnaZawodnik(zv);
            zawodnicyRepository.UsunZawodnika(z.id_zawodnika);
        } 

        public ZawodnikVM[] WygenerujRaportPDF()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zaw =  zr.PodajZawodnikow();
            string[] linie = zaw.Select(x => x.imie + " " + x.nazwisko + " " + x.kraj).ToArray();
            PDFManager pm = new PDFManager();
            string sciezka= "HelloWorld.pdf";
            pm.WygenerujPDF(sciezka, linie);
            Process.Start(sciezka);

            return zaw.Select(x => new ZawodnikVM()
            {
                Id = x.id_zawodnika,
                Imie = x.imie,
                Nazwisko = x.nazwisko,
                Kraj = x.kraj
            }).ToArray();
        }

        public DaneWykresu WygenerujDaneDoWykresu()
        {
            var zawodnicy = zawodnicyRepository.PodajZawodnikow();
            var grupy =  zawodnicy
                .Where(x=>x.wzrost != null)
                .GroupBy(x => x.kraj)
                .Select(x => new { Kraj = x.Key, Wzrost = x.Average(y => y.wzrost) }).ToArray();

            DaneWykresu daneWykresu = new DaneWykresu();
            daneWykresu.X = grupy.Select(x => x.Kraj).ToArray();
            daneWykresu.Y = grupy.Select(x => (double)x.Wzrost).ToArray();
            return daneWykresu;
        }

        private Zawodnik KonwertujZawodnikVMnaZawodnik(ZawodnikVM zv)
        {
            Zawodnik z = new Zawodnik()
            {
                imie = zv.Imie,
                nazwisko = zv.Nazwisko,
                kraj = zv.Kraj,
                data_ur = zv.DataUrodzenia,
                waga = zv.Waga,
                wzrost = zv.Wzrost
            };

            if (zv.Id != null)
                z.id_zawodnika = (int)zv.Id;

            return z;
        }

        public void WyslijZawodnikaNaServer(ZawodnikVM z)
        {
            string jsonString = JsonConvert.SerializeObject(z);
            // KomunikacjaZServerem ks = new KomunikacjaZServerem();
            KomunikacjaZServerem.WyslijDane(jsonString);
        }

        
    }
}
