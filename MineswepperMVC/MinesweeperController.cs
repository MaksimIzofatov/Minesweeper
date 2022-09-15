using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineswepperMVC
{
    public class MinesweeperController
    {
        public MinesweeperModel Model { get; set; }
        public MinesweeperView View { get; set; }

        public void StartNewGame()
        {
            Model.StartGame();
            View.ClearBoard();
        }

        public void OnLeftClick(int row, int column)
        {
            Model.OpenCell(row, column);
            View.SyncWithModel();
            if (Model.IsWin())
            {
                View.ShowWinMessage();
                StartNewGame();
            }
            else
                if (Model.IsGameOver())
            {
                View.ShowGameOverMessage();
                StartNewGame();
            }
        }

        public void OnRightClick(int row, int column)
        {
            Model.NextCellMark(row, column);

            View.BlockCell(row, column,
                Model.GetCell(row, column).State == CellState.Flagged);
            View.SyncWithModel();
        }
    }
}
