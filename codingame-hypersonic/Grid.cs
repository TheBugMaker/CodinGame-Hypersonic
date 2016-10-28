using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Grid
    {
        public static char [,]g ;
        public static LinkedList<Bomb> boms = new LinkedList<Bomb>() ; 
        public static void setGrid(int height , int width)
        {
            g = new char[width, height]; 
        }

        public static char getAt(int x, int y)
        {
            if (x < 0 || x >= g.GetLength(0)) return 'o';
            if (y < 0 || y >= g.GetLength(1)) return 'o';

            return g[x, y];
        }
        public static  char getAt(Position p )
        {
            if (p.x < 0 || p.x >= g.GetLength(0)) return 'o';
            if (p.y < 0 || p.y >= g.GetLength(1)) return 'o';

            return g[p.x, p.y];
        }
        public static void setAt(Position p , char marker = '.' )
        {
            if (p.x < 0 || p.x >= g.GetLength(0)) return ;
            if (p.y < 0 || p.y >= g.GetLength(1)) return ;

            g[p.x, p.y] = marker ;
        }

        public static bool isABox(Position p)
        {
            var x = p.x;
            var y = p.y; 
            if (x < 0 || x >= g.GetLength(0)) return false;
            if (y < 0 || y >= g.GetLength(1)) return false ;


            int i = 0;
            var r = int.TryParse(g[x, y] + "", out i); 
            return r ;
        }


        public static void ApplyExplosions(LinkedList<Impact> ims)
        {
            foreach (var im in ims)
            {
                foreach (var p in im.destroyed)
                {
                    setAt(p, 'd'); 
                }
            }
        }

        public static bool isFree(Position p)
        {   
            var val = getAt(p) ; 
            return val == '.' || val == 't' || val == 'v' ; 
        }

        public static bool passExplosion(Position p)
        {
            var val = getAt(p);
            return val == '.'  ;
        }

        public static void ApplyItems(LinkedList<Item> its)
        {
            foreach (var i in its)
                setAt(i.p, 't'); 
        }
        public static bool isItem(Position p)
        {
            var val = getAt(p);
            return  val == 't'; 
        }

        public static void SetVirtual(Position p)
        {
            setAt(p, 'v');  
        }


        public static void ApplyBomPositions(LinkedList<Bomb> bombs)
        {
            foreach (var b in bombs)
            {
                setAt(b.p, 'b'); 
            }
        }
    }
}
