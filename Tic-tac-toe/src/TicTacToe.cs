using System;
using Borders;
using Squares;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main;

namespace Tic_tac_toe
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }

        //create an new board
        Border border = new Border();
        Bot bot = new Bot();

        //if that index is not ocypyed then add an Cross (Player)

        private void printBorderEmpty(Border border)
        {
            for (int i = 0; i < Border.row; i++)
            {
                for (int j = 0; j < Border.col; j++)
                {
                    updateButton(i, j, "");
                }
            }
        }

        private void updateButton(int x, int y, String text)
        {
            if (x == 0 && y == 0) button1.Text = text;
            else if (x == 0 && y == 1) button2.Text = text;
            else if (x == 0 && y == 2) button3.Text = text;
            else if (x == 1 && y == 0) button4.Text = text;
            else if (x == 1 && y == 1) button5.Text = text;
            else if (x == 1 && y == 2) button6.Text = text;
            else if (x == 2 && y == 0) button7.Text = text;
            else if (x == 2 && y == 1) button8.Text = text;
            else if (x == 2 && y == 2) button9.Text = text;
        }

        private void playBot(Bot bot)
        {
            bot.play(border);
            int X = bot.lastPoint.X;
            int Y = bot.lastPoint.Y;

            updateButton(X, Y, "O");

            if (border.botWon())
            {
                MessageBox.Show("You have lost!", "Better luck next time!");
                border.reset();
                printBorderEmpty(border);
            }
            else if (border.isDraw())
            {
                MessageBox.Show("its an Draw", "Draw");
                border.reset();
                printBorderEmpty(border);
            }
        }

        private void initiateButton(int x, int y)
        {
            Point buttonIndex = new Point(x, y);
            bool clickedBefore = false;
            if (border.isEmptySquare(buttonIndex.X, buttonIndex.Y))
            {
                Square square = new Square(squareType.Cross);
                border.changeSquare(square, buttonIndex.X, buttonIndex.Y);
                updateButton(buttonIndex.X, buttonIndex.Y, "X");
            }
            else
            {
                clickedBefore = true;
            }

            if (border.playerWon())
            {
                MessageBox.Show("You Won!", "Well done");
                border.reset();
                printBorderEmpty(border);
            }else if (border.isDraw())
            {
                MessageBox.Show("its an Draw", "Draw");
                border.reset();
                printBorderEmpty(border);
            }
            else
            {
                if(!clickedBefore) playBot(bot);
            }
        }

        private void button1_Click(object sender, EventArgs e) => initiateButton(0, 0);
        private void button2_Click(object sender, EventArgs e) => initiateButton(0, 1);
        private void button3_Click(object sender, EventArgs e) => initiateButton(0, 2);
        private void button4_Click(object sender, EventArgs e) => initiateButton(1, 0);
        private void button5_Click(object sender, EventArgs e) => initiateButton(1, 1);
        private void button6_Click(object sender, EventArgs e) => initiateButton(1, 2);
        private void button7_Click(object sender, EventArgs e) => initiateButton(2, 0);
        private void button8_Click(object sender, EventArgs e) => initiateButton(2, 1);
        private void button9_Click(object sender, EventArgs e) => initiateButton(2, 2);
        
    }
}
