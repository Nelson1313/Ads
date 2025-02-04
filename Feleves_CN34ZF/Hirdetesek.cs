using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Hirdetesek : IComparable
    {
        string cím { get; }
        double szélesség { get; }
        double magasság { get; }
        
        public string Cím { get { return cím; } }
        public double Szélesség { get { return szélesség; } }
        public double Magasság { get { return magasság; } }
        public double Terület { get; }

        public Hirdetesek(string cím, double szélesség, double magasság)
        {
            this.cím = cím;
            this.szélesség = szélesség;
            this.magasság = magasság;
            Terület = szélesség * magasság;
        }

        public int CompareTo(object obj)
        {
            return (int)(obj as Hirdetesek).Terület;
        }
    }
}
