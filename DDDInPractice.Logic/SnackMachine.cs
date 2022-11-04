namespace DDDInPractice.Logic;

public sealed class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }
    
    public void InsertMoney(Money money)
    {
        MoneyInTransaction += money;
    }

    public void ReturnMoney()
    {
        // Simulate giving the current money 'in transaction' back to the user
        //MoneyInTransaction = 0;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;
        
        // MoneyInTransction = 0;
    }
    
}