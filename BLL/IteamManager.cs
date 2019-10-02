using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    public class IteamManager
    {
        IteamRepository _iteamRepository = new IteamRepository();
        public bool Add(string name, double price)
        {      
            return _iteamRepository.Add(name, price);
        }

        public bool IsNameExists(string name)
        {
            return _iteamRepository.IsNameExists(name);
        }

        public bool Delete(int id)
        {
            return _iteamRepository.Delete(id);
        }

        public bool Update(string name, double price, int id)
        {
            return _iteamRepository.Update(name, price, id);
        }

        public DataTable Display()
        {
            return _iteamRepository.Display();
        }

        public DataTable Search(string name)
        {
            return _iteamRepository.Search(name);
        }
    }
}
