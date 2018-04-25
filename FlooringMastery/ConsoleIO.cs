using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery
{
    class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"Account number: {order.OrderNumber}");
            Console.WriteLine($"Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}%");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost per Square Foot: ${order.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost per Square Foot: ${order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost: ${order.MaterialCost}");
            Console.WriteLine($"Labor Cost: ${order.LaborCost}");
            Console.WriteLine($"Tax: ${order.Tax}");
            Console.WriteLine($"Total: ${order.Total}");

        }
        public static void DisplayNewOrder(Order order)
        {
            Console.WriteLine($"Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}%");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost per Square Foot: ${order.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost per Square Foot: ${order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material Cost: ${order.MaterialCost}");
            Console.WriteLine($"Labor Cost: ${order.LaborCost}");
            Console.WriteLine($"Tax: ${order.Tax}");
            Console.WriteLine($"Total: ${order.Total}");

        }


        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input.ToUpper();
                }
            }
        }
        public static string GetRequiredStringFromUserForEdit(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

             
                    return input.ToUpper();
                
            }
        }
        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return input;
                }
            }
        }
        public static decimal GetRequiredDecimalFromUser(string prompt)
        {
            decimal output;

            while (true)
            {
                
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }
        public static DateTime GetRequiredDateFromUser(string prompt)
        {
            DateTime output;
           
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!DateTime.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid datetime.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                   
                    return output;
                }
            }
        }
        public static decimal GetRequiredAreaFromUser(string prompt)
        {
            decimal output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal over 100.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                if (output < 100)
                {
                    Console.WriteLine("You must enter valid decimal over 100.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }
        public static decimal GetRequiredDecimalFromUserForEdit(string prompt)
        {
            decimal output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if(input == "")
                {
                    return 0;
                }
                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output == 0)
                    {
                        return output;
                    }
                    else if (output < 100)
                    {

                        Console.WriteLine("You must enter a number over 100.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {

                        return output;
                    }



                }
            }
        }
        public static int GetRequiredIntFromUser(string prompt)
            {
                int output;

                while (true)
                {
                Console.Write(prompt);
                string input = Console.ReadLine();
               
                if (!int.TryParse(input, out output))
                    {
                        Console.WriteLine("You must enter valid int.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        return output;
                    }
                }
            }

       


    }
}
