namespace ProgressBar_Desktop
{
    partial class Results
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
            this.label1 = new System.Windows.Forms.Label();
            this.statsLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.nextButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Уровень пройден!";
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statsLabel.Location = new System.Drawing.Point(47, 47);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(193, 60);
            this.statsLabel.TabIndex = 1;
            this.statsLabel.Text = "Синих сегментов: {0}\r\nОранжевых сегментов: {1}\r\nИтого: {2}%";
            this.statsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(34, 113);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(219, 23);
            this.progressBar.TabIndex = 3;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(34, 313);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(219, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Дальше";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.Location = new System.Drawing.Point(49, 145);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 20);
            this.scoreLabel.TabIndex = 5;
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreTimer
            // 
            this.scoreTimer.Enabled = true;
            this.scoreTimer.Interval = 30;
            this.scoreTimer.Tick += new System.EventHandler(this.scoreTimer_Tick);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 366);
            this.ControlBox = false;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Results";
            this.Text = "Результаты";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer scoreTimer;
    }
}