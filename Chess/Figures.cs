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
    internal class Pawn : Figure
    {
        public Pawn(string pawnColor)
        {
            color = pawnColor;
            type = "Pawn";
        }
    }

    internal class Rook : Figure
    {
        public Rook(string rookColor)
        {
            color = rookColor;
            type = "Rook";
        }
    }
}
