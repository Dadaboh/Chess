using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    internal static class Move
    {
        internal static void MoveFigure(Button cell, Label DEB, ref Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, ref List<Button> cellsInMove, ref string whoseMove)
        {
            if (cellsInMove.Count == 0 && !figuresArrangement.ContainsKey(cell.Name))
            {
                DEB.Content = "Перша клітинка має містити фігуру";
            }
            else if (cellsInMove.Count == 0 && figuresArrangement.ContainsKey(cell.Name) && figuresArrangement[cell.Name].color != whoseMove)
            {
                DEB.Content = $"Зараз мають ходити {(whoseMove == "White" ? "білі" : "чорні")}";
            }
            else if (cellsInMove.Count == 0 && figuresArrangement.ContainsKey(cell.Name) && figuresArrangement[cell.Name].color == whoseMove)
            {
                DEB.Content = $"{cell.Name}";
                cellsInMove.Add(cell);
            }
            else if (cellsInMove.Count == 1 && cell == cellsInMove[0])
            {
                DEB.Content = "Однакова клітинка";
                cellsInMove.Clear();
            }
            else if (cellsInMove.Count == 1 && cell != cellsInMove[0])
            {
                cellsInMove.Add(cell);

                AvaliableCells.GetAvaliableCells(cellsInMove[0].Name, cellsInMove[1].Name, figuresArrangement, ref avaliableCells, whoseMove);

                if (avaliableCells.Contains("check kings safety result - false"))
                {
                    DEB.Content = "Підставляємо короля під удар.";
                    cellsInMove.Clear();
                }
                else if (!avaliableCells.Contains(cellsInMove[1].Name))
                {
                    DEB.Content = "Недоступний хід";
                    cellsInMove.Clear();
                }
                else if (avaliableCells.Contains(cellsInMove[1].Name))
                {
                    cellsInMove[1].Content = cellsInMove[0].Content;
                    cellsInMove[0].Content = string.Empty;

                    if (figuresArrangement.ContainsKey(cellsInMove[1].Name))
                    {
                        figuresArrangement.Remove(cellsInMove[1].Name);

                        figuresArrangement.Add(cellsInMove[1].Name, figuresArrangement[cellsInMove[0].Name]);
                        figuresArrangement.Remove(cellsInMove[0].Name);
                    }
                    else
                    {
                        figuresArrangement.Add(cellsInMove[1].Name, figuresArrangement[cellsInMove[0].Name]);
                        figuresArrangement.Remove(cellsInMove[0].Name);
                    }

                    //History.Add($"{CellsInMove[0].Name} => {CellsInMove[1].Name}");


                    //перевіряємо чи поставили шах ворожому королю 
                    {
                        avaliableCells.Clear();
                        AvaliableCells.GetAvaliableCells(cellsInMove[1].Name, "", figuresArrangement, ref avaliableCells, whoseMove, true);

                        var whoseMoveStr = whoseMove.ToString();

                        if (avaliableCells.Contains(figuresArrangement.Where(w => w.Value.type == "King" && w.Value.color != whoseMoveStr).First().Key))
                        {
                            DEB.Content = "ШАХ";
                        }
                    }

                    //перевіряємо чи є доступні ходи для ворожої команди
                    {
                        var tmpAvaliableCells = new List<string>();
                        var result = new List<string>();
                        var inverseWhoseMove = $"{(whoseMove == "White" ? "Black" : "White")}";

                        foreach (var item in figuresArrangement)
                        {

                            if (item.Key == "G7")
                            {
                                avaliableCells.Clear();
                                tmpAvaliableCells.Clear();

                                if (item.Value.color == whoseMove)
                                {
                                    continue;
                                }

                                AvaliableCells.GetAvaliableCells(item.Key, "", figuresArrangement, ref avaliableCells, inverseWhoseMove, true);

                                foreach (var str in avaliableCells)
                                {
                                    tmpAvaliableCells.Add(str);
                                }

                                if (!tmpAvaliableCells.Any())
                                {
                                    continue;
                                }
                                else
                                {
                                    foreach (var str in tmpAvaliableCells)
                                    {
                                        AvaliableCells.CheckKingsSafety(item.Key, str, figuresArrangement, ref avaliableCells, inverseWhoseMove);


                                        if(!avaliableCells.Contains("check kings safety result - false"))
                                        {
                                            result.Add(str);
                                        }

                                    }
                                }
                            }
                            
                        }




                        result.Add("asd");
                        result.Remove("asd");

                    }

                    cellsInMove.Clear();
                    whoseMove = whoseMove == "White" ? "Black" : "White";
                }
            }
        }
    }
}
