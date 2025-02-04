using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    interface IHirdetes
    {
        string Cím { get; }
        double Szélesség { get; }
        double Magasság { get; }
        double Terület { get; }
    }
}
