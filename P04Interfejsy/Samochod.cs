using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Interfejsy
{
    class Samochod : IUmiejacyJezdzic
    {
        public void Jedz()
        {
            Console.WriteLine("jade");
        }
    }
}
