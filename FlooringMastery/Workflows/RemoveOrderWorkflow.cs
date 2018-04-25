using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Data;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Workflows
{
    class RemoveOrderWorkflow
    {


        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine("=================================");
            Console.WriteLine();
            DateTime OrderDate =ConsoleIO.GetRequiredDateFromUser("Enter a date (MMDDYYYY):");
            int OrderNumber = ConsoleIO.GetRequiredIntFromUser("OrderNumber: ");
           
            LookupOrderResponse responseData = manager.LookupOrder(OrderNumber, OrderDate);
            RemoveOrderResponse RemoveData = manager.RemoveOrder(OrderNumber, OrderDate);




            if (RemoveData.Order.Area == 1)
            {
                ConsoleIO.DisplayOrderDetails(responseData.Order);
                Console.WriteLine();

                if (ConsoleIO.GetYesNoAnswerFromUser("Remove the following information") == "Y")
                {
                    RemoveOrderResponse response = manager.RemoveOrder(OrderNumber, OrderDate);

                    Console.WriteLine("Order Removed!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Remove Cancelled");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            }
            if (RemoveData.Order.Area == -1)
            {
                Console.WriteLine("The ordernumber entered does not exist ");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
            }

            if (RemoveData.Order.Area == -2)
            {
                Console.WriteLine("We do not have a file for that date, try making one ");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
            }


          
        }
    }
}
