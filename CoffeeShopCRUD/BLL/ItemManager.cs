using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopCRUD.Repository;

namespace CoffeeShopCRUD.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public bool Add(string name, double price)
        {
            return _itemRepository.Add(name,price);
        }

        public bool Update(int id, string name, double price)
        {
            return _itemRepository.Update(id,name,price);
        }

        public DataTable Display()
        {
           return _itemRepository.Display();
        }

        public bool CheckIfNumeric(string input)
        {
            return _itemRepository.CheckIfNumeric(input);
        }

        public bool Delete(int id)
        {
            return _itemRepository.Delete(id);
        }

        public bool IsNameExist(string name)
        {
            return _itemRepository.IsNameExist(name);
        }

        public DataTable Search(string name)
        {
            return _itemRepository.Search(name);
        }
    }
}
