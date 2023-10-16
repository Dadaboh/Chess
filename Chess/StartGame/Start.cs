using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    internal class Start
    {
        internal static string whoseMove = "White";
        internal static List<Button> cellsInMove = new List<Button>();
        internal static List<string> avaliableCells = new List<string>();

        List<string> history = new List<string>();

        #region FiguresCreations
        static Pawn whitePawn_1 = new Pawn("White");
        static Pawn whitePawn_2 = new Pawn("White");
        static Pawn whitePawn_3 = new Pawn("White");
        static Pawn whitePawn_4 = new Pawn("White");
        static Pawn whitePawn_5 = new Pawn("White");
        static Pawn whitePawn_6 = new Pawn("White");
        static Pawn whitePawn_7 = new Pawn("White");
        static Pawn whitePawn_8 = new Pawn("White");
        static Rook whiteRook_1 = new Rook("White");
        static Rook whiteRook_2 = new Rook("White");
        static Knight whiteKnight_1 = new Knight("White");
        static Knight whiteKnight_2 = new Knight("White");
        static Bishop whiteBishop_1 = new Bishop("White");
        static Bishop whiteBishop_2 = new Bishop("White");
        static Queen whiteQueen = new Queen("White");
        static King whiteKing = new King("White");

        static Pawn blackPawn_1 = new Pawn("Black");
        static Pawn blackPawn_2 = new Pawn("Black");
        static Pawn blackPawn_3 = new Pawn("Black");
        static Pawn blackPawn_4 = new Pawn("Black");
        static Pawn blackPawn_5 = new Pawn("Black");
        static Pawn blackPawn_6 = new Pawn("Black");
        static Pawn blackPawn_7 = new Pawn("Black");
        static Pawn blackPawn_8 = new Pawn("Black");
        static Rook blackRook_1 = new Rook("Black");
        static Rook blackRook_2 = new Rook("Black");
        static Knight blackKnight_1 = new Knight("Black");
        static Knight blackKnight_2 = new Knight("Black");
        static Bishop blackBishop_1 = new Bishop("Black");
        static Bishop blackBishop_2 = new Bishop("Black");
        static Queen blackQueen = new Queen("Black");
        static King blackKing = new King("Black");
        #endregion

        Dictionary<string, Figure> figuresArrangement = new Dictionary<string, Figure>()
        {
            { "A2" , whitePawn_1 },
            { "B2" , whitePawn_2 },
            { "C2" , whitePawn_3 },
            { "D2" , whitePawn_4 },
            { "E2" , whitePawn_5 },
            { "F2" , whitePawn_6 },
            { "G2" , whitePawn_7 },
            { "H2" , whitePawn_8 },
            { "A1" , whiteRook_1 },
            { "H1" , whiteRook_2 },
            { "B1" , whiteKnight_1 },
            { "G1" , whiteKnight_2 },
            { "C1" , whiteBishop_1 },
            { "F1" , whiteBishop_2 },
            { "D1" , whiteQueen },
            { "E1" , whiteKing },
            { "A7" , blackPawn_1 },
            { "B7" , blackPawn_2 },
            { "C7" , blackPawn_3 },
            { "D7" , blackPawn_4 },
            { "E7" , blackPawn_5 },
            { "F7" , blackPawn_6 },
            { "G7" , blackPawn_7 },
            { "H7" , blackPawn_8 },
            { "A8" , blackRook_1 },
            { "H8" , blackRook_2 },
            { "B8" , blackKnight_1 },
            { "G8" , blackKnight_2 },
            { "C8" , blackBishop_1 },
            { "F8" , blackBishop_2 },
            { "D8" , blackQueen },
            { "E8" , blackKing },
        };
        internal static void StartGame()
        {

        }
    }
}
