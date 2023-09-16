﻿using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
        public string WhoseMove = "White";
        public List<Button> CellsInMove = new List<Button>();
        public List<string> avaliableCells = new List<string>();



        static Pawn whitePawn_1 = new Pawn("White");
        static Pawn whitePawn_2 = new Pawn("White");
        static Pawn whitePawn_3 = new Pawn("White");
        static Pawn whitePawn_4 = new Pawn("White");
        static Pawn whitePawn_5 = new Pawn("White");
        static Pawn whitePawn_6 = new Pawn("White");
        static Pawn whitePawn_7 = new Pawn("White");
        static Pawn whitePawn_8 = new Pawn("White");

        static Pawn blackPawn_1 = new Pawn("Black");
        static Pawn blackPawn_2 = new Pawn("Black");
        static Pawn blackPawn_3 = new Pawn("Black");
        static Pawn blackPawn_4 = new Pawn("Black");
        static Pawn blackPawn_5 = new Pawn("Black");
        static Pawn blackPawn_6 = new Pawn("Black");
        static Pawn blackPawn_7 = new Pawn("Black");
        static Pawn blackPawn_8 = new Pawn("Black");


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

            { "A7" , blackPawn_1 },
            { "B7" , blackPawn_2 },
            { "C7" , blackPawn_3 },
            { "D7" , blackPawn_4 },
            { "E7" , blackPawn_5 },
            { "F7" , blackPawn_6 },
            { "G7" , blackPawn_7 },
            { "H7" , blackPawn_8 },

        };

        //Dictionary<string, Button> CellsInMove = new Dictionary<string, Button>();

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
            Move(B1);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Move(B2);
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Move(B3);
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Move(B4);
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            Move(B5);
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            Move(B6);
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {
            Move(B7);
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            Move(B8);
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            Move(C1);
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            Move(C2);
        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            Move(C3);
        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {
            Move(C4);
        }

        private void C5_Click(object sender, RoutedEventArgs e)
        {
            Move(C5);
        }

        private void C6_Click(object sender, RoutedEventArgs e)
        {
            Move(C6);
        }

        private void C7_Click(object sender, RoutedEventArgs e)
        {
            Move(C7);
        }

        private void C8_Click(object sender, RoutedEventArgs e)
        {
            Move(C8);
        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {
            Move(D1);
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            Move(D2);
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            Move(D3);
        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {
            Move(D4);
        }

        private void D5_Click(object sender, RoutedEventArgs e)
        {
            Move(D5);
        }

        private void D6_Click(object sender, RoutedEventArgs e)
        {
            Move(D6);
        }

        private void D7_Click(object sender, RoutedEventArgs e)
        {
            Move(D7);
        }

        private void D8_Click(object sender, RoutedEventArgs e)
        {
            Move(D8);
        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {
            Move(E1);
        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {
            Move(E2);
        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {
            Move(E3);
        }

        private void E4_Click(object sender, RoutedEventArgs e)
        {
            Move(E4);
        }

        private void E5_Click(object sender, RoutedEventArgs e)
        {
            Move(E5);
        }

        private void E6_Click(object sender, RoutedEventArgs e)
        {
            Move(E6);
        }

        private void E7_Click(object sender, RoutedEventArgs e)
        {
            Move(E7);
        }

        private void E8_Click(object sender, RoutedEventArgs e)
        {
            Move(E8);
        }

        private void F1_Click(object sender, RoutedEventArgs e)
        {
            Move(F1);
        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {
            Move(F2);
        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {
            Move(F3);
        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {
            Move(F4);
        }

        private void F5_Click(object sender, RoutedEventArgs e)
        {
            Move(F5);
        }

        private void F6_Click(object sender, RoutedEventArgs e)
        {
            Move(F6);
        }

        private void F7_Click(object sender, RoutedEventArgs e)
        {
            Move(F7);
        }

        private void F8_Click(object sender, RoutedEventArgs e)
        {
            Move(F8);
        }

        private void G1_Click(object sender, RoutedEventArgs e)
        {
            Move(G1);
        }

        private void G2_Click(object sender, RoutedEventArgs e)
        {
            Move(G2);
        }

        private void G3_Click(object sender, RoutedEventArgs e)
        {
            Move(G3);
        }

        private void G4_Click(object sender, RoutedEventArgs e)
        {
            Move(G4);
        }

        private void G5_Click(object sender, RoutedEventArgs e)
        {
            Move(G5);
        }

        private void G6_Click(object sender, RoutedEventArgs e)
        {
            Move(G6);
        }

        private void G7_Click(object sender, RoutedEventArgs e)
        {
            Move(G7);
        }

        private void G8_Click(object sender, RoutedEventArgs e)
        {
            Move(G8);
        }

        private void H1_Click(object sender, RoutedEventArgs e)
        {
            Move(H1);
        }

        private void H2_Click(object sender, RoutedEventArgs e)
        {
            Move(H2);
        }

        private void H3_Click(object sender, RoutedEventArgs e)
        {
            Move(H3);
        }

        private void H4_Click(object sender, RoutedEventArgs e)
        {
            Move(H4);
        }

        private void H5_Click(object sender, RoutedEventArgs e)
        {
            Move(H5);
        }

        private void H6_Click(object sender, RoutedEventArgs e)
        {
            Move(H6);
        }

        private void H7_Click(object sender, RoutedEventArgs e)
        {
            Move(H7);
        }

        private void H8_Click(object sender, RoutedEventArgs e)
        {
            Move(H8);
        }
        #endregion

        private void Move(Button cell)
        {
            #region oldLogic
            //DEB.Content = $"movenum = {cellChoiseNum}";

            //if (cellChoiseNum == 0 && !FiguresArrangement.ContainsKey(cell.Name))
            //{
            //    return;
            //    DEB.Content = $"movenum = {cellChoiseNum}";
            //}
            //else if (cellChoiseNum == 0 && FiguresArrangement.ContainsKey(cell.Name))
            //{
            //    avaliableCells = GetAvaliableCells(cell.Name);

            //    CellsInMove.Add("first", cell);
            //    cellChoiseNum = 1;

            //    DEB.Content = $"movenum = {cellChoiseNum}";
            //    DEB.Content = avaliableCells;
            //}
            //else if (cellChoiseNum == 1 && CellsInMove["first"] == cell)
            //{
            //    CellsInMove.Clear();
            //    cellChoiseNum = 0;

            //    DEB.Content = $"movenum = {cellChoiseNum}";
            //}
            //else if (cellChoiseNum == 1 && avaliableCells.Contains(cell.Name.ToString()))
            //{
            //    FiguresArrangement.Add(cell.Name, FiguresArrangement[CellsInMove["first"].Name]);
            //    FiguresArrangement.Remove(CellsInMove["first"].Name);

            //    cell.Content = CellsInMove["first"].Content;
            //    CellsInMove["first"].Content = "";
            //    CellsInMove.Clear();

            //    cellChoiseNum = 0;

            //    DEB.Content = $"movenum = {cellChoiseNum}";
            //}
            #endregion

            if (CellsInMove.Count == 0 && !FiguresArrangement.ContainsKey(cell.Name))
            {
                DEB.Content = "Перша клітинка має містити фігуру";
            }
            else if(CellsInMove.Count == 0 && FiguresArrangement.ContainsKey(cell.Name) && FiguresArrangement[cell.Name].color != WhoseMove)
            {
                DEB.Content = $"Зараз мають ходити {(WhoseMove == "White" ? "білі" : "чорні")}";
            }
            else if (CellsInMove.Count == 0 && FiguresArrangement.ContainsKey(cell.Name) && FiguresArrangement[cell.Name].color == WhoseMove)
            {
                DEB.Content = $"{cell.Name}";
                CellsInMove.Add(cell);
            }
            else if (CellsInMove.Count == 1 && cell == CellsInMove[0])
            {
                DEB.Content = "Однакова клітинка";
                CellsInMove.Clear();
            }
            else if (CellsInMove.Count == 1 && cell != CellsInMove[0])
            {
                CellsInMove.Add(cell);

                GetAvaliableCells(CellsInMove[0].Name);

                if(!avaliableCells.Contains(CellsInMove[1].Name))
                {
                    DEB.Content = "Недоступний хід";
                    CellsInMove.Clear();
                }
                else if (avaliableCells.Contains(CellsInMove[1].Name))
                {
                    CellsInMove[1].Content = CellsInMove[0].Content;
                    CellsInMove[0].Content = string.Empty;

                    if (FiguresArrangement.ContainsKey(CellsInMove[1].Name))
                    {
                        // тут описана логіка при взятті фігури
                    }
                    else
                    {
                        FiguresArrangement.Add(CellsInMove[1].Name, FiguresArrangement[CellsInMove[0].Name]);
                        FiguresArrangement.Remove(CellsInMove[0].Name);
                    }

                    CellsInMove.Clear();

                    WhoseMove = (WhoseMove == "White" ? "Black" : "White");
                }

            }
        }

        #region oldLogic2
        private void GetAvaliableCells(string cell)
        {
            avaliableCells.Clear();

            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));
            var cellHorizontalValue = cell.Substring(0, 1);

            #region Pawn
            if (FiguresArrangement[cell].type == "Pawn")
            {

                if (FiguresArrangement[cell].color == "White" && cellVerticalValue < 8)
                {

                    if (cellVerticalValue == 2 && !FiguresArrangement.ContainsKey(cellHorizontalValue + "4") && !FiguresArrangement.ContainsKey(cellHorizontalValue + "3"))
                    {
                        avaliableCells.Add(cellHorizontalValue + "4");
                    }

                    if (!FiguresArrangement.ContainsKey(cellHorizontalValue + (++cellVerticalValue).ToString()))
                    {
                        avaliableCells.Add(cellHorizontalValue + (cellVerticalValue++).ToString());
                    }
                }
                else if (FiguresArrangement[cell].color == "Black" && cellVerticalValue > 1)
                {
                    if (cellVerticalValue == 7 && !FiguresArrangement.ContainsKey(cellHorizontalValue + "5") && !FiguresArrangement.ContainsKey(cellHorizontalValue + "6"))
                    {
                        avaliableCells.Add(cellHorizontalValue + "5");
                    }

                    if (!FiguresArrangement.ContainsKey(cellHorizontalValue + (--cellVerticalValue).ToString()))
                    {
                        avaliableCells.Add(cellHorizontalValue + (cellVerticalValue--).ToString());
                    }
                }
            }
            #endregion

        }
        #endregion

    }
}
