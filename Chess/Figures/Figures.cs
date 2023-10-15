using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Figure
    {
        public string color;
        public string type;
    }


    internal class Rook : Figure
    {
        public Rook(string rookColor)
        {
            color = rookColor;
            type = "Rook";
        }
    }

    internal class Bishop : Figure
    {
        public Bishop(string bishopColor)
        {
            color = bishopColor;
            type = "Bishop";
        }
    }

    internal class Queen : Figure
    {
        public Queen(string queenColor)
        {
            color = queenColor;
            type = "Queen";
        }
    }
    internal class King : Figure
    {
        public King(string kingColor)
        {
            color = kingColor;
            type = "King";
        }
    }

}
