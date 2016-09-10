using TalaATMCase;

namespace TalaATMCase
{
    public class Withdrawal : Transaction
    {
        private decimal amount;
        private Keypad keypad;
        private CashDispenser cashDispenser;

        private const int Cancelled = 6;

        public Withdrawal(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase, Keypad atmKeypad, CashDispenser atmCashDispenser)
            : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            keypad = atmKeypad;
            cashDispenser = atmCashDispenser;
        }
        public override void Execute()
        {
            bool cashDispensed = false;
            bool transactionCancelled = false;

            do
            {
                int selection = DisplayMenuOfAmounts();
                if (selection != Cancelled)
                {
                    amount = selection;
                    decimal availableBalance = Database.GetAvailableBalance(AccountNumber);

                
                if (amount <= availableBalance)
                {
                    if (cashDispenser.IsSufficientCashAvailable(amount))
                    {
                        Database.Debit(AccountNumber, amount);
                        cashDispenser.DispenseCash(amount);
                        cashDispensed = true;

                        UserScreen.DisplayMessageLine("\nPlease Take your cahs fromt eh dispenser.");
                    }
                    else
                    
                        UserScreen.DisplayMessageLine(
                            "\n Insufficient cash available in the ATM" + "\n please choose a smaller amount.");
                    }
                
                else
                    
                    UserScreen.DisplayMessageLine(
                        "\n Insufficient cash available in the ATM" + "\n please choose a smaller amount.");
                }
                else { 
                     UserScreen.DisplayMessageLine("\nCancelling Transaction...");
                     transactionCancelled = true;
                  }
            } while ((!cashDispensed) && (!transactionCancelled));
        }

        private int DisplayMenuOfAmounts()
        {
            int userChoice = 0;
            int[] amounts = { 0, 20, 40, 60, 100, 200 };

            while (userChoice == 0)
            {
                UserScreen.DisplayMessageLine("\n Withdrawal Options:");
                UserScreen.DisplayMessageLine("1 - $20");
                UserScreen.DisplayMessageLine("2 - $40");
                UserScreen.DisplayMessageLine("3 - $60");
                UserScreen.DisplayMessageLine("4 - $100");
                UserScreen.DisplayMessageLine("5 - $200");
                UserScreen.DisplayMessageLine("6 - Cancel Transaction");
                UserScreen.DisplayMessage(
                "\n Choose a withdrawal Option (1-6):");
            }
            int input = keypad.GetInput();

            switch (input)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    break;
                case Cancelled:
                    userChoice = Cancelled;
                    break;
                default:
                    UserScreen.DisplayMessageLine(
                       "\nInvalid Selection. Try Again.");
                    break;
            }
            return userChoice;
        }
    }
}