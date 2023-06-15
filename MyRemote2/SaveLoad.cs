using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2
{
    public static class SaveLoad
    {

        public static void LoadData(string filename)
        {
            string filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"/SAVE/"
                +filename+".txt";
            Console.WriteLine("수정 SaveLoad.cs test");
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                Form1_Func.MacroItemList = JsonConvert.DeserializeObject<List<MacroItem>>(json);
                Form1.Instance.ItemToListNameWhenLoad("");

            }
        }

        public static void SaveData(string filename)
        {
            
            string filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/SAVE/"
                + filename + ".txt";
            Console.WriteLine(filepath);

            string json = JsonConvert.SerializeObject(Form1_Func.MacroItemList, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

    }
}
