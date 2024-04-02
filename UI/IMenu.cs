using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.UI
{
    internal interface IMenu
    {
        void DisplayMenu(string mainText, string[] menuItems);
        void MenuManagement(string[] menuItems);
        void HandleMenuItemSelection(int selectedItemIndex);

    }
}
