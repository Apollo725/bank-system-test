namespace BankSystem
{
    public enum AccountType
    {
        Checking,
        Savings
    }

    public enum CheckingAccountType
    {
        Individual,
        MoneyMarket
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Transfer
    }

    public class Bank
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }

    public class Account
    {
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public CheckingAccountType? CheckingAccountType { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (AccountType == AccountType.Checking && CheckingAccountType == CheckingAccountType.Individual && amount > 1000)
            {
                throw new Exception("Individual checking accounts have a withdrawal limit of 1000 dollars.");
            }

            if (Balance < amount)
            {
                throw new Exception("Insufficient funds.");
            }

            Balance -= amount;
        }

        public void Transfer(Account recipient, decimal amount)
        {
            if (Balance < amount)
            {
                throw new Exception("Insufficient funds.");
            }

            Withdraw(amount);
            recipient.Deposit(amount);
        }
    }
}
