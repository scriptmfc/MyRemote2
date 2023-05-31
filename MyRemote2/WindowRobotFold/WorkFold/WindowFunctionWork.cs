using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Clipboard = System.Windows.Clipboard;

namespace MyRemote2.WindowRobotFold.WorkFold
{
    public static class WindowFunctionWork
    {
        private const int WM_PASTE = 0x0302;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_RETURN = 0x0D;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowName);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        private static string GetWindowText(IntPtr hWnd)
        {
            const int maxLength = 512;
            var builder = new System.Text.StringBuilder(maxLength);
            GetWindowText(hWnd, builder, maxLength);
            return builder.ToString();
        }




        /// <summary>
        /// window창을 활성화 시킵니다.
        /// </summary>
        /// <param name="windowName"></param>
        public static void SetForegroundWindow(string windowName)
        {
            IntPtr targetHwnd = FindWindow(null, windowName);



            if (targetHwnd != IntPtr.Zero)
            {
                // 대상 창을 활성화합니다.
                SetForegroundWindow(targetHwnd);

                Console.WriteLine("Succeed 활성화");
            }
            else
            {

                Console.WriteLine($"ERR_ FindWindow Fail : " +
                    $"\r\n targetHwnd : {targetHwnd} " +
                    $"\r\n windowName : {windowName} ");
            }

        }

        public static void ClipboardSetting(string str)
        {
            Thread thread = new Thread(() =>
            {
                // 클립보드에 문자열 복사
                Clipboard.SetText(str);

                // 복사된 문자열 확인
                string clipboardText = Clipboard.GetText();

                if (clipboardText == str)
                {
                    Console.WriteLine("String successfully copied to clipboard: " + str);
                }
                else
                {
                    Console.WriteLine("Failed to copy string to clipboard: " + str);
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }


        public static string GetActiveWindowHandle()
        {
            string result;

            IntPtr activeWindowHandle = GetForegroundWindow();
            string activeWindowName = GetWindowText(activeWindowHandle);

            result = activeWindowName;

            return result;
        }

        public static void ClipboardPaste()
        {
            if (Clipboard.ContainsText())
            {
                // 붙여넣기를 실행할 대상 창을 확인합니다.
                //IntPtr visualStudioHwnd = FindWindow("MyRemote2 (실행) - Microsoft Visual Studio", null);
                //IntPtr visualStudioHwnd = FindWindow(null, "MyRemote2 (실행) - Microsoft Visual Studio");

                if (!GetActiveWindowHandle().Contains("(실행) - Microsoft Visual Studio"))
                {
                    Console.WriteLine("GetActiveWindowHandle은 Microsoft visual studio 가 아닙니다. ");
                    return;
                }
                else
                {

                }
                IntPtr visualStudioHwnd = FindWindow(null, GetActiveWindowHandle());



                if (visualStudioHwnd != IntPtr.Zero)
                {
                    // 대상 창을 활성화합니다.
                    SetForegroundWindow(visualStudioHwnd);

                    // 붙여넣기를 실행합니다.
                    SendKeys.SendWait("^v");
                    Console.WriteLine("Succeed Paste: ");
                }
                else
                {
                    Console.WriteLine("GetActiveWindowHandle : " + GetActiveWindowHandle());


                    Console.WriteLine("ERR_ClipboardPaste FindWindow Fail :" + visualStudioHwnd);
                }
            }
            else
            {
                Console.WriteLine("ERR_ClipboardPaste containText는 false");
            }
        }

        public static void WindowCopy()
        {
            // 복사할 대상 창을 활성화합니다.
            if (!GetActiveWindowHandle().Contains("(실행) - Microsoft Visual Studio"))
            {
                Console.WriteLine("GetActiveWindowHandle은 Microsoft visual studio 가 아닙니다. ");
                return;
            }
            else
            {

            }
            IntPtr visualStudioHwnd = FindWindow(null, GetActiveWindowHandle());

            if (visualStudioHwnd != IntPtr.Zero)
            {
                // 대상 창을 활성화합니다.
                SetForegroundWindow(visualStudioHwnd);

                // Ctrl+C 키 조합을 시뮬레이트하여 복사를 실행합니다.
                SendKeys.SendWait("^c");
                Console.WriteLine("Succeed Copy");
            }
            else
            {
                Console.WriteLine("ERR_WindowCopy FindWindow Fail");
            }
        }


    }
}
