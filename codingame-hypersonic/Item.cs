using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Item
    {
        public Position p;
        public int type;
        public Item(Position p , int type )
        {
            this.p = p;
            this.type = type; 
        }
    }
}
