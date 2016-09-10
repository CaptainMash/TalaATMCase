using TalaATMCase;

namespace TalaATMCase
{
    public class Deposit : Transaction
    {
        private decimal amount;
        private Keypad keypad;
        private DepositSlot depositSlot;

        private const int CANCELLED = 0;

        public Deposit(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase,
            Keypad atmKeypad, DepositSlot atmDepositSlot)
            : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            keypad = atmKeypad;
            depositSlot = atmDepositSlot;
        }

        public override void Execute()
        {
            amount = PrompForDepositAmount();
            if (amount != CANCELLED)
            {
                UserScreen.DisplayMessage("\n Please insert a deposit Envolp containing");
                UserScreen.DisplayDollarAmount(amount);
                UserScreen.DisplayMessageLine("in the deposit slot.");
                bool envelopReceived = depositSlot.IsDepositEnvelopeReceived();
                if (envelopReceived)
                {
                    UserScreen.DisplayMessageLine(
                        "\n Your envelope has been received." +
                        "The money you just deposited will not be available" +
                        "until we verify the amount of any" +
                        "enclosed cash, and any enclosed checks clear");
                    Database.Credit(AccountNumber, amount);
                }
                else
                    UserScreen.DisplayMessageLine(
                        "\n You did not insert an elvelop. Sot he ATM has" + "Cancelled your transaction.");
            }
            else
                UserScreen.DisplayMessageLine("\n Canceling Transaction..");
        }

        private decimal PrompForDepositAmount()
        {
            UserScreen.DisplayMessage("\nPlease Input a deposit amountin Cents (or 0 to cancel):");
            int input = keypad.GetInput();

            if (input == CANCELLED)
                return CANCELLED;
            else
                return input/100.00M;

        }

    }
}
