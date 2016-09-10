namespace TalaATMCase
{
    public class Account
    {
        private int accountNumber;
        private int pin;
        private decimal availableBalance;
        private decimal totalBalance;

        public Account(int theAccountNumber, int thePin, decimal theAvailableBalance, decimal theTotalBalance)
        {
            accountNumber = theAccountNumber;
            pin = thePin;
            availableBalance = theAvailableBalance;
            totalBalance = theTotalBalance;
        }
        public int AccountNumber
        {
            get { return accountNumber; }
        }
        public decimal AvailableBalance
        {
            get { return availableBalance; }
        }
        public decimal TotalBalance
        {
            get { return totalBalance; }
        }
        public bool ValidatePIN(int userPIN)
        {
            return (userPIN == pin);
        }
        public void Credit(decimal amount)
        {
            totalBalance += amount;
        }
        public void Debit(decimal amount)
        {
            availableBalance -= amount;
            totalBalance -= amount;
        }

    }
}