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
    class AddOrderWorkflow
    {
       
        public void Execute()
        {
            StateCheck stateCheck = new StateCheck();
            ProductCheck ProductCheck = new ProductCheck();
            OrderManager manager = OrderManagerFactory.Create();
          
            Console.Clear();
            Console.WriteLine("Add Order");
            Console.WriteLine("=================================");
            Console.WriteLine();
            bool future = false;
            string ProductType;
            string ValidateProduct;
            Order Statecheck;
            Order newOrder = new Order();
            // DateTime LineDate = DateTime.Today;
            DateTime LineDate;
            do
            {
                LineDate = ConsoleIO.GetRequiredDateFromUser("LineDate: ");
                if (LineDate >= DateTime.Today)
                {
                    future = true;
                }
                else { Console.WriteLine("Please enter a date in the future"); }
            } while (future == false);
            newOrder.Date = LineDate;
            newOrder.CustomerName = ConsoleIO.GetRequiredStringFromUser("Name: ");
            do {
                string State = ConsoleIO.GetRequiredStringFromUser("State: ");
                Statecheck = stateCheck.CheckForGivenString(State);
            } while (Statecheck.State == "0");
            newOrder.State = Statecheck.State;

            decimal TaxRate = Statecheck.TaxRate;
            newOrder.TaxRate = TaxRate;
            Console.WriteLine("=================================");
            ProductCheck.MakeAListOfDataForDisplay();
            Console.WriteLine("=================================");
            do
            {
                ProductType = ConsoleIO.GetRequiredStringFromUser("ProductType: ");
                ValidateProduct = ProductCheck.CheckForGivenString(ProductType).ProductType;
            } while (ValidateProduct == "0");
            newOrder.ProductType = ValidateProduct;

            decimal Area = ConsoleIO.GetRequiredAreaFromUser("Area ");
            newOrder.Area = Area;
            decimal CostPerSquareFoot = ProductCheck.CheckForGivenString(ProductType).CostPerSquareFoot;
            newOrder.CostPerSquareFoot = CostPerSquareFoot;
            decimal LaborCostPerSquareFoot = ProductCheck.CheckForGivenString(ProductType).LaborCostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = LaborCostPerSquareFoot;
            decimal MaterialCost = Area * CostPerSquareFoot;
            newOrder.MaterialCost = MaterialCost;
            decimal LaborCost = Area * LaborCostPerSquareFoot;
            newOrder.LaborCost = LaborCost;
            decimal tax = (MaterialCost + LaborCost) * (TaxRate / 100);
            newOrder.Tax = tax;
            newOrder.Total = (MaterialCost + LaborCost + tax);

            Console.WriteLine("=================================");
            ConsoleIO.DisplayNewOrder(newOrder);
            Console.WriteLine("=================================");



            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
               
                AddOrderResponse response = manager.AddOrder(newOrder, LineDate);
                response.Sucess = true;
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

}

}
