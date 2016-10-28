using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Position
    {
        public int x;
        public int y;
        public int data; 

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y; 
        }

        public Position(int x, int y  ,int duration)
        {
            this.data = duration;
            this.x = x;
            this.y = y;
        }

        public Position go(string dir, int steps)
        {
            switch (dir)
            {
                case "top": return new Position(x, y + steps);
                case "bot": return new Position(x, y - steps);
                case "left": return new Position(x-steps, y );
                case "right": return new Position(x + steps, y); 
            }

            return new Position(x, y); 
        }

        public override bool Equals(object obj)
        {
            
            return false; 
        }


        public  bool Equals(Position p )
        {     
            return p.x == this.x && this.y == p.y; 
        }


        public override int GetHashCode()
        {
            return x + (y*64);
        }

        public override string ToString()
        {
            return x + " " + y; 
        }


    }
}
