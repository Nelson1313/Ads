using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class NincsIlyenHirdetesVagyFeluletException : Exception
    {
        public NincsIlyenHirdetesVagyFeluletException() : base("Nincs ilyen hirdetés/felület a listában.")
        {

        }
    }
}
