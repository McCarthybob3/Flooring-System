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
   public class StateCheck : IReadDataFromFile
    {

        public List<Order> listData()
        {
            List<Order> States = new List<Order>();

            using (StreamReader sr = new StreamReader(FilePathSetting.TaxPath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();

                    string[] columns = line.Split(',');

                    newOrder.State = columns[0];
                    newOrder.TaxRate = Convert.ToDecimal(columns[2]);




                    States.Add(newOrder);
                }
            }

            return States;

        }

        public  Order CheckForGivenString(string Input)
        {
            Order NeverChange = new Order();
            NeverChange.State = "";
            Order Blankorder = new Order();
            Blankorder.State = "0";
            List<Order> States = listData();

            if(Input == "")
            {
                return NeverChange;
            }

            for (int i = 0; i < States.Count; i++)
            {
                if (States[i].State == Input)
                {
                    return States[i];
                }
            }
            Console.WriteLine("Please Sorry, That's not a proper state");
            return Blankorder;
        }

        public  void MakeAListOfDataForDisplay()
        {
            throw new NotImplementedException();
        }
    }
}
