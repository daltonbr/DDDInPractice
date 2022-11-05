using DDDInPractice.Logic;

namespace DDDInPractice.ConsoleUI;

public class MainViewModel
{
    private SnackMachine SnackMachine { get; }
    public MainViewModel() => SnackMachine = new SnackMachine();
    public void BuySnack() => SnackMachine.BuySnack();
    public void InsertMoney(Money money) => SnackMachine.InsertMoney(money);
    public void ReturnMoney() => SnackMachine.ReturnMoney();
    
    public string GetInTransactionText() => SnackMachine.MoneyInTransaction.ToString();
    public string GetMoneyInsideText => SnackMachine.MoneyInside.ToString();
}