namespace Domain.Dishes; 

public class DishFactory {

    private static DishFactory _instance = new DishFactory();

    private DishFactory() {
        
    }
    
    public List<Dish> CreateDishes() {
            List<Dish> dishes = new List<Dish>() {
                new Dish("Tomatensuppe", 300, EDishType.VEGETARIAN,
                    new List<EIngredient>() {
                        EIngredient.TOMATOE, EIngredient.ONION, EIngredient.SALT, EIngredient.WATER, EIngredient.CREAM,
                        EIngredient.PEPPER
                    }),
                new Dish("Kürbiscremesuppe", 350, EDishType.VEGETARIAN,
                    new List<EIngredient>() {
                        EIngredient.SALT, EIngredient.BROTH, EIngredient.ONION, EIngredient.CREAM, EIngredient.CARROT,
                        EIngredient.GARLIC, EIngredient.PEPPER, EIngredient.PUMPKIN, EIngredient.CELERY
                    }),

                new Dish("Wiener Schnitzel", 400, EDishType.MEAT,
                    new List<EIngredient>() {
                        EIngredient.VEAL, EIngredient.BREAD_CRUMBS, EIngredient.FLOUR, EIngredient.EGG,
                        EIngredient.MILK, EIngredient.BUTTER, EIngredient.LEMON, EIngredient.SALT
                    }),
                new Dish("Risotto", 530, EDishType.VEGETARIAN,
                    new List<EIngredient>() {
                        EIngredient.OIL, EIngredient.MUSHROOM, EIngredient.SHALLOT, EIngredient.SALT,
                        EIngredient.PEPPER, EIngredient.WINE, EIngredient.BROTH, EIngredient.BUTTER, EIngredient.CHIVES,
                        EIngredient.CHEESE
                    }),
                new Dish("Carbonara", 650, EDishType.MEAT,
                    new List<EIngredient>() {
                        EIngredient.PASTA, EIngredient.SALT, EIngredient.BACON, EIngredient.BROTH, EIngredient.EGG_YOLK,
                        EIngredient.PEPPER, EIngredient.PARMESAN_CHEESE
                    }),
                new Dish("Mushroom Pasta", 400, EDishType.VEGETARIAN,
                    new List<EIngredient>() {
                        EIngredient.PASTA, EIngredient.PEPPER, EIngredient.SALT, EIngredient.BROTH, EIngredient.CREAM,
                        EIngredient.CREAM, EIngredient.GARLIC, EIngredient.PARMESAN_CHEESE, EIngredient.MUSHROOM
                    }),
                new Dish("Cordon Bleu", 550, EDishType.MEAT, new List<EIngredient>() {
                    EIngredient.VEAL, EIngredient.EGG, EIngredient.OIL, EIngredient.BREAD_CRUMBS, EIngredient.BUTTER, EIngredient.CHEESE, EIngredient.BACON, EIngredient.SALT, EIngredient.PEPPER
                }),
            };

            return dishes;
        }

    public static DishFactory GetInstance() {
        return _instance;
    }

}