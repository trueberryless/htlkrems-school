PlayfairChiffre.PlayfairChiffre pc = new PlayfairChiffre.PlayfairChiffre("Snowball");

string test = pc.Encryption("Euston saw I was not Sue");
Console.WriteLine(test);

test = pc.Decryption("CAWLTAXWYMMENEKZ");
Console.WriteLine(test);

Console.ReadLine();
