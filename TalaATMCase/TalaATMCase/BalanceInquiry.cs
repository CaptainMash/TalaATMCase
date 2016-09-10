using TalaATMCase;
namespace TalaATMCase
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase)
            : base(userAccountNumber, atmScreen, atmBankDatabase) { }

        public override void Execute()
        {
            decimal availableBalance = Database.GetAvailableBalance(AccountNumber);
            decimal totalBalance = Database.GetTotalBalance(AccountNumber);

            UserScreen.DisplayMessageLine("\n Balance Information : ");
            UserScreen.DisplayMessage("- Available Balance: ");
            UserScreen.DisplayDollarAmount(availableBalance);
            UserScreen.DisplayMessage("\n Total Balance");
            UserScreen.DisplayDollarAmount(totalBalance);
            UserScreen.DisplayMessageLine("");
        }
    }
}