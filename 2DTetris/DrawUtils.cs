using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2DTetris
{
    public static class DrawUtils
    {
        static int width = 20;
        static int height = 20;

        static Dictionary<Color, Brush> brushes = null;
        public static void MakeBrushes()
        {
            brushes = new Dictionary<Color, Brush>();
            brushes[Color.Red] = new TextureBrush(new Bitmap("blocks/red_block.bmp"));
            brushes[Color.Green] = new TextureBrush(new Bitmap("blocks/green_block.bmp"));
            brushes[Color.Blue] = new TextureBrush(new Bitmap("blocks/blue_block.bmp"));
            brushes[Color.Orange] = new TextureBrush(new Bitmap("blocks/orange_block.bmp"));
            brushes[Color.Gray] = new TextureBrush(new Bitmap("blocks/gray_block.bmp"));
        }

        public static void FillRect(Graphics g, Color c, int x, int y)
        {
            if (brushes == null) MakeBrushes();
            Brush b;
            if (!brushes.TryGetValue(c, out b))
            {
                b = new SolidBrush(c);
            }
            g.FillRectangle(b, new Rectangle(new Point(x * width, y * height), new Size(width, height)));
        }

        public static void DrawLine(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(x1 * width, y1 * height), new Point(x2 * width, y2 * height));
        }
    }
}
