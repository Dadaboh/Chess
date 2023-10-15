using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    internal static class Move
    {
        internal static void MoveFigure(Button cell, Label DEB, ref Dictionary<string, Figure> FiguresArrangement, ref List<string> avaliableCells, ref List<Button> CellsInMove, ref string WhoseMove)
        {
            if (CellsInMove.Count == 0 && !FiguresArrangement.ContainsKey(cell.Name))
            {
                DEB.Content = "Перша клітинка має містити фігуру";
            }
            else if (CellsInMove.Count == 0 && FiguresArrangement.ContainsKey(cell.Name) && FiguresArrangement[cell.Name].color != WhoseMove)
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

                AvaliableCells.GetAvaliableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);

                if (!avaliableCells.Contains(CellsInMove[1].Name))
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
                        FiguresArrangement.Remove(CellsInMove[1].Name);

                        FiguresArrangement.Add(CellsInMove[1].Name, FiguresArrangement[CellsInMove[0].Name]);
                        FiguresArrangement.Remove(CellsInMove[0].Name);
                    }
                    else
                    {
                        FiguresArrangement.Add(CellsInMove[1].Name, FiguresArrangement[CellsInMove[0].Name]);
                        FiguresArrangement.Remove(CellsInMove[0].Name);
                    }

                    //History.Add($"{CellsInMove[0].Name} => {CellsInMove[1].Name}");

                    CellsInMove.Clear();

                    WhoseMove = WhoseMove == "White" ? "Black" : "White";
                }

            }
        }
    }
}
