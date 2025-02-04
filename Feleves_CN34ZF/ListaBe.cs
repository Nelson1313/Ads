using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class ListaBe : IEnumerator
    {
        ListItem fej;
        ListItem aktualis;
        public ListaBe(ListItem fej)
        {
            this.fej = fej;
            this.aktualis = new ListItem();
            this.aktualis.Kovetkezo = fej;
        }

        public object Current
        {
            get
            {
                return aktualis.Tartalom;
            }
        }

        public bool MoveNext()
        {
            if (aktualis == null)
            {
                return false;
            }
            aktualis = aktualis.Kovetkezo;
            return aktualis != null;
        }

        public void Reset()
        {
            aktualis = new ListItem();
            aktualis.Kovetkezo = fej;
        }
    }
}
