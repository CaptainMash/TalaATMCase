﻿using TalaATMCase;

namespace TalaATMCase
{
    public abstract class Transaction
    {
        private int accountNumber;
        private Screen userScreen;
        private BankDatabase database;
        public Transaction(int userAccount, Screen theScreen, BankDatabase theDatabase)
        {
            accountNumber = userAccount;
            userScreen = theScreen;
            database = theDatabase;
        }
        public int AccountNumber   //Create an autoproperty here (Borrow from c#6.0
        {
            get
            {
                return accountNumber;
            }
        }
        public Screen UserScreen
        {
            get
            {
                return userScreen;
            }
        }
        public BankDatabase Database
        {
            get
            {
                return database;
            }
        }

        public abstract void Execute();

    }
}