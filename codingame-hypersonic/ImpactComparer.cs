using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class ImpactComparer : IEqualityComparer<Impact>
    {


        public bool Equals(Impact x, Impact y)
        {
            return x.p.Equals(y.p); 
        }

        public int GetHashCode(Impact obj)
        {
            return obj.p.x + obj.p.y * 64; 
        }
    }
}
