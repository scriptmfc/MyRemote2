using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyRemote2.MacroPlusFold.ModuleFold.DebugModuleFold.FormFold
{
    public static class SimpleConsoleDebug
    {
        public static void SimpleDebugSetting()
        {
            //NotYet
            MacroPlusFold.MacroBox macrobox = new MacroBox();

            MacroItem item;

            string copystr=Clipboard.GetText();

            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Copy;
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Copy;
            macrobox.MacroItemList.Add(item);
           



            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.ClipboardSetting;
            item.SetClipboardSettingStr();
            macrobox.MacroItemList.Add(item);

#if false
            WindowRobotFold.WorkFold.WindowFunctionWork.WindowCopy();
#endif
            //WindowRobotFold.WorkFold.WindowFunctionWork.ClipboardPaste();
            
            UTIL.CollectCon.Dict.Set_IfNotExistAdd(MacroPlus.MacroBoxDict, "SimpleDebug", macrobox);
        }

    }
}
