using System.Diagnostics;
using System.Text;

namespace Heist;

public class Robery {
    
    public void EvaluateHeistAsync() {
        //CallTraditionalTaskmodel();
        
    }

    public async Task CallFatTommyAsync()
    {
        // 1. Phase
        var phase1 = await Task.WhenAll(
            Task.Run(HireCrew),
            Task.Run(GetBankPlans),
            Task.Run(BribeBankEmployee),
            Task.Run(BuyGetawayCar)
        );

        phase1.ToList().ForEach(Console.WriteLine);

        Console.WriteLine(AggregateLog(phase1));
        
        // 2. Phase
        var phase2 = await Task.Run(EnterBank);
        Console.WriteLine(AggregateLog(phase2));
        
        // 3. Phase
        var phase3 = await Task.WhenAll(
            Task.Run(RobCounter1),
            Task.Run(RobCounter2),
            Task.Run(RobCounter3)
        );

        Console.WriteLine(AggregateLog(phase3));

        Stopwatch sw = new Stopwatch();
        sw.Start();
        // 4. Phase
        var phase4 = await Task.Run(LeaveBank);
        Console.WriteLine(AggregateLog(phase4));
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        
        // 5. Phase
        var phase5 = await Task.Run(LoosePolice);
        Console.WriteLine(AggregateLog(phase5));
    }

    public void CallTraditionalTaskmodel() {
        // 1. Phase
        var phase1 = Task.WhenAll(
            Task.Run(HireCrew),
            Task.Run(GetBankPlans),
            Task.Run(BribeBankEmployee),
            Task.Run(BuyGetawayCar)
        );

        var messages = phase1.Result;
        Console.WriteLine(AggregateLog(messages));
        
        // 2. Phase
        var phase2 = Task.Run(EnterBank);
        Console.WriteLine(AggregateLog(phase2.Result));
        
        // 3. Phase
        var phase3 = Task.WhenAll(
            Task.Run(RobCounter1),
            Task.Run(RobCounter2),
            Task.Run(RobCounter3)
        );

        Console.WriteLine(AggregateLog(phase3.Result));
        
        // 4. Phase
        var phase4 = Task.Run(LeaveBank);
        Console.WriteLine(AggregateLog(phase4.Result));
        
        // 5. Phase
        var phase5 = Task.Run(LoosePolice);
        Console.WriteLine(AggregateLog(phase5.Result));
    }

    private string AggregateLog(string
        message) {
        StringBuilder str = new StringBuilder();
        str.Append(message);
        str.AppendLine();
        return str.ToString();
    }

    private string AggregateLog(string[]
        messages) {
        StringBuilder str = new
            StringBuilder();
        foreach (var message in messages) {
            str.Append(message);
            str.Append(" ");
        }

        str.AppendLine();
        return str.ToString();
    }

    private string BribeBankEmployee() {
        Thread.Sleep(300);
        return
            ELog.BRIBE_BANK_EMPLOYEE.ToString();
    }

    private string BuyGetawayCar() {
        Thread.Sleep(200);
        return ELog.BUY_GETAWAY_CAR.ToString();
    }

    private string GetBankPlans() {
        Thread.Sleep(200);
        return ELog.GET_BANK_PLAN.ToString();
    }

    private string HireCrew() {
        Thread.Sleep(400);
        return ELog.HIRE_CREW.ToString();
    }

    private string EnterBank() {
        Thread.Sleep(100);
        return ELog.ENTER_BANK.ToString();
    }

    private string RobCounter1() {
        Thread.Sleep(300);
        return ELog.ROB_COUNTER_1.ToString();
    }

    private string RobCounter2() {
        Thread.Sleep(300);
        return ELog.ROB_COUNTER_2.ToString();
    }

    private string RobCounter3() {
        Thread.Sleep(300);
        return ELog.ROB_COUNTER_3.ToString();
    }

    private async Task<string> LeaveBank() {
        await Task.Delay(120);
        return ELog.LEAVE_BANK.ToString();
    }

    private string LoosePolice() {
        Thread.Sleep(300);
        return ELog.LOOSE_POLICE.ToString();
    }
}