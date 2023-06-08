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
        public static bool TestMode20230531 = false;
        public static bool ReverseMode = false;

        //public static string TestModeCode = "GGS_M";
        //public static string TestModeCode = "GGS_JO";
        public static string TestModeCode = "GBV_YE";
        public static string TestModeCodeSub = "";
        public static string TestModeCodeSub2 = "";
        public static double TestModeTimeSpanValue = 0;//= new TimeSpan();

        public static List<Key> SkillKeyList = new List<Key>();
        public static List<Key> BaseKeyList = new List<Key>();
        public static List<Key> FunctionKeyList = new List<Key>();
        static void TestMode20230531EXE(Key key)
        {


            if (key.Equals(Key.Q) ||
                key.Equals(Key.W) ||
                key.Equals(Key.E) ||
                key.Equals(Key.R) ||
                key.Equals(Key.T) ||
                key.Equals(Key.Y) ||
                key.Equals(Key.G) ||
                key.Equals(Key.H) ||
                key.Equals(Key.B) ||
                key.Equals(Key.N) ||
                key.Equals(Key.D0))

            {
                SettingTestMode(key);
                // 특정 메서드 호출
                Console.WriteLine("dddgg Testmode  " + key);
                if (TestModeCode == "GGS_M")
                {
                    if(key.Equals(Key.E) ||
                        key.Equals(Key.W) ||
                        key.Equals(Key.G))
                    {

                    }
                    else
                    {
                        KeyReleaseIfDownTestMode();
                    }
                }
                else
                {
                    KeyReleaseIfDownTestMode();
                }
                if (TestModeCode == "GGS_M")
                {
                    if (TestModeCodeSub == "MD")
                    {
                        TestModeCodeSub = "";
                        if (key.Equals(Key.E))
                        {
                            Form1_Func.StopMacro();
                        }
                        else
                        {
                            Form1_Func.StartMacro();
                        }
                    }
                }
                else
                {
                    Form1_Func.StartMacro();
                }
            }
            else if (key == Form1_Func.StopKey)
            {
                Form1_Func.StopMacro();
            }
        }

        static Random ranTest = new Random();
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
            if (Keyboard.GetKeyStates(Key.A).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.A);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.S).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.S);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }
            if (Keyboard.GetKeyStates(Key.D).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.D);
                Thread.Sleep(5 + 2 * BackGroundKeyListener.TestModeRandom1_10() / 3);
            }

            if (Keyboard.GetKeyStates(Key.F).HasFlag(KeyStates.Down))
            {
                Form1_Func.ReleaseKey_Public(Keys.F);
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
            if (TestModeCode == "GBV_YE")
            {
                #region GBV
                switch (key)
                {
                    case Key.Q:

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "623";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUpDownUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.Z;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.W:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "236";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.Z;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.E:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "214";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_LeftUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.Z;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.R:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "236";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.C;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.T:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "x";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.Wait;
                        itemTmp.waitdelay = 140;
                        listTmp.Add(itemTmp);

                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "z";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.Wait;
                        itemTmp.waitdelay = 200;
                        listTmp.Add(itemTmp);

                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "c";
                        listTmp.Add(itemTmp);
                        break;
                    case Key.G:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "z";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.Wait;
                        itemTmp.waitdelay=140;
                        listTmp.Add(itemTmp);

                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "x";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.Wait;
                        itemTmp.waitdelay = 200;
                        listTmp.Add(itemTmp);

                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "c";
                        listTmp.Add(itemTmp);
                        break;
                    case Key.H:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "623";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUpDownUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.C;
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
                        itemTmp.TestModeKeyPressCode = "Keys_RightUpDownUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.C;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.B:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "22";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_DownUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.C;
                        listTmp.Add(itemTmp);


                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.Wait;
                        itemTmp.waitdelay = 600;
                        listTmp.Add(itemTmp);

                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "c";
                        listTmp.Add(itemTmp);
                        break;
                    case Key.D0:

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "AllUp";
                        listTmp.Add(itemTmp);

                        break;
                }
                #endregion
            }
            else if (TestModeCode == "GGS_M")
            {
                #region GGS
                switch (key)
                {
                    case Key.Q:

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "214";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_LeftUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.A;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.W:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "(4)Dash_4모으기6_Key";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.D;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.E:
                        //if (TestModeCodeSub == "MD")
                        //{
                            //break;
                        //}

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "(4)모으기6_Key";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.D;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.R:
                        
                        break;
                    case Key.T:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "623";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUpDownUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.S;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.G:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "(2)모으기8_Key";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.D;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.H:
                        break;
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
                        itemTmp.TestModeKeyPressCode = "632146";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.F;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.D0:

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "AllUp";
                        listTmp.Add(itemTmp);

                        break;
                }
                #endregion
            }
            else if (TestModeCode == "GGS_JO")
            {
                #region GGS_JO
                switch (key)
                {
                    case Key.Q:

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "236";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUpFast";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.A;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.W:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "214";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_LeftUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.A;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.E:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "214";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_LeftUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.S;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.R:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "214";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_LeftUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.D;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.T:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "236";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.S;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.G:
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "(2)모으기8_Key";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.D;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.H:
                        break;
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
                        itemTmp.TestModeKeyPressCode = "632146";
                        listTmp.Add(itemTmp);
                        itemTmp = new MacroItem();
                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "Keys_RightUp";
                        itemTmp.TestModeKeyPressCode_Sub = Keys.A;
                        listTmp.Add(itemTmp);
                        break;
                    case Key.D0:

                        itemTmp.macroEnum = MacroEnum.TestModeKeyPress;
                        itemTmp.TestModeKeyPressCode = "AllUp";
                        listTmp.Add(itemTmp);

                        break;
                }
                #endregion
            }


            //Console.WriteLine(e + ":?? WriteTextWindow 키 확인");
            //  키가 눌렸는지 확인


        }
    
            #endregion

        static bool CheckKeyDown(Key key)
        {
            if (Keyboard.GetKeyStates(key).HasFlag(KeyStates.Down))
                return true;
            else
                return false;
        }

            static void Keyboardd()
        {
            keysToCheckList.Add(Key.Return);
            #region Base
            keysToCheckList.Add(Key.A);
            keysToCheckList.Add(Key.S);
            keysToCheckList.Add(Key.D);
            keysToCheckList.Add(Key.F);

            keysToCheckList.Add(Key.Z);
            keysToCheckList.Add(Key.X);
            keysToCheckList.Add(Key.C);
            keysToCheckList.Add(Key.V);

            keysToCheckList.Add(Key.Left);
            keysToCheckList.Add(Key.Right);
            keysToCheckList.Add(Key.Up);
            keysToCheckList.Add(Key.Down);

            keysToCheckList.Add(Key.D1);
            keysToCheckList.Add(Key.D3);
            #endregion
            keysToCheckList.Add(Key.F9);
            keysToCheckList.Add(Key.F3);
            keysToCheckList.Add(Key.F7);
            keysToCheckList.Add(Key.Scroll);
            keysToCheckList.Add(Key.Pause);

            #region 기능
            keysToCheckList.Add(Key.F20);//ONOFF
            keysToCheckList.Add(Key.D4);//Left
            keysToCheckList.Add(Key.D5);//Right
            keysToCheckList.Add(Key.D0);//Allup
            #endregion




            #region Skill

            keysToCheckList.Add(Key.Q);
            keysToCheckList.Add(Key.W);
            keysToCheckList.Add(Key.E);
            keysToCheckList.Add(Key.R);
            keysToCheckList.Add(Key.T);
            keysToCheckList.Add(Key.Y);
            keysToCheckList.Add(Key.G);
            keysToCheckList.Add(Key.H);
            keysToCheckList.Add(Key.B);
            keysToCheckList.Add(Key.N);

            #endregion
            #region Setting Sort
            SkillKeyList.Add(Key.Q);
            SkillKeyList.Add(Key.W);
            SkillKeyList.Add(Key.E);
            SkillKeyList.Add(Key.R);
            SkillKeyList.Add(Key.T);
            SkillKeyList.Add(Key.Y);
            SkillKeyList.Add(Key.G);
            SkillKeyList.Add(Key.H);
            SkillKeyList.Add(Key.B);
            SkillKeyList.Add(Key.N);



            BaseKeyList.Add(Key.A);
            BaseKeyList.Add(Key.S);
            BaseKeyList.Add(Key.D);
            BaseKeyList.Add(Key.F);

            BaseKeyList.Add(Key.Z);
            BaseKeyList.Add(Key.X);
            BaseKeyList.Add(Key.C);
            BaseKeyList.Add(Key.V);

            BaseKeyList.Add(Key.Left);
            BaseKeyList.Add(Key.Down);
            BaseKeyList.Add(Key.Up);
            BaseKeyList.Add(Key.Right);

            BaseKeyList.Add(Key.D1);
            BaseKeyList.Add(Key.D3);




            FunctionKeyList.Add(Key.F20);
            FunctionKeyList.Add(Key.D0);
            FunctionKeyList.Add(Key.D4);
            FunctionKeyList.Add(Key.D5);

            #endregion


            int a =0;
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
                                    key.Equals(Key.D5)||
                                    key.Equals(Key.D0))


                            {
                                if(TestModeCodeSub=="MD")
                                    TestModeCodeSub = "";
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
                                else if (key.Equals(Key.D0))
                                {
                                    KeyReleaseIfDownTestMode();
                                }
                                InputKeyList.Clear();
                                Thread.Sleep(300);
                                continue;
                            }
                            if (TestMode20230531) {
                                if (TestModeCodeSub2 == "M4_Ing" ||
                                    TestModeCodeSub2 == "M24_Ing"||
                                    TestModeCodeSub2 == "M2_Ing"
                                    )
                                {
                                    if (
                                        key.Equals(Key.E)||
                                        key.Equals(Key.W)||
                                        key.Equals(Key.G)||
                                        (key.Equals(Key.Left)&&!ReverseMode)||
                                        (key.Equals(Key.Right) && ReverseMode)||
                                        key.Equals(Key.Down)
                                        )
                                        
                                    {

                                    }
                                    else
                                    {
                                        TestModeCodeSub2 = "_NONESub2_";
                                        consoleUtil.ConsoleWCode(key+TestModeCodeSub2 + " Setting#$1",
                                               scriptname, "$*@#_NONESub2_");
                                    }
                                }
                                else
                                {
                                    TestModeCodeSub2 = "_NONESub2_";
                                    consoleUtil.ConsoleWCode(key + TestModeCodeSub2 + " Setting#$2",
                                               scriptname, "$*@#_NONESub2_");
                                }
                                if (key.Equals(Key.Left)||
                                    key.Equals(Key.Right) ||
                                    key.Equals(Key.Down) ||
                                    key.Equals(Key.Up) ||
                                    key.Equals(Key.Left) ||
                                    key.Equals(Key.A) ||
                                    key.Equals(Key.S) ||
                                    key.Equals(Key.D) ||
                                    key.Equals(Key.F) ||
                                    key.Equals(Key.Z) ||
                                    key.Equals(Key.X) ||
                                    key.Equals(Key.C) ||
                                    key.Equals(Key.D1) ||
                                    key.Equals(Key.D3))
                                {
                                    
                                    if (key.Equals(Key.Left)&&
                                        !BackGroundKeyListener.ReverseMode)
                                    {
                                        if (!(TestModeCodeSub2 == "M24_Ing" ||
                                            TestModeCodeSub2 == "M4_Ing"))
                                        {
                                            TestModeTimeSpanValue = (double)DateTime.Now.TimeOfDay.TotalMilliseconds;
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " Setting1",
                                               scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        if (Keyboard.GetKeyStates(Key.Down).HasFlag(KeyStates.Down))
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " Check1",
                                               scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        else
                                        {
                                            TestModeCodeSub2 = "M4_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " Check2",
                                               scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        /*
                                        if (TestModeCodeSub2 == "M2_Ing")
                                        {
                                            

                                                TestModeCodeSub2 = "M24_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingLeft1",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        else if(TestModeCodeSub2 == "M24_Ing")
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                        }
                                        else
                                        {
                                            
                                            TestModeCodeSub2 = "M4_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingLeft2",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        */
                                        //DateTime currentTime = DateTime.Now;
                                        //TimeSpan timeSpan = currentTime.TimeOfDay;

                                        //long milliseconds = (long)timeSpan.TotalMilliseconds;

                                        
                                        
                                    }
                                    else if (key.Equals(Key.Right) &&
                                        BackGroundKeyListener.ReverseMode)
                                    {
                                        if (!(TestModeCodeSub2 == "M24_Ing" ||
                                            TestModeCodeSub2 == "M4_Ing"))
                                        {
                                            TestModeTimeSpanValue = (double)DateTime.Now.TimeOfDay.TotalMilliseconds;
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " Setting2",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        if (Keyboard.GetKeyStates(Key.Down).HasFlag(KeyStates.Down))
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                        }
                                        else
                                        {
                                            TestModeCodeSub2 = "M4_Ing";
                                        }
                                        /*
                                        if (TestModeCodeSub2 == "M2_Ing")
                                        {
                                            
                                            TestModeCodeSub2 = "M24_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingRight1",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        else if (TestModeCodeSub2 == "M24_Ing")
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                        }
                                        else
                                        {
                                            TestModeCodeSub2 = "M4_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingRight2",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        */
                                        
                                    }
                                    else if (key.Equals(Key.Down))
                                    {
                                        if (!(TestModeCodeSub2 == "M24_Ing" ||
                                            TestModeCodeSub2 == "M4_Ing"))
                                        {
                                            TestModeTimeSpanValue = (double)DateTime.Now.TimeOfDay.TotalMilliseconds;
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingDown1",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        if (Keyboard.GetKeyStates(Key.Left).HasFlag(KeyStates.Down)&&
                                             !BackGroundKeyListener.ReverseMode)
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                        }
                                        else if (Keyboard.GetKeyStates(Key.Right).HasFlag(KeyStates.Down) &&
                                             BackGroundKeyListener.ReverseMode)
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                        }
                                        else
                                        {
                                            TestModeCodeSub2 = "M2_Ing";
                                        }


                                        /*
                                        if (TestModeCodeSub2 == "M4_Ing")
                                        {
                                            
                                            TestModeCodeSub2 = "M24_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingDown1",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        else if (TestModeCodeSub2 == "M24_Ing")
                                        {
                                            TestModeCodeSub2 = "M24_Ing";
                                        }
                                        else
                                        {
                                            TestModeCodeSub2 = "M2_Ing";
                                            consoleUtil.ConsoleWCode(TestModeCodeSub2 + " SettingDown2",
                                                scriptname, "$*@#TestModeCodeSub2");
                                        }
                                        */
                                        

                                    }
                                    
                                    //RelaseKey
                                    //TestMode20230531EXE(Key.D0);
                                    InputKeyList.Clear();
                                    
                                    bool continuecondition=true;
                                    foreach (var item in FunctionKeyList) {
                                        if (CheckKeyDown(item))
                                        {
                                            
                                            continuecondition = false;
                                            
                                        }       
                                    }
                                    foreach (var item in SkillKeyList)
                                    {
                                        if (CheckKeyDown(item))
                                        {
                                            consoleUtil.ConsoleWCode(item.ToString(), scriptname,
                                                "ChekKeyDown ContinueCondtion#@");
                                            //continuecondition = false;
                                            TestMode20230531EXE(item);
                                            InputKeyList.Clear();
                                            Thread.Sleep(400);
                                            continue;
                                        }
                                            
                                    }
                                    Thread.Sleep(10);
                                    if (continuecondition)
                                        continue;
                                }

                                Form1_Func.BASE_Wait_Delay = 20;
                                TestMode20230531EXE(key);
                                InputKeyList.Clear();
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
                                if (TestModeCodeSub == "MD")
                                    TestModeCodeSub = "";
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

