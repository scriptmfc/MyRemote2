using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2.MacroPlusFold.ModuleFold.DebugModuleFold.FormFold
{
    public static class SimpleConsoleDebug
    {
        public static void SimpleDebugSetting()
        {
            //NotYet
            MacroPlusFold.MacroBox macrobox = new MacroBox();
            /*
            MacroItem item = new MacroItem();
            item.macroEnum = MacroEnum.CustomMacro.

            macrobox.MacroItemList.Add();

            WindowRobotFold.WorkFold.WindowFunctionWork.WindowCopy();
            WindowRobotFold.WorkFold.WindowFunctionWork.ClipboardPaste();
            */
            UTIL.CollectCon.Dict.Set_IfNotExistAdd(MacroPlus.MacroBoxDict, "SimpleDebug", macrobox);
        }

    }
}
