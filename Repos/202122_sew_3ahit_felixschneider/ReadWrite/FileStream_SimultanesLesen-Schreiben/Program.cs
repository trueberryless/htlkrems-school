
FileStream fs_w = new FileStream("file.txt", FileMode.Truncate, FileAccess.Write, FileShare.Read);
FileStream fs_r = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.Write);

StreamWriter sw = new StreamWriter(fs_w);
StreamReader sr = new StreamReader(fs_r);

// moin in file.txt schreiben und flushen
sw.WriteLine("moin");
sw.Flush();

// Inhalt auslesen
Console.WriteLine(sr.ReadToEnd());

// moin2 in file.txt schreiben und flushen
sw.WriteLine("zweites moin");
sw.Flush();

// Inhalt auslesen
Console.WriteLine(sr.ReadToEnd());


// alles Closen
sw.Close();
sw.Close();