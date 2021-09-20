using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTetris
{
    class I : Block
    {
        public I(Color c)
        {
            BlockColor = c;
            var (rootX, rootY) = RootPosition;
            for (int i = 0; i < 4; i++)
            {
                Positions.Add((rootX + i, rootY));
            }
        }


        // x               x
        // x               x
        // x  x x x x  x x x x
        // x               x
        public override void rotate(Color[,] matrix)
        {
            var (x1, y1) = Positions[0];
            var (x2, y2) = Positions[1];
            var (x3, y3) = Positions[2];
            var (x4, y4) = Positions[3];

            try
            {
                if (y1 < y2 && matrix[y3, x1 - 2] == Color.White && matrix[y3, x2 - 1] == Color.White && matrix[y3, x4 + 1] == Color.White)
                {
                    Positions = new List<(int, int)>
                    {
                        (x1 - 2, y3), (x2 - 1, y3), (x3, y3), (x4 + 1, y3)
                    };
                }
                else if (x1 < x2 && matrix[y1 - 2, x3] == Color.White && matrix[y2 - 1, x3] == Color.White && matrix[y4 + 1, x3] == Color.White)
                {
                    Positions = new List<(int, int)>
                    {
                        (x3, y1 - 2), (x3, y2 - 1), (x3, y3), (x3, y4 + 1)
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
