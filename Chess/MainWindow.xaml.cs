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

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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

            InitializeComponent();

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
        }

        public object cd = "";
        public int movecount = 0;

        internal Cage asd = new Cage { cageid = new CageId("A", 1), figure = new Pawn(), access = true };



        private void A1_Click(object sender, RoutedEventArgs e)
        {
            if (movecount == 0)
            {
                cd = A1.Content;
                movecount++;
            }
            else if (movecount == 1)
            {
                A1.Content = cd;
                A4.Content = "";
                movecount = 0;
            }
            Cage asd = new Cage { cageid = new CageId("A", 1), figure = new Pawn(), access = true };

    }


    private void A4_Click(object sender, RoutedEventArgs e)
        {
            if(movecount == 0)
            {
                cd = A4.Content;
                movecount++;
            }
            else if(movecount == 1)
            {
                A4.Content = cd;
                A1.Content = "";
                movecount = 0;
            }
        }
    }
}
