using System.Security.Cryptography.X509Certificates;

namespace TalaATMCase
{
    public class AtmConstants
    {
        //Depost Rules
        public const int Maxdepositamountperday = 150000;
        public const int Maxdepositamountpertransaction = 40000;
        public const int Maxdepositfreqperday = 4;
        //Withdrawal Rules
        public const int Maxwithdralperday = 50000;
        public const int Maxwithdrawalpertransaction = 20000;
        public const int Maxwithdrawalfreqperday = 3;

    }

}