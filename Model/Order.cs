using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsFormsApp.Model
{
    public class Order
    {
        public int OrderId { set; get; }
        public string CustomerName { set; get; }
        public string IteamName { set; get; }
        public int OrderQuantity { set; get; }
        public double TotalPrice { set; get; }
    }
}
