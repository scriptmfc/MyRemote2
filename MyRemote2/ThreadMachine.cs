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
        static void ThreadWork()
        {
            // BASE_Wait_Delay 값만큼 대기
            for (int i = 0; i < Form1_Func.MacroItemList.Count; i++)
            {
                Thread.Sleep(Form1_Func.BASE_Wait_Delay);
                Form1_Func.MacroWork(Form1_Func.MacroItemList[i]);
                Console.WriteLine(i+"실행");
            }
            Console.WriteLine("종료");
            
        }

        public static void WaitThread(int time)
        {
            Thread.Sleep(time);
        }

        // 스레드 시작 메서드
        public static void StartThread()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
            else
            {
                thread = new Thread(new ThreadStart(ThreadWork));
                thread.Start();
            }
            if (!thread.IsAlive)
            {
                // 스레드 생성 및 시작
                thread = new Thread(new ThreadStart(ThreadWork));
                thread.Start();
            }
        }

        public static void StopThread()
        {
            // 스레드 생성 및 시작
            
            thread.Abort();
        }
    }

}
