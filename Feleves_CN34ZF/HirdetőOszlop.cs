using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class HirdetőOszlop : Felület, IFelulet
    {
        public FelületTípus tipus { get; }
        public FelületTípus Felulettype { get { return tipus; } }

        public HirdetőOszlop(double szélesség, double magasság, FelületTípus tipus) : base(szélesség, magasság)
        {
            this.tipus = tipus;
        }

        public override string ToString()
        {
            return ($"[HIRDETŐ-OSZLOP] Méretei: {szélesség}x{magasság}");
        }

        public string Cím()
        {
            return "HIRDETŐ OSZLOP";
        }
    }
}
