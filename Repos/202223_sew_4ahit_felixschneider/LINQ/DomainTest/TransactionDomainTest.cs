using System.Reflection.PortableExecutable;
using Domain.Trader;

namespace DomainTest;

public class TransactionDomainTest
{
    [SetUp]
    public void Setup()
    {
    }

    /*
        * 2.1) Beispiel: Geben Sie fuer jeden Trader den Wert der Summe
        *      seiner Transaktionen an. Geben Sie den Namen des Tader
        *      und die Summe aus. Ordnen Sie das Ergebnis nach dem
        *      Namen des Traders.
        *
        */
    [Test]
    public void GroupByTrader()
    {
        var transactions = TraderDataFactory.Instance.CreateTransactions();

        var query = from transaction in transactions
            group transaction by transaction.Trader
            into transactionGroup
            select new { trader = transactionGroup.Key, value = transactionGroup.Sum(t => t.Value) };

        var data = query.ToList();
        
        Assert.That(data.Count, Is.EqualTo(6));

        var query2 = transactions
            .GroupBy(
                t => t.Trader,
                (key, transactionGroup)
                    => new
                    {
                        trader = key,
                        valueSum = transactionGroup.Sum(t => t.Value)
                    }
            );

        var data2 = query.ToList();
        
        Assert.That(data2.Count, Is.EqualTo(6));
    }
    
    /*
        * 2.1) Beispiel: Geben Sie fuer jeden Trader die Anzahl
        *      seiner Transaktionen an. Geben Sie den Namen des Tader
        *      und die Anzahl aus. Ordnen Sie das Ergebnis nach dem
        *      Namen des Traders.
        *
     * select count(t.transactionId) from transations t group by t.traderId;
     * 
     * 
        */
    [Test]
    public void GroupByTrader2()
    {
        // erster Schritt -> Daten bekommen
        var transactions = TraderDataFactory.Instance.CreateTransactions();

        // zweiter Schritt -> Abfrage vormulieren
        var query = from t in transactions
            group t by t.Trader
            into transactionGroup
            orderby transactionGroup.Key.Name
            select new { Name = transactionGroup.Key.Name, TransactionCount = transactionGroup.Count() };

        var data = query.ToList();

        Assert.That(data.Count, Is.EqualTo(6));

        var query2 = transactions
            .GroupBy(
                t => t.Trader, 
                (key, transactionGroup) 
                    => new
                    {
                        Name = key.Name,
                        TransactionCount = transactionGroup.Count()
                    }).OrderBy(t => t.Name);

        var data2 = query2.ToList();
        
        Assert.That(data2.Count, Is.EqualTo(6));
    }

    /*
     * 2.2) Beispiel: In welcher Stadt arbeiten die meisten erfaßten
     *      Trader
     *
     */
    [Test]
    public void GroupTransaction()
    {
        var traders = TraderDataFactory.Instance.CreateTrader();

        var maxTraderAmount = (from t in traders
            group t by t.City
            into cityGroup
            select cityGroup.Count()).Max();

        var query = from t in traders
            group t by t.City
            into cityGroup
            where cityGroup.Count() == maxTraderAmount
            select new { City = cityGroup.Key, TraderAmount = cityGroup.Count() };

        var data = query.ToList();

        Assert.That(data[0].City, Is.EqualTo(ECity.MILAN));

        var maxTraderAmount2 = traders
            .GroupBy(
                t => t.City,
                (key, cityGroup) =>
                    new
                    {
                        City = key,
                        TraderAmount = cityGroup.Count()
                    }
            ).Select(cityGroup => cityGroup.TraderAmount).Max();
        
        var query2 = traders
            .GroupBy(
                t => t.City,
                (key, cityGroup) =>
                    new
                    {
                        City = key,
                        TraderAmount = cityGroup.Count()
                    }
            ).Where(cityGroup => cityGroup.TraderAmount == maxTraderAmount2);

        var data2 = query2.ToList();
        
        Assert.That(data2[0].City, Is.EqualTo(ECity.MILAN));
    }

    /*
     * 2.3) Beispiel: Berechnen Sie die Stadt mit dem höchsten Transaktionsumsatz
     *
     */
    [Test]
    public void GroupTransactionsHaving()
    {
        var transactions = TraderDataFactory.Instance.CreateTransactions();

        var maxTurnover = (from t in transactions
            group t by t.Trader.City
            into cityGroup
            select cityGroup.Sum(t => t.Value)).Max();

        var query = from t in transactions
            group t by t.Trader.City
            into cityGroup
            where cityGroup.Sum(t => t.Value) == maxTurnover
            select new { City = cityGroup.Key, Turnover = cityGroup.Sum(t => t.Value) };

        var data = query.ToList();
        
        Assert.That(data.Count, Is.EqualTo(1));
        Assert.That(data[0].City, Is.EqualTo(ECity.MILAN));
        Assert.That(data[0].Turnover, Is.EqualTo(4030000));
        

        var maxCityTurnover2 = transactions
            .GroupBy(t => t.Trader.City,
                (key, cityGroup) => new
                {
                    City = key,
                    Turnover = cityGroup.Sum(t => t.Value)
                }).Select(t => t.Turnover).Max();

        var query2 = transactions
            .GroupBy(t => t.Trader.City,
                (key, cityGroup) => new
                {
                    City = key,
                    Turnover = cityGroup.Sum(t => t.Value)
                }).Where(t => t.Turnover == maxCityTurnover2);

        var data2 = query2.ToList();
        
        Assert.Multiple(() =>
        {
            Assert.That(data2, Has.Count.EqualTo(1));
            Assert.That(data2[0].City, Is.EqualTo(ECity.MILAN));
            Assert.That(data2[0].Turnover, Is.EqualTo(4030000));
        });
    }

    /*
     * 2.4) Beispiel: Wieviele Trader gibt es deren Name mit einem A bzw. P
     *      beginnnen. Geben Sie jeweils die Anzahl der Trader aus einen
     *      entsprechenden Namensanfangsbuchstaben haben.
     */
    [Test]
    public void GroupTraderByName()
    {        
        var traders = TraderDataFactory.Instance.CreateTrader();

        var query = from t in traders
            group t by t.Name.ToUpper()[..1]
            into firstLetterGroup
            where new List<string>() { "A", "P" }.Contains(firstLetterGroup.Key)
            orderby firstLetterGroup.Key
            select new { FirstLetter = firstLetterGroup.Key, TraderAmount = firstLetterGroup.Count() };

        var data = query.ToList();
        
        Assert.That(data.Count, Is.EqualTo(2));
        Assert.That(data[0].TraderAmount, Is.EqualTo(2));

        var query2 = traders
            .GroupBy(
                t => t.Name.ToUpper()[..1],
                (key, firstLetterGroup) => new
                {
                    FirstLetter = key,
                    TraderAmount = firstLetterGroup.Count()
                })
            .Where(f => new List<string>() { "A", "P" }.Contains(f.FirstLetter))
            .OrderBy(f => f.FirstLetter)
            .Select(f => new { f.FirstLetter, f.TraderAmount });

        var data2 = query2.ToList();
        
        Assert.That(data2.Count, Is.EqualTo(2));
        Assert.That(data2[0].TraderAmount, Is.EqualTo(2));
    }
}