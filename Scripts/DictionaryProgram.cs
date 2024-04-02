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
        private static _Dictionary dictionary = new _Dictionary();
        private static MainMenu mainMenu = new MainMenu();

        public static void Start()
        {
            mainMenu.StartMenu();
        }
    }
}
