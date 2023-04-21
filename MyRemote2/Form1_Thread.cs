using System;

public class Form1_Thread
{
	public static int BASE_Wait_Delay;

    public Form1_Thread()
    {

    }

    // 스레드 작업 메서드
    public void ThreadWork()
    {
        // BASE_Wait_Delay 값만큼 대기
        Thread.Sleep(BASE_Wait_Delay);

        // 첫 번째 작업 수행
        // TODO: 첫 번째 작업 내용 작성

        // 두 번째 작업 수행
        // TODO: 두 번째 작업 내용 작성

        // 세 번째 작업 수행
        // TODO: 세 번째 작업 내용 작성
    }

    // 스레드 시작 메서드
    public static void StartThread()
    {
        // 스레드 생성 및 시작
        Thread thread = new Thread(new ThreadStart(ThreadWork));
        thread.Start();
    }
}
