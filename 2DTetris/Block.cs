using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTetris
{
    abstract class Block
    {
        public Color BlockColor { get; set; }
        public List<(int, int)> Positions { get; set; } = new List<(int, int)>();

        public static List<Block> Blocks = new List<Block>();
        
        public static (int, int) RootPosition = (4, 0);

        public void Draw(Graphics g)
        {
            foreach (var (x, y) in Positions)
            {
                DrawUtils.FillRect(g, BlockColor, x, y);
            }
        }

        public abstract void rotate(Color[,] matrix);
    }
}
