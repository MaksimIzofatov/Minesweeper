using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineswepperMVC
{
    public class MinesweeperModel
    {
        private int _rowCount;
        private int _colCount;
        private int _mineCount;

        private MinesweeperCell[,] _cells;
        private Random _r = new Random();

        private bool _firstStep;
        private bool _gameOver;

        public int RowCount => _rowCount;
        public int ColumnCount => _colCount;
        public int MineCount => _mineCount;
        public bool FirstStep => _firstStep;
       
        public MinesweeperModel()
        {
            SetGameMode(GameMode.Easy);
            StartGame();
        }

        public void SetGameMode(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.Easy:
                    _rowCount = 9;
                    _colCount = 9;
                    _mineCount = 10;
                    _cells = new MinesweeperCell[_rowCount, _colCount];
                    break;
                case GameMode.Medium:
                    _rowCount = 16;
                    _colCount = 16;
                    _mineCount = 40;
                    _cells = new MinesweeperCell[_rowCount, _colCount];
                    break;
                case GameMode.Hard:
                    _rowCount = 22;
                    _colCount = 22;
                    _mineCount = 99;
                    _cells = new MinesweeperCell[_rowCount, _colCount];
                    break;
            }
        }

        public void StartGame()
        {
            _firstStep = true;
            _gameOver = false;
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    _cells[i, j] = new MinesweeperCell { Row = i, Column = j };
                }
            }
            //GenerateMines();
        }



        public MinesweeperCell GetCell(int row, int column)
        {
            if (row < 0 || row >= _rowCount || column < 0 || column >= _colCount)
                return null;
            return _cells[row, column];
        }

        public bool IsWin()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    if (!_cells[i, j].Mined && (_cells[i, j].State != CellState.Opened))//&& cells[i, j].State != CellState.Flagged
                        return false;
                }

            }
            return true;
        }

        public bool IsGameOver() => _gameOver;



        public void OpenCell(int row, int column)
        {
            MinesweeperCell cell = _cells[row, column];
            if (cell == null)
                return;
            cell.Open();
            if (cell.Mined)
            {
                _gameOver = true;
                return;
            }
            if (_firstStep)
            {
                _firstStep = false;
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

            for (int i = 0; i < _mineCount; i++)
            {
                bool isOk = false;

                while (!isOk)
                {
                    int r = _r.Next(0, _rowCount - 1);
                    int c = _r.Next(0, _colCount - 1);
                    if (_cells[r, c].State != CellState.Opened && !_cells[r, c].Mined)
                    {
                        _cells[r, c].Mined = true;

                        isOk = true;
                    }
                }
            }

        }

        public void NextCellMark(int row, int column)
        {
            if (_cells[row, column] != null)
                _cells[row, column].NextMark();
        }
    }
}
