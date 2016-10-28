using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Bomb
    {
        
        public Position p;
        public int duration;
        public int range; 
        public bool active = false;

        public Bomb(int duration)
        {
            this.duration = duration ; 
        }

        public Bomb(int x, int y, int duration, int range)
        {
            p = new Position(x, y);
            this.duration = duration;
            this.range = range;  
        }
 
    }
}
