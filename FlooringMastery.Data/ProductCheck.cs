using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;
using FlooringMastery.Models.Interfaces;

namespace FlooringMastery
{
   public class ProductCheck: IReadDataFromFile
        
    {
       

        public List<Order> listData()
        {
            List<Order> Products = new List<Order>();

            using (StreamReader sr = new StreamReader(FilePathSetting.ProductsPath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();

                    string[] columns = line.Split(',');

                    newOrder.ProductType = columns[0];
                    newOrder.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                    newOrder.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);



                    Products.Add(newOrder);
                }
            }

            return Products;
        }

        public Order CheckForGivenString(string Input)
        {
            Order NeverChange = new Order();
            NeverChange.ProductType = "";
            Order Blankorder = new Order();
            Blankorder.ProductType = "0";
            List<Order> Prods = listData();

            if (Input == "")
            {
                return NeverChange;
            }

            for (int i = 0; i < Prods.Count; i++)
            {
                if (Prods[i].ProductType.ToUpper() == Input)
                {
                    return Prods[i];
                }
            }
            Console.WriteLine("Please Enter a Valid Product type from the list above");
            return Blankorder;

        }

        public void MakeAListOfDataForDisplay()
        {
            List<Order> Prods = listData();


            for (int i = 0; i < Prods.Count; i++)
            {

                Console.WriteLine(Prods[i].ProductType);

            }

        }
    }
}
