using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuItemRepo
    {
        protected List<MenuItem> _menuRepo = new List<MenuItem>();

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuRepo.Add(menuItem);
        }

        public List<MenuItem> ListAllMenuItems()
        {
            return _menuRepo;
        }

        public int MenuItemNumber()
        {
            int num = _menuRepo.Count() + 1;
            return num;
        }

        public void DeleteMenuItemByName(string name)
        {
            List<int> indexes = new List<int>();
            foreach (MenuItem item in _menuRepo)
            {
                if (item.MealName.ToLower() == name)
                {
                    int index = _menuRepo.IndexOf(item);
                    indexes.Add(index);
                }
            }
            foreach (int index in indexes)
            {
                _menuRepo.RemoveAt(index);
            }
        }
    }
}
