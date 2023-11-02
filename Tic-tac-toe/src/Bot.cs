using System;
using Borders;
using Squares;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace Main
{
    internal class Bot
    {
        public Point lastPoint;
        public void play(Border border)
        {

            Point initialPoint = new Point();
            
            while (true)
            {
                Point point = new Point((new Random().Next(0, 3)), (new Random().Next(0, 3)));
                if(border.isEmptySquare(point.X, point.Y))
                {
                    initialPoint.X = point.X;
                    initialPoint.Y = point.Y;

                    break;
                }
            }

            Square square = new Square(squareType.Circle);

            border.changeSquare(square, initialPoint.X, initialPoint.Y);

            lastPoint = initialPoint;
        }
    }
}
