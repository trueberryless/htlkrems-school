namespace Domain.Trader; 

public class TraderDataFactory {

    public static TraderDataFactory Instance { get; } = new();

    public List<Trader> CreateTrader() {
        List<Trader> traders = new List<Trader> {
            new("Peppi",ECity.VIENNA),
            new("Gustaf",ECity.VIENNA),
            new("Abdul",ECity.VIENNA),
            new("Luka",ECity.MILAN),
            new("Enzo", ECity.MILAN),
            new("Gianni", ECity.MILAN),
            new("Romeo",ECity.MILAN),
            new("Fabricio",ECity.MILAN),
            new("Alan", ECity.LONDON),
            new("Eric",ECity.LONDON)
        };

        return traders;
    }
    
    public  List<Transaction> CreateTransactions() {
        List<Trader> traders = CreateTrader();
            
        List<Transaction> transactions = new List<Transaction>() {
            new(traders[0], 2020, 50000),
            new(traders[0], 2020,340000),
            new(traders[0], 2020,210000),
            new(traders[0], 2019,20000),
            new(traders[0], 2019,10000),
            new(traders[1], 2019,450000),
            new(traders[2], 2019,100),
            new(traders[3], 2018,320000),
            new(traders[3], 2020,560000),
            new(traders[3], 2020,230000),
            new(traders[3], 2020,120000),
            new(traders[3], 2019,560000),
            new(traders[6], 2019,430000),
            new(traders[6], 2020,110000),
            new(traders[6], 2020,320000),
            new(traders[6], 2019,350000),
            new(traders[7], 2020,120000),
            new(traders[7], 2020,560000),
            new(traders[7], 2020,230000),
            new(traders[7], 2018,120000)
        };

        return transactions;
    }

}