using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    public class ListaElem<T>
    {
        public T Tartalom { get; set; }

        public ListaElem<T> Kovetkezo { get; set; }
    }

    public delegate void HirdetesBeszurasHandler(string cím, double terulet);
    public delegate void HirdetesTorlesHandler(string cim);

    public delegate void FeluletBeszurasHandler(double terulet, string cím);
    public delegate void FeluletTorlesHandler(string cim);


    class LáncoltLista<T> : IEnumerable where T : IComparable
    {
        public delegate bool SzuroDelegalt(T adott);
        public delegate void BejaroDelegalt(T adott);

        public ListaElem<T> fej;
        private int db = 0;
        public event HirdetesBeszurasHandler HirdetesBeszurasTortent;
        public event HirdetesTorlesHandler HirdetesTorlesTortent;

        public event FeluletBeszurasHandler FeluletBeszurasTortent;
        public event FeluletTorlesHandler FeluletTorlesTortent;


        public void Beszuras(T adott)
        {
            ListaElem<T> uj = new ListaElem<T>();
            uj.Tartalom = adott;

            ListaElem<T> p = fej;
            ListaElem<T> e = null;
            HirdetesBeszurasTortent?.Invoke(adott.ToString(), (adott as Hirdetesek).Terület);
            FeluletBeszurasTortent?.Invoke((adott as Felület).terület, adott.ToString());

            while (p != null && p.Tartalom.CompareTo(p.Tartalom) > adott.CompareTo(adott))
            {
                e = p;
                p = p.Kovetkezo;
            }

            if (e == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                uj.Kovetkezo = p;
                e.Kovetkezo = uj;
            }
            db++;
        }

        public T Kereses(T keresendo)
        {
            ListaElem<T> p = fej;
            while (p != null && !(p.Tartalom.Equals(keresendo)))
            {
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                return p.Tartalom;
            }
            else
            {
                throw new NincsIlyenHirdetesVagyFeluletException();
            }
        }

        public void Torles(T torlendo)
        {
            ListaElem<T> p = fej;
            ListaElem<T> e = null;

            while (p != null && !(p.Tartalom.GetHashCode() != torlendo.GetHashCode()))
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                if (e == null)
                {
                    fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                throw new NincsIlyenHirdetesVagyFeluletException();
            }
            HirdetesTorlesTortent?.Invoke(torlendo.ToString());
            FeluletTorlesTortent?.Invoke(torlendo.ToString());
            db--;
        }

        public T KovetkezoMegrendeles(T tartalom)
        {
            ListaElem<T> p = fej;
            ListaElem<T> e = null;
            //ListaElem<T> aktualis = null;
            while (p != null && p.Tartalom.GetHashCode() != tartalom.GetHashCode())
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                return p.Kovetkezo.Tartalom;
            }
            else
            {
                throw new NincsIlyenHirdetesVagyFeluletException();
            }
        }

        public bool VanEKovetkezo(int kod)
        {
            bool eredmeny = false;
            ListaElem<T> p = fej;
            ListaElem<T> e = null;

            while (p != null && p.Tartalom.GetHashCode() != kod)
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                if (p.Kovetkezo != null)
                {
                    eredmeny = true;
                }
            }
            return eredmeny;
        }

        public bool VanEMegMegrendeles()
        {
            if (fej != null)
            {
                return true;
            }
            return false;
        }

        public T MegrendelesKivetele()
        {
            if (fej == null)
            {
                return default(T);
            }
            return fej.Tartalom;
        }
        public IEnumerator GetEnumerator()
        {
            return new ListaBejaro<T>(fej);
        }
    }
}
