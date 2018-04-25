using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Workflows
{
   public class DisplayOrderWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an Order");
            Console.WriteLine("------------------------");
            Console.WriteLine();
           
            
          
            DateTime OrderDate = ConsoleIO.GetRequiredDateFromUser("Enter a date (MMDDYYYY): ");
            int OrderNumber = ConsoleIO.GetRequiredIntFromUser("Enter an order number: ");
            LookupOrderResponse response = manager.LookupOrder(OrderNumber, OrderDate);





            if (response.Order.Area == -1)
            {
                Console.WriteLine("The ordernumber entered does not exist ");
                Console.WriteLine("Press any key to continue... ");

            }

            else if (response.Order.Area == -2)
            {
                Console.WriteLine("We do not have a file for that date, try making one ");
                Console.WriteLine("Press any key to continue... ");

            }
            else
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();



        }

    }
}
