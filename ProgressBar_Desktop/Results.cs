using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar_Desktop
{
    public partial class Results : Form
    {
        private const int LEVEL_SCORE_MULTIPLIER = 50;
        private const int CLOSED_POPUP_COST = 5;
        private const int EMPTY_SEGMENTS_COST = 2500;
        private const int MINUS_SEGMENTS_COST = 4000;
        private const int EXTRA_PRECENT_COST = 200;
        private const int PERFECTIONIST_COST = 1500;
        private const int ONE_ORANGE_COST = 750;
        private const int YING_YANG_COST = 1250;

        private int totalScore = 0;
        private Dictionary<string, int> strings = new Dictionary<string, int>();
        private Dictionary<string, int>.Enumerator stringsEnumerator;
        private int _score = 0;

        public Results(ResultsObj stats)
        {
            InitializeComponent();
            if (stats.IsEmptySegments || stats.IsMinusSegments)
            {
                stats.BlueSegments = 100 / Config.SegmentValue;

            }
            var proc = (int) ((float) stats.BlueSegments / (stats.BlueSegments + stats.OrangeSegments) * 100);
            var extra_precent = EXTRA_PRECENT_COST * Math.Max(stats.BlueSegments - 100 / Config.SegmentValue, 0);

            progressBar.Value = proc;
            totalScore +=
                progressBar.Value * LEVEL_SCORE_MULTIPLIER
                + stats.ClosedPopupsCount * CLOSED_POPUP_COST
                + (stats.IsEmptySegments ? EMPTY_SEGMENTS_COST : stats.IsMinusSegments ? MINUS_SEGMENTS_COST : 0) + extra_precent 
                + (stats.OrangeSegments == 0 && !stats.IsMinusSegments && !stats.IsEmptySegments ? PERFECTIONIST_COST : 0)
                + (stats.OrangeSegments == 1 ? ONE_ORANGE_COST : 0)
                + (stats.OrangeSegments == stats.BlueSegments ? YING_YANG_COST : 0);

            strings.Add("Очки за уровень: {0}", progressBar.Value * LEVEL_SCORE_MULTIPLIER);
            if(stats.ClosedPopupsCount > 0) strings.Add("Закрыто " + stats.ClosedPopupsCount + " поп-апов: {0}", stats.ClosedPopupsCount * CLOSED_POPUP_COST);
            if (stats.IsEmptySegments) strings.Add("Пустота: {0}", EMPTY_SEGMENTS_COST);
            if (stats.IsMinusSegments) strings.Add("Отрицательно: {0}", MINUS_SEGMENTS_COST);
            if (stats.BlueSegments > 100 / Config.SegmentValue) strings.Add("Экстра-проценты: {0}", extra_precent);
            if (stats.OrangeSegments == 0 && !stats.IsMinusSegments && !stats.IsEmptySegments)
                strings.Add("Перфекционист: {0}", PERFECTIONIST_COST);
            if (stats.OrangeSegments == 1) strings.Add("95%: {0}", ONE_ORANGE_COST);
            if (stats.OrangeSegments == stats.BlueSegments) strings.Add("Инь-янь: {0}", YING_YANG_COST);

            stringsEnumerator = strings.GetEnumerator();
            stringsEnumerator.MoveNext();

            statsLabel.Text = string.Format(statsLabel.Text, stats.BlueSegments, stats.OrangeSegments, progressBar.Value);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            Close();
            if (!Config.IsCustomGame)
            {
                Config.Level++;
                Config.Score += totalScore;
            }
                
        }

        private void scoreTimer_Tick(object sender, EventArgs e)
        {
            var element = stringsEnumerator.Current;
            _score += Math.Min(_score > 1000 ? 100 : _score > 300 ? 10 : 5, element.Value - _score);
            if (_score >= element.Value)
            {
                if (!stringsEnumerator.MoveNext())
                {
                    scoreLabel.Text = "";
                    scoreTimer.Stop();
                    foreach (var item in strings)
                    {
                        scoreLabel.Text += string.Format(item.Key, item.Value) + '\n';
                        _score += item.Value;
                    }
                    scoreLabel.Text += $"Итого: {totalScore}";
                    return;
                }
                _score = 0;
            }
            scoreLabel.Text = string.Format(element.Key, _score);
        }
    }

    public class ResultsObj
    {
        public int BlueSegments { get; set; }
        public int OrangeSegments { get; set; }
        public bool IsMinusSegments { get; set; }
        public bool IsEmptySegments { get; set; }
        public int ClosedPopupsCount { get; set; }

        public ResultsObj(int blue, int orange, int closedPopupsCount)
        {
            BlueSegments = blue;
            OrangeSegments = orange;
            ClosedPopupsCount = closedPopupsCount;
        }
    }
}
