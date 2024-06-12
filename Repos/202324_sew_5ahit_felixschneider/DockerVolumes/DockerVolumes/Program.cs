using Microsoft.AspNetCore.Mvc;

// Setup
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Endpoint mapping
app.MapPost("/add", SaveFile);

app.MapGet("get/{name}", GetFileContent);

// Endpoint implementation
async Task<IResult> GetFileContent([FromRoute] string name)
{
    var fileNames = FileNames.FromInput(name);
    if (!File.Exists(fileNames.PersistentFilePath))
    {
        return Results.NotFound();
    }

    var content = await File.ReadAllTextAsync(fileNames.PersistentFilePath);
    return Results.Ok(content);
}

async Task SaveFile([FromBody] AddRequest addRequest)
{
    var fileNames = FileNames.FromInput(addRequest.Name);
    await using (var sw = File.CreateText(fileNames.TempFilePath))
    {
        await sw.WriteAsync(addRequest.Content);
    }

    if (File.Exists(fileNames.TempFilePath))
    {
        File.Move(
            fileNames.TempFilePath, 
            fileNames.PersistentFilePath, 
            overwrite: true);
    }
}

if (!Directory.Exists("./temp"))
{
    Directory.CreateDirectory("./temp");
}

if (!Directory.Exists("./persistent"))
{
    Directory.CreateDirectory("./persistent");
}

app.Run();

public class FileNames
{
    public string FileName { get; set; }
    
    public string TempFilePath
    {
        get => "./temp/" + FileName;
    }

    public string PersistentFilePath
    {
        get => "./persistent/" + FileName;
    }

    public static FileNames FromInput(string name) =>
        new()
        {
            FileName = SanitizeFileName(name) + ".txt"
        };

    private static string SanitizeFileName(string name)
    {
        string invalidChars = System.Text.RegularExpressions.Regex.Escape( new string( Path.GetInvalidFileNameChars() ) );
        string invalidRegStr = string.Format( @"([{0}]*\.+$)|([{0}]+)", invalidChars );

        return System.Text.RegularExpressions.Regex.Replace( name, invalidRegStr, "_" );
    }
}

public class AddRequest
{
    public string Name { get; set; }
    public string Content { get; set; }
}
