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
        while (a.Withdraw(1) != 0)
        {
            amount++;
        }

        return amount;
    }

    static void Main()
    {
        for (uint i = 0; i < 200; i++)
        {
            if (new Account(i).Rob() != i)
            {
                throw new Exception("You're not good enough!");
            }
        }

        Console.WriteLine("All appears to be well");
    }
}
