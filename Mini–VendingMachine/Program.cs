namespace Mini_VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            VendingMachineDemo();

        }

        public static void VendingMachineDemo()
        {
            VendingMachine newMachine = new();

            try
            {

                Product prod1 = new(DrinkType.Soda, 1, 2.99, "Cola");
                Product prod2 = new(DrinkType.Juice, 15, 1.99, "Orange-Juice");
                Product prod3 = new(DrinkType.Water, 20, 0.99, "Water");


                newMachine.RegisterProduct(prod1);
                newMachine.RegisterProduct(prod2);
                newMachine.RegisterProduct(prod3);


        }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }




            bool isRunning = true;



                Console.WriteLine("Welcome Verkoopautomaat staat klaar !");
                Console.WriteLine();
                VendingMachine.Explain();
                Console.WriteLine();

            while (isRunning)
            {
                newMachine.ShowInventory();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Kies een drank :");

                string userChoice = Console.ReadLine() ?? "";

                if (userChoice == "") 
                {
                    isRunning = false;
                    continue;
                }

                try
                {
                    newMachine.Purchase(userChoice);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}
