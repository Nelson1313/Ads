using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class BiggerException : Exception
    {
        public BiggerException() : base("A megrendelő hirdetése nagyobb, mint a legnagyobb felület.")
        {

        }
    }
}
