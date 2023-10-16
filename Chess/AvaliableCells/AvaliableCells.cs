using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    internal static class AvaliableCells
    {
        internal static Dictionary<int, string> verticalValues = new Dictionary<int, string>
        {
                { 0 , "empty" },
                { 1 , "1" },
                { 2 , "2" },
                { 3 , "3" },
                { 4 , "4" },
                { 5 , "5" },
                { 6 , "6" },
                { 7 , "7" },
                { 8 , "8" },
                { 9 , "empty" },
         };

        public static  Dictionary<int, string> horizontalValues = new Dictionary<int, string>
         {
                { 0 , "empty" },
                { 1 , "A" },
                { 2 , "B" },
                { 3 , "C" },
                { 4 , "D" },
                { 5 , "E" },
                { 6 , "F" },
                { 7 , "G" },
                { 8 , "H" },
                { 9 , "empty" },
         };

        internal static void GetAvaliableCells(string cell, string secondCell, Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, string whoseMove, bool isKingsSafetyCheck = false)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = horizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            if(!isKingsSafetyCheck)
            {
                avaliableCells.Clear();
            }

            if (figuresArrangement[cell].type == "Pawn")
            {
                GetPawnAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove);
            }
            else if(figuresArrangement[cell].type == "Knight")
            {
                GetKnightAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove);
            }
            else if (figuresArrangement[cell].type == "Rook")
            {
                GetStraightAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove);
            }
            else if (figuresArrangement[cell].type == "Bishop")
            {
                GetDiagonalAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove);
            }
            else if (figuresArrangement[cell].type == "Queen")
            {
                GetStraightAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove);
                GetDiagonalAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove);
            }
            else if (figuresArrangement[cell].type == "King")
            {
                GetStraightAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove, true);
                GetDiagonalAvailableCells(cell, figuresArrangement, ref avaliableCells, whoseMove, true);
            }

            if(!isKingsSafetyCheck)
            {
                CheckKingsSafety(cell, secondCell, figuresArrangement, ref avaliableCells, whoseMove);
            }
        }

        private static void GetPawnAvailableCells(string cell, Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, string whoseMove)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = horizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            if (figuresArrangement[cell].color == "White" && cellVerticalValue < 8)
            {
                if (!figuresArrangement.ContainsKey(cellHorizontalValue + (cellVerticalValue + 1).ToString()))
                {
                    avaliableCells.Add(cellHorizontalValue + (cellVerticalValue + 1).ToString());
                }

                if (cellVerticalValue == 2 && !figuresArrangement.ContainsKey(cellHorizontalValue + "4") && !figuresArrangement.ContainsKey(cellHorizontalValue + "3"))
                {
                    avaliableCells.Add(cellHorizontalValue + "4");
                }

                //перевіряємо чи є фігури які можна забрати
                var tmp = horizontalValues[myHorizontalKey + 1] + verticalValues[cellVerticalValue + 1];

                if (figuresArrangement.ContainsKey(tmp) && figuresArrangement[tmp].color != whoseMove)
                {
                    avaliableCells.Add(tmp);
                }

                tmp = horizontalValues[myHorizontalKey - 1] + verticalValues[cellVerticalValue + 1];

                if (figuresArrangement.ContainsKey(tmp) && figuresArrangement[tmp].color != whoseMove)
                {
                    avaliableCells.Add(tmp);
                }
            }
            else if (figuresArrangement[cell].color == "Black" && cellVerticalValue > 1)
            {
                if (!figuresArrangement.ContainsKey(cellHorizontalValue + (cellVerticalValue - 1).ToString()))
                {
                    avaliableCells.Add(cellHorizontalValue + (cellVerticalValue - 1).ToString());
                }

                if (cellVerticalValue == 7 && !figuresArrangement.ContainsKey(cellHorizontalValue + "5") && !figuresArrangement.ContainsKey(cellHorizontalValue + "6"))
                {
                    avaliableCells.Add(cellHorizontalValue + "5");
                }

                //перевіряємо чи є фігури які можна забрати
                var tmp = horizontalValues[myHorizontalKey + 1] + verticalValues[cellVerticalValue - 1];

                if (figuresArrangement.ContainsKey(tmp) && figuresArrangement[tmp].color != whoseMove)
                {
                    avaliableCells.Add(tmp);
                }

                tmp = horizontalValues[myHorizontalKey - 1] + verticalValues[cellVerticalValue - 1];

                if (figuresArrangement.ContainsKey(tmp) && figuresArrangement[tmp].color != whoseMove)
                {
                    avaliableCells.Add(tmp);
                }
            }
        }

        private static void GetKnightAvailableCells(string cell, Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, string whoseMove)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = horizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            if (horizontalValues.ContainsKey(myHorizontalKey + 2) && verticalValues.ContainsKey(cellVerticalValue + 1))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey + 2] + verticalValues[cellVerticalValue + 1]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey + 2) && verticalValues.ContainsKey(cellVerticalValue - 1))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey + 2] + verticalValues[cellVerticalValue - 1]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey - 2) && verticalValues.ContainsKey(cellVerticalValue + 1))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey - 2] + verticalValues[cellVerticalValue + 1]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey - 2) && verticalValues.ContainsKey(cellVerticalValue - 1))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey - 2] + verticalValues[cellVerticalValue - 1]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey + 1) && verticalValues.ContainsKey(cellVerticalValue + 2))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey + 1] + verticalValues[cellVerticalValue + 2]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey + 1) && verticalValues.ContainsKey(cellVerticalValue - 2))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey + 1] + verticalValues[cellVerticalValue - 2]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey - 1) && verticalValues.ContainsKey(cellVerticalValue + 2))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey - 1] + verticalValues[cellVerticalValue + 2]);
            }
            if (horizontalValues.ContainsKey(myHorizontalKey - 1) && verticalValues.ContainsKey(cellVerticalValue - 2))
            {
                avaliableCells.Add(horizontalValues[myHorizontalKey - 1] + verticalValues[cellVerticalValue - 2]);
            }

            var wrongCells = new List<string>();

            foreach (var item in avaliableCells)
            {
                if(item.Length > 2)
                {
                    wrongCells.Add(item);
                }
                if(figuresArrangement.ContainsKey(item) && figuresArrangement[item].color == whoseMove)
                {
                    wrongCells.Add(item);
                }
            }

            foreach (var item in wrongCells)
            {
                avaliableCells.Remove(item);
            }
        }

        private static void GetStraightAvailableCells(string cell, Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, string whoseMove, bool isKing = false)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = horizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            for (int i = cellVerticalValue + 1; i <= 8; i++)
            {
                if (figuresArrangement.ContainsKey(cellHorizontalValue + i) && figuresArrangement[cellHorizontalValue + i].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(cellHorizontalValue + i))
                {
                    avaliableCells.Add(cellHorizontalValue + i);
                }
                else if (figuresArrangement.ContainsKey(cellHorizontalValue + i) && figuresArrangement[cellHorizontalValue + i].color != whoseMove)
                {
                    avaliableCells.Add(cellHorizontalValue + i);
                    break;
                }
                if(isKing)
                {
                    break;
                }
            }

            for (int i = cellVerticalValue - 1; i >= 1; i--)
            {
                if (figuresArrangement.ContainsKey(cellHorizontalValue + i) && figuresArrangement[cellHorizontalValue + i].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(cellHorizontalValue + i))
                {
                    avaliableCells.Add(cellHorizontalValue + i);
                }
                else if (figuresArrangement.ContainsKey(cellHorizontalValue + i) && figuresArrangement[cellHorizontalValue + i].color != whoseMove)
                {
                    avaliableCells.Add(cellHorizontalValue + i);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int i = myHorizontalKey + 1; i <= 8; i++)
            {
                if (figuresArrangement.ContainsKey(horizontalValues[i] + cellVerticalValue) && figuresArrangement[horizontalValues[i] + cellVerticalValue].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(horizontalValues[i] + cellVerticalValue))
                {
                    avaliableCells.Add(horizontalValues[i] + cellVerticalValue);
                }
                else if (figuresArrangement.ContainsKey(horizontalValues[i] + cellVerticalValue) && figuresArrangement[horizontalValues[i] + cellVerticalValue].color != whoseMove)
                {
                    avaliableCells.Add(horizontalValues[i] + cellVerticalValue);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int i = myHorizontalKey - 1; i >= 1; i--)
            {
                if (figuresArrangement.ContainsKey(horizontalValues[i] + cellVerticalValue) && figuresArrangement[horizontalValues[i] + cellVerticalValue].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(horizontalValues[i] + cellVerticalValue))
                {
                    avaliableCells.Add(horizontalValues[i] + cellVerticalValue);
                }
                else if (figuresArrangement.ContainsKey(horizontalValues[i] + cellVerticalValue) && figuresArrangement[horizontalValues[i] + cellVerticalValue].color != whoseMove)
                {
                    avaliableCells.Add(horizontalValues[i] + cellVerticalValue);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }
        }

        private static void GetDiagonalAvailableCells(string cell, Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, string whoseMove, bool isKing = false)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = horizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            for (int h = myHorizontalKey + 1, v = cellVerticalValue + 1; h <= 8 && v <= 8; h++, v++)
            {
                if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(horizontalValues[h] + v))
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                }
                else if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color != whoseMove)
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int h = myHorizontalKey - 1, v = cellVerticalValue + 1; h >= 1 && v <= 8; h--, v++)
            {
                if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(horizontalValues[h] + v))
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                }
                else if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color != whoseMove)
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int h = myHorizontalKey - 1, v = cellVerticalValue - 1; h >= 1 && v >= 1; h--, v--)
            {
                if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(horizontalValues[h] + v))
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                }
                else if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color != whoseMove)
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int h = myHorizontalKey + 1, v = cellVerticalValue - 1; h <= 8 && v >= 1; h++, v--)
            {
                if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color == whoseMove)
                {
                    break;
                }
                else if (!figuresArrangement.ContainsKey(horizontalValues[h] + v))
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                }
                else if (figuresArrangement.ContainsKey(horizontalValues[h] + v) && figuresArrangement[horizontalValues[h] + v].color != whoseMove)
                {
                    avaliableCells.Add(horizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }
        }

        private static void CheckKingsSafety(string cell, string secondCell, Dictionary<string, Figure> figuresArrangement, ref List<string> avaliableCells, string whoseMove)
        {
            var possibleAvaliableCells = new List<string>();
            var possibleFiguresArrangement = new Dictionary<string, Figure>();
            var inverseWhoseMove = $"{(whoseMove == "White" ? "Black" : "White")}";


            //перевірка, щоб не взяти свою фігуру
            if (figuresArrangement.ContainsKey(secondCell) && figuresArrangement[secondCell].color == whoseMove)
            {
                avaliableCells.Clear();
                return;
            }

            foreach(var item in figuresArrangement)
            {
                possibleFiguresArrangement.Add(item.Key, item.Value);
            }

            if (possibleFiguresArrangement.ContainsKey(secondCell))
            {
                possibleFiguresArrangement.Remove(secondCell);

                possibleFiguresArrangement.Add(secondCell, possibleFiguresArrangement[cell]);
                possibleFiguresArrangement.Remove(cell);
            }
            else
            {
                possibleFiguresArrangement.Add(secondCell, possibleFiguresArrangement[cell]);
                possibleFiguresArrangement.Remove(cell);
            }

            foreach (var item in possibleFiguresArrangement)
            {
                if (item.Value.color == whoseMove)
                {
                    continue;
                }
                else
                {
                    GetAvaliableCells(item.Key, "", possibleFiguresArrangement, ref possibleAvaliableCells, inverseWhoseMove, true);
                }

                if(possibleAvaliableCells.Contains(possibleFiguresArrangement.Where(w => w.Value.type == "King" && w.Value.color == whoseMove).First().Key))
                {
                    avaliableCells.Clear();
                    avaliableCells.Add("check kings safety result - false");
                    break;
                }
            }

        }

    }
}
