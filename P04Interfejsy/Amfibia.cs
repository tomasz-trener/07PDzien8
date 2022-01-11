using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Interfejsy
{
    class Amfibia : IUmiejacyPlywac, IUmiejacyJezdzic
    {
        public void Jedz()
        {
            Console.WriteLine("jedzie amfibia");
        }

        public void Plyn()
        {
            Console.WriteLine("Plynie amfibia");
        }

        public void Holuj(IUmiejacyJezdzic innyPojazd)
        {
          //  innyPojazd.
        }

    }
}
