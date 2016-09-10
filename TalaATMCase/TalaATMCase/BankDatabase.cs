namespace TalaATMCase
{
    public class BankDatabase
    {
        private Account[] accounts;

        public BankDatabase()
        {
            accounts = new Account [2];
            accounts[0] = new Account(12, 1234, 1000.00m, 1200.00m);
            accounts[1] = new Account(98765, 56789, 200.00M, 200.00M);
        }

      private  Account GetAccount(int accountNumber)
        {
            foreach (Account currentAccount in accounts)
            {
                if (currentAccount.AccountNumber == accountNumber)
                    return currentAccount;
            }
            return null;
        }
        public bool AuthenticateUser(int userAccountNumber, int userPIN)
        {
            Account userAccount = GetAccount(userAccountNumber);
            if (userAccount != null)
                return userAccount.ValidatePIN(userPIN);
            else
                return false;
        }
        public decimal GetAvailableBalance(int userAccountNumber)
        {
            Account userAccount = GetAccount(userAccountNumber);
            return userAccount.AvailableBalance;
        }

        public decimal GetTotalBalance(int userAccountNumber)
        {
            Account userAccount = GetAccount(userAccountNumber);
            return userAccount.TotalBalance;
        }

        public void Credit(int userAccountNumber, decimal amount)
        {
            Account userAccount = GetAccount(userAccountNumber);
            userAccount.Credit(amount);

        }

        public void Debit(int userAccountNumber, decimal amount)
        {
            Account userAccount = GetAccount(userAccountNumber);
            userAccount.Debit(amount);
        }

    }
}