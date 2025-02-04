using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Megrendelő : IComparable
    {

        public Hirdetesek[] hirdetések { get; }
        public string Nev { get; }
        public Megrendelő(string nev, Hirdetesek[] hirdetések)
        {
            this.hirdetések = hirdetések;
            //for (int i = 0; i < hirdetések.Length; i++)
            //{
            //    this.hirdetések[i] = hirdetések[i];
            //}
            this.Nev = nev;
            if (hirdetések.Length > 10)
            {
                throw new LotsofAdsException();
            }
        }

        public override string ToString()
        {
            return Nev;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
