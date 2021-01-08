using System;
using System.Text.RegularExpressions;

namespace ReceiptV4
{
    class Program
    {
        // Programmer:      Nicolai LeBlanc
        // Date written:    12/08/2020
        // Program purpose: Validate user information using regular expressions and the ReceiptV3 program made earlier in the course.
        /* Major changes since version 3:
         * Removed the for loop that originally controlled the majority of the program and replaced it with do while loops.
         * Split up the 2d array into 3 1d arrays
         */
        static void Main(string[] args)
        {
            // Regular expressions to validate the information that the user entered

            var nameReg = (@"^[a-zA-Z0-9 \(\)\,\.\&\-_\+]+$"); // Item regex
            var quantReg = ("^[0-9]+$"); // Quantity regex
            var priceReg = ("^[0-9.]+$"); // Price regex

            string[] items = new string[100]; // Create the main array
            decimal[] price = new decimal[100];
            int[] quantity = new int[100];
            decimal subTotal = 0;
            int count = 0; // Initialize 
            decimal tax;
            decimal total;
            string input;


            Console.WriteLine("");
            Console.WriteLine("                        Scan Items Now.");
            Console.WriteLine("");

            do // For loop to add elements to the array. The loop breaks when the user enters 0.
            {

                while (true)
                {
                    Console.Write("Please enter item name(enter 0 to stop the program): ");
                    input = Console.ReadLine();


                    Match match = Regex.Match(input, nameReg, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        items[count] = input; // Add input to the array after validation
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can only enter characters a-z, 0-9, and these special characters: () _ - , . +");
                        Console.WriteLine("Please try again: ");
                    }

                }
                if (input == "0") // If the user enters 0, the loop will break and the count will not go up
                {
                    count--;
                    break;
                }
                

                while (true)
                {
                    // Input statements 
                    Console.Write("Enter Item Price: ");
                    input = Console.ReadLine();
                    Match match = Regex.Match(input, priceReg, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        price[count] = Convert.ToDecimal(input); // Add input to the array after validation
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can only enter a number 0-9 with a .");
                        Console.WriteLine("Please try again: ");
                    }
                    

                }

                while (true)
                {
                    Console.Write("Enter Item Quantity: ");

                    input = Console.ReadLine();

                    Match match = Regex.Match(input, quantReg, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        quantity[count] = Convert.ToInt32(input);
                        subTotal += (Convert.ToDecimal(price[count]) * Convert.ToInt32(quantity[count]));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can only enter a number 0-9");
                        Console.WriteLine("Please try again: ");
                    }

                }
                // subTotal[count] += price[count]; // Update subTotal variable to keep a running count of the price before tax.
                Console.WriteLine(); // Display
                count++;


            } while (!input.Equals("0"));

            Console.WriteLine("");
            Console.WriteLine("                  Your Receipt.");
            Console.WriteLine("");
            Console.WriteLine("Item       Price       Quantity      Subtotal");

            
            // For loop to display each array element's value.
            for (int i = 0; i <= count; i++)
            {
                Console.WriteLine(items[i] + "      " + price[i] + "         " + quantity[i] + "            " + subTotal);

            }

            // Display blank lines and a solid line to make the console look neater
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            // Initialize variables
            tax = (subTotal * 0.065M);
            total = (tax + subTotal);

            Console.WriteLine("{0} items total", (count + 1));
            Console.WriteLine("Subtotal: {0, 26:c}", subTotal);
            Console.WriteLine("Tax (0.065%): {0, 21:c}", tax);
            Console.WriteLine("Total: {0, 29:c}", total);
            Console.WriteLine();
            Console.WriteLine("Have a wonderful day!");

        } // End main
    }
}
