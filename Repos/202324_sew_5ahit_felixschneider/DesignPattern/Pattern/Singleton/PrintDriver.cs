namespace Pattern;

public class PrintDriver
{
    private static readonly PrintDriver Instance = new();
    
    // Try to restrict the constructor access
    private PrintDriver() { }

    public static PrintDriver GetInstance()
    {
        return Instance;
    }
}