using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int movenum = 0;

        static Pawn whitePawn_1 = new Pawn("white");
        static Pawn whitePawn_2 = new Pawn("white");
        static Pawn whitePawn_3 = new Pawn("white");
        static Pawn whitePawn_4 = new Pawn("white");
        static Pawn whitePawn_5 = new Pawn("white");
        static Pawn whitePawn_6 = new Pawn("white");
        static Pawn whitePawn_7 = new Pawn("white");
        static Pawn whitePawn_8 = new Pawn("white");

        Dictionary<string, Figure> FiguresArrangement = new Dictionary<string, Figure>()
        {
            { "A2" , whitePawn_1 },
            { "B2" , whitePawn_1 },
            { "C2" , whitePawn_1 },
            { "D2" , whitePawn_1 },
            { "E2" , whitePawn_1 },
            { "F2" , whitePawn_1 },
            { "G2" , whitePawn_1 },
            { "H2" , whitePawn_1 },
        };

        //List<Figure> FiguresArrangement2 = new List<Figure>();

        Dictionary<string, Button> CellsInMove = new Dictionary<string, Button>();


        public MainWindow()
        {

            InitializeComponent();


            #region Content

            var WhiteChess = new Dictionary<string, string>()
            {
                { "Pawn"   , "\u2659" },
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
            Move(A1);
        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {
            Move(A2);
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            Move(A3);
        }

        private void A4_Click(object sender, RoutedEventArgs e)
        {
            Move(A4);
        }

        private void A5_Click(object sender, RoutedEventArgs e)
        {
            Move(A5);
        }

        private void A6_Click(object sender, RoutedEventArgs e)
        {
            Move(A6);
        }

        private void A7_Click(object sender, RoutedEventArgs e)
        {
            Move(A7);
        }

        private void A8_Click(object sender, RoutedEventArgs e)
        {
            Move(A8);
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void D8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void G8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void H8_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Move(Button cell)
        {
            DEB.Content = $"movenum = {movenum}";


            if (movenum == 0 && !FiguresArrangement.ContainsKey(cell.Name))
            {
                return;
                DEB.Content = $"movenum = {movenum}";

            }
            else if (movenum == 0 && FiguresArrangement.ContainsKey(cell.Name))
            {
                CellsInMove.Add("first", cell);
                movenum = 1;
                DEB.Content = $"movenum = {movenum}";

            }
            else if (movenum == 1 && CellsInMove["first"] == cell)
            {
                CellsInMove.Clear();
                movenum = 0;
                DEB.Content = $"movenum = {movenum}";

            }
            else if (movenum == 1)
            {
                FiguresArrangement.Add(cell.Name, FiguresArrangement[CellsInMove["first"].Name]);
                FiguresArrangement.Remove(CellsInMove["first"].Name);

                cell.Content = CellsInMove["first"].Content;
                CellsInMove["first"].Content = "";
                CellsInMove.Clear();

                movenum = 0;
                DEB.Content = $"movenum = {movenum}";

            }

        }

    }
}
