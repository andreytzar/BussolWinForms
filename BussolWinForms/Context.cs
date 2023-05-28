using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BussolWinForms
{
    public static class Context
    {
        const string file = "settings.xml";
        public static Settings Settings { get; set; } = new();

        public static void Load()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Settings));
                using var steam = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read);
                Settings = serializer.Deserialize(steam) as Settings;
                if (Settings == null) Settings = new();
            }
            catch  { Settings = new(); }
        }

        public static void Save()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Settings));
                using var steam = new FileStream(file, FileMode.Truncate);
                serializer.Serialize(steam, Settings);
            }
            catch { Settings = new(); }
        }
    }

    public class Settings
    {
        public Point PanelLocation { get; set; }=new Point();
        public List<Bussol> Bussols { get; set; } = new();
    }

}
