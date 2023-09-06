using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class CageId
    {
        public string Id { get; }
        public CageId(string horizontal, int vertical)
        {
            Id = $"{horizontal + vertical}";
        }
    }
    internal class Cage
    {
        public CageId cageid;
        public Figure figure;
        public bool access;
    }

    internal class Figure
    {
        public string cage;
    }
    internal class Pawn : Figure
    {

    }
}
