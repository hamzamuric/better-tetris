using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DTetris
{
    class O : Block
    {
        public O(Color c)
        {
            BlockColor = c;
            var (rootX, rootY) = RootPosition;
            Positions.Add(RootPosition);
            Positions.Add((rootX + 1, rootY));
            Positions.Add((rootX, rootY + 1));
            Positions.Add((rootX + 1, rootY + 1));
        }

        public override void rotate(Color[,] matrix)
        {
        }
    }
}
