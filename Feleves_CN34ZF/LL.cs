using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class ListItem
    {
        public Megrendelő Tartalom { get; set; }

        public ListItem Kovetkezo { get; set; }
    }
    public delegate void MegrendeloBeszurasHandler(string nev);
    public delegate void MegrendeloTorlesHandler(string nev);

    public delegate void MegrendeloKiszolgalasHandler(string nev);
    class LL : IEnumerable
    {
        public event MegrendeloBeszurasHandler MegrendeloBeszurasTortent;
        public event MegrendeloTorlesHandler MegrendeloTorlesTortent;

        public event MegrendeloKiszolgalasHandler MegrendeloKiszolgalva;
        public ListItem fej;
        public void ElemBeszuras(Megrendelő tartalom)
        {
            MegrendeloBeszurasTortent?.Invoke(tartalom.Nev);
            ListItem uj = new ListItem();
            uj.Tartalom = tartalom;
            uj.Kovetkezo = fej;
            fej = uj;
        }

        public void Torles(Megrendelő torlendo)
        {
            ListItem e = null;
            ListItem p = fej;

            while (p != null && p.Tartalom.GetHashCode() != torlendo.GetHashCode())
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
                MegrendeloTorlesTortent?.Invoke(torlendo.Nev);
            }
            else
            {
                throw new ArgumentException("Nincs ilyen elem.");

            }

        }

        public IEnumerator GetEnumerator()
        {
            return new ListaBe(fej);
        }
    }

}
