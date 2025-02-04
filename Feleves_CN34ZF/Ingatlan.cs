using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Ingatlan : Hirdetesek, IHirdetes
    {
        public Ingatlan(string cím, double szélesség, double magasság)
            : base(cím, szélesség, magasság)
        {

        }

        public override string ToString()
        {
            return ($"[INGATLAN] Méretei: {Szélesség}x{Magasság}");
        }
    }
}
