using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Chess
{
    internal class AfterMove
    {
        //перевіряємо чи поставили шах ворожому королю 
        internal static void СheckCheck(ref List<string> avaliableCells, ref List<Button> cellsInMove, ref Dictionary<string, Piece> figuresArrangement, ref string whoseMove, Label DEB, ref bool isCheck)
        {
            avaliableCells.Clear();
            AvaliableCells.GetAvailableCells(cellsInMove[1].Name, "", figuresArrangement, ref avaliableCells, whoseMove, true);

            var whoseMoveStr = whoseMove.ToString();

            if (avaliableCells.Contains(figuresArrangement.Where(w => w.Value.type == (int)MyEnums.PiecesTypes.King && w.Value.color != whoseMoveStr).First().Key))
            {
                DEB.Content = "ШАХ";
                isCheck = true;
            }
        }


        //перевіряємо чи є доступні ходи для ворожої команди
        internal static void GetOpponentAvailableCells(ref List<string> avaliableCells, ref Dictionary<string, Piece> figuresArrangement, ref string whoseMove, Label DEB, ref bool isCheck)
        {
            
            var tmpAvaliableCells = new List<string>();

            //в result будемо записувати всі доступні ходи для всіх ворожих фігур
            var result = new List<string>();

            var inverseWhoseMove = $"{(whoseMove == "White" ? "Black" : "White")}";

            foreach (var item in figuresArrangement)
            {

                avaliableCells.Clear();
                tmpAvaliableCells.Clear();

                if (item.Value.color == whoseMove)
                {
                    continue;
                }

                //заповнюємо avaliableCells доступними ходами для обраної фігури
                AvaliableCells.GetAvailableCells(item.Key, "", figuresArrangement, ref avaliableCells, inverseWhoseMove, true);

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
                        avaliableCells.Remove("check kings safety result - false");

                        AvaliableCells.CheckKingsSafety(item.Key, str, figuresArrangement, ref avaliableCells, inverseWhoseMove);


                        if (!avaliableCells.Contains("check kings safety result - false"))
                        {
                            result.Add(str);
                        }

                    }
                }
            }

            result.Remove("check kings safety result - false");

            if (!result.Any() && isCheck == true)
            {
                DEB.Content = $"Шах і мат. Перемогли {(whoseMove == "White" ? "білі" : "чорні")}";
            }
            else if (!result.Any() && isCheck == false)
            {
                DEB.Content = "Пат. Нічия.";
            }
        }
    }
}
