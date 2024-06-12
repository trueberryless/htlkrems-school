using System.Collections;

namespace LinqExamples;

internal class Program
{
    private static Random rng = new Random();

    /*
     * Replace every 'TODO' comment with the appropriate code to pass the tests
     * AND fulfill the requirements in the comments.
     * For all your code, don't use any loops, but Linq only to complete the tasks.
     */

    static void Main(string[] args)
    {
        // Create a set of elements first holding 1.000 objects of type Person.
        // The IDs range from 0 to 999 and the items are shuffled.
        var elements = Enumerable.Range(0, 1_000)
            .OrderBy(n => rng.Next())
            .Select(n => new Person { Id = n })
            .ToList();

        // Find the highest ID
        int id = default;
        // TODO
        id = elements.Select(p => p.Id).Max();
        Assert("Find highest ID", id == 999);

        // Find the element with the highest ID by choosing the element with the ID selected above
        Person person = new Person();
        // TODO
        person = elements.First(p => p.Id == id);
        Assert("Find element with highest ID", person.Id == 999);

        // Find the element with the highest ID by using the MaxBy method
        Person person2 = new Person();
        // TODO
        person2 = elements.MaxBy(p => p.Id);
        Assert("Find element with highest ID with MaxBy", person2.Id == 999);

        // Find the element with the highest ID by using the Aggregate method
        Person person3 = new Person();
        // TODO
        person3 = elements.Aggregate((p1, p2) => p1.Id > p2.Id ? p1 : p2);
        Assert("Find element with highest ID with Aggregate", person3.Id == 999);

        // Group elements by even/odd IDs
        IEnumerable<Person> peopleWithEvenIds = Enumerable.Empty<Person>();
        IEnumerable<Person> peopleWithOddIds = Enumerable.Empty<Person>();
        // TODO
        peopleWithEvenIds = elements.Where(p => p.Id % 2 == 0);
        peopleWithOddIds = elements.Where(p => p.Id % 2 == 1);
        Assert("Group even/odd elements", peopleWithEvenIds.Count() == peopleWithOddIds.Count() && peopleWithEvenIds.Any());

        // Let's create a second set of elements of type Person.
        // This time the IDs range from 500 to 1.499,
        // meaning the list overlaps with the first set of people.
        var elements2 = Enumerable.Range(500, 1_000)
            .OrderBy(n => rng.Next())
            .Select(n => new Person { Id = n })
            .ToList();

        // Find intersection of elements and elements2 via their IDs
        IEnumerable<Person> intersection = Enumerable.Empty<Person>();
        // TODO
        intersection = elements.Intersect(elements2, new Person());
        Assert("Find intersection",
            intersection.Count() == 500
            && intersection.Min(p => p.Id) == 500
            && intersection.Max(p => p.Id) == 999);

        // Find union of elements and elements2 via their IDs, removing duplicates
        IEnumerable<Person> personUnion = Enumerable.Empty<Person>();
        // TODO
        personUnion = elements.Union(elements2, new Person());
        Assert("Find union",
            personUnion.Count() == 1_500
            && personUnion.DistinctBy(p => p.Id).Count() == 1_500);

        // Let's create another set of elements.
        // This time it's objects of type Items.
        // A Person can own an Item. If so the Item's OwnerId will be equal to the Owner's ID.
        var items = Enumerable.Range(0, 1_500_000)
            .Select(n => new Item 
            { 
                Id = n, 
                OwnerId = rng.Next(1_499) 
            })
            .ToList();

        // Make sure that every owner ID in items is an existing ID in the union of elements and elements2
        Assert("Verify OwnerIds exist", items.All(i => personUnion.Any(p => i.OwnerId == p.Id)));

        // Join Items with their owners using a Linq Query Expression (from ... in ... join ...)
        IEnumerable<ItemMapping> itemMappings1 = Enumerable.Empty<ItemMapping>();
        // TODO
        Assert("Join tables with Linq Query Expression", itemMappings1.Count() == 1_500);

        // Join Items with their owners using Linq with Lambda Expressions
        IEnumerable<ItemMapping> itemMappings2 = Enumerable.Empty<ItemMapping>();
        // TODO
        Assert("Join tables with Lambda Expressions", itemMappings2.Count() == 1_500);

        // Make sure both approaches yield the same result
        Assert("Verify Join approaches yield same result", false /* TODO */);

        // Make sure the results are correct,
        // meaning an ItemMapping should only contain items
        // where the OwnerId matches the owner inside the same mapping.
        Assert("Verify Join yields correct result", false /* TODO */);

        // Use SelectMany to select all items from the itemMappings1 into one Enumerable
        IEnumerable<Item> selectedItemsFromMappings = Enumerable.Empty<Item>();
        // TODO
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
}