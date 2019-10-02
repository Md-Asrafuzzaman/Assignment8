using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public bool AddOrderInfo(Order order)
        {
            return _orderRepository.AddOrderInfo(order);
        }

        public bool IsCustomerNameAndIteamNameExists(string Customername, string itemName)
        {
            return _orderRepository.IsCustomerNameAndIteamNameExists(Customername, itemName);
        }
    }
}
