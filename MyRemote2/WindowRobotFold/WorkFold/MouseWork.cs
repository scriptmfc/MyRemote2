using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyRemote2.WindowRobotFold.WorkFold
{
    public class MouseWork : Work
    {

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out System.Windows.Point lpPoint);

        
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);


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
        public void Click(MouseButtonNormalEnum sort)
        {

        }
        public void DoubleClick()
        {

        }

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
