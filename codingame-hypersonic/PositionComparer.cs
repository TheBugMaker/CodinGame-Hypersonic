using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class PositionComparer : IEqualityComparer<Position>
    {
        public bool Equals(Position x, Position y)
        {
            return x.Equals(y); 
        }

        public int GetHashCode(Position obj)
        {
            return obj.x + obj.y * 64; 
        }
    }
}
