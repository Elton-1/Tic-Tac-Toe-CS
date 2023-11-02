using System;
using System.Runtime.CompilerServices;

enum squareType
{
    Circle,
    Cross,
}

namespace Squares
{
    internal class Square
    {
        public squareType? type { get; set; }

        public Square(squareType type)
        {
            this.type = type;
        }

        public void resetType() { this.type = null; }

        public void setType(squareType type) {  this.type = type; }

    }
}
