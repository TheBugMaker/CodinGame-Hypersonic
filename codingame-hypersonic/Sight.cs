using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codingame_hypersonic
{
    class Sight
    {
        public LinkedList<Position> Arround( Position p, int diametre)
        {
            var result = new LinkedList<Position>();

            for (int i = (p.x - diametre); i <= (diametre + p.x); i++)
            {
                var pTop = new Position(i, p.y + diametre);
                var pBot = new Position(i, p.y - diametre);
                if (Grid.getAt(pTop) == '.')
                {
                    result.AddLast(pTop);
                }
                if (Grid.getAt(pBot) == '.')
                {
                    result.AddLast(pBot);
                }
            }

            for (int i = (p.y - diametre) + 1; i < (diametre + p.y); i++)
            {
                var pTop = new Position(p.x + diametre, i);
                var pBot = new Position(p.x - diametre, i);
                if (Grid.getAt(pTop) == '.')
                {
                    result.AddLast(pTop);
                }
                if (Grid.getAt(pBot) == '.')
                {
                    result.AddLast(pBot);
                }
            }

            return result;

        }
    }
}
