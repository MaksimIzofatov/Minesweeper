using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineswepperMVC
{
    public class MinesweeperCell
    {
        //Возможные состояния игровой клетки:
        //closed - закрыта
        //opened - открыта
        //flagged - помечена флажком
        //questioned - помечена вопросительным знаком
        public int Row { get; set; }
        public int Column { get; set; }
        public CellState State { get; set; } = CellState.Closed;
        public bool Mined { get; set; } = false;
        public int Counter { get; set; } = 0;



        public void NextMark()
        {
            switch (State)
            {
                case CellState.Closed:
                    {
                        State = CellState.Flagged;
                        break;
                    }

                case CellState.Flagged:
                    {
                        State = CellState.Questioned;
                        break;
                    }
                case CellState.Questioned:
                    {
                        State = CellState.Closed;
                        break;
                    }

            }
        }

        public void Open()
        {
            if (State != CellState.Flagged)
                State = CellState.Opened;
        }
    }
}
