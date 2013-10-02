using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToee
{
    class Piece
    {
        private Point location;
        private int Value = Board.B;

        public void setLocation(Point p)
        {
            location = p;
        }
        public Point getLocation()
        {
            return location;
        }

        public void SetValue(int i)
        {
            Value = i;
        }
        public int GetValue()
        {
            return Value;
        }
    }
}

