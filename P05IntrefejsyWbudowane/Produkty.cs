using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05IntrefejsyWbudowane
{
    class Produkty : IComparable
    {
        public string Nazwa;

        public int CompareTo(object obj)
        {
            return Nazwa.Length - ((Produkty)obj).Nazwa.Length;
            
        }
    }
}
