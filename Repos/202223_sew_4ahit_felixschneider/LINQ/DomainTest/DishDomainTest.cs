using Domain.Dishes;

namespace DomainTest;

public class DishDomainTest
{
    [SetUp]
    public void Setup()
    {
    }

    /*
        * 1.1) Beispiel: Ermitteln Sie alle Gerichte die weniger
        *      als 400 Kalorien haben. Geben Sie die Namen der
        *      entsprechenden Gerichte aus.
        *
        */
    [Test]
    public void GetDishByCalories()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes where dish.Calories < 400 select dish.Name;

        var data = query.ToList();

        Assert.That(data.Count, Is.EqualTo(2));

        var query2 = dishes.Where(d => d.Calories < 400).Select(d => d.Name);

        var data2 = query2.ToList();

        Assert.That(data2.Count, Is.EqualTo(2));
    }

    /*
     * 1.2) Beispiel: Ermitteln Sie die Fisch- und Fleischgerichte, die nicht
     *      mit einem C beginnen.
     *
     *      Geben Sie die Namen der entsprechenden Gerichte aus. Sortieren Sie
     *      das Ergebnis nach den Namen der Gerichte.
     */
    [Test]
    public void GetDishByDishType()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes
            where (dish.Type == EDishType.FISH || dish.Type == EDishType.MEAT)
                  && dish.Name.ToLower()[0] != 'c'
            orderby dish.Name
            select dish.Name;

        var data = query.ToList();

        Assert.That(data.Count, Is.EqualTo(1));

        var query2 = dishes.Where(d => d.Type == EDishType.FISH || d.Type == EDishType.MEAT)
            .Where(d => d.Name.ToLower()[0] != 'c')
            .OrderBy(d => d.Name)
            .Select(d => d.Name);

        var data2 = query2.ToList();

        Assert.That(data2.Count, Is.EqualTo(1));
    }

    /*
     * 1.3) Beispiel: Ermitteln Sie alle Gerichte die mehr als
     *      7 Zutaten haben. Geben Sie die Namen der Gerichte aus.
     */
    [Test]
    public void CalculateMaxCalorieLevel2()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes where dish.Ingredients.Count > 7 select dish.Name;

        var data = query.ToList();

        Assert.That(data.Count, Is.EqualTo(5));

        var query2 = dishes.Where(d => d.Ingredients.Count > 7).Select(d => d.Name);

        var data2 = query2.ToList();

        Assert.That(data2.Count, Is.EqualTo(5));
    }

    /*
     * 1.4) Beispiel: Ermitteln Sie alle Gerichte die Pilze als Zutat beinhalten.
     */
    [Test]
    public void CalculateMaxCalorieLevel3()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes where dish.Ingredients.Contains(EIngredient.MUSHROOM) select dish;

        var data = query.ToList();

        Assert.That(data.Count, Is.EqualTo(2));

        var query2 = dishes.Where(d => d.Ingredients.Contains(EIngredient.MUSHROOM));

        var data2 = query2.ToList();

        Assert.That(data2.Count, Is.EqualTo(2));
    }

    /*
     * 1.5) Beispiel: Berechnen Sie die Anzahl der Kalorien aller Fleischgerichte.
     */
    [Test]
    public void CalculateSumCalorieLevel()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes
            where dish.Type == EDishType.MEAT
            select dish;

        var data = query.ToList().Sum(d => d.Calories);

        Assert.That(data, Is.EqualTo(1600));

        var query2 = from dish in dishes
            where dish.Type == EDishType.MEAT
            group dish by dish.Type
            into dishGroup
            select dishGroup.Sum(d => d.Calories);

        var data2 = query2.ToList();

        Assert.That(data2.Count, Is.EqualTo(1));

        var query3 = dishes
            .GroupBy(d => d.Type,
                (key, dishGroup)
                    => new
                    {
                        type = key,
                        Calories = dishGroup.Sum(d => d.Calories)
                    })
            .Where(d => d.type == EDishType.MEAT)
            .Select(d => d.Calories);

        var data3 = query3.ToList();

        Assert.That(data3[0], Is.EqualTo(1600));
    }

    /*
     * 1.6) Beispiel: Gruppieren Sie die Gerichte nach ihrem Typ. Geben
     *      Sie die gruppierten Gerichte zurück
     *
     */
    [Test]
    public void GroupDishByType()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes
            group dish by dish.Type
            into dishGroup
            select new { type = dishGroup.Key, dishGroup = dishGroup};

        var data = query.ToList();

        Assert.That(data.Count, Is.EqualTo(2));

        var query2 = dishes
            .GroupBy(
                d => d.Type,
                (key, dishGroup)
                    => new
                    {
                        type = key,
                        dishGroup = dishGroup
                    }
            );

        var data2 = query2.ToList();
        
        Assert.That(data2.Count, Is.EqualTo(2));
    }


    /*
     * 1.7) Beispiel: Berechnen Sie die Anzahl der Elemente für jede DishTyp Gruppe.
     *                
     */
    [Test]
    public void GroupDishByTypeCountingElements()
    {
        var dishes = DishFactory.GetInstance().CreateDishes();

        var query = from dish in dishes
            group dish by dish.Type
            into dishGroup
            select dishGroup.Count();

        var data = query.ToList();
        
        Assert.That(data[0], Is.EqualTo(4));

        var query2 = dishes
            .GroupBy(
                d => d.Type,
                (key, dishGroup)
                    => new
                    {
                        type = key,
                        count = dishGroup.Count()
                    });
        
        var data2 = query2.ToList();
        
        Assert.That(data2[0].count, Is.EqualTo(4));
    }

    /*
     * 1.8) Beispiel: Welche Zutaten befinden sich in jedem Gericht?
     *      Geben Sie die Zutaten geordnet nach ihrem Namen aus.
     *                
     */
    [Test]
    public void CommonIngredient()
    {
    }
}