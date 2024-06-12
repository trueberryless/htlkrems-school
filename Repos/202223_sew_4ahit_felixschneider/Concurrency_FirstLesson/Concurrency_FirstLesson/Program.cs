int counter = 0;
// object lockObj = new object(); // macht eig nix; dieses wird als Scope verwendet
// object lockObj2 = new object();

SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0);

new Thread(DoWork).Start();
new Thread(DoWork2).Start();

void DoWork()
{
    while (true)
    {
        Thread.Sleep(1000);
        Console.WriteLine("1");
        semaphoreSlim.Release();
        semaphoreSlim.Release();
        
        /*lock (lockObj) // solange es hier gelockt ist, kann es bei DoWork2 nicht gelockt werden
        {
            
            lock (lockObj2)
            {
                Thread.Sleep(100);
                Console.WriteLine("*");
            }
        }*/
    }
}

void DoWork2()
{
    while (true)
    {
        semaphoreSlim.Wait();
        Thread.Sleep(500);
        Console.WriteLine("2");
        
        /*lock (lockObj2)
        {
            lock (lockObj)
            {
                Thread.Sleep(100);
                Console.WriteLine("+");
            }
        }*/
    }
}