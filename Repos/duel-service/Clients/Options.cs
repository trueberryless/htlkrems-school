namespace Clients;

public class ServiceOptions
{
   public string hostname { get; set; } 
   public int port { get; set; } 
   public string basePath{ get; set; } 
}
public class RegistrationServiceOptions : ServiceOptions { }
public class StatisticsServiceOptions : ServiceOptions { }
public class MatchmakingServiceOptions : ServiceOptions { }
