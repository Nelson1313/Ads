using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class ListaBejaro<T> : IEnumerator<T>
    {
        ListaElem<T> fej;
        ListaElem<T> aktualis;

        public ListaBejaro(ListaElem<T> fej)
        {
            this.fej = fej;
            this.aktualis = new ListaElem<T>();
            this.aktualis.Kovetkezo = fej;
        }

        public object Current
        {
            get
            {
                return aktualis.Tartalom;
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return aktualis.Tartalom;
            }
        }

        public void Dispose()
        {

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
            aktualis = new ListaElem<T>();
            aktualis.Kovetkezo = fej;
        }
    }
}
