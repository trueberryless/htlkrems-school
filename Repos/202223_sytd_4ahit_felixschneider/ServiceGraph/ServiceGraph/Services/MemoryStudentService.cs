namespace ServiceGraph.Services;

public class MemoryStudentService
{
    public IEnumerable<string> GetStudentNames()
    {
        return new List<string>
        {
            "Max",
            "Moritz",
            "Magnus"
        };
    }
}