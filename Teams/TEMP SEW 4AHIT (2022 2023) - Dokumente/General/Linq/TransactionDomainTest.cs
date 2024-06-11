public class TransactionDomainTest { 

    [SetUp]
    public void Setup() {
    }

    /*
        * 2.1) Beispiel: Geben Sie fuer jeden Trader den Wert der Summe
        *      seiner Transaktionen an. Geben Sie den Namen des Tader
        *      und die Summe aus. Ordnen Sie das Ergebnis nach dem
        *      Namen des Traders.
        * 
        */
    [Test]
    public void GroupByTrader() {
        var transactions = TraderDataFactory.Instance.CreateTransactions();

       
        
        Assert.That(result2.Count, Is.EqualTo(5));
    }

    /*
     * 2.2) Beispiel: In welchem Land arbeiten die meisten erfaßten
     *      Trader
     * 
     */
    [Test]
    public void GroupTransaction() {
      
        
        Assert.That(result2[0].City, Is.EqualTo(ECity.MILAN));
        Assert.That(result2[0].TraderCount, Is.EqualTo(5));
    }

    /*
     * 2.3) Beispiel: Berechnen Sie das Land mit dem höchsten Transaktionsumsatz
     * 
     */
    [Test]
    public void GroupTransactionsHaving() {
       
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].City, Is.EqualTo(ECity.MILAN));
        Assert.That(result[0].Turnover, Is.EqualTo(4030000));
    }

    /*
     * 2.4) Beispiel: Wieviele Trader gibt es deren Name mit einem A bzw. P
     *      beginnnen. Geben Sie jeweils die Anzahl der Trader aus einen
     *      entsprechenden Namensanfangsbuchstaben haben.
     */
    [Test]
    public void GroupTraderByName() {
        List<Trader> traders = TraderDataFactory.Instance.CreateTrader();

       
        Assert.AreEqual(2, query.ToList().Count);
    }

    }
