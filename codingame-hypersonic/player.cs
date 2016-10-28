using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Player 
    {
        public Position p ;
        public int numBomb ;
        public Bomb bomb; 

        public Player()
        {          
        }

        public Player(int x, int y , int p1)
        {
            p = new Position(x, y);
            numBomb = p1; 
        }

    }
}
