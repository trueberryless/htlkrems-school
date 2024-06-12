
using BinaryFormatter_Person;
using System.Runtime.Serialization.Formatters.Binary;

static void BinWrite(string name, int age)
{
    Person person = new Person();
    person.Name = name;
    person.Age = age;

    BinaryFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream("binaryformatter.txt", FileMode.Create, FileAccess.Write, FileShare.None);
    formatter.Serialize(stream, person);
    stream.Close();
}

static void BinRead()
{
    BinaryFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream("binaryformatter.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
    Person person = (Person)formatter.Deserialize(stream);
    stream.Close();
}

BinWrite("Felix", 16);
BinRead();
