using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToee
{
    public partial class Form1 : Form
    {
        Grafix engine;
        Board theBoard;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics pass = panel1.CreateGraphics();
            engine = new Grafix(pass);

            theBoard = new Board();
            theBoard.initBoard();

            RefreshLabel();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            theBoard.detectClick(mouse);
            RefreshLabel();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            theBoard.reset();
            Grafix.setUpPlayfield();
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe");
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void RefreshLabel()
        {
            String newText = "It is ";
            if (theBoard.getPlayerForTurn() == Board.X)
            {
                newText += "X";
            }
            else
            {
                newText += "O";
            }
            newText += "'s Turn\n";
            newText += "'X has won " + theBoard.getXwins() + " times. \nO has won " + theBoard.getOwins() + " times.";

            label1.Text = newText;
        }

    }
}
