using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace LinqVorbereitung;

internal class ProgramSolved
{
    private static Random rng = new Random();

    public static void MainSolved(string[] args)
    {
        // For all your code, don't use any loops, but Linq only to complete the tasks

        var elements = Enumerable.Range(0, 1_000)
            .OrderBy(n => rng.Next())
            .Select(n => new Person { Id = n })
            .ToList();

        // Find the highest ID
        int id = default;
        id = elements.Max(n => n.Id);
        Assert("Find highest ID", id == 999);

        // Find the element with the highest ID by choosing the element with the ID selected above
        Person person = new Person();
        person = elements.First(p => p.Id == id);
        Assert("Find element with highest ID", person.Id == 999);

        // Find the element with the highest ID by using the MaxBy method
        Person person2 = new Person();
        person2 = elements.MaxBy(n => n.Id) !;
        Assert("Find element with highest ID with MaxBy", person2.Id == 999);

        // Find the element with the highest ID by using the Aggregate method
        Person person3 = new Person();
        person3 = elements.Aggregate((p1, p2) => p1.Id > p2.Id ? p1 : p2);
        Assert("Find element with highest ID with Aggregate", person3.Id == 999);

        // Group elements by even/odd IDs
        IEnumerable<Person> peopleWithEvenIds = Enumerable.Empty<Person>();
        IEnumerable<Person> peopleWithOddIds = Enumerable.Empty<Person>();
        var groupings = elements.GroupBy(e => e.Id % 2);
        peopleWithEvenIds = groupings.First(g => g.Key % 2 == 0);
        peopleWithOddIds = groupings.First(g => g.Key % 2 != 0);
        Assert("Group even/odd elements", peopleWithEvenIds.Count() == peopleWithOddIds.Count() && peopleWithEvenIds.Any());

        var elements2 = Enumerable.Range(500, 1_000)
            .OrderBy(n => rng.Next())
            .Select(n => new Person { Id = n })
            .ToList();

        // Find intersection of elements and elements2 via their IDs
        IEnumerable<Person> intersection = Enumerable.Empty<Person>();    
        intersection = elements.Intersect(
            elements2, 
            ProjectionEqualityComparer<Person>.Create(p => p.Id));
        Assert("Find intersection",
            intersection.Count() == 500
            && intersection.Min(p => p.Id) == 500
            && intersection.Max(p => p.Id) == 999);

        // Find union of elements and elements2 via their IDs, removing duplicates
        IEnumerable<Person> personUnion = Enumerable.Empty<Person>();
        personUnion = elements.UnionBy(elements2, e => e.Id);
        Assert("Find union",
            personUnion.Count() == 1_500
            && personUnion.DistinctBy(p => p.Id).Count() == 1_500);

        var items = Enumerable.Range(0, 1_500_000)
            .Select(n => new Item 
            { 
                Id = n, 
                OwnerId = rng.Next(1_499)
            })
            .ToList();

        // Make sure that every owner ID in items is an existing ID in the union of elements and elements2
        var personIds = personUnion.Select(p => p.Id).ToList();
        Assert("Verify OwnerIds exist", items.Select(i => i.OwnerId).All(personIds.Contains));

        // Join Items with their owners using a Linq Query Expression (from ... in ... join ...)
        IEnumerable<ItemMapping> itemMappings1 = Enumerable.Empty<ItemMapping>();
        itemMappings1 =
            (from p in personUnion
            join item in items on p.Id equals item.OwnerId into gj
            select new ItemMapping
            {
                Owner = p,
                Items = gj.ToList()
            }).ToList();
        Assert("Join tables with Linq Query Expression", itemMappings1.Count() == 1_500);

        // Join Items with their owners using Linq with Lambda Expressions
        IEnumerable<ItemMapping> itemMappings2 = Enumerable.Empty<ItemMapping>();
        itemMappings2 = personUnion.GroupJoin(
            items, 
            p => p.Id, 
            i => i.OwnerId, 
            (p, gj) => new ItemMapping 
            { 
                Owner = p, 
                Items = gj.ToList() 
            }).ToList();
        Assert("Join tables with Lambda Expressions", itemMappings2.Count() == 1_500);

        // Make sure both approaches yield the same result
        Assert("Verify Join approaches yield same result", itemMappings1.SequenceEqual(itemMappings2, new ItemMappingComparer()));

        // Make sure the results are correct,
        // meaning an ItemMapping should only contain items
        // where the OwnerId matches the owner inside the same mapping.
        Assert("Verify Join yields correct result", itemMappings1.All(m => m.Items.All(i => i.OwnerId == m.Owner.Id)));

        // Use SelectMany to select all items from the itemMappings1 into one Enumerable
        IEnumerable<Item> selectedItemsFromMappings = Enumerable.Empty<Item>();
        selectedItemsFromMappings = itemMappings1.SelectMany(m => m.Items);
        Assert("Use select many to flatten results", selectedItemsFromMappings.DistinctBy(i => i.Id).Count() == 1_500_000);
    }

    private static void Assert(string description, bool condition)
    {
        if (condition)
        {
            Console.WriteLine($"✓ - {description}");
        }
        else
        {
            Console.Error.WriteLine($"FAIL - {description}");
        }
    }

    private class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person? x, Person? y)
        {
            return x == null && y == null
                || x != null && y != null && x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    private class ItemMappingComparer : IEqualityComparer<ItemMapping>
    {
        public bool Equals(ItemMapping? x, ItemMapping? y)
        {
            return x == null && y == null
                || x != null
                    && y != null
                    && x.Owner.Id == y.Owner.Id
                    && x.Items.SequenceEqual(y.Items, ProjectionEqualityComparer<Item>.Create(i => i.Id));
        }

        public int GetHashCode([DisallowNull] ItemMapping obj)
        {
            var hashCode = obj.Owner.GetHashCode() * 17;
            if (obj.Items != null)
            {
                foreach (var item in obj.Items)
                {
                    hashCode ^= item.GetHashCode();
                }
            }
            return hashCode;
        }
    }
}