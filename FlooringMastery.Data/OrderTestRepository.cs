using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models;
using System.IO;
using FlooringMastery;
using FlooringMastery.Data;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class OrderTestRepository : IOrderRepository
    {


        private static Order _1order = new Order
        {
            Date = Convert.ToDateTime( "2/13/2018"),
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.00M
        };
        private static Order _1order2 = new Order
        {
            Date =Convert.ToDateTime( "2/13/2018"),
            OrderNumber = 2,
            CustomerName = "Wiser",
            State = "WA",
            TaxRate = 4.25M,
            ProductType = "Wood",
            Area = 103.00M,
            CostPerSquareFoot = 5.30M,
            LaborCostPerSquareFoot = 5.80M,
            MaterialCost = 750.00M,
            LaborCost = 475.00M,
            Tax = 88.88M,
            Total = 5763.00M
        };
        private static Order _1order3 = new Order
        {
            Date = Convert.ToDateTime("2/13/2018"),
            OrderNumber = 3,
            CustomerName = "Wisest",
            State = "PA",
            TaxRate = 5.25M,
            ProductType = "Platinum",
            Area = 134.00M,
            CostPerSquareFoot = 1.30M,
            LaborCostPerSquareFoot = 1.80M,
            MaterialCost = 700.00M,
            LaborCost = 55.00M,
            Tax = 8.88M,
            Total = 563.00M
        };
        private static Order _2order = new Order
        {
            Date = Convert.ToDateTime("2/14/2018"),
            OrderNumber = 1,
            CustomerName = "Dumb",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.00M
        };
        private static Order _2order2 = new Order
        {
            Date = Convert.ToDateTime("2/14/2018"),
            OrderNumber = 2,
            CustomerName = "Dumber",
            State = "WA",
            TaxRate = 4.25M,
            ProductType = "Wood",
            Area = 103.00M,
            CostPerSquareFoot = 5.30M,
            LaborCostPerSquareFoot = 5.80M,
            MaterialCost = 750.00M,
            LaborCost = 475.00M,
            Tax = 88.88M,
            Total = 5763.00M
        };
        private static Order _2order3 = new Order
        {
            Date = Convert.ToDateTime("2/14/2018"),
            OrderNumber = 3,
            CustomerName = "Dumbest",
            State = "PA",
            TaxRate = 5.25M,
            ProductType = "Platinum",
            Area = 134.00M,
            CostPerSquareFoot = 1.30M,
            LaborCostPerSquareFoot = 1.80M,
            MaterialCost = 700.00M,
            LaborCost = 55.00M,
            Tax = 8.88M,
            Total = 563.00M
        };
        private static List<Order> Orders = new List<Order>()
        {_1order, _1order2, _1order3, _2order, _2order2, _2order3
        };
        //    private static List<Order> Order_02142018 = new List<Order>()
        //   {_2order, _2order2, _2order3
        // };

        //    private static OrderList TestList1 = new OrderList()
        //    {TheOrders=Order_02132018, TheDate =Convert.ToDateTime( "02/13/2018") };
        //    private static OrderList TestList2 = new OrderList()
        // { TheOrders = Order_02142018, TheDate = Convert.ToDateTime("02/14/2018") };

        // List<OrderList> TheTestLists = new List<OrderList>()
        //    {TestList1,TestList2 };



        public Order SaveOrder(Order Order, DateTime ListName)
        {

            Order Correct = new Order();
            Correct.Area = 1;

            var Test = OrderCheck(ListName);
            if (Test == false)
            {

                Order NewOrder = new Order();

                NewOrder.Date = ListName;
                Order.OrderNumber = 1;
                Orders.Add(Order);
                Console.WriteLine("looks like we have to make a new list for that one, list made!");
                return Correct;


            }

            else
            {
                List<Order> TempOrders = new List<Order>();

                for (int i = 0; i < Orders.Count; i++)
                {


                    if (Orders[i].Date == ListName)
                    {
                        TempOrders.Add(Orders[i]);

                        

                        Order.OrderNumber = TempOrders[TempOrders.Count - 1].OrderNumber + 1;

                    }
                   
                }
                Orders.Add(Order);
            }
            return Correct;
        }
        public Order LoadOrder(int OrderNumber, DateTime ListName)
        {
            Order orderError = new Order();
            orderError.Area = -1;
            Order linedateError = new Order();
            linedateError.Area = -2;
            Order Correct = new Order();
            Correct.Area = 1;
            var Test = OrderCheck(ListName);

            if (Test == false)
            {
              
                return linedateError;
            }



            for (int i = 0; i < Orders.Count; i++)
            {



                if (Orders[i].Date == ListName)
                {
                    if (Orders[i].OrderNumber == OrderNumber)
                    {
                        return Orders[i];
                    }


                }

            }
            return orderError;
        }


    
          
    

        public Order RemoveOrder(int UserNumber, DateTime ListName)
        {
            Order orderError = new Order();
            orderError.Area = -1;
            Order linedateError = new Order();
            linedateError.Area = -2;
            Order Correct = new Order();
            Correct.Area = 1;
            var Test = OrderCheck(ListName);

            if (Test == false)
            {

                return linedateError;
            }

            for (int i = 0; i < Orders.Count; i++)
            {


                if (Orders[i].Date == ListName && Orders[i].OrderNumber == UserNumber)
                {
                    
                    Orders.Remove(Orders[i]);
                    return Correct;
                }
        
            }
          
                return orderError;
            

        }
        public Order EditOrder(Order order, DateTime ListName, int OrderNumber)
        {
            Order orderError = new Order();
            orderError.Area = -1;
            Order linedateError = new Order();
            linedateError.Area = -2;
            Order Correct = new Order();
            Correct.Area = 1;
            int counter = 0;
            var Test = OrderCheck(ListName);
            
            if (Test == false)
            {

                return linedateError;
            }

            for (int i = 0; i < Orders.Count; i++)
            {


                if (Orders[i].Date == ListName)
                {
                   
                        if (Orders[i].OrderNumber == OrderNumber)
                        {
                        counter++;
                            if(order.Area == 0)
                            {
                            }
                            else
                            {
                                Orders[i].Area = order.Area;
                            }
                           

                            if(order.CustomerName == "")
                            {
                            }
                            else
                            {
                                Orders[i].CustomerName = order.CustomerName;
                            }

                            if(order.State == "")
                            {
                            }
                            else
                            {
                                Orders[i].State = order.State;
                            }

                            if (order.ProductType == "")
                            {
                            }
                            else
                            {
                                Orders[i].ProductType = order.ProductType;
                            }
                        }
                    
                }
            }
            if (counter == 0)
            {
                return orderError;
            }
            return Correct;


        }

     

        public bool OrderCheck(DateTime ListName)
        {
            for (int i = 0; i < Orders.Count; i++)
            {


                if (Orders[i].Date == ListName)
                {
                    return true;
                }


            }
            return false;
        }

       


        

    }
}
