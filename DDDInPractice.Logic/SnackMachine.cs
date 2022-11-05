namespace DDDInPractice.Logic;

using static DDDInPractice.Logic.Money;

public sealed class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; } = Zero;
    public Money MoneyInTransaction { get; private set; } = Zero;

    public void InsertMoney(Money money)
    {
        Money[] coinsAndNotes = { OneCent, TenCent, Quarter, OneDollar, FiveDollar, TwentyDollar };

        if (!coinsAndNotes.Contains(money))
        {
            throw new InvalidOperationException("Can only add one coin or note at a time");
        }

        MoneyInTransaction += money;
    }

    /// <summary>
    /// Simulate giving the current money 'in transaction' back to the user
    /// </summary>
    public void ReturnMoney()
    {
        MoneyInTransaction = Zero;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;
        MoneyInTransaction = Zero;
    }
    
}