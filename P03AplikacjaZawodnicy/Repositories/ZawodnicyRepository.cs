using P03AplikacjaZawodnicy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaZawodnicy.Repositories
{
    class ZawodnicyRepository
    {
        public Zawodnik[] PodajZawodnikow()
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            Zawodnik[] zawodnicy = db.Zawodnik.ToArray();
            return zawodnicy;
        }
        public void DodajZawodnika(Zawodnik z)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            db.Zawodnik.InsertOnSubmit(z);
            db.SubmitChanges();
        }

        public void EdytujZawodnika(Zawodnik z)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            var doEdycji = db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == z.id_zawodnika);

            doEdycji.imie = z.imie;
            doEdycji.nazwisko = z.nazwisko;
            doEdycji.kraj = z.kraj;
            doEdycji.data_ur = z.data_ur;
            doEdycji.wzrost = z.wzrost;
            doEdycji.waga = z.waga;

            db.SubmitChanges();
        }

        public void UsunZawodnika(int id)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            var doUsuniecia = db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == id);
            db.Zawodnik.DeleteOnSubmit(doUsuniecia);
            db.SubmitChanges();
        }

        public Zawodnik PodajZawodnika(int id)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            return db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == id);
        }
    }
}
