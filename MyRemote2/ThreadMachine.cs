using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRemote2
{
    public static class ThreadMachine
    {
        static Thread thread;
        // 스레드 작업 메서드
        static string thread_code;

        static void ThreadWorkForm1_FuncMacro()
        {
            // BASE_Wait_Delay 값만큼 대기
            for (int i = 0; i < Form1_Func.MacroItemList.Count; i++)
            {

                if (Form1_Func.MacroItemList[i].macroEnum == MacroEnum.Wait)
                {
                    Thread.Sleep(Form1_Func.MacroItemList[i].waitdelay);
                    
                }
                else
                {
                    Thread.Sleep(Form1_Func.BASE_Wait_Delay);
                    Form1_Func.MacroWork(Form1_Func.MacroItemList[i]);
                }
                
                Console.WriteLine(i+ "실행 ThreadWorkForm1_FuncMacro");
            }
            Console.WriteLine("종료");
            
        }

        static void ThreadWork_MacroPlus()
        {
            MacroPlusFold.MacroBox MacroBox;
            if (!MacroPlusFold.MacroPlus.MacroBoxDict.TryGetValue(thread_code, out MacroBox))
            {
                Console.WriteLine(thread_code + "ERR_ Code 없음 ThreadWork_MacroPlus");
                return;
            }

            // BASE_Wait_Delay 값만큼 대기
            for (int i = 0; i < MacroBox.MacroItemList.Count; i++)
            {

                if (MacroBox.MacroItemList[i].macroEnum == MacroEnum.Wait)
                {
                    Thread.Sleep(MacroBox.MacroItemList[i].waitdelay);

                }
                else
                {
                    Thread.Sleep(MacroBox.BASE_Wait_Delay);
                    MacroPlusFold.MacroWorkEXE.Process(MacroBox.MacroItemList[i]);
                }

                Console.WriteLine(i + "실행 ThreadWork_MacroPlus");
            }
            Console.WriteLine("종료");

        }

        public static void WaitThread(int time)
        {
            Thread.Sleep(time);
        }

        // 스레드 시작 메서드
        public static void StartThread(string code)
        {
            thread_code = code;

            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
            else
            {
                ThreadSetting(code);
                if (thread != null)
                    thread.Start();

            }
            if (!thread.IsAlive)
            {
                ThreadSetting(code);
                // 스레드 생성 및 시작
                if (thread!=null)
                    thread.Start();
            }
        }

        public static void ThreadSetting(string code)
        {
            switch (code)
            {
                case "Form1_FuncMacro":

                    thread = new Thread(new ThreadStart(ThreadWorkForm1_FuncMacro));
                    break;
                case "MacroPlus_MacroTest1":
                    thread = new Thread(new ThreadStart(ThreadWork_MacroPlus));
                    break;
                default:
                    Console.WriteLine("ThreadSetting " + "ERR_ Code 없음 ThreadWork_MacroPlus");
                    thread = null;
                    break;
            }
        }

        public static void StopThread()
        {
            // 스레드 생성 및 시작
            
            thread.Abort();
        }
    }

}
