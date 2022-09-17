namespace ProgressBar_Desktop
{
    partial class Menu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.segTimeLabel = new System.Windows.Forms.Label();
            this.segmentTime = new System.Windows.Forms.TrackBar();
            this.segSpeedLabel = new System.Windows.Forms.Label();
            this.segmentSpeed = new System.Windows.Forms.TrackBar();
            this.startGameButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.popupMaxCountLabel = new System.Windows.Forms.Label();
            this.popupMaxCount = new System.Windows.Forms.TrackBar();
            this.popupTimeLabel = new System.Windows.Forms.Label();
            this.popupTime = new System.Windows.Forms.TrackBar();
            this.startNormalGameButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.segmentFluctuationLabel = new System.Windows.Forms.Label();
            this.popupEnabled = new System.Windows.Forms.CheckBox();
            this.segmentFluctuation = new System.Windows.Forms.TrackBar();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.aboutGameButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMaxCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentFluctuation)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.segTimeLabel);
            this.groupBox1.Controls.Add(this.segmentTime);
            this.groupBox1.Controls.Add(this.segSpeedLabel);
            this.groupBox1.Controls.Add(this.segmentSpeed);
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сегменты";
            // 
            // segTimeLabel
            // 
            this.segTimeLabel.AutoSize = true;
            this.segTimeLabel.Location = new System.Drawing.Point(7, 64);
            this.segTimeLabel.Name = "segTimeLabel";
            this.segTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.segTimeLabel.TabIndex = 3;
            this.segTimeLabel.Text = "Время: 35";
            // 
            // segmentTime
            // 
            this.segmentTime.Location = new System.Drawing.Point(10, 83);
            this.segmentTime.Maximum = 250;
            this.segmentTime.Minimum = 1;
            this.segmentTime.Name = "segmentTime";
            this.segmentTime.Size = new System.Drawing.Size(196, 45);
            this.segmentTime.TabIndex = 2;
            this.segmentTime.Value = 35;
            this.segmentTime.ValueChanged += new System.EventHandler(this.segmentTime_ValueChanged);
            // 
            // segSpeedLabel
            // 
            this.segSpeedLabel.AutoSize = true;
            this.segSpeedLabel.Location = new System.Drawing.Point(7, 16);
            this.segSpeedLabel.Name = "segSpeedLabel";
            this.segSpeedLabel.Size = new System.Drawing.Size(76, 13);
            this.segSpeedLabel.TabIndex = 1;
            this.segSpeedLabel.Text = "Скорость: 2.5";
            // 
            // segmentSpeed
            // 
            this.segmentSpeed.Location = new System.Drawing.Point(10, 32);
            this.segmentSpeed.Maximum = 400;
            this.segmentSpeed.Minimum = 10;
            this.segmentSpeed.Name = "segmentSpeed";
            this.segmentSpeed.Size = new System.Drawing.Size(196, 45);
            this.segmentSpeed.TabIndex = 0;
            this.segmentSpeed.Value = 25;
            this.segmentSpeed.ValueChanged += new System.EventHandler(this.segmentSpeed_ValueChanged);
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(454, 325);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(123, 23);
            this.startGameButton.TabIndex = 1;
            this.startGameButton.Text = "Начать игру";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.popupMaxCountLabel);
            this.groupBox2.Controls.Add(this.popupMaxCount);
            this.groupBox2.Controls.Add(this.popupTimeLabel);
            this.groupBox2.Controls.Add(this.popupTime);
            this.groupBox2.Location = new System.Drawing.Point(293, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 164);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поп-апы";
            // 
            // popupMaxCountLabel
            // 
            this.popupMaxCountLabel.AutoSize = true;
            this.popupMaxCountLabel.Location = new System.Drawing.Point(3, 78);
            this.popupMaxCountLabel.Name = "popupMaxCountLabel";
            this.popupMaxCountLabel.Size = new System.Drawing.Size(91, 13);
            this.popupMaxCountLabel.TabIndex = 5;
            this.popupMaxCountLabel.Text = "Макс. кол-во: 20";
            // 
            // popupMaxCount
            // 
            this.popupMaxCount.Location = new System.Drawing.Point(6, 97);
            this.popupMaxCount.Maximum = 100;
            this.popupMaxCount.Minimum = 1;
            this.popupMaxCount.Name = "popupMaxCount";
            this.popupMaxCount.Size = new System.Drawing.Size(196, 45);
            this.popupMaxCount.TabIndex = 4;
            this.popupMaxCount.Value = 20;
            this.popupMaxCount.ValueChanged += new System.EventHandler(this.popupsMaxCount_ValueChanged);
            // 
            // popupTimeLabel
            // 
            this.popupTimeLabel.AutoSize = true;
            this.popupTimeLabel.Location = new System.Drawing.Point(3, 13);
            this.popupTimeLabel.Name = "popupTimeLabel";
            this.popupTimeLabel.Size = new System.Drawing.Size(64, 13);
            this.popupTimeLabel.TabIndex = 3;
            this.popupTimeLabel.Text = "Время: 100";
            // 
            // popupTime
            // 
            this.popupTime.Location = new System.Drawing.Point(6, 32);
            this.popupTime.Maximum = 500;
            this.popupTime.Minimum = 1;
            this.popupTime.Name = "popupTime";
            this.popupTime.Size = new System.Drawing.Size(196, 45);
            this.popupTime.TabIndex = 2;
            this.popupTime.Value = 100;
            this.popupTime.ValueChanged += new System.EventHandler(this.popupTime_ValueChanged);
            // 
            // startNormalGameButton
            // 
            this.startNormalGameButton.Location = new System.Drawing.Point(325, 325);
            this.startNormalGameButton.Name = "startNormalGameButton";
            this.startNormalGameButton.Size = new System.Drawing.Size(123, 23);
            this.startNormalGameButton.TabIndex = 5;
            this.startNormalGameButton.Text = "Уровень 1";
            this.startNormalGameButton.UseVisualStyleBackColor = true;
            this.startNormalGameButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startNormalGameButton_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.segmentFluctuationLabel);
            this.groupBox3.Controls.Add(this.popupEnabled);
            this.groupBox3.Controls.Add(this.segmentFluctuation);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(548, 220);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Своя игра";
            // 
            // segmentFluctuationLabel
            // 
            this.segmentFluctuationLabel.AutoSize = true;
            this.segmentFluctuationLabel.Location = new System.Drawing.Point(23, 134);
            this.segmentFluctuationLabel.Name = "segmentFluctuationLabel";
            this.segmentFluctuationLabel.Size = new System.Drawing.Size(74, 13);
            this.segmentFluctuationLabel.TabIndex = 5;
            this.segmentFluctuationLabel.Text = "Колебания: 4";
            // 
            // popupEnabled
            // 
            this.popupEnabled.AutoSize = true;
            this.popupEnabled.Location = new System.Drawing.Point(293, 189);
            this.popupEnabled.Name = "popupEnabled";
            this.popupEnabled.Size = new System.Drawing.Size(69, 17);
            this.popupEnabled.TabIndex = 6;
            this.popupEnabled.Text = "Поп-апы";
            this.popupEnabled.UseVisualStyleBackColor = true;
            // 
            // segmentFluctuation
            // 
            this.segmentFluctuation.Location = new System.Drawing.Point(26, 153);
            this.segmentFluctuation.Maximum = 400;
            this.segmentFluctuation.Name = "segmentFluctuation";
            this.segmentFluctuation.Size = new System.Drawing.Size(196, 45);
            this.segmentFluctuation.TabIndex = 4;
            this.segmentFluctuation.Value = 40;
            this.segmentFluctuation.ValueChanged += new System.EventHandler(this.segmentFluctuation_ValueChanged);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(12, 334);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(50, 13);
            this.scoreLabel.TabIndex = 7;
            this.scoreLabel.Text = "Очков: 0";
            // 
            // aboutGameButton
            // 
            this.aboutGameButton.Location = new System.Drawing.Point(196, 324);
            this.aboutGameButton.Name = "aboutGameButton";
            this.aboutGameButton.Size = new System.Drawing.Size(123, 23);
            this.aboutGameButton.TabIndex = 8;
            this.aboutGameButton.Text = "О игре";
            this.aboutGameButton.UseVisualStyleBackColor = true;
            this.aboutGameButton.Click += new System.EventHandler(this.aboutGameButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 360);
            this.Controls.Add(this.aboutGameButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.startNormalGameButton);
            this.Controls.Add(this.startGameButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "ProgressBar: Desktop";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMaxCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentFluctuation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label segSpeedLabel;
        private System.Windows.Forms.TrackBar segmentSpeed;
        private System.Windows.Forms.Label segTimeLabel;
        private System.Windows.Forms.TrackBar segmentTime;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label popupTimeLabel;
        private System.Windows.Forms.TrackBar popupTime;
        private System.Windows.Forms.Label popupMaxCountLabel;
        private System.Windows.Forms.TrackBar popupMaxCount;
        private System.Windows.Forms.Button startNormalGameButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox popupEnabled;
        private System.Windows.Forms.Label segmentFluctuationLabel;
        private System.Windows.Forms.TrackBar segmentFluctuation;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button aboutGameButton;
    }
}