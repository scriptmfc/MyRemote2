using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyRemote2.MacroPlusFold.ModuleFold.DebugModuleFold.UnityFold
{
    public static class SimpleUnityDebug
    {
        static readonly string scriptname = "SimpleUnityDebug";

        public static void SimpleDebugSetting()
        {
            
            MacroPlusFold.MacroBox macrobox = new MacroBox();

            MacroItem item;


            Clipboard.Clear();
            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Copy;
            macrobox.MacroItemList.Add(item);



            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.GetClipboardText;
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.KeyPress;
            item.key = System.Windows.Forms.Keys.Down;
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.WriteText;
            item.str = "Debug.Log($\"{";
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Paste;
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.WriteText;
            item.str = "} : ";
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.WindowFunction;
            item.windowFunctionEnum = MacroItem.WindowFunctionEnum.Paste;
            macrobox.MacroItemList.Add(item);

            item = new MacroItem();
            item.macroEnum = MacroEnum.WriteText;
            item.str = "\");";
            //item.str = "\",scriptname);";
            macrobox.MacroItemList.Add(item);



            UTIL.CollectCon.Dict.Set_IfNotExistAdd(MacroPlus.MacroBoxDict,
                "SimpleDebugUnity", macrobox);
        }
    }
}
