using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Fényújság : Felület
    {
        public FelületTípus tipus { get; }
        public FelületTípus Felulettype { get { return tipus; } }

        public Fényújság(double szélesség, double magasság, FelületTípus tipus) : base(szélesség, magasság)
        {
            this.tipus = tipus;
        }

        public override string ToString()
        {
            return ($"[FÉNYÚJSÁG] Méretei: {szélesség}x{magasság}");
        }

        public string Cím()
        {
            return "FÉNYÚJSÁG";
        }
    }
}
