namespace SnakeGame
{
    partial class MainForm
    {
        /// <summary>
        ///  必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应处置托管资源，则为true；否则为假。</param>
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
        ///  设计器支持所需的方法-请勿修改
        ///  使用代码编辑器显示此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gamePanel = new Panel();
            scoreLabel = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            score = new Label();
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.BackColor = SystemColors.ActiveCaptionText;
            gamePanel.Location = new Point(100, 50);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(600, 400);
            gamePanel.TabIndex = 0;
            gamePanel.Paint += gamePanel_Paint;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(100, 12);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(94, 35);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "Score:";
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 200;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // score
            // 
            score.AutoSize = true;
            score.Location = new Point(191, 12);
            score.Name = "score";
            score.Size = new Size(31, 35);
            score.TabIndex = 2;
            score.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(16F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 521);
            Controls.Add(score);
            Controls.Add(scoreLabel);
            Controls.Add(gamePanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "贪吃蛇";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel gamePanel;
        private Label scoreLabel;
        private System.Windows.Forms.Timer gameTimer;
        private Label score;
    }
}
