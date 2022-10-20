using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MineswepperMVC
{
    public partial class MinesweeperView : Form
    {
        private const int MARGIN = 30;
        private int _mineCounter;
        private class ButtonCell : Button
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public bool Block { get; set; } = false;
        }

        private MinesweeperModel _model;
        private MinesweeperController _controller;

        private ButtonCell[,] _buttons;

        private DateTime _time;

        public MinesweeperView(MinesweeperModel model, MinesweeperController controller)
        {
            InitializeComponent();

            _model = model;
            _controller = controller;
            controller.View = this;
            
            FillButtons();

            //ShowAllMines();
        }

        private void FillButtons()
        {
            Controls.Clear();
            Controls.Add(Menu);
            Controls.Add(Status);

            _buttons = new ButtonCell[_model.RowCount, _model.ColumnCount];
            for (int i = 0; i < _buttons.GetLength(0); i++)
            {
                for (int j = 0; j < _buttons.GetLength(1); j++)
                {
                    _buttons[i, j] = new ButtonCell
                    {
                        Row = i,
                        Column = j
                    };
                    _buttons[i, j].Height = 30;
                    _buttons[i, j].Width = 30;
                    _buttons[i, j].Location = new Point(i * 30 + MARGIN, j * 30 + MARGIN);

                    _buttons[i, j].MouseDown += MinesweeperView_MouseClick;
                    Controls.Add(_buttons[i, j]);
                }
            }
            Width = (_model.RowCount + 1) * 30 + MARGIN;
            Height = (_model.ColumnCount + 1) * 30 + MARGIN * 3;
            _mineCounter = _model.MineCount;
            AmountMineSL.Text = "Осталось мин: " + _mineCounter;
            _time = new DateTime(0001, 1, 1, 0, 0, 0);
            TimerSL.Text = string.Format("Time: {0:0#}:{1:0#}", _time.Minute, _time.Second);
        }

        private void MinesweeperView_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonCell btn = sender as ButtonCell;
            if (_model.FirstStep)
                Timer.Start();
            if (e.Button == MouseButtons.Left && !btn.Block)
            {
                _controller.OnLeftClick(btn.Row, btn.Column);
                //ShowAllMines();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (btn.Block)
                    AmountMineSL.Text = "Осталось мин: " + (++_mineCounter);
                else
                    AmountMineSL.Text = "Осталось мин: " + (--_mineCounter);
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
                    _buttons[i, j].BackColor = Color.White;
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
                            btn.Font = new Font("Arial", 12, FontStyle.Bold);
                            switch (c.Counter)
                            {
                                case 1: btn.ForeColor = Color.Blue; break;
                                case 2: btn.ForeColor = Color.Green; break;
                                case 3: btn.ForeColor = Color.Red; break;
                                case 4: btn.ForeColor = Color.DarkViolet; break;
                                case 5: btn.ForeColor = Color.DarkOrange; break;
                                case 6: btn.ForeColor = Color.Brown; break;
                                default: break;
                            }
                            if (c.Counter > 0)
                            {
                                btn.Text = c.Counter.ToString();
                            }
                            else if (c.Mined)
                            {
                                btn.BackColor = Color.Red;
                            }
                        }
                        else if (c.State == CellState.Flagged)
                        {
                            btn.Font = new Font("Arial", 12, FontStyle.Bold);
                            btn.ForeColor = Color.IndianRed;
                            btn.Text = "P";
                        }
                    }
                }
            }
        }

        internal void ShowWinMessage()
        {
            Timer.Stop();
            _time = new DateTime(0001, 1, 1, 0, 0, 0);
            MessageBox.Show("Поздравляем!", "Вы победили!");
            TimerSL.Text = string.Format("Time: {0:0#}:{1:0#}", _time.Minute, _time.Second);
        }

        internal void ShowGameOverMessage()
        {
            Timer.Stop();
            _time = new DateTime(0001, 1, 1, 0, 0, 0);
            MessageBox.Show("Игра окончена!", "Вы проиграли!");
            TimerSL.Text = string.Format("Time: {0:0#}:{1:0#}", _time.Minute, _time.Second);
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

        private void CloseTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewGameTSMI_Click(object sender, EventArgs e)
        {
            _controller.StartNewGame();
        }

        private void EasyModeTSMI_Click(object sender, EventArgs e)
        {
            _model.SetGameMode(GameMode.Easy);
            FillButtons();
            _controller.StartNewGame();
        }

        private void MediumModeTSMI_Click(object sender, EventArgs e)
        {
            _model.SetGameMode(GameMode.Medium);
            FillButtons();
            _controller.StartNewGame();
        }

        private void HardModeTSMI_Click(object sender, EventArgs e)
        {
            _model.SetGameMode(GameMode.Hard);
            FillButtons();
            _controller.StartNewGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _time = _time.AddSeconds(1);
            TimerSL.Text = string.Format("Time: {0:0#}:{1:0#}", _time.Minute, _time.Second);
        }
    }
}
