using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    class LotsofAdsException : Exception
    {
        public LotsofAdsException() : base("Túl sok megrendelés érkezett.")
        {

        }
    }
}
