Console.WriteLine("concurrent programming!");

// Anlegen einer Task
// var task = new Task(() => Console.WriteLine("42"));
var task = Task.Run(() => 42);

// Console.WriteLine(task.Status);
// task.Start();

Console.WriteLine(task.Status); // Zustände in dem sich der Task befindet
var result = task.Result;

Console.WriteLine(result);