﻿using System;

namespace TalaATMCase
{
    public class Screen
    {
        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }
        public void DisplayMessageLine(string message)
        {
            Console.WriteLine(message);
        }
        public void DisplayDollarAmount(decimal amount)
        {
            Console.Write("{0:C} ", amount);  //diplay the dollar sign before amount.
        }
    }
}