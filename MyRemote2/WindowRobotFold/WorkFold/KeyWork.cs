using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MyRemote2.WindowRobotFold.WorkFold
{
    public static class KeyWork
    {


        #region Property
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // Shift 키의 가상 키 코드
        const byte VK_SHIFT = 0x10;
        // CONTROL 키의 가상 키 코드
        const byte VK_CONTROL = 0x11;
        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;
        #endregion


        public static void OneKeyInput_Press_Release(Keys keys)
        {
            PressReleaseKey(keys);
        }


        /// <summary>
        /// Shift,Alt,Ctrl + 추가키 하나만 가능
        /// </summary>
        /// <param name="key"></param>
        public static void MultiKey_Input_Press_Release(Keys[] keysArray)
        {
        }

        #region Base
        // 키 눌렀다 떼기 함수
        private static void PressReleaseKey(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        public static void ShiftPressKey(Keys key)
        {
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        private static void ControlPressKey(Keys key)
        {
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        private static void AltPressKeyNotYet(Keys key)
        {

            return;

            //keybd_event(VK_ALT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            //keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            //keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            //keybd_event(VK_ALT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        //키 계속 누르고 있기 함수
        private static void PressContinueKey(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        }

        // 키 떼기 함수
        private static void ReleaseKey(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }
        #endregion
        

    }
    
}
