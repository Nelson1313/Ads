using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    abstract class Felület : FeluletEnum, IComparable
    {

        public double szélesség { get; set; }
        public double magasság { get; set; }
        public double terület { get; set; }

        public LáncoltLista<Hirdetesek> hirdetesek = new LáncoltLista<Hirdetesek>();

        public FelületTípus felulettipus { get; }

        //public Felület(FelületTípus vmi)
        //{
        //    this.szélesség = szélesség;
        //    this.magasság = magasság;
        //}

        public Felület(double szélesség, double magasság)
        {
            this.szélesség = szélesség;
            this.magasság = magasság;
            terület = szélesség * magasság;
        }

        public int CompareTo(object obj)
        {
            return (int)(obj as Felület).terület;
        }
    }
}
