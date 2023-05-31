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
        static bool TestMode20230531 = true;

        static void TestMode20230531EXE(Key key)
        {
            
            if (key.Equals(Key.Q)||
                key.Equals(Key.W) ||
                key.Equals(Key.E) ||
                key.Equals(Key.R) ||
                key.Equals(Key.T) ||
                key.Equals(Key.Y) ||
                key.Equals(Key.F) ||
                key.Equals(Key.G))
                
            {
                SettingTestMode(key);
                // 특정 메서드 호출
                Console.WriteLine("dddggTestmode  "+key);
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

        static void SettingTestMode(Key key)
        {
            var listTmp = Form1_Func.MacroItemList;
            listTmp.Clear();
            var rantmp1 = TestModeRandom1_10();
            if (true) {
                Console.WriteLine(rantmp1);
            }
            var itemTmp = new MacroItem();
            if (!(key == Key.Q))
                return;
            switch (key)
            {
                case Key.Q:
                    
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "zRightUp";
                    listTmp.Add(itemTmp);
                    break;
                case Key.W:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "a";
                    listTmp.Add(itemTmp);
                    break;
                case Key.E:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "a";
                    listTmp.Add(itemTmp);
                    break;
                case Key.R:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "a";
                    listTmp.Add(itemTmp);
                    break;
                case Key.T:
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "623";
                    listTmp.Add(itemTmp);
                    itemTmp = new MacroItem();
                    itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                    itemTmp.TestModeKeyPressCode = "a";
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



            keysToCheckList.Add(Key.Q);
            keysToCheckList.Add(Key.W);
            keysToCheckList.Add(Key.E);
            keysToCheckList.Add(Key.R);
            keysToCheckList.Add(Key.T);
            keysToCheckList.Add(Key.Y);

            int a=0;
            while (isRunning)
            {
                Thread.Sleep(40); //minimum CPU usage
                a++;
                if (a % 30 == 0)
                {
                    //Console.WriteLine("돌고있음-_"+(a/30).ToString());
                }

                // 각 키들을 확인하여 눌린 경우 동작 수행
                foreach (var key in keysToCheckList)
                {
                    if (Keyboard.GetKeyStates(key).HasFlag(KeyStates.Down))
                    {
                        if (InputKeyList.Count == 0)
                        {
                            if (TestMode20230531) {
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

