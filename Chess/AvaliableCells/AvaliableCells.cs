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
        internal static Dictionary<int, string> VerticalValues = new Dictionary<int, string>
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

        public static  Dictionary<int, string> HorizontalValues = new Dictionary<int, string>
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

        internal static void GetAvaliableCells(ref List<Button> CellsInMove, Dictionary<string, Figure> FiguresArrangement, ref List<string> avaliableCells, string WhoseMove, bool isKingsSafetyCheck = false)
        {
            var cellHorizontalValue = CellsInMove[0].Name.Substring(0, 1);
            var myHorizontalKey = HorizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(CellsInMove[0].Name.Substring(1, 1));

            if(!isKingsSafetyCheck)
            {
                avaliableCells.Clear();
            }

            if (FiguresArrangement[CellsInMove[0].Name].type == "Pawn")
            {
                GetPawnAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);
            }
            else if(FiguresArrangement[CellsInMove[0].Name].type == "Knight")
            {
                GetKnightAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);
            }
            else if (FiguresArrangement[CellsInMove[0].Name].type == "Rook")
            {
                GetStraightAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);
            }
            else if (FiguresArrangement[CellsInMove[0].Name].type == "Bishop")
            {
                GetDiagonalAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);
            }
            else if (FiguresArrangement[CellsInMove[0].Name].type == "Queen")
            {
                GetStraightAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);
                GetDiagonalAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove);
            }
            else if (FiguresArrangement[CellsInMove[0].Name].type == "King")
            {
                GetStraightAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove, true);
                GetDiagonalAvailableCells(CellsInMove[0].Name, FiguresArrangement, ref avaliableCells, WhoseMove, true);
            }

            //перевірити чи не підставляємо короля під удар
            CheckKingsSafety();
        }

        private static void GetPawnAvailableCells(string cell, Dictionary<string, Figure> FiguresArrangement, ref List<string> avaliableCells, string WhoseMove)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = HorizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            if (FiguresArrangement[cell].color == "White" && cellVerticalValue < 8)
            {
                if (!FiguresArrangement.ContainsKey(cellHorizontalValue + (cellVerticalValue + 1).ToString()))
                {
                    avaliableCells.Add(cellHorizontalValue + (cellVerticalValue + 1).ToString());
                }

                if (cellVerticalValue == 2 && !FiguresArrangement.ContainsKey(cellHorizontalValue + "4") && !FiguresArrangement.ContainsKey(cellHorizontalValue + "3"))
                {
                    avaliableCells.Add(cellHorizontalValue + "4");
                }

                //перевіряємо чи є фігури які можна забрати
                var tmp = HorizontalValues[myHorizontalKey + 1] + VerticalValues[cellVerticalValue + 1];

                if (FiguresArrangement.ContainsKey(tmp) && FiguresArrangement[tmp].color != WhoseMove)
                {
                    avaliableCells.Add(tmp);
                }

                tmp = HorizontalValues[myHorizontalKey - 1] + VerticalValues[cellVerticalValue + 1];

                if (FiguresArrangement.ContainsKey(tmp) && FiguresArrangement[tmp].color != WhoseMove)
                {
                    avaliableCells.Add(tmp);
                }
            }
            else if (FiguresArrangement[cell].color == "Black" && cellVerticalValue > 1)
            {
                if (!FiguresArrangement.ContainsKey(cellHorizontalValue + (cellVerticalValue - 1).ToString()))
                {
                    avaliableCells.Add(cellHorizontalValue + (cellVerticalValue - 1).ToString());
                }

                if (cellVerticalValue == 7 && !FiguresArrangement.ContainsKey(cellHorizontalValue + "5") && !FiguresArrangement.ContainsKey(cellHorizontalValue + "6"))
                {
                    avaliableCells.Add(cellHorizontalValue + "5");
                }

                //перевіряємо чи є фігури які можна забрати
                var tmp = HorizontalValues[myHorizontalKey + 1] + VerticalValues[cellVerticalValue - 1];

                if (FiguresArrangement.ContainsKey(tmp) && FiguresArrangement[tmp].color != WhoseMove)
                {
                    avaliableCells.Add(tmp);
                }

                tmp = HorizontalValues[myHorizontalKey - 1] + VerticalValues[cellVerticalValue - 1];

                if (FiguresArrangement.ContainsKey(tmp) && FiguresArrangement[tmp].color != WhoseMove)
                {
                    avaliableCells.Add(tmp);
                }
            }
        }

        private static void GetKnightAvailableCells(string cell, Dictionary<string, Figure> FiguresArrangement, ref List<string> avaliableCells, string WhoseMove)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = HorizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            if (HorizontalValues.ContainsKey(myHorizontalKey + 2) && VerticalValues.ContainsKey(cellVerticalValue + 1))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey + 2] + VerticalValues[cellVerticalValue + 1]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey + 2) && VerticalValues.ContainsKey(cellVerticalValue - 1))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey + 2] + VerticalValues[cellVerticalValue - 1]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey - 2) && VerticalValues.ContainsKey(cellVerticalValue + 1))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey - 2] + VerticalValues[cellVerticalValue + 1]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey - 2) && VerticalValues.ContainsKey(cellVerticalValue - 1))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey - 2] + VerticalValues[cellVerticalValue - 1]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey + 1) && VerticalValues.ContainsKey(cellVerticalValue + 2))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey + 1] + VerticalValues[cellVerticalValue + 2]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey + 1) && VerticalValues.ContainsKey(cellVerticalValue - 2))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey + 1] + VerticalValues[cellVerticalValue - 2]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey - 1) && VerticalValues.ContainsKey(cellVerticalValue + 2))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey - 1] + VerticalValues[cellVerticalValue + 2]);
            }
            if (HorizontalValues.ContainsKey(myHorizontalKey - 1) && VerticalValues.ContainsKey(cellVerticalValue - 2))
            {
                avaliableCells.Add(HorizontalValues[myHorizontalKey - 1] + VerticalValues[cellVerticalValue - 2]);
            }

            var wrongCells = new List<string>();

            foreach (var item in avaliableCells)
            {
                if(item.Length > 2)
                {
                    wrongCells.Add(item);
                }
                if(FiguresArrangement.ContainsKey(item) && FiguresArrangement[item].color == WhoseMove)
                {
                    wrongCells.Add(item);
                }
            }

            foreach (var item in wrongCells)
            {
                avaliableCells.Remove(item);
            }
        }

        private static void GetStraightAvailableCells(string cell, Dictionary<string, Figure> FiguresArrangement, ref List<string> avaliableCells, string WhoseMove, bool isKing = false)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = HorizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            for (int i = cellVerticalValue + 1; i <= 8; i++)
            {
                if (FiguresArrangement.ContainsKey(cellHorizontalValue + i) && FiguresArrangement[cellHorizontalValue + i].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(cellHorizontalValue + i))
                {
                    avaliableCells.Add(cellHorizontalValue + i);
                }
                else if (FiguresArrangement.ContainsKey(cellHorizontalValue + i) && FiguresArrangement[cellHorizontalValue + i].color != WhoseMove)
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
                if (FiguresArrangement.ContainsKey(cellHorizontalValue + i) && FiguresArrangement[cellHorizontalValue + i].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(cellHorizontalValue + i))
                {
                    avaliableCells.Add(cellHorizontalValue + i);
                }
                else if (FiguresArrangement.ContainsKey(cellHorizontalValue + i) && FiguresArrangement[cellHorizontalValue + i].color != WhoseMove)
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
                if (FiguresArrangement.ContainsKey(HorizontalValues[i] + cellVerticalValue) && FiguresArrangement[HorizontalValues[i] + cellVerticalValue].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(HorizontalValues[i] + cellVerticalValue))
                {
                    avaliableCells.Add(HorizontalValues[i] + cellVerticalValue);
                }
                else if (FiguresArrangement.ContainsKey(HorizontalValues[i] + cellVerticalValue) && FiguresArrangement[HorizontalValues[i] + cellVerticalValue].color != WhoseMove)
                {
                    avaliableCells.Add(HorizontalValues[i] + cellVerticalValue);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int i = myHorizontalKey - 1; i >= 1; i--)
            {
                if (FiguresArrangement.ContainsKey(HorizontalValues[i] + cellVerticalValue) && FiguresArrangement[HorizontalValues[i] + cellVerticalValue].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(HorizontalValues[i] + cellVerticalValue))
                {
                    avaliableCells.Add(HorizontalValues[i] + cellVerticalValue);
                }
                else if (FiguresArrangement.ContainsKey(HorizontalValues[i] + cellVerticalValue) && FiguresArrangement[HorizontalValues[i] + cellVerticalValue].color != WhoseMove)
                {
                    avaliableCells.Add(HorizontalValues[i] + cellVerticalValue);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }
        }

        private static void GetDiagonalAvailableCells(string cell, Dictionary<string, Figure> FiguresArrangement, ref List<string> avaliableCells, string WhoseMove, bool isKing = false)
        {
            var cellHorizontalValue = cell.Substring(0, 1);
            var myHorizontalKey = HorizontalValues.FirstOrDefault(x => x.Value == cellHorizontalValue).Key;
            var cellVerticalValue = Convert.ToInt32(cell.Substring(1, 1));

            for (int h = myHorizontalKey + 1, v = cellVerticalValue + 1; h <= 8 && v <= 8; h++, v++)
            {
                if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(HorizontalValues[h] + v))
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                }
                else if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color != WhoseMove)
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int h = myHorizontalKey - 1, v = cellVerticalValue + 1; h >= 1 && v <= 8; h--, v++)
            {
                if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(HorizontalValues[h] + v))
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                }
                else if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color != WhoseMove)
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int h = myHorizontalKey - 1, v = cellVerticalValue - 1; h >= 1 && v >= 1; h--, v--)
            {
                if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(HorizontalValues[h] + v))
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                }
                else if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color != WhoseMove)
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }

            for (int h = myHorizontalKey + 1, v = cellVerticalValue - 1; h <= 8 && v >= 1; h++, v--)
            {
                if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color == WhoseMove)
                {
                    break;
                }
                else if (!FiguresArrangement.ContainsKey(HorizontalValues[h] + v))
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                }
                else if (FiguresArrangement.ContainsKey(HorizontalValues[h] + v) && FiguresArrangement[HorizontalValues[h] + v].color != WhoseMove)
                {
                    avaliableCells.Add(HorizontalValues[h] + v);
                    break;
                }
                if (isKing)
                {
                    break;
                }
            }
        }

        private static void CheckKingsSafety()
        {

        }

    }
}
