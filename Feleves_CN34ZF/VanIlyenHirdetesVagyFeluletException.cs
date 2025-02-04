using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class VanIlyenHirdetesVagyFeluletException : Exception
    {
        public VanIlyenHirdetesVagyFeluletException() : base("Már van ilyen hirdetés/felület a listában.")
        {

        }
    }
}
