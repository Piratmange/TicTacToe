using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToee
{
    class Grafix
    {
        private static Graphics gfxObject;

        public Grafix(Graphics gfx)
        {
            gfxObject = gfx;
            setUpPlayfield();
        }

        public static void setUpPlayfield()
        {
            Brush BackGround = new SolidBrush(Color.WhiteSmoke);
            Pen Lines = new Pen(Color.Black, 5);

            gfxObject.FillRectangle(BackGround, new Rectangle(0,0,500,600));

            //Drawing vertical lines
            gfxObject.DrawLine(Lines, new Point(167, 0), new Point(167, 500));
            gfxObject.DrawLine(Lines, new Point(334, 0), new Point(334, 500));

            //Drawing Horizontal lines
            gfxObject.DrawLine(Lines, new Point(0, 167), new Point(500, 167));
            gfxObject.DrawLine(Lines, new Point(0, 334), new Point(500, 334));
            gfxObject.DrawLine(Lines, new Point(0, 500), new Point(500, 500));
        }

        public static void DrawX(Point loc)
        {
            //Method for drawing X
            Pen xPen = new Pen(Color.Blue, 5);

            int xAbs = loc.X * 167;
            int yAbs = loc.Y * 167;

            gfxObject.DrawLine(xPen, xAbs + 10, yAbs + 10, xAbs + 157, yAbs + 157);
            gfxObject.DrawLine(xPen, xAbs + 157, yAbs + 10, xAbs + 10, yAbs + 157);
        }

        public static void DrawO(Point loc)
        {
            //Method for drawing O
            Pen oPen = new Pen(Color.Red, 5);

            int xAbs = loc.X * 167;
            int yAbs = loc.Y * 167;

            gfxObject.DrawEllipse(oPen, xAbs + 10, yAbs + 10 , 147, 147);
        }
    }
}
