// You have some money in your bank account, the only function to withdraw money is uint16 Withdraw(uint16 value),
// if the value is greater than the money you have it returns 0, otherwise it withdraws the requested amount and returns the "value"
//

using System;

class Account
{
    private uint Value { get; set; }

    public Account(uint value)
    {
        Value = value;
    }

    public uint Withdraw(uint value)
    {
        if (value > Value)
        {
            return 0;
        }

        Value -= value;
        return value;
    }
}

static class Program
{
    static uint Rob(this Account a)
    {
        uint amount = 0;
        uint canary = uint.MaxValue; 
        while (canary != 0)
        {
            if (a.Withdraw(canary) != 0)
            {
                amount += canary;
            }
            else
            {
                canary /= 2;
            }
        }

        return amount;
    }

    static void Main()
    {
        for (uint i = 0; i < 200; i++)
        {
            if (new Account(i).Rob() != i)
            {
                throw new Exception(String.Format("You're not good enough! Here: {0}", i));
            }
        }

        Console.WriteLine("All appears to be well");
    }
}
