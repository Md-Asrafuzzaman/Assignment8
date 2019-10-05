using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyWindowsFormsApp.Model
{
    public class Customer
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Contact { set; get; }
        public string District { set; get; }
        public int SL { get; set; }
    }
}
