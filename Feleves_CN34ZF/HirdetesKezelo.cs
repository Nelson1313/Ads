using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{

    class HirdetesKezelo
    {
        public static void MegrendelesTeljesites()
        {
            Console.WriteLine("[MEGRENDELÉS TELJESÍTVE]");
        }
        public void HirdetesFelvetel(string cím, double terulet)
        {
            Console.WriteLine($"[HIRDETÉS FELVÉTEL TÖRTÉNT] Típusa: {cím}");
        }

        public void HirdetesTorles(string cím)
        {
            Console.WriteLine($"[HIRDETÉS TÖRLÉS TÖRTÉNT] Címe: {cím}");
        }

        public void MegrendeloFelvetel(string nev)
        {
            Console.WriteLine($"[MEGRENDELŐ FELVÉTEL TÖRTÉNT] Neve: {nev}");
        }

        public void FeluletFelvetel(double terulet, string cím)
        {
            Console.WriteLine($"[FELÜLET FELVÉTEL TÖRTÉNT] Területe: {terulet} \t Típusa: {cím}");
        }


        public void MegrendeloTorles(string nev)
        {
            Console.WriteLine($"[MEGRENDELŐ TÖRLÉS TÖRTÉNT] Neve: {nev}");
        }

        public void FeluletTorles(string cím)
        {
            Console.WriteLine($"[FELÜLET TÖRLÉS TÖRTÉNT] Címe: {cím}");
        }
        LáncoltLista<Felület> feluletek = new LáncoltLista<Felület>();
        LáncoltLista<Hirdetesek> hirdetesek = new LáncoltLista<Hirdetesek>();
        LL megrendelok = new LL();

        private void _HirdetesFelvetele(Hirdetesek hirdetes)
        {
            hirdetesek.HirdetesBeszurasTortent += HirdetesFelvetel;
            foreach (Felület felület in feluletek)
            {
                if (hirdetes.Terület < felület.terület)
                {
                    hirdetesek.Beszuras(hirdetes);
                }
                else
                {
                    throw new BiggerException();
                }
            }
            hirdetesek.HirdetesBeszurasTortent -= HirdetesFelvetel;
        }

        public void HirdetesFelvetel(Hirdetesek hirdetes)
        {
            try
            {
                _HirdetesFelvetele(hirdetes);
            }
            catch (BiggerException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void HirdetesTorlese(Hirdetesek hirdetes)
        {
            hirdetesek.HirdetesTorlesTortent += HirdetesTorles;
            hirdetesek.Torles(hirdetes);
            hirdetesek.HirdetesTorlesTortent -= HirdetesTorles;
        }

        public void FeluletFelvetele(Felület felulet)
        {
            feluletek.FeluletBeszurasTortent += FeluletFelvetel;
            feluletek.Beszuras(felulet);
            feluletek.FeluletBeszurasTortent -= FeluletFelvetel;
        }

        public void FeluletTorlese(Felület felulet)
        {
            feluletek.FeluletTorlesTortent += FeluletTorles;
            feluletek.Beszuras(felulet);
            feluletek.FeluletTorlesTortent -= FeluletTorles;
        }

        private void MegrendeloFelvetele(Megrendelő[] megrendelo)
        {
            megrendelok.MegrendeloBeszurasTortent += MegrendeloFelvetel;
            for (int i = 0; i < megrendelo.Length; i++)
            {
                megrendelok.ElemBeszuras(megrendelo[i]);
            }
            megrendelok.MegrendeloBeszurasTortent -= MegrendeloFelvetel;
        }

        private void MegrendeloTorlese(Megrendelő torlendo)
        {
            megrendelok.MegrendeloTorlesTortent += MegrendeloTorles;
            megrendelok.Torles(torlendo);
            megrendelok.MegrendeloTorlesTortent -= MegrendeloTorles;
        }


        public delegate void MegrendelesTeljesitveHandler();
        public event MegrendelesTeljesitveHandler MegrendelesTeljesítve;

        private void _MegrendelesKezelo()
        {
            foreach (Megrendelő item in megrendelok)
            {
                int i = 0;
                while (i <= 10 && item.hirdetések[i] != null)
                {
                    hirdetesek.Beszuras(item.hirdetések[i]);
                    item.hirdetések[i] = null;
                    i++;
                }
                int j = 0;
                foreach (Felület felulet in feluletek)
                {
                    if (felulet.terület > 0 && hirdetesek.VanEMegMegrendeles())
                    {
                        Hirdetesek hirdetes = this.hirdetesek.MegrendelesKivetele();
                        bool van = true;
                        while (van)
                        {
                            double tomeg = (hirdetes as IHirdetes).Terület;
                            if ((felulet.terület - hirdetes.Terület) >= 0)
                            { 
                                Console.WriteLine(hirdetes.ToString());
                                felulet.terület -= hirdetes.Terület;
                                item.hirdetések[j] = hirdetes;
                                this.hirdetesek.Torles(hirdetes);
                                j++;
                            }
                            else if (felulet.terület > 0 && !(this.hirdetesek.fej is null))
                            {
                                hirdetes = this.hirdetesek.KovetkezoMegrendeles(hirdetes);
                            }
                            if (this.hirdetesek.fej is null)
                            {
                                van = false;
                            }
                        }
                    }
                }
                if (this.hirdetesek.fej is null)
                {
                    MegrendelesTeljesítve?.Invoke();
                }
            }
        }

        public void MegrendelesKezelo(Megrendelő[] kezelok)
        {

            MegrendeloFelvetele(kezelok);
            MegrendelesTeljesítve += MegrendelesTeljesites;
            _MegrendelesKezelo();
            MegrendelesTeljesítve -= MegrendelesTeljesites;
        }
    }
}
