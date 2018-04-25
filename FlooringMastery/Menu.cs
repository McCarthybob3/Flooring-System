using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Workflows;


namespace FlooringMastery
{
   public class Menu
    {

        public static void Start()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Program ");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add An Order");
                Console.WriteLine("3. Edit An Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine("\nEnter Selection:");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        DisplayOrderWorkFlow LookupWorkFlow = new DisplayOrderWorkFlow();
                        LookupWorkFlow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow AddAnOrder = new AddOrderWorkflow();
                            AddAnOrder.Execute();
                        break;
                    case "3":
                        EditOrderWorkFlow EditAnOrder = new EditOrderWorkFlow();
                        EditAnOrder.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow RemoveAnOrder = new RemoveOrderWorkflow();
                        RemoveAnOrder.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("That's not a selection");
                        break;


                }

            }
        }

    }
}
