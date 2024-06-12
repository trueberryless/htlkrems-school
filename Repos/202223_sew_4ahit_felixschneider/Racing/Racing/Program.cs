using Racing;

string[] drivers = {"Nikki Lauda", "Ayrton Senna", "Fernando Alonso", "Mika Häkkinen", "Michael Schumacher"};

new Thread(new F1Race(drivers.Length).Run).Start();
foreach (var driver in drivers)
{
    new Thread(new Car(driver).Run).Start();
}
