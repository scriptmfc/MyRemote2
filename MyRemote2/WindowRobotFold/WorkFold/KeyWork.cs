using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyRemote2.WindowRobotFold.WorkFold
{
    public class KeyWork : Work
    {
        
        

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // Shift 키의 가상 키 코드
        const byte VK_SHIFT = 0x10;
        // CONTROL 키의 가상 키 코드
        const byte VK_CONTROL = 0x11;
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;
        public void OneKeyInput_Press_Release(Key key)
        {
        }

        public void 다중Key_Input_Press_Release(Key[] key)
        {
        }

    }
}
