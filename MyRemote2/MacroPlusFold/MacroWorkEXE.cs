using MyRemote2.WindowRobotFold.WorkFold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRemote2.MacroPlusFold
{
    public static class MacroWorkEXE
    {

        public static void Process(MacroItem item)
        {
            switch (item.macroEnum)
            {
                case MacroEnum.KeyPress:
                    if (item.press꾹Key.Count == 0)
                    {
                        KeyWork.OneKeyInput_Press_Release(item.key);
                    }
                    else if (item.press꾹Key.Count == 1)
                    {
                        Console.WriteLine("아직 안했음-------");
                        //PressContinueKey(item.press꾹Key[0]);
                        //KeyPress(item.key);
                        //ReleaseKey(item.press꾹Key[0]);
                        //=>안되는 듯?

                        if (item.press꾹Key[0] == Keys.Shift)
                        {
                            //KeyWork.MultiKey_Input_Press_Release(item.press꾹Key.a)
                            //ShiftPressKey(item.key);
                        }
                        else if (item.press꾹Key[0] == Keys.Control)
                        {
                            //ControlPressKey(item.key);
                        }

                    }
                    break;
                case MacroEnum.WriteText:
                    WriteTextWork.WriteText(item.str);
                    break;
                case MacroEnum.MouseMove:
                    MouseWork.MouseMove(item.x, item.y);
                    break;
                case MacroEnum.MouseClick:
                    MouseWork.Click(MouseWork.MouseButtonNormalEnum.Left);
                    break;
                case MacroEnum.Wait:
                    Console.WriteLine("여기는 오면 안됨! Form1_Func.cs (MacroThread에서 직접처리)");
                    break;
                case MacroEnum.None:
                    break;
                case MacroEnum.WindowFunction:
                    switch (item.windowFunctionEnum)
                    {
                        case MacroItem.WindowFunctionEnum.Copy:
                            WindowFunctionWork.WindowCopy();
                            break;
                        case MacroItem.WindowFunctionEnum.Paste:
                            WindowFunctionWork.ClipboardPaste();
                            break;
                        case MacroItem.WindowFunctionEnum.ClipboardSetting:
                            if (string.IsNullOrEmpty(item.ClipboardSettingStr))
                            {
                                Console.WriteLine(item.macroEnum + ":MacroEnum 오류_WindowFunction_CopyStr");
                            }
                            else
                            {
                                WindowFunctionWork.ClipboardSetting(item.ClipboardSettingStr);
                            }
                            break;
                        case MacroItem.WindowFunctionEnum.GetClipboardText:
                            item.SetStr_FromClipboardGetText(
                                WindowFunctionWork.GetClipboardGetText());
                            break;
                        default:
                            Console.WriteLine(item.macroEnum + ":MacroEnum 오류_WindowFunction_Default");
                            break;
                    }
                    break;

                case MacroEnum.CustomMacro:

                    //if (item.CustomMacroCode == "testClipboard")
                    {
                        Console.WriteLine("ffasdasd아직 설정 xxx");
                        //WindowFunctionWork.ClipboardSetting("test333");
                        //WindowFunctionWork.ClipboardPaste();
                    }
                    break;
                default:
                    Console.WriteLine(item.macroEnum + ":MacroEnum 오류");
                    break;
            }
        }
    }
}
