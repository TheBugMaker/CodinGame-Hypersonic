using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Path
    {
        public int items =0 ;
        public bool safeToBomb = true; 
        public LinkedList<Impact> road;
        public float score = 0; 
        public int maxHits = 0 ; 
        public int maxHitIndex = -1 ;

        public Path()
        {
            this.road = new LinkedList<Impact>(); 
        }

        public Path(LinkedList<Impact> road )
        {
            this.road = road;      
        }

        public Path(LinkedList<Impact> road , int items)
        {
            this.items = items ;
            this.road = road;
        }

        public Impact getLast()
        {
            return road.Last(); 
        }


        public Path AddPosition (Position p ){
            
            var im = new Impact(p) ;
            LinkedList<Impact> li = new LinkedList<Impact>(road);
            li.AddLast(im);

            Path path = new Path(li);
            path.score = score;
            var howSafe = Safety.IsItSafeToStand(p);
            if (Safety.isItSafeToBomb(p, p, Me.BombRange , 7 ))
            {
                

                var bonusSpeed = ( howSafe > 4 )? true : false   ;
                path.score += ((im.hits) * (3 + ((float)3 / (road.Count() + 1))));

                if (im.hits > maxHits || im.hits == maxHits && bonusSpeed )
                {
                    path.maxHits = im.hits  ;
                    path.maxHitIndex = road.Count();
                }
                else
                {
                    path.maxHits = maxHits;
                    path.maxHitIndex = maxHitIndex;
                }
            }

            if (Grid.isItem(p)) { path.score += ( (Me.numberOfBombs > 0 )? 3 : 9) ; } 
           
            
            var danger = (howSafe > 3) ? 1 : 100; 
            if (Safety.IsItSafeToStand(p) > 0)
            {
                path.score = (path.score - ((3 + ((float)road.Count() / (float)howSafe)) * danger));  
            }
            

            if (road.Count() > 0)
            {
                if (road.Last().p.Equals(p))
                {
                    path.score = path.score - (1 + (float)2 / road.Count());
                  
                }
                if(road.Count() > 1 ) {

                    if (road.Last.Previous.Value.p.Equals(p))
                        path.score = path.score - (1 + (float)2 / road.Count()); 
                }
            }
            
            path.safeToBomb = safeToBomb; 

            return path; 
        }
       
    }
}
