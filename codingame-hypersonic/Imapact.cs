using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Impact
    {
        public Position p ;
        public int hits;
        public LinkedList<Position> destroyed = new LinkedList<Position>(); 
        public Impact(Position p)
        {
            this.p = p;
            this.hits = calcImpact(p,Me.BombRange, new HashSet<Position>());
        }


        public Impact(Position p, int hits )
        {
            this.p = p;
            this.hits = hits ;
        }

        public int calcImpact (Position p  , int range , HashSet<Position> visited ){ 
            int numBom = 0 ; 
            foreach(var d in new String[]{"top","bot","right","left"} ){
          
                var nextP = p.go(d,1) ;
                 

                for (int i = 0; i < (range -1 )  ; i++)
			    {
                    if (visited.Contains(nextP)) continue;
                    visited.Add(nextP);
                    if (Grid.isABox(nextP))
                    {
                        destroyed.AddLast(nextP);
                        numBom++;
                        break;
                    }
                    foreach (var b in Grid.boms)
                    {
                        if (nextP.Equals(b.p) && b.duration > 3 )
                        {   
                            Console.Error.WriteLine("\n\n inception for "+this.p + "\ninception at " +b.p+" \n"); 
                            numBom += calcImpact(b.p, b.range, visited); 
                        }
                    } 

                    if (!Grid.passExplosion(nextP))
                    {
                        break;
                    }
                    
                    nextP = nextP.go(d, 1); 
			    }

            } 
            return numBom; 
        }


        public override bool Equals(object obj)
        {

            return false;
        }


        public bool Equals(Impact im)
        {
            return im.p.x == this.p.x && this.p.y == im.p.y;
        }


        public override int GetHashCode()
        {
            Console.Error.WriteLine("AM BEING COLLED FOR" + p);
            return p.x + (p.y * 64);
        }

        public override string ToString()
        {
            return p + " hits "+ hits;
        }

    }



}
