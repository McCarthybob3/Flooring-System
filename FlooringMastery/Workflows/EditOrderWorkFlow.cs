using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Data;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models.Interfaces;

namespace FlooringMastery.Workflows
{
    public class EditOrderWorkFlow
    {

        public void Execute()
        {
            string ProductType;
            Order ValidateProduct;
            ProductCheck ProductCheck = new ProductCheck();
            StateCheck stateCheck = new StateCheck();
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Edit an Order");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Order Statecheck;
            Order newOrder = new Order();
            DateTime LineDate = Convert.ToDateTime(ConsoleIO.GetRequiredStringFromUser("LineDate: "));
            int OrderNumber = ConsoleIO.GetRequiredIntFromUser("OrderNumber: ");
            newOrder.CustomerName = ConsoleIO.GetRequiredStringFromUserForEdit("Name: ");
            do
            {
                string State = ConsoleIO.GetRequiredStringFromUserForEdit("State:");
                Statecheck = stateCheck.CheckForGivenString(State);
            } while (Statecheck.State == "0");
            newOrder.State = Statecheck.State;
            newOrder.TaxRate = Statecheck.TaxRate;
            Console.WriteLine("=================================");
            ProductCheck.MakeAListOfDataForDisplay();
            Console.WriteLine("=================================");
            do
            {
                ProductType = ConsoleIO.GetRequiredStringFromUserForEdit("ProductType: ");    
                    ValidateProduct = ProductCheck.CheckForGivenString(ProductType);
            } while (ValidateProduct.ProductType == "0");
            newOrder.ProductType = ValidateProduct.ProductType;
            newOrder.CostPerSquareFoot = ValidateProduct.CostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = ValidateProduct.LaborCostPerSquareFoot;

            newOrder.Area = ConsoleIO.GetRequiredDecimalFromUserForEdit("Area ");
          
           

            EditOrderResponse response = manager.EditOrder(newOrder, LineDate, OrderNumber);


            if (response.Order.Area == 1) {
                if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
                {

                    manager.EditOrder(newOrder, LineDate, OrderNumber);
                    Console.WriteLine("Order Added!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Add Cancelled");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            if(response.Order.Area == -1)
            {
                Console.WriteLine("The ordernumber entered does not exist ");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
            }

            if(response.Order.Area == -2)
            {
                Console.WriteLine("We do not have a file for that date, try making one ");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
            }
        }

    }
}
