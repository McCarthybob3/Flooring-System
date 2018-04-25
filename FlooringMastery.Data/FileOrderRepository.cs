using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System.IO;


namespace FlooringMastery.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        private string _FilePath = FilePathSetting.FilePath;
        public string Namecreator(DateTime Date)
        {

            string Converted = Date.ToString("MMddyyyy");
            string Name = "Orders_" + $"{Converted}.txt";
            return Name;
        }

        public List<Order> Orders()
        {
            try
            {
                List<Order> Orders = new List<Order>();


                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Order newOrder = new Order();

                        string[] columns = line.Split(',');

                        newOrder.OrderNumber = Convert.ToInt32(columns[0]);
                        newOrder.CustomerName = columns[1];
                        newOrder.State = columns[2];
                        newOrder.TaxRate = decimal.Parse(columns[3]);
                        newOrder.ProductType = columns[4];
                        newOrder.Area = decimal.Parse(columns[5]);
                        newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                        newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                        newOrder.MaterialCost = decimal.Parse(columns[8]);
                        newOrder.LaborCost = decimal.Parse(columns[9]);
                        newOrder.Tax = decimal.Parse(columns[10]);
                        newOrder.Total = decimal.Parse(columns[11]);

                        Orders.Add(newOrder);
                    }
                }

                return Orders;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            
        }

        public static string TheDate(DateTime time)
        {
            return Convert.ToString(time);
        }

    

        public string _filePath = $@".\ReadThis\SampleData\";
        public FileOrderRepository(string filePath)
        {
            _filePath = filePath;

        }






        public Order EditOrder(Order order, DateTime ListName, int OrderNumber)
        {
            try
            {
                Order orderError = new Order();
                orderError.Area = -1;
                Order linedateError = new Order();
                linedateError.Area = -2;
                Order Correct = new Order();
                Correct.Area = 1;

                int counter = 0;

                bool FileCheck = FilePathCheck.ValidateFile(ListName);
                if (FileCheck != true)
                {

                    return linedateError;
                }

                string date = Namecreator(ListName);
                _filePath = $"{_FilePath}" + $"{date}";
                var OrderList = Orders();



                for (int i = 0; i < OrderList.Count; i++)
                {



                    if (OrderList[i].OrderNumber == OrderNumber)
                    {
                        counter++;
                        if (order.Area == 0)
                        {
                        }
                        else
                        {
                            OrderList[i].Area = order.Area;
                        }


                        if (order.CustomerName == "")
                        {
                        }
                        else
                        {
                            OrderList[i].CustomerName = order.CustomerName;
                        }

                        if (order.State == "")
                        {
                        }
                        else
                        {
                            OrderList[i].State = order.State;
                            OrderList[i].TaxRate = order.TaxRate;
                        }

                        if (order.ProductType == "")
                        {
                        }
                        else
                        {
                            OrderList[i].ProductType = order.ProductType;
                            OrderList[i].CostPerSquareFoot = order.CostPerSquareFoot;
                            OrderList[i].LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
                        }

                        OrderList[i].MaterialCost = OrderList[i].Area * OrderList[i].CostPerSquareFoot;
                        OrderList[i].LaborCost = OrderList[i].Area * OrderList[i].LaborCostPerSquareFoot;
                        OrderList[i].Tax = (OrderList[i].MaterialCost + OrderList[i].LaborCost) * (OrderList[i].TaxRate / 100);
                        OrderList[i].Total = (OrderList[i].MaterialCost + OrderList[i].LaborCost + OrderList[i].Tax);

                        CreateOrderFile(OrderList);
                    }

                }
                if (counter == 0)
                {
                    return orderError;
                }
                return Correct;

                }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
}

        public Order LoadOrder(int OrderNumber, DateTime ListName)
        {
            try { 
            Order orderError = new Order();
            orderError.Area = -1;
            Order linedateError = new Order();
            linedateError.Area = -2;
            Order Correct = new Order();
            Correct.Area = 1;

            int counter = 0;
            bool FileCheck = FilePathCheck.ValidateFile(ListName);
            if (FileCheck != true)
            {
                return linedateError;
            }
            string date = Namecreator(ListName);
            _filePath = $"{_FilePath}" + $"{date}";

            var OrderList = Orders();
       
            for (int i = 0; i < OrderList.Count; i++)
            {

                if (OrderList[i].OrderNumber == OrderNumber)
                {
                    counter++;
                    return OrderList[i];
                }

            }
            if (counter == 0)
            {
                return orderError;
            }
            return Correct;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }





        public Order RemoveOrder(int UserNumber, DateTime ListName)
        {
            try { 
            Order orderError = new Order();
            orderError.Area = -1;
            Order linedateError = new Order();
            linedateError.Area = -2;
            Order Correct = new Order();
            Correct.Area = 1;
            int counter = 0;

            bool FileCheck = FilePathCheck.ValidateFile(ListName);
            if (FileCheck != true)
            {
               
                return linedateError;
            }
            string date = Namecreator(ListName);
            _filePath = $"{_FilePath}" + $"{date}";
            var OrderList = Orders();

            for (int i = 0; i < OrderList.Count; i++)
            {


                if (OrderList[i].OrderNumber == UserNumber)
                {
                    counter++;
                    OrderList.Remove(OrderList[i]);
                    CreateOrderFile(OrderList);
                }

            }
            if (counter == 0)
            {
                return orderError;
            }
            return Correct;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Order SaveOrder(Order order, DateTime ListName)
        {
            try { 
            Order correct = new Order();
            correct.Area = 1;

            string date = Namecreator(ListName);
                _filePath = $"{_FilePath}" + $"{date}";
            
            
            if (!File.Exists(_filePath))
            {
              var newFile= File.Create(_filePath);
                newFile.Close();



                order.OrderNumber = 1;
                var OrderList = Orders();
                OrderList.Add(order);

                using (StreamWriter sw = new StreamWriter(_filePath, true))
                {
                    string line = CreateCsvForOrder(order);

                    sw.WriteLine(line);
                }
                CreateOrderFile(OrderList);

            }
            else
            {
                List<Order> TempOrders = new List<Order>();
                var OrderList = Orders();
                for (int i = 0; i < OrderList.Count; i++)
                {



                    TempOrders.Add(OrderList[i]);

                   


                }
                if (TempOrders.Count > 0)
                {
                    order.OrderNumber = TempOrders[TempOrders.Count - 1].OrderNumber + 1;
                }
                else
                {
                    order.OrderNumber = 1;
                };

                OrderList.Add(order);
                CreateOrderFile(OrderList);
            }
            return correct;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
            
        

        private string CreateCsvForOrder(Order order)
        {
            order.Tax = Math.Round(order.Tax,2);
            order.Total = Math.Round(order.Total, 2);
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber,
                order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot,
            order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }

        private void CreateOrderFile(List<Order> orders)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }

        }
        public bool OrderCheck(DateTime ListName)
        {
            try
            {
                var OrderList = Orders();
                for (int i = 0; i < OrderList.Count; i++)
                {


                    if (OrderList[i].Date == ListName)
                    {
                        return true;
                    }


                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
