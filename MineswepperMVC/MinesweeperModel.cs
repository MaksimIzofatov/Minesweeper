using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineswepperMVC
{
    public class MinesweeperModel
    {
        int rowCount = 10;
        int colCount = 10;
        int mineCount = 15;

        MinesweeperCell[,] cells;

        bool firstStep;
        bool gameOver;

        public int RowCount => rowCount;
        public int ColumnCount => colCount;

        Random random = new Random();
        public MinesweeperModel()
        {
            cells = new MinesweeperCell[rowCount, colCount];
            StartGame();
        }

        public void StartGame()
        {
            firstStep = true;
            gameOver = false;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    cells[i, j] = new MinesweeperCell { Row = i, Column = j };
                }
            }
            //GenerateMines();
        }



        public MinesweeperCell GetCell(int row, int column)
        {
            if (row < 0 || row >= rowCount || column < 0 || column >= colCount)
                return null;
            return cells[row, column];
        }

        public bool IsWin()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if ((!cells[i, j].Mined && (cells[i, j].State != CellState.Opened)))//&& cells[i, j].State != CellState.Flagged
                        return false;
                }

            }
            return true;
        }

        public bool IsGameOver() => gameOver;



        public void OpenCell(int row, int column)
        {
            MinesweeperCell cell = cells[row, column];
            if (cell == null)
                return;
            cell.Open();
            if (cell.Mined)
            {
                gameOver = true;
                return;
            }
            if (firstStep)
            {
                firstStep = false;
                GenerateMines();
            }
            cell.Counter = CountMinesAroundCell(row, column);
            if (cell.Counter == 0)
            {
                List<MinesweeperCell> neighbours = GetCellNeighbours(row, column);
                foreach (var item in neighbours)
                {
                    if (item.State == CellState.Closed)
                        OpenCell(item.Row, item.Column);
                }
            }
        }

        private List<MinesweeperCell> GetCellNeighbours(int row, int column)
        {
            List<MinesweeperCell> neighbours = new List<MinesweeperCell>();
            for (int r = row - 1; r < row + 2; r++)
            {
                neighbours.Add(GetCell(r, column - 1));
                if (r != row)
                    neighbours.Add(GetCell(r, column));
                neighbours.Add(GetCell(r, column + 1));
            }
            return neighbours.Where(c => c != null).ToList();
        }
        //определение количества мин в соседних ячейках
        private int CountMinesAroundCell(int row, int column)
        {
            return GetCellNeighbours(row, column).Count(c => c.Mined);
        }
        //минирование игровых ячеек случайным образом     
        private void GenerateMines()
        {

            for (int i = 0; i < mineCount; i++)
            {
                bool isOk = false;

                while (!isOk)
                {
                    int r = random.Next(0, rowCount - 1);
                    int c = random.Next(0, colCount - 1);
                    if (cells[r, c].State != CellState.Opened && !cells[r, c].Mined)
                    {
                        cells[r, c].Mined = true;

                        isOk = true;
                    }
                }
            }

        }

        public void NextCellMark(int row, int column)
        {
            if (cells[row, column] != null)
                cells[row, column].NextMark();
        }
    }
}
