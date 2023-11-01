using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Chess
{
    internal static class Move
    {
        //static List<string> history = new List<string>();
        static string history;

        internal static void MoveFigure(Button cell, Label DEB, ref Dictionary<string, Piece> figuresArrangement, ref List<string> avaliableCells, ref List<Button> cellsInMove, ref string whoseMove, List<RadioButton> radioButtonsList = null)
        {
            bool isCheck = false;

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

                AvaliableCells.GetAvailableCells(cellsInMove[0].Name, cellsInMove[1].Name, figuresArrangement, ref avaliableCells, whoseMove);

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


                    //заміна пішки на іншу фігуру коли вона досягне останньої лінії
                    if (figuresArrangement[cellsInMove[1].Name].type == (int)MyEnums.PiecesTypes.Pawn)
                    {
                        CheckPawnLastRow(DEB, ref cellsInMove, ref figuresArrangement, ref radioButtonsList);
                    }

                    //перевіряємо чи поставили шах ворожому королю 
                    AfterMove.СheckCheck(ref avaliableCells, ref cellsInMove, ref figuresArrangement, ref whoseMove, DEB, ref isCheck);

                    //перевіряємо чи є доступні ходи для ворожої команди
                    AfterMove.GetOpponentAvailableCells(ref avaliableCells, ref figuresArrangement, ref whoseMove, DEB, ref isCheck);


                    //переписати історію в окремий клас. записувати в json всі партії
                    {
                        history += (cellsInMove[0].Name + " => " + cellsInMove[1].Name + "\n");

                        using (var sw = new StreamWriter("History.txt"))
                        {
                            sw.Write(history);
                        }
                    }

                    cellsInMove.Clear();
                    whoseMove = whoseMove == "White" ? "Black" : "White";
                }
            }
        }

        //заміна пішки на іншу фігуру коли вона досягне останньої лінії
        internal static void CheckPawnLastRow(Label DEB, ref List<Button> cellsInMove, ref Dictionary<string, Piece> figuresArrangement, ref List<RadioButton> radioButtonsList)
        {
            if (cellsInMove[1].Name.Substring(1, 1) == "8" || cellsInMove[1].Name.Substring(1, 1) == "1")
            {
                var isPawnWasChanged = false;

                DEB.Content = "Оберіть на яку фігуру\nзамінити пішку:";

                foreach (var radioButton in radioButtonsList)
                {
                    radioButton.Visibility = System.Windows.Visibility.Visible;
                }

                do
                {
                    foreach (var radioButton in radioButtonsList)
                    {
                        if (radioButton.IsChecked == true)
                        {
                            isPawnWasChanged = true;
                            break;
                        }
                    }
                }
                while (!isPawnWasChanged);

            }
        }
    }
}
