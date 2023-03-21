// Write a console program that prints output to the console continously until the user pushes ENTER. 
class Program
{
    /*static void Main(string[] args)
    {
        bool continuePrinting = true;
        while (continuePrinting)
        {
            Console.WriteLine("Printing...");
            Thread.Sleep(1000);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    continuePrinting = false;
                }
            }
        }
        Console.WriteLine("Printing stopped");
    }*/

    static void Main(string[] args)
    {
        var tokenSource = new CancellationTokenSource();

        void WriteToConsole(CancellationToken token)
        {
            while (!token.IsCancellationRequested) Console.Write('-');
        }
        try
        {
            Task task = Task.Factory.StartNew(() =>
            {
                throw new NotImplementedException();
                while (!tokenSource.Token.IsCancellationRequested)
                {
                    Console.Write('-');
                }
            }, tokenSource.Token);
            Console.ReadLine();
            tokenSource.Cancel();
            task.Wait(); // never leave task running
        }
        catch (Exception exception) 
        {
            Console.WriteLine(exception);
        }

        /*Task task = Task.Run(() =>
        {
            throw new NotImplementedException();
            while (true) Console.WriteLine('-');
        });
        Console.ReadLine();*/
    }
}