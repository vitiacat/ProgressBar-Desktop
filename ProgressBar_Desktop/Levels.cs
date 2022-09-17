using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProgressBar_Desktop
{
    public class Levels
    {
        private XmlDocument doc = new XmlDocument();
        public bool IsValid { get; private set; } = false;
        public int LevelsCount { get { return doc.DocumentElement.GetElementsByTagName("level").Count; } }
        public Levels()
        {
            try
            {
                doc.Load("levels.xml");
                IsValid = true;
            } catch(FileNotFoundException)
            {
                MessageBox.Show("Не удалось найти файл levels.xml для загрузки уровней.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } catch(XmlException e)
            {
                MessageBox.Show("Ошибка парсинга XML: " + e.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public Level GetLevel(int id)
        {
            var levelNode = doc.DocumentElement.GetElementsByTagName("level").Cast<XmlNode>().FirstOrDefault(node => int.Parse(node.Attributes.GetNamedItem("id").Value) == id);
            if(levelNode == null)
            {
                return null;
            }
            var level = new Level()
            {
                Id = id,
                SegmentSpeed = GetAttribute(levelNode, "segmentSpeed", 1.25f),
                SegmentTime = GetAttribute(levelNode, "segmentTime", 40),
                SegmentValue = GetAttribute(levelNode, "segmentValue", 5),
                PopoutTime = GetAttribute(levelNode, "popoutTime", 0),
                PopoutsMaxCount = GetAttribute(levelNode, "popoutsMaxCount", 0),
                IsPopoutsEnabled = GetAttribute(levelNode, "isPopoutsEnabled", false),
                Segments = GetAttribute(levelNode, "segments", "GOOD").Split(',').Select(s => (SegmentType) Enum.Parse(typeof(SegmentType), s, true)).ToList(),
                SegmentFluctuation = GetAttribute(levelNode, "segmentFluctuation", 0f)
            };

            return level;
        }

        public bool LoadLevel(int id)
        {
            var level = GetLevel(id);
            if(level == null)
            {
                MessageBox.Show("Уровень не был найден.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            Config.Level = id;
            Config.SegmentSpeed = level.SegmentSpeed;
            Config.SegmentTime = level.SegmentTime;
            Config.SegmentValue = level.SegmentValue;
            Config.PopupTime = level.PopoutTime;
            Config.PopupsMaxCount = level.PopoutsMaxCount;
            Config.IsPopupsEnabled = level.IsPopoutsEnabled;
            Config.Segments = level.Segments;
            Config.SegmentFluctuation = level.SegmentFluctuation;
            return true;
        }

        private T GetAttribute<T>(XmlNode node, string name, T defaultValue)
        {
            if (node.Attributes[name] == null)
            {
                return defaultValue;
            }

            return (T)Convert.ChangeType(node.Attributes[name].Value, typeof(T));
        }
    }

    public class Level
    {
        public int Id { get; set; }
        public float SegmentSpeed { get; set; }
        public int SegmentTime { get; set; }
        public int SegmentValue { get; set; }
        public float SegmentFluctuation { get; set; }
        public int PopoutTime { get; set; }
        public bool IsPopoutsEnabled { get; set; }
        public int PopoutsMaxCount { get; set; }
        public List<SegmentType> Segments { get; set; }
    }
}
