using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Commander
    {
        public static Impact im = new Impact(new Position(100,100) , 0) ; 

        public static void setImpact (Impact newIm){
                im = newIm ; 
        }

        public static String DoAction(Path path , Me me )
        {
            var action = "MOVE ";
            Console.Error.WriteLine("Gonna Hit "+ path.maxHitIndex); 


            if (path.road.Count() < 2)
            {
                return "MOVE " + me.p + " I got Nothing !!"; 
            }
            var im = path.road.First(); 
            path.road.RemoveFirst();
            var im2 = path.road.First();
            var target = im2.p;
            if (path.maxHitIndex == 0 || ( path.maxHitIndex > -1 && path.road.ElementAt(path.maxHitIndex - 1 ).p.Equals(me.p)) )
            {
                action = "BOMB ";
                if (!Safety.isItSafeToBomb(im.p, im2.p, Me.BombRange, 5))
                {  
                    target = im.p;   
                }
            } 

           
            action = action  + target;
 
            return action  ; 
        }

    }
}
