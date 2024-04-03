using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.UI;

namespace Dictionary.Scripts
{
    internal class DictionaryProgram
    {
        private Dictionary dictionary;
        private MainMenu mainMenu;

        public DictionaryProgram(Dictionary dictionary)
        {
            this.dictionary = dictionary;
            mainMenu = new MainMenu(dictionary);
        }

        public void Start()
        {
            mainMenu.StartMenu();
        }
    }
}
