using ServiceGraph.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MemoryStudentService>(); // Singleton -> nur eine Instanz
builder.Services.AddSingleton<SchoolService>();
// builder.Services.AddTransient<MemoryStudentService>(); // Transient -> Instanz immer neu

var app = builder.Build();

var studentService = app.Services.GetService<MemoryStudentService>();
var schoolService = app.Services.GetService<SchoolService>();

Console.ReadLine();