namespace ServiceGraph.Services;

public class SchoolService
{
    private readonly MemoryStudentService _studentService;

    public SchoolService(MemoryStudentService studentService)
    {
        this._studentService = studentService;
    }
}