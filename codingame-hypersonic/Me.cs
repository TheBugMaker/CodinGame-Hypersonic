using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Me : Player
    {
        public static int BombRange = 3; 
        public static int numberOfBombs = 1  ; 
        public Me()
        {

        }
        public Me(int x , int y , int p1) : base(x,y,p1)
        {

        }
    }
}
