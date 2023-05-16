using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
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

    // Shift 키의 가상 키 코드
    const byte VK_SHIFT = 0x10;


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
    public static Key StartKey= Key.Scroll;
    public static Key StopKey= Key.Pause;

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
                KeyPress(item.key);
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
                break;
            case MacroEnum.None:
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

    public static void WriteText(string str)
    {
        if (str == null)
        {
            Console.WriteLine("WriteText str이 null임");
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

    // 키 뗄기 함수
    private static void ReleaseKey(Keys key)
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
