using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2.Extend.WriteText
{
    public static class SaveLoad
    {
        static string Folder = "WriteText/";
        public static void LoadData(string filename)
        {
            string filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/SAVE/"
                + Folder + filename + ".txt";
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                ThisFunction.MacroItemList = JsonConvert.DeserializeObject<List<MacroItem>>(json);
                WriteTextWindow.Instance.ItemToListNameWhenLoad();
            }
        }

        public static void SaveData(string filename)
        {

            string filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/SAVE/"
                + Folder + filename + ".txt";
            Console.WriteLine(filepath);

            string json = JsonConvert.SerializeObject(ThisFunction.MacroItemList, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

    }
}
