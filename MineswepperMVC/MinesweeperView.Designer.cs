namespace MineswepperMVC
{
    partial class MinesweeperView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.NewGameTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.сложностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyModeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumModeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HardModeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.AmountMineSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimerSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Menu.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameTSMI,
            this.сложностьToolStripMenuItem,
            this.CloseTSMI});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(800, 28);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // NewGameTSMI
            // 
            this.NewGameTSMI.Name = "NewGameTSMI";
            this.NewGameTSMI.Size = new System.Drawing.Size(103, 24);
            this.NewGameTSMI.Text = "Новая игра";
            this.NewGameTSMI.Click += new System.EventHandler(this.NewGameTSMI_Click);
            // 
            // сложностьToolStripMenuItem
            // 
            this.сложностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyModeTSMI,
            this.MediumModeTSMI,
            this.HardModeTSMI});
            this.сложностьToolStripMenuItem.Name = "сложностьToolStripMenuItem";
            this.сложностьToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.сложностьToolStripMenuItem.Text = "Сложность";
            // 
            // EasyModeTSMI
            // 
            this.EasyModeTSMI.Name = "EasyModeTSMI";
            this.EasyModeTSMI.Size = new System.Drawing.Size(151, 26);
            this.EasyModeTSMI.Text = "Легкая";
            this.EasyModeTSMI.Click += new System.EventHandler(this.EasyModeTSMI_Click);
            // 
            // MediumModeTSMI
            // 
            this.MediumModeTSMI.Name = "MediumModeTSMI";
            this.MediumModeTSMI.Size = new System.Drawing.Size(151, 26);
            this.MediumModeTSMI.Text = "Средняя";
            this.MediumModeTSMI.Click += new System.EventHandler(this.MediumModeTSMI_Click);
            // 
            // HardModeTSMI
            // 
            this.HardModeTSMI.Name = "HardModeTSMI";
            this.HardModeTSMI.Size = new System.Drawing.Size(151, 26);
            this.HardModeTSMI.Text = "Тяжелая";
            this.HardModeTSMI.Click += new System.EventHandler(this.HardModeTSMI_Click);
            // 
            // CloseTSMI
            // 
            this.CloseTSMI.Name = "CloseTSMI";
            this.CloseTSMI.Size = new System.Drawing.Size(67, 24);
            this.CloseTSMI.Text = "Выход";
            this.CloseTSMI.Click += new System.EventHandler(this.CloseTSMI_Click);
            // 
            // Status
            // 
            this.Status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AmountMineSL,
            this.TimerSL});
            this.Status.Location = new System.Drawing.Point(0, 428);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(800, 22);
            this.Status.TabIndex = 1;
            this.Status.Text = "statusStrip1";
            // 
            // AmountMineSL
            // 
            this.AmountMineSL.Name = "AmountMineSL";
            this.AmountMineSL.Size = new System.Drawing.Size(0, 16);
            // 
            // TimerSL
            // 
            this.TimerSL.Name = "TimerSL";
            this.TimerSL.Size = new System.Drawing.Size(0, 16);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MinesweeperView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "MinesweeperView";
            this.Text = "MineswepperView";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip Menu;
        private ToolStripMenuItem NewGameTSMI;
        private ToolStripMenuItem сложностьToolStripMenuItem;
        private ToolStripMenuItem EasyModeTSMI;
        private ToolStripMenuItem MediumModeTSMI;
        private ToolStripMenuItem HardModeTSMI;
        private ToolStripMenuItem CloseTSMI;
        private StatusStrip Status;
        private ToolStripStatusLabel AmountMineSL;
        private ToolStripStatusLabel TimerSL;
        private System.Windows.Forms.Timer Timer;
    }
}