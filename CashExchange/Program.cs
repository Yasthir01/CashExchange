using System;

namespace CashExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };

            while (true)
            {
                // call the WriteMyInfo method on each Guy object
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();

                // if howMuch is the same as nothing, then return nothing
                if (howMuch == "")
                {
                    return; 
                }
                // try to convert the string to an int.
                // if the conversion was successful then do the following
                if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();

                    if (whichGuy == "Joe")
                    {
                        int cashGiven = joe.GiveCash(amount);  // joe has to give out cash
                        bob.ReceiveCash(cashGiven);  // bob will receive the cash
                    }
                    else if (whichGuy == "Bob")
                    {
                        int cashGiven = bob.GiveCash(amount);  // bob has to give out cash
                        joe.ReceiveCash(cashGiven);  // joe will receive the cash
                    }
                    else
                    {
                        // if the user did NOT enter any name
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }

                }
                else
                {
                    Console.WriteLine("Please enter an amount (or blank line to exit): ");
                }
            }
        }
    }
    class Guy
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// Writes my name and the amount of cash I have to the console
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks");
        }

        /// <summary>
        /// Gives some of my cash, removing it from my wallet (or printing a message to the console
        /// if I dont have enough cash
        /// </summary>
        /// <param name="amount">Amount of cash to give</param>
        /// <returns>The amount of cash removed from my wallet, or 0 if I dont have 
        /// enough cash (or if the amount is invalid)
        /// </returns>
        public int GiveCash(int amount)
        {
            // if the requested amount is less than 0
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
                return 0;
            }
            // if the requested amount is greater than the cash available
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + " I don't have enough cash to give you " + amount);
                return 0;
            }
            // deduct the amount of cash from the available cash
            Cash -= amount;
            return amount;         
        }

        /// <summary>
        /// Receive some cash, adding it to my wallet (or printing a message to the console
        /// if the amount is invalid)
        /// </summary>
        /// <param name="amount">Amount of cash to give</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + "Amount isn't an amount I will accept");
            }
            else
            {
                Cash += amount;
            }
        }

    }
}
