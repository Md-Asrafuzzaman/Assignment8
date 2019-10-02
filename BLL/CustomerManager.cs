using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    public class CustomerManager
    {
        //Create CustomerRepository Object
        CustomerRepository _customerRepository = new CustomerRepository();

        //Add Operation Method
        public bool AddCustomerInfo(string name, string address, string contact)
        {
            return _customerRepository.AddCustomerInfo(name,address,contact);
        }
        public bool IsNameExists(string name)
        {
            return _customerRepository.IsNameExists(name);
        }

        //Update Operation Method
        public bool UpdateCustomerInfo(int id, string name, string address, string contact)
        {
            return _customerRepository.UpdateCustomerInfo(id,name,address,contact);
        }

        //Display Operation Method
        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        // Delete Operation Method
        public bool DeleteCustomerInfo(int id)
        {
            return _customerRepository.DeleteCustomerInfo(id);
        }

        //Search Operation Method
        public DataTable SearchCustomerInfo(string name)
        {
            return _customerRepository.SearchCustomerInfo(name);
        }

    }
}
