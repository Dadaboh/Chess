﻿namespace Chess
{
    internal class Piece
    {
        public string color;
        public int type;
    }

    internal class Pawn : Piece
    {
        public Pawn(string pawnColor)
        {
            color = pawnColor;
            type = (int) MyEnums.PiecesTypes.Pawn;
        }
    }

    internal class Rook : Piece
    {
        public bool isCastlingAvailable;

        public Rook(string rookColor)
        {
            isCastlingAvailable = true;
            color = rookColor;
            type = (int) MyEnums.PiecesTypes.Rook;
        }
    }
    internal class Knight : Piece
    {
        public Knight(string bishopColor)
        {
            color = bishopColor;
            type = (int) MyEnums.PiecesTypes.Knight;
        }
    }

    internal class Bishop : Piece
    {
        public Bishop(string bishopColor)
        {
            color = bishopColor;
            type = (int) MyEnums.PiecesTypes.Bishop;
        }
    }

    internal class Queen : Piece
    {
        public Queen(string queenColor)
        {
            color = queenColor;
            type = (int) MyEnums.PiecesTypes.Queen;
        } 
    }
    internal class King : Piece
    {
        public bool isCastlingAvailable;

        public King(string kingColor)
        {
            isCastlingAvailable = true;
            color = kingColor;
            type = (int) MyEnums.PiecesTypes.King;
        }
    }

}
