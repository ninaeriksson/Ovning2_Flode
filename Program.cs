/************************************************************************
Övning 2, C# - Flöde via loopar och strängmanipulation
Nina Eriksson
2025-05-29
*************************************************************************/

namespace Ovning2_Flode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("HUVUDMENY (navigera genom att välja alternativ nedan)");
                Console.ResetColor();
                Console.WriteLine("1. Vad kostar biobiljetten?");
                Console.WriteLine("2. Biljettpris för ett helt sällskap");
                Console.WriteLine("3. Upprepa inmatad mening tio gånger");
                Console.WriteLine("4. Det tredje ordet i en mening");
                Console.WriteLine("0. Avsluta");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CheckTicketPrice();
                        break;
                    case "2":
                        TotalCost();
                        break;
                    case "3":
                        PrintTenTimes();
                        break;
                    case "4":
                        ThirdWord();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning!");
                        break;
                }

            } while (true);

        }


        /*This method prints the cost of a ticket. Ticket prices depend on age.*/
        private static void CheckTicketPrice()
        {
            try
            {
                Console.WriteLine("Ange din ålder:");
                var input = Console.ReadLine();
                int age = int.Parse(input);
                if (age <= 0)
                    Console.WriteLine("Ogiltig ålder. Välj ur menyn igen!");
                else if (age < 5)
                    Console.WriteLine("Barn under 5 år går in gratis");
                else if (age < 20)
                    Console.WriteLine("Ungdomspris: 80kr");
                else if (age > 99)
                    Console.WriteLine("Personer 100 år eller äldre går in gratis");
                else if (age > 64)
                    Console.WriteLine("Pensionärspris: 90kr");
                else
                    Console.WriteLine("Standardpris: 120kr");
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktig inmatning. Välj ur menyn igen!");
            }
        }

        /*This method calculates the total cost of tickets. Ticket prices depend on age.*/
        private static void TotalCost()
        {
            try
            {
                Console.WriteLine("Ange antalet besökare: ");
                var input = Console.ReadLine();
                int numberOfVisitors = int.Parse(input);
                int totalCost = 0;

                for (int i = 0; i < numberOfVisitors; i++)
                {
                    Console.WriteLine($"Vad är åldern på person nummer {i + 1}?");
                    int age = int.Parse(Console.ReadLine());

                    if (age <= 0)
                    {
                        Console.WriteLine("Åldern måste vara 1 år eller äldre, försök igen!");
                        i--;
                        continue;
                    }

                    if (age < 5)
                        totalCost += 0;
                    else if (age < 20)
                        totalCost += 80;
                    else if (age > 99)
                        totalCost += 0;
                    else if (age > 64)
                        totalCost += 90;
                    else
                        totalCost += 120;
                }
                Console.WriteLine($"Totala kostnaden för {numberOfVisitors} personer är: {totalCost} kr");
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktig inmatning. Välj ur menyn igen!");
            }
        }

        /*This method prints the input string ten times.*/
        private static void PrintTenTimes()
        {
            Console.WriteLine("Skriv en text: ");
            var input = Console.ReadLine();

            for (int i = 0; i < 10; i++)
                Console.Write($"{i + 1}. {input}, ");

            Console.WriteLine("");
        }

        /*This method prints the third word in a string. The string is read from the console.*/
        private static void ThirdWord()
        {
            try
            {
                Console.WriteLine("Skriv en mening innehållande minst tre ord: ");
                var input = Console.ReadLine();
                string[] stringArray = input.Split([" "], StringSplitOptions.RemoveEmptyEntries);
                string output = stringArray[2];
                Console.WriteLine($"Tredje ordet är: {output}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Meningen var för kort. Välj ur menyn igen!");
            }
        }
    }
}
