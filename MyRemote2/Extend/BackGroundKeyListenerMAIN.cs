using MyRemote2.MacroPlusFold.ModuleFold.FastCodeModuleFold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MyRemote2.Extend
{
    public static class BackGroundKeyListenerMAIN
    {
        static readonly string scriptname = "BackGroundKeyListenerMAIN";

        public static int SpecialKeyboardLayer;


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



        static bool CheckKeyDown(Key key)
        {
            if (Keyboard.GetKeyStates(key).HasFlag(KeyStates.Down))
                return true;
            else
                return false;
        }

        static void Keyboardd()
        {
            #region Key -> Scroll,Pause F14~F24
            keysToCheckList.Add(Key.Scroll);
            keysToCheckList.Add(Key.Pause);

            keysToCheckList.Add(Key.F14);
            keysToCheckList.Add(Key.F15);
            keysToCheckList.Add(Key.F16);
            keysToCheckList.Add(Key.F17);
            keysToCheckList.Add(Key.F18);
            keysToCheckList.Add(Key.F19);
            keysToCheckList.Add(Key.F20);
            keysToCheckList.Add(Key.F21);
            keysToCheckList.Add(Key.F22);
            keysToCheckList.Add(Key.F23);
            keysToCheckList.Add(Key.F24);
            #endregion

            //int a = 0;
            while (isRunning)
            {

                Thread.Sleep(40); //minimum CPU usage
#if false
                a++;
                if (a % 30 == 0)
                {
                    //Console.WriteLine("돌고있음-_"+(a/30).ToString());
                }
#endif

              
                // 각 키들을 확인하여 눌린 경우 동작 수행
                foreach (var key in keysToCheckList)
                {
                    if (Keyboard.GetKeyStates(key).HasFlag(KeyStates.Down))
                    {
                        switch(key)
                        {
                            case Key.F14:
                                if (MacroPlusFold.MacroPlus.selectedEnvironMentMode
                                == MacroPlusFold.MacroPlus.EnvironMentMode.CONSOLE)
                                {
                                    ThreadMachine.StartThread("SimpleDebugConsole");
                                }
                                else if (MacroPlusFold.MacroPlus.selectedEnvironMentMode
                                    == MacroPlusFold.MacroPlus.EnvironMentMode.UNITY)
                                {
                                    ThreadMachine.StartThread("SimpleDebugUnity");
                                }
                                else
                                {
                                    Console.WriteLine("ERR_ BackGroundKeyListenerMAIN아직 정해지지 않음" + key);
                                }
                                break;
                            case Key.F15:
                                FastCodeSimple.For_SimpleSetting();
                                ThreadMachine.StartThread("FastCodeSimple_[For]_SimpleSetting");
                                break;
                            case Key.F16:
                                FastCodeSimple.Switch_SimpleSetting();
                                ThreadMachine.StartThread("FastCodeSimple_[Switch]_SimpleSetting");
                                break;

                            default:
                                if (key.Equals(Form1_Func.StartKey))
                                    ThreadMachine.StartThread("Form1_FuncMacro");
                                else if (key.Equals(Form1_Func.StopKey))
                                {
                                    ThreadMachine.StopThread();
                                }
                                else
                                {
                                    Console.WriteLine("ERR_ BackGroundKeyListenerMAIN아직 정해지지 않음" + key);
                                }
                                break; 

                        }

                        

                        Thread.Sleep(400);

                        
                    }
                }
            }
            Console.WriteLine("BackGroundKeyListnerMAIN Keyboardd Thread는 종료되었습니다.");
        }

        public static void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("BackGroundKeyListnerMAIN thread 러닝 false");
            isRunning = false;
        }

    }
}
