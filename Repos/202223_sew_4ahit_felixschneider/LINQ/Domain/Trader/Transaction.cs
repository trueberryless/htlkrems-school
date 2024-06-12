namespace Domain.Trader; 

public class Transaction {

    public Trader Trader { get; init; }

    public int Year { get; init; }

    public int Value { get; init; }
    
    public Transaction(Trader trader, int year, int value) {
        Trader = trader;
        Year = year;
        Value = value;
    }

    protected bool Equals(Transaction other) {
        return Trader.Equals(other.Trader) && Year == other.Year && Value == other.Value;
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Transaction)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Trader, Year, Value);
    }
}