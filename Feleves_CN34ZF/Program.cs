using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class Program
    {
        static void Main(string[] args)
        {
            Felület közesz = new KözlekedésiEszköz(10, 20, FeluletEnum.FelületTípus.sima);
            Felület hiroszlop = new HirdetőOszlop(15, 25, FeluletEnum.FelületTípus.henger);
            Felület fenyuj = new Fényújság(20, 25, FeluletEnum.FelületTípus.sima);

            Hirdetesek[] tomb = new Hirdetesek[10];
            Hirdetesek[] tomb2 = new Hirdetesek[2];

            tomb[0] = new Autó("Kecskebéka út 25.", 20, 24);
            tomb[1] = new Autó("Kecskebéka út 20.", 15, 10);
            tomb[2] = new Autó("Kecskebéka út 21.", 10, 5);
            tomb2[0] = new Autó("Kecskebéka út 25.", 20, 24);
            tomb2[1] = new Autó("Kecskebéka út 20.", 15, 10);

            Megrendelő[] megrendelok = new Megrendelő[2];
            megrendelok[0] = new Megrendelő("Jóska Lajos", tomb);
            megrendelok[1] = new Megrendelő("Jóska Péter", tomb2);
            


            HirdetesKezelo hk = new HirdetesKezelo();
            hk.FeluletFelvetele(közesz);
            hk.FeluletFelvetele(hiroszlop);
            hk.FeluletFelvetele(fenyuj);


            Console.ReadKey();
        }
    }
}
