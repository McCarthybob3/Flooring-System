using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Data;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models.Interfaces;


namespace FlooringMastery.Tests
{
    class TestRepoTests
    {
        
        [TestCase(1, "Bob", "OH", "Tile", 250, true)]
        [TestCase(2, "Bob", "PA", "Wood", 100, true)]
        [TestCase(3, "Bob", "AL", "Dirt", 250, true)]
        public void AddOrder(int OrderNumber, string name, string state, string ProductType, decimal Area, bool expectedResults)
        {
            //should output to 1 for true but keeps throwing exception because not bool

            OrderTestRepository repo = new OrderTestRepository();

            Order Order = new Order();

            Order.OrderNumber = OrderNumber;
            Order.CustomerName = name;
            Order.State = state;
            Order.Area = Area;
            Order.ProductType = ProductType ;

          
            AddOrderResponse response = new AddOrderResponse();
            response.Order = repo.SaveOrder(Order,DateTime.Today);
            if(response.Order.Area == 1)
            {
                response.Sucess = true;
            }
            var response2 = repo.SaveOrder(response.Order, DateTime.Today);

            

            Assert.AreEqual(expectedResults,response.Sucess);

        }



    }
}
