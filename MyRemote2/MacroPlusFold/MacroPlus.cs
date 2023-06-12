using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2.MacroPlusFold
{
    public static class MacroPlus
    {
        public static Dictionary<string, MacroBox> MacroBoxDict = new Dictionary<string, MacroBox>();

        /// <summary>
        /// WindowFunctionEnum.GetClipboardText에서 가져온 거를 저장한 string
        /// </summary>
        public static string ClipBoardGetTextStr = "";


        public enum EnvironMentMode
        {
            CONSOLE,
            UNITY
        }

        public static EnvironMentMode selectedEnvironMentMode;

        public static void Init()
        {
            ModuleFold.DebugModuleFold.FormFold.SimpleConsoleDebug.SimpleDebugSetting();
            ModuleFold.DebugModuleFold.UnityFold.SimpleUnityDebug.SimpleDebugSetting();

        }


    }
}
