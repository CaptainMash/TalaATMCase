
namespace TalaATMCase
{
    public class ATM
    {
        private bool userAuthenticated;
        private int currentAccountNumber;
        private Screen screen;
        private Keypad keypad;
        private CashDispenser cashDispenser;
        private DepositSlot depositSlot;
        private BankDatabase bankDatabase;

        private enum MenuOption
        {
            BALANCE_INQUIRY = 1,
            WITHDRAWAL = 2,
            DEPOSIT = 3,
            EXIT_ATM = 4
        }

        public ATM()
        {
            userAuthenticated = false;
            currentAccountNumber = 0;
            screen = new Screen();
            keypad = new Keypad();
            cashDispenser = new CashDispenser();
            depositSlot = new DepositSlot();
            bankDatabase = new BankDatabase();
        }

        public void Run()
        {
            while (true)
            {
                while (!userAuthenticated)
                {
                    screen.DisplayMessageLine("\nWelcome");
                    AuthenticateUser();

                }
                PerformTransactions();
                userAuthenticated = false;
                currentAccountNumber = 0;
                screen.DisplayMessageLine("\nThank You GoodBye");
            }
        }

        private void AuthenticateUser()
        {
            screen.DisplayMessage("\nPlease enter your accountNumber");
            int accountNumber = keypad.GetInput();

            screen.DisplayMessage("Enter your pin");
            int pin = keypad.GetInput();

            userAuthenticated = bankDatabase.AuthenticateUser(accountNumber, pin);
            if (userAuthenticated)
                currentAccountNumber = accountNumber;
            else screen.DisplayMessage("INvalid account number or pin. please try again");

        }

        private void PerformTransactions()
        {
            Transaction currentTransaction;
            bool userExited = false;
            while (!userExited)
            {
                int mainMenuSelection = DisplayMainMenu();
                switch ((MenuOption) mainMenuSelection)
                {
                    case MenuOption.BALANCE_INQUIRY:
                    case MenuOption.WITHDRAWAL:
                    case MenuOption.DEPOSIT:

                        currentTransaction = CreateTransaction(mainMenuSelection);
                        currentTransaction.Execute();
                        break;
                    case MenuOption.EXIT_ATM:
                        screen.DisplayMessageLine("\n Exiting the system...");
                        userExited = true;
                        break;
                    default:
                        screen.DisplayMessageLine("\n You did not enter a valid selection. Try again");
                        break;

                }
            }
        }

        private int DisplayMainMenu()
        {
            screen.DisplayMessageLine("\n Main Menu:");
            screen.DisplayMessageLine("1. View My balance:");
            screen.DisplayMessageLine("2. Withdraw Cash:");
            screen.DisplayMessageLine("3. Deposit Funds");
            screen.DisplayMessageLine("4. Exit \n:");
            screen.DisplayMessageLine("Enter a Choise");

            return keypad.GetInput();
        }

        private Transaction CreateTransaction(int type)
        {
            Transaction temp = null;
            switch ((MenuOption) type)
            {
                case MenuOption.BALANCE_INQUIRY:
                    temp = new BalanceInquiry(currentAccountNumber, screen, bankDatabase);
                    break;
                case MenuOption.WITHDRAWAL:
                    temp = new Withdrawal(currentAccountNumber, screen, bankDatabase, keypad, cashDispenser);
                    break;
                case MenuOption.DEPOSIT:
                    temp = new Deposit(currentAccountNumber, screen, bankDatabase, keypad, depositSlot);
                    break;
            }
            return temp;
        }
    }
}
