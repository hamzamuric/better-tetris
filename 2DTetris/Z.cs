using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DTetris
{
    class Z : Block
    {
        public Z(Color c)
        {
            BlockColor = c;
            var (rootX, rootY) = RootPosition;
            Positions.Add(RootPosition);
            Positions.Add((rootX + 1, rootY));
            Positions.Add((rootX + 1, rootY + 1));
            Positions.Add((rootX + 2, rootY + 1));
        }

        // xx       x
        //  xx     xx
        //         x 

        public override void rotate(Color[,] matrix)
        {
            var (x1, y1) = Positions[0];
            var (x2, y2) = Positions[1];
            var (x3, y3) = Positions[2];

            try
            {
                if (x1 < x2 && matrix[y3, x3 - 1] == Color.White && matrix[y3 + 1, x3 - 1] == Color.White)
                {
                    Positions = new List<(int, int)>
                {
                    (x2, y2), (x3, y3), (x3 - 1, y3), (x3 - 1, y3 + 1)
                };
                }
                else if (y1 < y2)
                {
                    Positions = new List<(int, int)>
                {
                    (x1 - 1, y1), (x1, y1), (x2, y2), (x2 + 1, y2)
                };
                }
            }
            catch (IndexOutOfRangeException e)
            {
                // can not rotate
            }
        }
    }
}
