namespace Test;

public class VisitorGroup
{
    public static SemaphoreSlim StudentHandshake = new SemaphoreSlim(0);
    public static SemaphoreSlim CryptGuard = new SemaphoreSlim(2);
    public static SemaphoreSlim PhotostationGuard = new SemaphoreSlim(2);
    
    public void Run()
    {
        StudentGuide.GroupHandshake.Wait();
        AcknowledgeGuide();
        StudentHandshake.Release();

        CryptGuard.Wait();
        VisitCrypt();
        CryptGuard.Release();

        PhotostationGuard.Wait();
        VisitPhotostation();
        PhotostationGuard.Release();

        StudentGuide.EndingHandshake.Release();

    }

    private void AcknowledgeGuide()
    {
        Console.WriteLine(
            "Acknowleding Guide"
        );
        Thread.Sleep(100);
    }

    private void VisitCrypt()
    {
        Console.WriteLine("Visiting Crypt");
        Thread.Sleep(1000);
    }

    private void VisitPhotostation()
    {
        Console.WriteLine(
            "Visiting Photostation"
        );
        Thread.Sleep(1500);
    }
}