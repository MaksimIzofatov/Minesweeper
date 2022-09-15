using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineswepperMVC
{
    public partial class MinesweeperView : Form
    {
        private class ButtonCell : Button
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public bool Block { get; set; } = false;
        }

        private MinesweeperModel _model;
        private MinesweeperController _controller;

        private ButtonCell[,] _buttons;

        public MinesweeperView(MinesweeperModel model, MinesweeperController controller)
        {
            InitializeComponent();

            _model = model;
            _controller = controller;
            controller.View = this;

            _buttons = new ButtonCell[model.RowCount, model.ColumnCount];
            for (int i = 0; i < _buttons.GetLength(0); i++)
            {
                for (int j = 0; j < _buttons.GetLength(1); j++)
                {
                    _buttons[i, j] = new ButtonCell
                    {
                        Row = i,
                        Column = j
                    };
                    _buttons[i, j].Height = 40;
                    _buttons[i, j].Width = 40;
                    _buttons[i, j].Location = new Point(i * 40, j * 40);

                    _buttons[i, j].MouseDown += MinesweeperView_MouseClick;
                    Controls.Add(_buttons[i, j]);
                }
            }

            //ShowAllMines();
        }



        private void MinesweeperView_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonCell btn = sender as ButtonCell;


            if (e.Button == MouseButtons.Left && !btn.Block)
            {
                _controller.OnLeftClick(btn.Row, btn.Column);
                //ShowAllMines();
            }
            else
                 if (e.Button == MouseButtons.Right)
            {
                _controller.OnRightClick(btn.Row, btn.Column);
            }
        }

        //для отладки
        private void ShowAllMines()
        {
            for (int i = 0; i < _model.RowCount; i++)
            {
                for (int j = 0; j < _model.ColumnCount; j++)
                {
                    MinesweeperCell c = _model.GetCell(i, j);
                    if (c.Mined)
                    {
                        _buttons[i, j].BackColor = Color.Black;
                    }
                }
            }
        }

        internal void ClearBoard()
        {
            for (int i = 0; i < _model.RowCount; i++)
            {
                for (int j = 0; j < _model.ColumnCount; j++)
                {
                    _buttons[i, j].BackColor = Button.DefaultBackColor;
                    _buttons[i, j].Text = "";
                    _buttons[i, j].Block = false;
                }
            }
        }
        internal void SyncWithModel()
        {
            for (int i = 0; i < _model.RowCount; i++)
            {
                for (int j = 0; j < _model.ColumnCount; j++)
                {
                    MinesweeperCell c = _model.GetCell(i, j);
                    if (c != null)
                    {
                        Button btn = _buttons[i, j];
                        if (_model.IsGameOver() && c.Mined)
                        {
                            btn.BackColor = Color.Black;
                            btn.Text = "";
                        }
                        if (c.State == CellState.Closed)
                        {
                            btn.Text = "";
                        }
                        else if (c.State == CellState.Opened)
                        {
                            btn.Text = "";
                            btn.BackColor = Color.LightGray;
                            btn.ForeColor = Color.Red;
                            if (c.Counter > 0)
                            {
                                btn.Text = c.Counter.ToString();
                            }
                            else
                              if (c.Mined)
                            {
                                btn.BackColor = Color.Red;
                            }
                        }
                        else if (c.State == CellState.Flagged)
                        {
                            btn.Text = "P";

                        }
                        else if (c.State == CellState.Questioned)
                        {
                            btn.Text = "?";
                        }
                    }
                }
            }

        }

        internal void ShowWinMessage()
        {
            MessageBox.Show("Поздравляем!", "Вы победили!");
        }

        internal void ShowGameOverMessage()
        {
            MessageBox.Show("Игра окончена!", "Вы проиграли!");
        }

        internal void BlockCell(int row, int column, bool v = true)
        {

            ButtonCell btn = _buttons[row, column];
            if (btn == null)
                return;
            if (v)
                btn.Block = true;
            else
                btn.Block = false;

        }
    }
}
