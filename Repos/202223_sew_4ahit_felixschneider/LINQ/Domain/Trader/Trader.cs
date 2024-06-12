namespace Domain.Trader; 

public class Trader {

    public string Name { get; init; }

    public ECity City { get; set; }

    public Trader(string name, ECity city) {
        Name = name;
        City = city;
    }


    protected bool Equals(Trader other) {
        return Name == other.Name && City == other.City;
    }

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Trader)obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Name, (int)City);
    }
}