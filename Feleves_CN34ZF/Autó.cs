using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Autó : Hirdetesek, IHirdetes
    {
        public Autó(string cím, double szélesség, double magasság)
            :base(cím, szélesség, magasság)
        {

        }

        public override string ToString()
        {
            return ($"[AUTÓ] Méretei: {Szélesség}x{Magasság} Címe: {Cím}");
        }
    }
}
