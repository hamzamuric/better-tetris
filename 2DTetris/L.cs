using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DTetris
{
    class L : Block
    {
        private int rotation = 0;

        public L(Color c)
        {
            BlockColor = c;
            var (rootX, rootY) = RootPosition;
            for (int i = 0; i < 3; i++)
            {
                Positions.Add((rootX + i, rootY + 1));
            }
            Positions.Add((rootX + 2, rootY));
        }

        //              x    
        // x x x      x x x 
        // x x x      x x x
        //   x         
        //                    
        public override void rotate(Color[,] matrix)
        {
            var (x1, y1) = Positions[0];
            var (x2, y2) = Positions[1];
            var (x3, y3) = Positions[2];
            var (x4, y4) = Positions[3];

            try
            {
                if (rotation == 0 && matrix[y1 - 1, x1 + 1] == Color.White && matrix[y3 + 1, x3 - 1] == Color.White && matrix[y4 + 2, x4] == Color.White)
                {
                    Positions = new List<(int, int)>
                    {
                        (x1 + 1, y1 - 1), (x2, y2), (x3 - 1, y3 + 1), (x4, y4 + 2)
                    };
                    rotation = 1;
                }
                else if (rotation == 1 && matrix[y1 + 1, x1 + 1] == Color.White && matrix[y3 - 1, x3 - 1] == Color.White && matrix[y4, x4 - 2] == Color.White)
                {
                    Positions = new List<(int, int)>
                    {
                        (x1 + 1, y1 + 1), (x2, y2), (x3 - 1, y3 - 1), (x4 - 2, y4)
                    };
                    rotation = 2;
                }
                else if (rotation == 2 && matrix[y1 + 1, x1 - 1] == Color.White && matrix[y3 - 1, x3 + 1] == Color.White && matrix[y4 - 2, x4] == Color.White)
                {
                    Positions = new List<(int, int)>
                    {
                        (x1 - 1, y1 + 1), (x2, y2), (x3 + 1, y3 - 1), (x4, y4 - 2)
                    };
                    rotation = 3;
                }
                else if (rotation == 3 && matrix[y1 - 1, x1 - 1] == Color.White && matrix[y3 + 1, x3 + 1] == Color.White && matrix[y4, x4 + 2] == Color.White)
                {
                    Positions = new List<(int, int)>
                    {
                        (x1 - 1, y1 - 1), (x2, y2), (x3 + 1, y3 + 1), (x4 + 2, y4)
                    };
                    rotation = 0;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                // can not rotate
            }
        }
    }
}
