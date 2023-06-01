using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MyRemote2.Extend.WriteText
{
    public static class BackGroundKeyListener
    {
        public static string scriptname = "BackGroundKeyListener";

        public static bool isRunning = true;

        /// <summary>
        /// Keys 아니고 
        /// System.Window.Input.Key
        /// 눌린키
        /// </summary>
        public static List<Key> InputKeyList = new List<Key>();
        public static void ListenStart(object sender, EventArgs e)
        {
            Thread TH = new Thread(Keyboardd);
            TH.SetApartmentState(ApartmentState.STA);
            //CheckForIllegalCrossThreadCalls = false;
            TH.Start();
        }

        /// <summary>
        /// 눌리는 키 observe. 감시. 
        /// </summary>
        public static List<Key> keysToCheckList = new List<Key>();
        //{ Key.Return, Key.A, Key.B, Key.C,Key.F9,
        //Key.F3,Key.F7,Key.Scroll,Key.Pause}; // 원하는 키들을 배열에 추가


        #region TestMode
        public static bool TestMode20230531 = true;
        public static bool ReverseMode = false;

        static void TestMode20230531EXE(Key key)
        {


            if (key.Equals(Key.Q)||
                key.Equals(Key.W) ||
                key.Equals(Key.E) ||
                key.Equals(Key.R) ||
                key.Equals(Key.T) ||
                key.Equals(Key.Y) ||
                key.Equals(Key.F) ||
                key.Equals(Key.G)||
                key.Equals(Key.D0))
                
            {
                SettingTestMode(key);
                // 특정 메서드 호출
                Console.WriteLine("dddggTestmode  "+key);
                KeyReleaseIfDownTestMode();
                Form1_Func.StartMacro();
            }
            else if (key == Form1_Func.StopKey)
            {
                Form1_Func.StopMacro();
            }
        }

        static Random ranTest =new Random();
        static Random ranTest2 = new Random();

        public static int TestModeRandom1_10()
        {
            var rantmp = ranTest.Next(1, 100);
            var rantmp2 = ranTest2.Next(1, 3);

            if (rantmp > 96 + rantmp2)
            {
                return 9;
            }
            else if (rantmp > 91 + rantmp2)
                return 8;
            else if (rantmp > 85 + rantmp2)
                return 7;
            else if (rantmp > 56 + rantmp2)
                return 6;
            else if (rantmp > 34 + rantmp2)
                return 5;
            else if (rantmp > 21 + rantmp2)
                return 4;
            else if (rantmp > 15 + rantmp2)
                return 3;
            else if (rantmp > 2 + rantmp2)
                return 2;
            else
                return 1;
            

        }
        static void KeyReleaseIfDownTestMode()
        {

                if (Keyboard.GetKeyStates(Key.Down).HasFlag(KeyStates.Down))
                {

                Form1_Func.ReleaseKey_Public(Keys.Down);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }

            if (Keyboard.GetKeyStates(Key.Up).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.Up);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.Left).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.Left);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }

            if (Keyboard.GetKeyStates(Key.Right).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.Right);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
                Console.WriteLine("Right키 누르@#$" + Keyboard.GetKeyStates(Key.Right));
            }
            else
            {
                Console.WriteLine("Right키 누르고 있지 않음@#$" + Keyboard.GetKeyStates(Key.Right));
            }


            if (Keyboard.GetKeyStates(Key.Z).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.Z);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.X).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.X);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.C).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.C);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.D1).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.D1);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.D3).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.D3);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
        }

        static void SettingTestMode(Key key)
        {
            var listTmp = Form1_Func.MacroItemList;
            listTmp.Clear();
            var rantmp1 = TestModeRandom1_10();
            if (true) {
                Console.WriteLine(rantmp1);
            }
            var itemTmp = new MacroItem();
            //if (!(key == Key.Q))
            //    return;
            switch (key)
            {
                case Key.Q:
                    
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "zRightUpDownUp";
                    listTmp.Add(itemTmp);
                    break;
                case Key.W:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "236";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "zRightUp";
                    listTmp.Add(itemTmp);
                    break;
                case Key.E:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "214";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "zLeftUp";
                    listTmp.Add(itemTmp);
                    break;
                case Key.R:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "22";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "zDownUp";
                    listTmp.Add(itemTmp);
                    break;
                case Key.T:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "22";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "z";
                    listTmp.Add(itemTmp);
                    break;
                case Key.F:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "a";
                    listTmp.Add(itemTmp);
                    break;
                case Key.G:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "a";
                    listTmp.Add(itemTmp);
                    break;
                case Key.Y:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "236";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "236";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "cRightUpDownUp";
                    listTmp.Add(itemTmp);
                    break;
                case Key.D0:

                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "AllUp";
                    listTmp.Add(itemTmp);
                    
                    break;
            }

            //Console.WriteLine(e + ":?? WriteTextWindow 키 확인");
            //  키가 눌렸는지 확인


        }
        #endregion

        

        static void Keyboardd()
        {
            keysToCheckList.Add(Key.Return);
            keysToCheckList.Add(Key.A);
            keysToCheckList.Add(Key.B);
            keysToCheckList.Add(Key.C);
            keysToCheckList.Add(Key.F9);
            keysToCheckList.Add(Key.F3);
            keysToCheckList.Add(Key.F7);
            keysToCheckList.Add(Key.Scroll);
            keysToCheckList.Add(Key.Pause);

            keysToCheckList.Add(Key.F20);
            keysToCheckList.Add(Key.D4);
            keysToCheckList.Add(Key.D5);



            keysToCheckList.Add(Key.Q);
            keysToCheckList.Add(Key.W);
            keysToCheckList.Add(Key.E);
            keysToCheckList.Add(Key.R);
            keysToCheckList.Add(Key.T);
            keysToCheckList.Add(Key.Y);
            keysToCheckList.Add(Key.F);
            keysToCheckList.Add(Key.G);
            keysToCheckList.Add(Key.D0);

            int a=0;
            while (isRunning)
            {
                Thread.Sleep(40); //minimum CPU usage
                a++;
                if (a % 30 == 0)
                {
                    //Console.WriteLine("돌고있음-_"+(a/30).ToString());
                }

#if false
                if (Keyboard.GetKeyStates(Key.Right).HasFlag(KeyStates.Down))
                {
                    consoleUtil.ConsoleW("right중 ", scriptname);
                }
                else
                {
                    consoleUtil.ConsoleW("right중 no ", scriptname);
                }
#endif
                //KeyReleaseIfDownTestMode();

                    // 각 키들을 확인하여 눌린 경우 동작 수행
                foreach (var key in keysToCheckList)
                {
                    if (Keyboard.GetKeyStates(key).HasFlag(KeyStates.Down))
                    {
                        if (InputKeyList.Count == 0)
                        {
                            if (key.Equals(Key.F20) ||
                                   key.Equals(Key.D4)||
                                    key.Equals(Key.D5))

                            {

                                Console.Beep();
                                if (key.Equals(Key.F20))
                                {
                                    TestMode20230531 = !TestMode20230531;
                                }
                                else if (key.Equals(Key.D4))
                                {
                                    ReverseMode = false;
                                }
                                else if (key.Equals(Key.D5))
                                {
                                    ReverseMode = true;
                                }


                            }
                            if (TestMode20230531) {

                                if (key.Equals(Key.Left)||
                                    key.Equals(Key.Right) ||
                                    key.Equals(Key.Down) ||
                                    key.Equals(Key.Up) ||
                                    key.Equals(Key.Left) ||
                                    key.Equals(Key.A) ||
                                    key.Equals(Key.S) ||
                                    key.Equals(Key.D) ||
                                    key.Equals(Key.Z) ||
                                    key.Equals(Key.X) ||
                                    key.Equals(Key.C) ||
                                    key.Equals(Key.D1) ||
                                    key.Equals(Key.D3))
                                {
                                    InputKeyList.Clear();
                                    //RelaseKey
                                    //TestMode20230531EXE(Key.D0);
                                    Thread.Sleep(30);
                                    continue;
                                }

                                Form1_Func.BASE_Wait_Delay = 20;
                                TestMode20230531EXE(key);
                                Thread.Sleep(400);
                                continue;
                            }
                            InputKeyList.Add(key);
                            if(WriteTextWindow.Instance!=null)
                            WriteTextWindow.Instance.KeyExe(key);
                            else if (Form1.Instance != null)
                            {
                                Form1.Instance.BackGroundKeyExe(key);
                            }
                            //InputKeyList.Clear();
                            Thread.Sleep(400);
                        }
                        else if (InputKeyList.Count == 1)
                        {

                            if (key.Equals(Key.F20) ||
                                   key.Equals(Key.D4) ||
                                    key.Equals(Key.D5))
                            {
                                
                                Console.Beep();
                                if (key.Equals(Key.F20))
                                {
                                    TestMode20230531 = !TestMode20230531;
                                }
                                else if (key.Equals(Key.D4))
                                {
                                    ReverseMode = false;
                                }
                                else if (key.Equals(Key.D5))
                                {
                                    ReverseMode = true;
                                }

                                InputKeyList.Clear();
                                Thread.Sleep(500);
                                continue;
                            }
                            InputKeyList[0] = key;
                            if (WriteTextWindow.Instance != null)
                                WriteTextWindow.Instance.KeyExe(key);
                            else if (Form1.Instance != null)
                            {
                                Form1.Instance.BackGroundKeyExe(key);
                            }
                            //InputKeyList.Clear();
                            Thread.Sleep(500);

                        }

                        Console.WriteLine($"{key} 키 누름"); // 눌린 키의 이름을 출력하거나 원하는 동작 수행
                    }
                }
            }
            Console.WriteLine("Keyboardd Thread는 종료되었습니다.");
        }
        
        public static void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("thread 러닝 false");
            isRunning = false;
            WriteTextWindow.Instance = null;
        }
    }
}

