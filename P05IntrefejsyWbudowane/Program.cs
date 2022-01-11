using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05IntrefejsyWbudowane
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liczby = { 3, 6, 4, 3 };

            Array.Sort(liczby);

            Console.WriteLine(string.Join(" ",liczby));


            Produkty[] produkty =
            {
                new Produkty(){Nazwa="Krzeslo"},
                new Produkty(){Nazwa="Stół"},
                new Produkty(){Nazwa="Szafa"},
            };

            Array.Sort(produkty);

            foreach (var p in produkty)
            {
                Console.WriteLine(p.Nazwa);
            }

            Console.ReadKey();
        }
    }
}
