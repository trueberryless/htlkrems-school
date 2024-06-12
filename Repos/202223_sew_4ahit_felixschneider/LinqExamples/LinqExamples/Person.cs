using System.Collections;

namespace LinqExamples;

internal class Person : IEqualityComparer<Person>
{
    public int Id { get; set; }
    public string Name { get => $"Person {Id}"; }

    public bool Equals(Person? x, Person? y)
    {
        return x.Id == y.Id;
    }

    public int GetHashCode(Person obj)
    {
        return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
    }
}
