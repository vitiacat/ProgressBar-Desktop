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

namespace ProgressBar_Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Config.Level = Properties.Settings.Default.Level;
            Config.Score = Properties.Settings.Default.Score;
            UpdateLevelInfo();
        }

        public void UpdateLevelInfo()
        {
            startNormalGameButton.Enabled = Program.Levels.IsValid && Program.Levels.LevelsCount >= Config.Level;
            startNormalGameButton.Text = "Уровень " + Config.Level;
            scoreLabel.Text = "Очков: " + Config.Score;
        }

        private void segmentSpeed_ValueChanged(object sender, EventArgs e)
        {
            segSpeedLabel.Text = "Скорость: " + segmentSpeed.Value / 10f;
        }

        private void segmentTime_ValueChanged(object sender, EventArgs e)
        {
            segTimeLabel.Text = "Время: " + segmentTime.Value;
        }

        private void popupTime_ValueChanged(object sender, EventArgs e)
        {
            popupTimeLabel.Text = "Время: " + popupTime.Value;
        }

        private void popupsMaxCount_ValueChanged(object sender, EventArgs e)
        {
            popupMaxCountLabel.Text = "Макс. кол-во: " + popupMaxCount.Value;
        }

        private void segmentFluctuation_ValueChanged(object sender, EventArgs e)
        {
            segmentFluctuationLabel.Text = "Колебания: " + segmentFluctuation.Value / 10f;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Config.SegmentSpeed = segmentSpeed.Value / 10f; 
            Config.SegmentTime = segmentTime.Value;
            Config.SegmentFluctuation = segmentFluctuation.Value / 10f;
            Config.PopupTime = popupTime.Value;
            Config.PopupsMaxCount = popupMaxCount.Value;
            Config.SegmentValue = 5;
            Config.IsPopupsEnabled = popupEnabled.Checked;
            Config.IsCustomGame = true;
            Config.Segments = Enum.GetValues(typeof(SegmentType)).OfType<SegmentType>().ToList();
            Hide();
            new Game().ShowDialog();
            Show();
            Config.IsCustomGame = false;
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Level = Config.Level;
            Properties.Settings.Default.Score = Config.Score;
            Properties.Settings.Default.Save();
        }

        private void startNormalGameButton_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if(MessageBox.Show("Сбросить уровень?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config.Level = 1;
                    startNormalGameButton.Text = "Уровень " + Config.Level;
                    SaveSettings();
                }
            }
            if(e.Button == MouseButtons.Left)
            {
                Config.IsCustomGame = false;
                if (Program.Levels.LoadLevel(Config.Level))
                {
                    Hide();
                    new Game().ShowDialog();
                    Show();
                    UpdateLevelInfo();
                    SaveSettings();
                }
            }
        }

        private void aboutGameButton_Click(object sender, EventArgs e)
        {
            new AboutGame().ShowDialog();
        }
    }
}
