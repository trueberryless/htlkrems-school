
static void BinWrite(string filename)
{ 
    FileStream fs = new FileStream(filename, FileMode.Create);
    BinaryWriter bw = new BinaryWriter(fs);

    bw.Write(187);
    bw.Write(3.14159265358767);
    bw.Write("Felix");

    bw.Close();
}

static void BinRead(string filename)
{
    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
    BinaryReader br = new BinaryReader(fs);

    Console.WriteLine(br.ReadInt32() + "\n" + br.ReadDouble() + "\n" + br.ReadString());

    br.Close();
}

BinWrite("data.bin");
BinRead("data.bin");

