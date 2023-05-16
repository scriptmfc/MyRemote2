﻿using System;
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
        static bool isRunning = true;

        public static List<Key> InputKeyList = new List<Key>();
        public static void ListenStart(object sender, EventArgs e)
        {
            Thread TH = new Thread(Keyboardd);
            TH.SetApartmentState(ApartmentState.STA);
            //CheckForIllegalCrossThreadCalls = false;
            TH.Start();
        }

        static Key[] keysToCheck = new Key[] { Key.Return, Key.A, Key.B, Key.C,Key.F9,
        Key.F3,Key.F7,Key.Scroll,Key.Pause}; // 원하는 키들을 배열에 추가


        static void Keyboardd()
        {
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
                foreach (var key in keysToCheck)
                {
                    if (Keyboard.GetKeyStates(key).HasFlag(KeyStates.Down))
                    {
                        if (InputKeyList.Count == 0)
                        {
                            InputKeyList.Add(key);
                            if(WriteTextWindow.Instance!=null)
                            WriteTextWindow.Instance.KeyExe(key);
                            else if (Form1.Instance != null)
                            {
                                Form1.Instance.BackGroundKeyExe(key);
                            }
                            //InputKeyList.Clear();
                            Thread.Sleep(500);
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
        }
        
        public static void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("thread 러닝 false");
            isRunning = false;
            WriteTextWindow.Instance = null;
        }
    }
}
