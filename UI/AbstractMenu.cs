using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.UI
{
    internal class AbstractMenu : IMenu
    {
        public int selectedItemIndex = 0;
        protected string mainText;
        protected string[] menuItems;
        
        public void DisplayMenu(string mainText, string[] menuItems)
        {
            Console.Clear();
            Console.WriteLine(mainText);

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedItemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($" > {menuItems[i]} ");
                }
                else
                {   
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" {menuItems[i]} ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public virtual void HandleMenuItemSelection(int selectedItemIndex) { }
        public void MenuManagement(string[] menuItems)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedItemIndex > 0)
                    {
                        selectedItemIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedItemIndex < menuItems.Length - 1)
                    {
                        selectedItemIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    HandleMenuItemSelection(selectedItemIndex);
                    break;
            }
        }
 
    }
}
