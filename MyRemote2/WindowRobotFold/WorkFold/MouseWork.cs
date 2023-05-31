using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MyRemote2.WindowRobotFold.WorkFold
{
    public static class MouseWork
    {

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out System.Windows.Point lpPoint);

        
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);


        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public enum MouseButtonNormalEnum
        {
            Left,
            Scroll,
            Right
        }
        public static void Click(MouseButtonNormalEnum sort)
        {
            switch (sort)
            {
                case MouseButtonNormalEnum.Left:
                    MouseLeftClick();
                    break;
                case MouseButtonNormalEnum.Scroll:
                    MouseMiddleClick();
                    break;
                case MouseButtonNormalEnum.Right:
                    MouseRightClick();
                    break;
                default :
                    Console.WriteLine("ERR_Click"+sort);
                    break;
            }
        }
        public static void DoubleClick()
        {
            MouseLeftClick();
            MouseLeftClick();//되려나?
        }



        // 마우스 이동 함수
        public static void MouseMove(int x, int y)
        {
            Console.WriteLine(x + " " + y + " 움직임");
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, (uint)x, (uint)y, 0, 0);
        }
        public static Point GetMouseCurrentPosition()
        {
            Point result = new Point();

            Point currentMousePosition;
            GetCursorPos(out currentMousePosition);

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // 화면 해상도에 따라 절대 좌표계로 변환
            int x = (int)(((double)currentMousePosition.X / screenWidth) * 65535);
            int y = (int)(((double)currentMousePosition.Y / screenHeight) * 65535);

            
            result.X = x;
            result.Y = y;
            return result;
        }


        #region MouseFunction??


        private static void MouseLeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0); // Simulate left button down
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0); // Simulate left button up
        }

        private static void MouseRightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0); // 
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0); // 
        }

        private static void MouseMiddleClick()
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }

        #endregion


        public class Press
        {

        }

        public class Release
        {

        }

        public class Move
        {

        }
    }
}
