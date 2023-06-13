using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyRemote2.MacroPlusFold.ModuleFold.FastCodeModuleFold
{
    public static class FastCodeSimple
    {
        static readonly string scriptname = "FastCodeSimple";

        public static void For_SimpleSetting()
        {
            string FullStr;

            MacroPlusFold.MacroBox macrobox = new MacroBox();

            MacroItem item;

            WindowRobotFold.WorkFold.WindowFunctionWork.WindowCopy();

            string TARGET = Clipboard.GetText();

            string LengthOrCount;
            if (TARGET.Contains("list") ||
                TARGET.Contains("List"))
                LengthOrCount = "Count";
            else
            {
                LengthOrCount = "Length";
            }

            string openmiddlebracket="{";
            string closemiddlebracket = "}";

            Clipboard.SetText(
                $"for(int i =0;i<{TARGET}.{LengthOrCount};i++)\n{openmiddlebracket}\n" +
                $"var tmpItem = {TARGET}[i];" +
                $"\n{closemiddlebracket}");


            item = new MacroItem();
            item.macroEnum = MacroEnum.KeyPress;
            item.key = System.Windows.Forms.Keys.Down;
            macrobox.MacroItemList.Add(item);


            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Paste;
            macrobox.MacroItemList.Add(item);


            UTIL.CollectCon.Dict.Set_IfNotExistAdd(MacroPlus.MacroBoxDict,
                "FastCodeSimple_[For]_SimpleSetting", macrobox);
        }

        public static void Switch_SimpleSetting()
        {
            string FullStr;

            MacroPlusFold.MacroBox macrobox = new MacroBox();

            MacroItem item;

            WindowRobotFold.WorkFold.WindowFunctionWork.WindowCopy();

            string TARGET = Clipboard.GetText();

            string DebugEnvironment;
            
            string ERRMessage = $"\"ERR_ Switch문_: [  ] \" + { TARGET}";
            if (MacroPlusFold.MacroPlus.selectedEnvironMentMode
                                == MacroPlusFold.MacroPlus.EnvironMentMode.CONSOLE)
            {
                DebugEnvironment = $"\nConsole.WriteLine({ERRMessage});";
            }
            else if (MacroPlusFold.MacroPlus.selectedEnvironMentMode
                == MacroPlusFold.MacroPlus.EnvironMentMode.UNITY)
            {
                DebugEnvironment = $"\nDebug.Log({ERRMessage});";
            }
            else
            {
                DebugEnvironment = "ERR_ [Switch_SimpleSetting] " + MacroPlusFold.MacroPlus.selectedEnvironMentMode;
                Console.WriteLine("ERR_ [Switch_SimpleSetting] " + MacroPlusFold.MacroPlus.selectedEnvironMentMode);
            }
            string openmiddlebracket = "{";
            string closemiddlebracket = "}";

            Clipboard.SetText(
                $"switch({TARGET})" +
                $"\n{openmiddlebracket}" +
                $"\ncase CASEVALUE:" +
                $"\nbreak;" +
                $"\ndefault:" +
                $"{DebugEnvironment}" +
                $"\nbreak;" +
                $"\n{closemiddlebracket}");


            item = new MacroItem();
            item.macroEnum = MacroEnum.KeyPress;
            item.key = System.Windows.Forms.Keys.Down;
            macrobox.MacroItemList.Add(item);


            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Paste;
            macrobox.MacroItemList.Add(item);


            UTIL.CollectCon.Dict.Set_IfNotExistAdd(MacroPlus.MacroBoxDict,
                "FastCodeSimple_[Switch]_SimpleSetting", macrobox);
        }
    }
}
