using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar_Desktop
{
    public class Config
    {
        public static float SegmentSpeed { get; set; } = 2.5f;
        public static int SegmentTime { get; set; } = 120;
        public static int SegmentValue { get; set; } = 5;
        public static float SegmentFluctuation { get; set; } = 0f;
        public static int PopupTime { get; set; } = 0;
        public static bool IsPopupsEnabled { get; set; } = false;
        public static int PopupsMaxCount { get; set; } = 20;
        public static List<SegmentType> Segments { get; set; } = new List<SegmentType>();
        public static bool IsCustomGame { get; set; } = false;
        public static bool IsInvulnerable { get; set; } = false;
        public static int Level { get; set; } = 13;
        public static int Score { get; set; } = 0;
    }
}
