
using BinaryFormatter;

static void BinWrite(string name, int age)
{
    Person person = new Person();
    person.Age = age;
    person.Name = name;

    BinaryFormatter formatter = new BinaryFormatter();
}
