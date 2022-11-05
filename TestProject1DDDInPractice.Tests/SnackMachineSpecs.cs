using System;
using DDDInPractice.Logic;
using FluentAssertions;
using Xunit;

using static DDDInPractice.Logic.Money;

namespace TestProject1DDDInPractice.Tests;

public class SnackMachineSpecs
{
    [Fact]
    public void Return_money_empties_money_in_transaction()
    {
        var snackMachine = new SnackMachine();

        snackMachine.InsertMoney(OneDollar);
        
        snackMachine.ReturnMoney();

        snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
    }

    [Fact]
    public void Inserted_money_goes_to_money_in_transaction()
    {
        var snackMachine = new SnackMachine();
        
        snackMachine.InsertMoney(OneCent);
        snackMachine.InsertMoney(OneDollar);

        snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
    }

    [Fact]
    public void Cannot_insert_more_than_one_coin_at_a_time()
    {
        var snackMachine = new SnackMachine();
        var twoCent = OneCent + OneCent;

        Action action = () => snackMachine.InsertMoney(twoCent);

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Money_in_transaction_goes_to_money_inside_after_purchase()
    {
        var snackMachine = new SnackMachine();
        
        snackMachine.InsertMoney(OneDollar);
        snackMachine.InsertMoney(TwentyDollar);
        snackMachine.InsertMoney(Quarter);
        
        snackMachine.BuySnack();

        snackMachine.MoneyInTransaction.Amount.Should().Be(Zero.Amount);
        snackMachine.MoneyInside.Amount.Should().Be(21.25m);
    }
}
