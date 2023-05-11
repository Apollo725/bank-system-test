public class AccountTests
{
    public void Deposit_ShouldIncreaseBalance()
    {
        var account = new Account { Balance = 0 };
        account.Deposit(200);
        Assert.AreEqual(200, account.Balance);
    }

    public void Withdraw_ShouldDecreaseBalance()
    {
        var account = new Account { Balance = 200 };
        account.Withdraw(100);
        Assert.AreEqual(100, account.Balance);
    }

    public void Withdraw_IndividualCheckingAccountWithAmountGreaterThanLimit_ShouldThrowException()
    {
        var account = new Account { Balance = 1000, AccountType = AccountType.Checking, CheckingAccountType = CheckingAccountType.Individual };
        Assert.ThrowsException<Exception>(() => account.Withdraw(2000));
    }

    public void Withdraw_AccountWithInsufficientFunds_ShouldThrowException()
    {
        var account = new Account { Balance = 200 };
        Assert.ThrowsException<Exception>(() => account.Withdraw(400));
    }

    public void Transfer_ShouldDecreaseSenderBalanceAndIncreaseRecipientBalance()
    {
        var sender = new Account { Balance = 200 };
        var recipient = new Account { Balance = 0 };
        sender.Transfer(recipient, 100);
        Assert.AreEqual(100, sender.Balance);
        Assert.AreEqual(100, recipient.Balance);
    }

    public void Transfer_AccountWithInsufficientFunds_ShouldThrowException()
    {
        var sender = new Account { Balance = 200 };
        var recipient = new Account { Balance = 0 };
        Assert.ThrowsException<Exception>(() => sender.Transfer(recipient, 400));
    }
}
