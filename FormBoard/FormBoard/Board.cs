using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToee
{
    class Board
    {

        public int movesMade = 0;
        public int Owins = 0;
        public int Xwins = 0;

        private Piece[,] holders = new Piece[3, 3];

        public const int X = 0;
        public const int O = 1;
        public const int B = 2;

        public int playersTurn = X;

        public int getPlayerForTurn()
        {
            return playersTurn;
        }

        public int getOwins()
        {
            return Owins;
        }

        public int getXwins()
        {
            return Xwins;
        }

        public void initBoard()
        {
            //Location in the array for buttons in the form
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {

                    holders[x, y] = new Piece();
                    holders[x, y].SetValue(B);
                    holders[x, y].setLocation(new Point(x, y));
                }
            }
        }

        public void detectClick(Point locate)
        {
            int x = 0;
            int y = 0;

            //checks if click hits board
            if (locate.Y <= 500)
            {
                if (locate.X < 167)
                {
                    x = 0;
                }
                else if (locate.X > 167 && locate.X < 334)
                {
                    x = 1;
                }
                else if (locate.X > 334)
                {
                    x = 2;
                }
                if (locate.Y < 167)
                {
                    y = 0;
                }
                else if (locate.Y > 167 && locate.Y < 334)
                {
                    y = 1;
                }
                else if (locate.Y > 334 && locate.Y < 500)
                {
                    y = 2;
                }

                movesMade++;

                if (movesMade % 2 == 0)
                {
                    Grafix.DrawX(new Point(x,y));
                    holders[x, y].SetValue(X);
                    if (detectRow())
                    {
                        MessageBox.Show("You Have Won, X");
                        reset();
                        Xwins++;
                    }

                    playersTurn = O;
                }
                else
                {
                    Grafix.DrawO(new Point(x,y));
                    holders[x, y].SetValue(O);
                    if (detectRow())
                    {
                        MessageBox.Show("You Have Won, O");
                        reset();
                        Owins++;
                    }
                    playersTurn = X;
                }
            }

            // Felsöknings sak 
            //MessageBox.Show(x.ToString() + ", " + y.ToString() + "\n\n" + locate.ToString());  
        }

        public bool detectRow()
        {
            bool isWon = false;

            for (int x = 0; x < 3; x++)
            {
                if (holders[x, 0].GetValue() == X && holders[x, 1].GetValue() == X && holders[x, 2].GetValue() == X)
                {
                    return true;
                }

                if (holders[x, 0].GetValue() == O && holders[x, 1].GetValue() == O && holders[x, 2].GetValue() == O)
                {
                    return true;
                }
                //Detects diagonal lines
                switch (x)
                {
                    case 0:
                        if (holders[x,0].GetValue() == X && holders[x+1,1].GetValue() == X && holders[x+2,2].GetValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].GetValue() == O && holders[x + 1, 1].GetValue() == O && holders[x + 2, 2].GetValue() == O)
                        {
                            return true;
                        }
                    
                        break;

                    case 2: 
                        if (holders[x, 0].GetValue() == X && holders[x - 1, 1].GetValue() == X && holders[x - 2, 2].GetValue() == X)
                        {
                            return true;
                        }
                        if (holders[x, 0].GetValue() == O && holders[x - 1, 1].GetValue() == O && holders[x - 2, 2].GetValue() == O)
                        {
                            return true;
                        }

                        break;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                if (holders[0, y].GetValue() == X && holders[1, y].GetValue() == X && holders[2, y].GetValue() == X)
                {
                    return true;
                }

                if (holders[0, y].GetValue() == O && holders[1, y].GetValue() == O && holders[2, y].GetValue() == O)
                {
                    return true;
                }
            }

            return isWon;
        }

        public void reset()
        {
            holders = new Piece[3, 3];
            Grafix.setUpPlayfield();
            initBoard();
        }
    }
}
