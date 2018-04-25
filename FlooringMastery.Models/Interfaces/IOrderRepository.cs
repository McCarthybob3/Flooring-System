using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
   public interface IOrderRepository
    {
        Order LoadOrder(int OrderNumber, DateTime ListName);
        Order SaveOrder(Order order, DateTime ListName);
        Order EditOrder(Order order, DateTime ListName, int OrderNumber);
        Order RemoveOrder(int AccountNumber, DateTime ListName);

    }
}
