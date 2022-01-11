using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Interfejsy
{
    class MechanizmDodawania : IUmijacyDodawac
    {
        public int Dodaj(int a, int b)
        {
            return a + b;
        }
    }
}
