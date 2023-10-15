using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;


namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static string WhoseMove = "White";
        internal static List<Button> CellsInMove = new List<Button>();
        internal static List<string> avaliableCells = new List<string>();
    
        List<string> History = new List<string>();

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

        Dictionary<string, Figure> FiguresArrangement = new Dictionary<string, Figure>()
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

        //Dictionary<string, Button> CellsInMove = new Dictionary<string, Button>();

        public MainWindow()
        {
            InitializeComponent();

            #region Content

            var WhiteChess = new Dictionary<string, string>()
            {
                { "Pawn"   , "\b\u2659" },
                { "Rook"   , "\u2656" },
                { "Knight" , "\u2658" },
                { "Bishop" , "\u2657" },
                { "Queen"  , "\u2655" },
                { "King"   , "\u2654" },
            };

            var BlackChess = new Dictionary<string, string>()
            {
                { "Pawn"   , "\u265F" },
                { "Rook"   , "\u265C" },
                { "Knight" , "\u265E" },
                { "Bishop" , "\u265D" },
                { "Queen"  , "\u265B" },
                { "King"   , "\u265A" },
            };

            A1.Content = WhiteChess["Rook"];
            B1.Content = WhiteChess["Knight"];
            C1.Content = WhiteChess["Bishop"];
            D1.Content = WhiteChess["Queen"];
            E1.Content = WhiteChess["King"];
            F1.Content = WhiteChess["Bishop"];
            G1.Content = WhiteChess["Knight"];
            H1.Content = WhiteChess["Rook"];

            A2.Content = WhiteChess["Pawn"];
            B2.Content = WhiteChess["Pawn"];
            C2.Content = WhiteChess["Pawn"];
            D2.Content = WhiteChess["Pawn"];
            E2.Content = WhiteChess["Pawn"];
            F2.Content = WhiteChess["Pawn"];
            G2.Content = WhiteChess["Pawn"];
            H2.Content = WhiteChess["Pawn"];

            A8.Content = BlackChess["Rook"];
            B8.Content = BlackChess["Knight"];
            C8.Content = BlackChess["Bishop"];
            D8.Content = BlackChess["Queen"];
            E8.Content = BlackChess["King"];
            F8.Content = BlackChess["Bishop"];
            G8.Content = BlackChess["Knight"];
            H8.Content = BlackChess["Rook"];

            A7.Content = BlackChess["Pawn"];
            B7.Content = BlackChess["Pawn"];
            C7.Content = BlackChess["Pawn"];
            D7.Content = BlackChess["Pawn"];
            E7.Content = BlackChess["Pawn"];
            F7.Content = BlackChess["Pawn"];
            G7.Content = BlackChess["Pawn"];
            H7.Content = BlackChess["Pawn"];
            #endregion
        }

        #region Cells
        private void A1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void A8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(A8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(B8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void C8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(C8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void D8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(D8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void E8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(E8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void F8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(F8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void G8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(G8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H1_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H1, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H2_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H2, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H3_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H3, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H4_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H4, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H5_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H5, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H6_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H6, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H7_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H7, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }

        private void H8_Click(object sender, RoutedEventArgs e)
        {
            Move.MoveFigure(H8, DEB, ref FiguresArrangement, ref avaliableCells, ref CellsInMove, ref WhoseMove);
        }
        #endregion 

    }
}
