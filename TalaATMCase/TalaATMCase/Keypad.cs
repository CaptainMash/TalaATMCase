using System;

namespace TalaATMCase
{
    public class Keypad
    {
        public int GetInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}