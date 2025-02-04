using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Bútorzat : Hirdetesek, IHirdetes
    {
        public Bútorzat(string cím, double szélesség, double magasság)
            : base(cím, szélesség, magasság)
        {

        }

        public override string ToString()
        {
            return ($"[BÚTORZAT] Méretei: {Szélesség}x{Magasság}");
        }
    }
}