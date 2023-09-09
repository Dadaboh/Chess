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
    }
    internal class Pawn : Figure
    {
        public Pawn(string pawnColor)
        {
            color = pawnColor;
        }
    }
}
