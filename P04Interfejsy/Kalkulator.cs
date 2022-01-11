using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Interfejsy
{
    class Kalkulator
    {
        public int Dodaj(int a, int b, IUmijacyDodawac mechanizm )
        {
            return mechanizm.Dodaj(a, b);
        }
    }
}
