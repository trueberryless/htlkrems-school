namespace Domain.Dishes; 

public class Dish {

    public string Name { get; init; }

    public int Calories { get; init; }

    public EDishType Type { get; init; }

    public List<EIngredient> Ingredients { get; init; }

    public Dish(string name, int calories, EDishType type, List<EIngredient> ingredients) {
        Name = name;
        Calories = calories;
        Type = type;
        Ingredients = ingredients;
    }

}