using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Safety
    {
        public static HashSet<Position> MapOfDestruction;
        public static bool calibrateExplosionChaine()
        {
           
            var done = true ; 
            foreach(var b in Grid.boms )
            { 
                var i = IsItSafeToStand(b.p);
                if (i > 0 && i < b.duration )
                {
                    b.duration = i;
                    done = false; 
                }
               
            }
          
            return done; 
        }
        public static void SetMapOfDestruction(){
            MapOfDestruction = new HashSet<Position>(new PositionComparer() ); 
            foreach (var b in Grid.boms)
            {
                if(b.duration > 1 )
                foreach (var d in new String[] { "top", "bot", "right", "left" })
                {
                    var nextP = b.p.go(d, 1);
                    for (int i = 0; i < (b.range-1); i++)
                    {
                         
                        if (!Grid.passExplosion(nextP))
                        {
                            break;
                        }
                        nextP.data = b.duration;
                        if (MapOfDestruction.Contains(nextP))
                        {
                            var k = MapOfDestruction.First(dp => dp.Equals(nextP)) ;
                            if (k.data > nextP.data)
                            {
                                MapOfDestruction.Remove(k); 
                                MapOfDestruction.Add(nextP); 
                            }
                        }
                        else {
                            MapOfDestruction.Add(nextP); 
                        }

                        nextP = nextP.go(d, 1);
                    }

                }


            }
          
        }

        public static bool amIGonnaHurt(Position p, int time)
        {
         
            foreach (var b in Grid.boms)
            {
                if (b.duration - time == 1)
                {
                   
                    foreach (var d in new String[] { "top", "bot", "right", "left" })
                    {
                        var nextP = b.p.go(d, 1);
                        for (int i = 0; i < (b.range - 1); i++)
                        {
                            if (nextP.Equals(p))
                            {
                                return true;
                            }
                            else
                            {
                                if (!Grid.passExplosion(nextP))
                                {
                                    break;
                                }
                            }
                            nextP = nextP.go(d, 1);
                        }

                    }
                }

            }
            return false; 
        }
        public static int IsItSafeToStand(Position p)
        {
            if (MapOfDestruction.Contains(p))
            {
                return MapOfDestruction.First(dp => dp.Equals(p) ).data;
            }
            else
            {
                return -1; 
            }
            
        }

        public static bool isItSafeToBomb(Position bomb, Position me , int range , int steps)
        {   
            var explode  = IsItSafeToStand(bomb)  ;
            if (explode > 0 &&  explode < 4 ) return false; 

             
                if (bomb.x != me.x && bomb.y != me.y  )
                {
                    return true; 
                }

                if (Math.Abs(bomb.x - me.x) >= range)
                {
                    return true; 
                }
            
                if (Math.Abs(bomb.y - me.y) >= range)
                {
                    return true;
                }
           
            if (steps == 0)
            {
                return false; 
            }
            steps -- ; 

            foreach (var d in new String[] { "top", "bot", "right", "left" })
            {
                var nextP = me.go(d, 1);
                if (Grid.isFree(nextP) && !nextP.Equals(bomb) )
                {
                    if (isItSafeToBomb(bomb, nextP, range, steps))
                    {
                        return true; 
                    } 
                }

            }

            return false; 
        }
    }
}
