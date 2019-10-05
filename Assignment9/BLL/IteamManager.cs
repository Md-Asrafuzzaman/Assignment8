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
        public bool Add(Item item)
        {      
            return _iteamRepository.Add(item);
        }

        public bool IsNameExists(Item item)
        {
            return _iteamRepository.IsNameExists(item);
        }

        public bool Delete(Item item)
        {
            return _iteamRepository.Delete(item);
        }

        public bool Update(Item item)
        {
            return _iteamRepository.Update(item);
        }

        public List<Item> Display()
        {
            return _iteamRepository.Display();
        }

        public Item Search(Item item)
        {
            return _iteamRepository.Search(item);
        }

        public DataTable ItemCombobox()
        {
            return _iteamRepository.ItemCombobox();
        }
    }
}
