using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MyRemote2;

public static class Form1_Func
{


    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out POINT lpPoint);
    // 윈도우 API 함수를 사용하기 위한 import
    [DllImport("user32.dll")]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    // POINT 구조체 정의
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    private const int MOUSEEVENTF_MOVE = 0x0001;
    private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const int MOUSEEVENTF_LEFTUP = 0x0004;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const int MOUSEEVENTF_RIGHTUP = 0x0010;
    private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
    private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

    private const int KEYEVENTF_KEYDOWN = 0x0000;
    private const int KEYEVENTF_KEYUP = 0x0002;

    public static List<MacroItem> MacroItemList= new List<MacroItem>();
    public static MacroItem SelectItem = new MacroItem();

    public static int BASE_Wait_Delay=100;

    public static Keys CurrentMousePositionSettingKey = Keys.F6;
    public static Keys StartKey= Keys.F7;
    public static Keys StopKey= Keys.F8;

    /*
    private static void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        // F7 키가 눌렸는지 확인
        if (e.KeyCode == StartKey)
        {
            // 특정 메서드 호출
            StartMacro(); 
        }
        if (e.KeyCode == StopKey)
        {
            // 특정 메서드 호출
            StopMacro(); 
        }

        if(e.KeyCode== CurrentMousePositionSettingKey)
        {
            Console.WriteLine("현재위치");
            Form1.Instance.MouseXPos1.Text = GetMouseCurrentPosition().X.ToString();
            Form1.Instance.MouseYPos1.Text = GetMouseCurrentPosition().Y.ToString();
            Form1.Instance.button4_Click();
            //Form1.Instance.Label4 = "현재 위치로 : "+F6;
        }
    }
    */
    public static POINT GetMouseCurrentPosition()
    {
        POINT currentMousePosition;
        GetCursorPos(out currentMousePosition);

        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        // 화면 해상도에 따라 절대 좌표계로 변환
        int x = (int)(((double)currentMousePosition.X / screenWidth) * 65535);
        int y = (int)(((double)currentMousePosition.Y / screenHeight) * 65535);

        POINT result;
        result.X = x;
        result.Y = y;
        return result;
    }

    public static void StartMacro()
    {
        ThreadMachine.StartThread();
    }

    public static void StopMacro()
    {
        ThreadMachine.StopThread();
    }

    public static void MacroWork(MacroItem item)
    {
        switch (item.macroEnum)
        {
            case MacroEnum.KeyPress:
                //KeyPress();
                break;
            case MacroEnum.MouseMove:
                MouseMove(item.x, item.y);
                break;
            case MacroEnum.MouseClick:
                MouseLeftClick();
                break;
            case MacroEnum.Wait:
                break;
        }
    }


    static void KeyPress(Keys key)
    {
        PressKey(key);
    }

    #region WindowFunction
    // 마우스 이동 함수
    private static void MouseMove(int x, int y)
    {
        Console.WriteLine(x + " " + y + " 움직임");
        mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, (uint)x, (uint)y, 0, 0);
    }

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


    // 키 눌렀다 떼기 함수
    private static void PressKey(Keys key)
    {
        keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }

    // 키 뗄기 함수
    private static void ReleaseKey(Keys key)
    {
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }

    // 문자 키 누르기 함수
    private static void PressKey(char key)
    {
        PressKey((Keys)key);
    }

    // 문자 키 뗄기 함수
    private static void ReleaseKey(char key)
    {
        ReleaseKey((Keys)key);
    }
    #endregion
}
