using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;
namespace MyWindowsFormsApp.BLL
{
    
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }
        public bool CodeFieldConditionCheck(Customer customer)
        {
            return _customerRepository.CodeFieldConditionCheck(customer);
        }

        public bool ContactFieldConditionCheck(Customer customer)
        {
            return _customerRepository.ContactFieldConditionCheck(customer);
        }

        public List<District> DistrictCombobox()
        {
            return _customerRepository.DistrictCombobox();
        }

        public List<Customer> Display()
        {
            return _customerRepository.Display();
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public List<Customer> Search(Customer customer)
        {
            return _customerRepository.Search(customer);

        }

    }
}
