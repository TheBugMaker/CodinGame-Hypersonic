using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Brain
    {
        public static Impact SearchAround(Me me)
        {
            var s = new Sight();
            var im = new Impact(new Position(4, 5), -1);
            for (int i = 1; i < 8; i++)
            {

                foreach (var test in s.Arround(me.p, i))
                {
                    var newIm = new Impact(test);
                    if (newIm.hits > im.hits || im.hits == 0)
                    {
                        im = newIm;
                    }
                };
            }
            return im;
        }

        public static Path navigateDirs(Me me)
        {
            var w = new Walker(); 
            var pp = new Path().AddPosition(me.p) ; 
            return w.walk(pp, 6, 0);
        }
    }
}

