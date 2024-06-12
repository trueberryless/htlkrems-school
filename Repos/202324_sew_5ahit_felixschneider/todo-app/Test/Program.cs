// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Model.Entities.Todos;

var todos = new List<Todo>()
{
    new Todo() {Id = 1, Name = "Docker Compose schreiben", Completed = true},
    new Todo() {Id = 2, Name = "Rocket League installieren", Completed = false},
    new Todo() {Id = 3, Name = "Mama Blumen kaufen", Completed = false},
};

// QuestPDF.Settings.License = LicenseType.Community;
//
// PdfGenerator.Program.SavePdf(JsonSerializer.Serialize(todos));