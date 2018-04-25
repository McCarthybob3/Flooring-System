using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models;
using FlooringMastery;

namespace FlooringMastery.BLL
{
   public class OrderManager
    {

        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            try { 
            _orderRepository = orderRepository;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
              
            }
        }

        public LookupOrderResponse LookupOrder(int OrderNumber,DateTime OrderDate)
        {
            LookupOrderResponse response = new LookupOrderResponse();
           
            response.Order = _orderRepository.LoadOrder(OrderNumber, OrderDate);
            if (response.Order == null)
            {
                response.Sucess = true;
            }
            return response;
        }

        public AddOrderResponse AddOrder(Order order, DateTime OrderDate)
        {
            AddOrderResponse response = new AddOrderResponse();

            response.Order = _orderRepository.SaveOrder(order, OrderDate);
            if (response.Order == null)
            {
                response.Sucess = true;
            }
            return response;
        }

        public EditOrderResponse EditOrder(Order order, DateTime OrderDate, int OrderNumber)
        {
            EditOrderResponse response = new EditOrderResponse();

            response.Order = _orderRepository.EditOrder(order, OrderDate, OrderNumber);
            if (response.Order == null)
            {
                response.Sucess = true;
            }
            return response;
        }
        public RemoveOrderResponse RemoveOrder(int ordernumber, DateTime OrderDate)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();

            response.Order = _orderRepository.RemoveOrder(ordernumber,OrderDate);
            if (response.Order == null)
            {
                response.Sucess = true;
            }
            return response;
        }







    }
}
