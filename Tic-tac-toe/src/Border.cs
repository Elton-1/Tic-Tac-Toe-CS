using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Squares;

namespace Borders
{
  
    internal class Border
    {
        public const int row = 3;
        public const int col = 3;

        Square[,] squares = new Square[row, col];

        public void changeSquare(Square square, int x, int y) => squares[x, y] = square;

        public void resetSquare(int x, int y) => squares[x, y].resetType();

        public bool isEmptySquare(int x, int y) => squares[x, y] == null;

        public bool playerWon()
        {
            squareType player = squareType.Cross;
            return (verticalWin(player) || horizontalWin(player) || diagonalWin(player));
        }

        public bool botWon()
        {
            squareType bot = squareType.Circle;
            return (verticalWin(bot) || horizontalWin(bot) || diagonalWin(bot));
        }
        
        //if all the spaces have been ocypyed and none of the players havent won then its an draw
        public bool isDraw()
        {
            bool allSpacesOcypyed = true;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (squares[i, j] == null) allSpacesOcypyed = false;
                }
            }

            return !(!allSpacesOcypyed && !botWon() && !playerWon()); 
        }

        public void reset()
        {
            for(int i = 0; i < row; i++) 
            {
                for(int j = 0; j < col; j++)
                {
                    if (squares[i, j] != null) squares[i, j] = null;
                }
            }
        }

        //gets an type and checks if an row with the same type exists
        private bool horizontalWin(squareType type)
        {
            for (int i = 0; i < row; i++)
            {
                //check if any is empty
                if (!(this.isEmptySquare(i, col - col) || this.isEmptySquare(i, col - 2) || this.isEmptySquare(i, col - 1)))
                {
                    //if in the same row all of the squares are the type that we entered
                    if (squares[i, col - col].type == type && squares[i, col - (col - 2)].type == type && squares[i, col - (col - 1)].type == type)
                    {
                        return true;
                    }
                }


            }

            return false;
        }

        private bool verticalWin(squareType type)
        {
            for (int i = 0; i < col; i++)
            {
                //check if any is empty
                if (!(this.isEmptySquare(row - row, i) || this.isEmptySquare(row - (row - 2), i) || this.isEmptySquare(row - (row - 1), i)))
                {
                    if (squares[row - row, i].type == type && squares[row - (row - 2), i].type == type && squares[row - (row - 1), i].type == type)
                    {
                        return true;
                    }
                }

               
            }

            return false;
        }

        private bool diagonalWin(squareType type)
        {
            bool leftToRight = true;
            bool rightToLeft = true;
            for(int i = 0; i < row; i++) 
            {
                // left to right diagonal
                if(!(this.isEmptySquare(i, i))){
                    if (squares[i, i].type != type)
                    {
                        leftToRight = false;
                    }
                }
                else
                {
                    leftToRight = false;
                }

                //right to left diagonal
                if(!(this.isEmptySquare(i, col - (i + 1)))) {
                    if (squares[i, col - (i + 1)].type != type)
                    {
                        rightToLeft = false;
                    }
                }
                else
                {
                    rightToLeft = false;
                }
            }
            return rightToLeft || leftToRight;
        }

    }



}
