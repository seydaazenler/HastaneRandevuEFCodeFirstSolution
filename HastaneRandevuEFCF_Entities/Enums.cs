using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuEFCF_Entities
{
    public class Enums
    {
        public int TheKey { get; set; }
        public string TheValue { get; set; }
    }
    public enum Branslar:Byte
    {
        BransYok,
        Dahiliye,
        KBB,
        GozHastaliklari,
        Ortopedi,
        Kardiyoloji
        
    }
}
