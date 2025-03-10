using System;
using System.Threading.Tasks;

public class Demo
{
    private Task _pollJobTask = Task.CompletedTask;
    private Task _executeSequentialJobTask = Task.CompletedTask;
    private Task _executeInstantJobTask = Task.CompletedTask;

    public void RunDemo()
    {
        _pollJobTask = _pollJobTask.ContinueWith(async _ =>
        {
            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);
                try
                {
                    await PollJobTaskLoop(i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"PollJobTaskLoop error: {ex}");
                }
            }
        });

        _executeSequentialJobTask = _executeSequentialJobTask.ContinueWith(async _ =>
        {
            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);
                try
                {
                    await ExecuteSequentialJobLoop(i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ExecuteSequentialJobLoop error: {ex}");
                }
            }
        });

        _executeInstantJobTask = _executeInstantJobTask.ContinueWith(async _ =>
        {
            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);
                try
                {
                    await ExecuteInstantJobLoop(i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ExecuteInstantJobLoop error: {ex}");
                }
            }
        });
        
    }

    private async Task PollJobTaskLoop(int iteration)
    {
        await Task.Delay(100);
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] 0.1秒任务 执行 {iteration} 次.");
    }

    private async Task ExecuteSequentialJobLoop(int iteration)
    {
        await Task.Delay(1000);
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] 1.0秒任务 执行 {iteration} 次.");
    }

    private async Task ExecuteInstantJobLoop(int iteration)
    {
        await Task.Delay(2000);
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] 2.0秒任务 执行 {iteration} 次.");
    }

    
    public static async Task Main(string[] args)
    {
        Demo demo = new Demo();
        demo.RunDemo();

        Console.ReadKey();
    }
}
