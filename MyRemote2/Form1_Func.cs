using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using MyRemote2;
using MyRemote2.Extend.WriteText;
using MyRemote2.WindowRobotFold.WorkFold;

public static class Form1_Func
{


    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out POINT lpPoint);
    // 윈도우 API 함수를 사용하기 위한 import
    [DllImport("user32.dll")]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    // Shift 키의 가상 키 코드
    const byte VK_SHIFT = 0x10;
    // CONTROL 키의 가상 키 코드
    const byte VK_CONTROL = 0x11;


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

    private const int KEYEVENTF_KEYRIGHT = 0x0000;
    private const int KEYEVENTF_KEYLEFT = 0x0002;
    private const int KEYEVENTF_KEYDOWN = 0x0000;
    private const int KEYEVENTF_KEYUP = 0x0002;

    public static List<MacroItem> MacroItemList= new List<MacroItem>();
    public static MacroItem SelectItem = new MacroItem();

    public static int BASE_Wait_Delay=100;

    public static Keys CurrentMousePositionSettingKey = Keys.F6;
    public static Key StartKey= Key.Scroll;
    public static Key StopKey= Key.Pause;

    public static bool KeyPress꾹Control;
    public static bool KeyPress꾹Shift;
    public static bool KeyPress꾹Alt;

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

    public static void Init()
    {
        consoleUtil.DebugON = true;
        consoleUtil.CONSOLEUTILSystemDebugON = true;
    }

    public static void StartMacro()
    {
        ThreadMachine.StartThread("Form1_FuncMacro");
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
                if (item.press꾹Key.Count == 0)
                {
                    KeyPress(item.key);
                }
                else if (item.press꾹Key.Count == 1)
                {
                    //PressContinueKey(item.press꾹Key[0]);
                    //KeyPress(item.key);
                    //ReleaseKey(item.press꾹Key[0]);
                    //=>안되는 듯?

                    if (item.press꾹Key[0] == Keys.Shift)
                    {
                        ShiftPressKey(item.key);
                    }
                    else if (item.press꾹Key[0] == Keys.Control)
                    {
                        ControlPressKey(item.key);
                    }

                }
                break;
            case MacroEnum.WriteText:
                WriteText(item.str);
                break;
            case MacroEnum.MouseMove:
                MouseMove(item.x, item.y);
                break;
            case MacroEnum.MouseClick:
                MouseLeftClick();
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
                    default:
                        Console.WriteLine(item.macroEnum + ":MacroEnum 오류_WindowFunction_Default");
                        break;
                }
                break;
            case MacroEnum.TestModeKeyPress:
                Console.WriteLine(item.TestModeKeyPressCode + "TestModeKeyPress진입");
                //KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
               
                switch (item.TestModeKeyPressCode) {
                    
                    case "623":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "66":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "44":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "22":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "c_Continue":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "236":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "214":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "a":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "s":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "d":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "z":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "x":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;
                    case "c":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);

                        break;
                    case "zRightUp":
                        KeyPressTestMode(Keys.None, item.TestModeKeyPressCode);
                        break;



                }

                break;
            case MacroEnum.CustomMacro:

                //if (item.CustomMacroCode == "test_Champion")
                    if(true)
                {
                    //ShiftPressKey(Keys.Down);
                    //ShiftPressKey(Keys.Down);
                    //ShiftPressKey(Keys.Down);
                    //PressKey(Keys.Oemcomma);
                    //PressKey(Keys.Down);
                    //PressKey(Keys.End);

                    PressKey(Keys.End);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    Thread.Sleep(300);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    Thread.Sleep(150);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(200);

                    PressKey(Keys.Oemcomma);
                    PressKey(Keys.Down);
                    PressKey(Keys.Down);
                    PressKey(Keys.Down);
                    /*
                    PressKey(Keys.End);
                    Thread.Sleep(70);
                    PressKey(Keys.Oemcomma);
                    Thread.Sleep(70);
                    PressKey(Keys.Down);
                    Thread.Sleep(70);
                    PressKey(Keys.Down); 
                    Thread.Sleep(70);
                    PressKey(Keys.Home);
                    Thread.Sleep(70);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    Thread.Sleep(150);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(200);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(70);
                    PressKey(Keys.Delete); Thread.Sleep(70);

                    PressKey(Keys.Delete); Thread.Sleep(70);

                    Thread.Sleep(70);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    Thread.Sleep(150);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(200);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

                    PressKey(Keys.Delete); Thread.Sleep(70);

                    PressKey(Keys.Delete); Thread.Sleep(70);

                    Thread.Sleep(70);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                    Thread.Sleep(150);
                    keybd_event((byte)Keys.End, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(200);
                    keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

                    PressKey(Keys.Delete); Thread.Sleep(70);

                    PressKey(Keys.Delete); Thread.Sleep(70);
                    */
                }

                //if (item.CustomMacroCode == "testClipboard")
                {
                    Console.WriteLine("ffasda123123sd아직 설정 xxx");
                    //WindowFunctionWork.ClipboardSetting("test333");
                    //WindowFunctionWork.ClipboardPaste();
                }
                break;
            default:
                Console.WriteLine(item.macroEnum + ":MacroEnum 오류");
                break;
        }
    }


    static void KeyPress(Keys key)
    {
        PressKey(key);
    }

    static void KeyPressTestMode(Keys key, string testcode)
    {
        var RIGHTKEY = (byte)Keys.Right;
        var LEFTKEY = (byte)Keys.Left;

        if (BackGroundKeyListener.ReverseMode)
        {
            RIGHTKEY = (byte)Keys.Left; 
            LEFTKEY = (byte)Keys.Right;
        }
        switch (testcode) {
#region 623 214 236 22
            case "623":
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(4 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(4 + BackGroundKeyListener.TestModeRandom1_10()+" TTr");
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(1 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(1 + BackGroundKeyListener.TestModeRandom1_10() + " TTr");
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(2 + BackGroundKeyListener.TestModeRandom1_10()/3);
                if(BackGroundKeyListener.TestModeRandom1_10() <5)
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(3 + BackGroundKeyListener.TestModeRandom1_10()/4);
                
                break;
            case "214":
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(1 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(1 + BackGroundKeyListener.TestModeRandom1_10() + " TTr");
                keybd_event(LEFTKEY, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(3 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(1 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(1 + BackGroundKeyListener.TestModeRandom1_10() + " TTr");
                keybd_event(LEFTKEY, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(2 + BackGroundKeyListener.TestModeRandom1_10() / 3);
                if (BackGroundKeyListener.TestModeRandom1_10() < 5)
                    keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(4 + BackGroundKeyListener.TestModeRandom1_10() / 4);

                break;
            case "236":
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(4 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(4 + BackGroundKeyListener.TestModeRandom1_10() + " TTr");
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(5 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(3 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(3 + BackGroundKeyListener.TestModeRandom1_10() + " TTr");
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(3 + BackGroundKeyListener.TestModeRandom1_10() / 3);
                if (BackGroundKeyListener.TestModeRandom1_10() < 5)
                    keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(3 + BackGroundKeyListener.TestModeRandom1_10() / 4);

                break;

            case "22":
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(23 + BackGroundKeyListener.TestModeRandom1_10());
                Console.WriteLine(23 + BackGroundKeyListener.TestModeRandom1_10() + " TTr");
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(24 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                
                
                Thread.Sleep(2 + BackGroundKeyListener.TestModeRandom1_10() / 3);
                if (BackGroundKeyListener.TestModeRandom1_10() < 5)
                    Thread.Sleep(1 + BackGroundKeyListener.TestModeRandom1_10() / 5); 
                Thread.Sleep(3 + BackGroundKeyListener.TestModeRandom1_10() / 4);

                break;

#endregion

    
#region KeysRightUpDownUp.....
            case "Keys_RightUpDownUp":
                Console.WriteLine("Keys_rightup 진입");
                keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero) ;
                Thread.Sleep(66 + BackGroundKeyListener.TestModeRandom1_10()/2);
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(140 + 7*BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(37 + 2*BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "Keys_RightUp":
                Console.WriteLine("Keys_rightup진입");
                keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(47 + 4*BackGroundKeyListener.TestModeRandom1_10());
                Thread.Sleep(136 + 7 * BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(43 + 2 * BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "Keys_LeftUp":
                
                Console.WriteLine("Keys_LeftUp 진입");
                keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(61 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event(LEFTKEY, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(138 + 5 * BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "Keys_DownUp":
                Console.WriteLine("Keys_DownUp 진입");
                keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(43 + 3 * BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(125 + 5 * BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
#endregion


            case "a":
                keybd_event((byte)Keys.A, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(34 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.A, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "s":
                keybd_event((byte)Keys.S, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(44 + BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.S, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "d":
                keybd_event((byte)Keys.D, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(34 + BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.D, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "z":
                keybd_event((byte)Keys.Z, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(37 + BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;

            case "cRightUpDownUp":
                Console.WriteLine("cRightUpDownUp 진입");
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(62 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(140 + 6 * BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(33 + 3 * BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event(RIGHTKEY, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;

            case "x":
                keybd_event((byte)Keys.X, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(40 + BackGroundKeyListener.TestModeRandom1_10() + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.X, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "c":
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(42 + BackGroundKeyListener.TestModeRandom1_10()+ BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "c_Continue":
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Thread.Sleep(430 + 35*BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                break;
            case "AllUp":
#region AllUp
                Console.WriteLine("AllUp 진입");

                Console.Beep();

#if false
                if (Keyboard.IsKeyDown(Key.Down))
                {

                    keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }

                if (Keyboard.IsKeyDown(Key.Up))
                {
                    keybd_event((byte)Keys.Up, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                if (Keyboard.IsKeyDown(Key.Left))
                {
                    keybd_event((byte)Keys.Left, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                
                if (Keyboard.GetKeyStates(Key.Right).HasFlag(KeyStates.Down))
                {
                    keybd_event((byte)Keys.Right, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                else
                {
                    Console.WriteLine("Right키 누르고 있지 않음@#$"+ Keyboard.GetKeyStates(Key.Right));
                }


                if (Keyboard.IsKeyDown(Key.Z))
                {
                    keybd_event((byte)Keys.Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                if (Keyboard.IsKeyDown(Key.X))
                {
                    keybd_event((byte)Keys.X, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                if (Keyboard.IsKeyDown(Key.C))
                {
                    keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                if (Keyboard.IsKeyDown(Key.D1))
                {
                    keybd_event((byte)Keys.D1, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
                if (Keyboard.IsKeyDown(Key.D3))
                {
                    keybd_event((byte)Keys.D3, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                }
#endif

                keybd_event((byte)Keys.Down, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10+ BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Left, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Up, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Right, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.Z, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.X, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.C, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.A, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.S, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.D, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.F, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.D1, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Thread.Sleep(10 + BackGroundKeyListener.TestModeRandom1_10());
                keybd_event((byte)Keys.D3, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

#endregion
                break;

        }
    }



    public static void WriteText(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            Console.WriteLine("WriteText str이 null이거나 empty");
            return;
        }

        

        for(int i =0;i<str.Length;i++)
        {
            
            char c = (char)str[i];
            PressKey(c);
        }
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

    private static void ShiftPressKey(Keys key)
    {
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }

    private static void TmpShiftPressKey(Keys key)
    {
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        Thread.Sleep(150);
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        Thread.Sleep(200);
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }

    private static void ControlPressKey(Keys key)
    {
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
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

    public static void ReleaseKey_Public(Keys key)
    {
        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }

    /// <summary>
    /// char key.
    /// Keys key 도 있음
    /// </summary>
    /// <param name="key"></param>
    private static void PressKey(char key)
    {
        Console.WriteLine(key + "글자판별");
        Keys keys;
        bool shiftOn = false;

        if (!Char.IsLower(key)&&char.IsLetter(key))
        {
            shiftOn = true;
            Console.WriteLine(key + "는 대문자입니다.");
        }

        switch (key)
        {
            case ' ':
                keys = Keys.Space;
                break;
            case '\'':
                Console.WriteLine(key + "__글자판별 \' ");
                keys = Keys.OemQuotes;
                break;
            case '\"':
                Console.WriteLine(key + "__글자판별 \" ");
                keys = Keys.OemQuotes;
                shiftOn = true;
                break;
            case '-':
                keys = Keys.OemMinus;
                break;
            case '.':
                keys = Keys.OemPeriod;
                break;
            case '\\':
                keys = Keys.OemBackslash;
                break;
            case '|':
                keys = Keys.OemBackslash;
                shiftOn = true;
                break;
            case ';':
                keys = Keys.OemSemicolon;
                break;
            case ':':
                keys = Keys.OemSemicolon;
                shiftOn = true;
                break;
            case '?':
                keys = Keys.OemQuestion;
                shiftOn = true;
                break;
            case '/':
                keys = Keys.OemQuestion;
                break;
            case '_':
                keys = Keys.OemMinus;
                shiftOn = true;
                break;
            case '=':
                keys = Keys.Oemplus;
                break;
            case '+':
                keys = Keys.Oemplus;
                shiftOn = true;
                break;
            case '`':
                keys = Keys.Oemtilde;
                break;
            case '~':
                keys = Keys.Oemtilde;
                shiftOn = true;
                break;
            case '!':
                keys = Keys.D1;
                shiftOn = true;
                break;
            case '@':
                keys = Keys.D2;
                shiftOn = true;
                break;
            case '#':
                keys = Keys.D3;
                shiftOn = true;
                break;
            case '$':
                keys = Keys.D4;
                shiftOn = true;
                break;
            case '%':
                keys = Keys.D5;
                shiftOn = true;
                break;
            case '^':
                keys = Keys.D6;
                shiftOn = true;
                break;
            case '&':
                keys = Keys.D7;
                shiftOn = true;
                break;
            case '*':
                keys = Keys.D8;
                shiftOn = true;
                break;
            case '(':
                keys = Keys.D9;
                shiftOn = true;
                break;
            case ')':
                keys = Keys.D0;
                shiftOn = true;
                break;
            case '[':
                keys = Keys.OemOpenBrackets;
                shiftOn = true;
                break;
            case ']':
                keys = Keys.OemCloseBrackets;
                shiftOn = true;
                break;
            case '{':
                keys = Keys.OemOpenBrackets;
                shiftOn = true;
                break;
            case '}':
                keys = Keys.OemCloseBrackets;
                shiftOn = true;
                break;
            case '<':
                keys = Keys.Oemcomma;
                shiftOn = true;
                break;
            case ',':
                keys = Keys.Oemcomma;
                break;
            case '>':
                keys = Keys.OemPeriod;
                shiftOn = true;
                break;
            default:
                keys = (Keys)Enum.Parse(typeof(Keys), key.ToString(), true);
                int num;
                if (int.TryParse(key.ToString(),out num))
                {
                    switch (num)
                    {
                        case 0:
                            keys = Keys.D0;
                            break;
                        case 1:
                            keys = Keys.D1;
                            break;
                        case 2:
                            keys = Keys.D2;
                            break;
                        case 3:
                            keys = Keys.D3;
                            break;
                        case 4:
                            keys = Keys.D4;
                            break;
                        case 5:
                            keys = Keys.D5;
                            break;
                        case 6:
                            keys = Keys.D6;
                            break;
                        case 7:
                            keys = Keys.D7;
                            break;
                        case 8:
                            keys = Keys.D8;
                            break;
                        case 9:
                            keys = Keys.D9;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("num", "입력된 숫자가 0부터 9까지의 범위를 벗어납니다.");
                    }

                }

                Console.WriteLine("default:" + keys);
                break;
        }


        if (shiftOn)
        {
            Console.WriteLine(key + "Shift__ ");
            ShiftPressKey(keys);
        }
        else
        {
            Console.WriteLine(key + "NonShift__ ");
            PressKey(keys);
        }
    }


    // 문자 키 뗄기 함수
    private static void ReleaseKey(char key)
    {
        ReleaseKey((Keys)key);
    }
#endregion
}
