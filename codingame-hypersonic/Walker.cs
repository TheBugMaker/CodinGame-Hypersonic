using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Walker
    {
        public Path walk(Path result , int steps , int counter = 0 )
        {
            if (steps == 0)
            {
                return result;
            }
            var curPosition = result.getLast(); 
            counter++;
            steps--;
            var score = float.MinValue;
            Path p = result;
            float variation = 0; 
            bool change = false; 
            var safeToBomb = false ; 
            foreach (var d in new string[] { "top", "bot", "right", "left", "none" })
            {
                var nextP = curPosition.p.go(d, 1);
                var gonnaHurt = Safety.amIGonnaHurt(nextP, counter);

                if (Grid.isFree(nextP) || nextP.Equals(curPosition.p) )
                {
                    safeToBomb = true;
                    variation+= 0.1f ;  // more choices  
                    var path = walk(result.AddPosition(nextP), steps, counter);
                    if (path.score > score )
                    {   
                        change = true; 
                        score = path.score;
                        p = path; 
                    }
                }


            }
            p.score += variation; 
            p.safeToBomb = (p.safeToBomb == false)? false : safeToBomb; 
            return p; 
        }

    }
}
