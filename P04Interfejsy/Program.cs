using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Interfejsy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IUmiejacyJezdzic> pojazy = new List<IUmiejacyJezdzic>();
            pojazy.Add(new Samochod());
            pojazy.Add(new Amfibia());

            foreach (var item in pojazy)
            {
                item.Jedz();
            }

            Kalkulator k = new Kalkulator();
            int wynik= k.Dodaj(3, 4, new MechanizmDodawania());



            Console.ReadKey();
        }
    }
}
