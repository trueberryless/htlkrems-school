
FileStream fs = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
StreamWriter sw = new StreamWriter(fs);
StreamReader sr = new StreamReader(fs);

// moin in file.txt schreiben und flushen
sw.WriteLine("moin");
sw.Flush();

// Zeiger wieder auf Begin der Datei setzen
fs.Seek(0, SeekOrigin.Begin);

// Inhalt auslesen
Console.WriteLine(sr.ReadToEnd());

// FileStream schließen
fs.Close();
