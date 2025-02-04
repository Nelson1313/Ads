using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves_CN34ZF
{
    interface IFelulet
    {
        double szélesség { get; }
        double magasság { get; }
        double terület { get; }
        FeluletEnum.FelületTípus Felulettype { get; }
    }
}
