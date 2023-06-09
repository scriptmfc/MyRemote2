﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyRemote2.MacroPlusFold.ModuleFold.DebugModuleFold.FormFold
{
    public static class SimpleConsoleDebug
    {
        static readonly string scriptname = "SimpleConsoleDebug";

        public static void SimpleDebugSetting()
        {
            //NotYet
            //Console.WriteLine("NotYet");
            //return;
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
            item.str = "consoleUtil.ConsoleW($\"{";
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
            item.str = "\",scriptname);";
            macrobox.MacroItemList.Add(item);
            /*
        item = new MacroItem();
        item.macroEnum = MacroEnum.WindowFunction;
        item.windowFunctionEnum = MacroItem.WindowFunctionEnum.ClipboardSetting;
        string tmpStr = "consoleUtil.ConsoleW(" +
            "$\"{"+MacroPlus.ClipBoardGetTextStr+"} : "+
            MacroPlus.ClipBoardGetTextStr + "\",scriptname);";
        item.SetClipboardSettingStr(tmpStr);
        macrobox.MacroItemList.Add(item);

        consoleUtil.ConsoleW($"{item}:item", scriptname);
            */



#if false
            WindowRobotFold.WorkFold.WindowFunctionWork.WindowCopy();
#endif
            //WindowRobotFold.WorkFold.WindowFunctionWork.ClipboardPaste();

            UTIL.CollectCon.Dict.Set_IfNotExistAdd(MacroPlus.MacroBoxDict, 
                "SimpleDebugConsole", macrobox);
        }

    }
}
