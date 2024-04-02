using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Scripts
{
    internal class _Dictionary
    {
        private readonly static string path = "Словарь.txt";
        Dictionary<string, string[]> wordsAndTranslations = new Dictionary<string, string[]>();

        public static bool IsCreated()
        {
            if (File.Exists(path)) 
            {
                return true;
            }
            return false;
        }

        public static void CreateDictionary(string typeOf)
        {
            if (!IsCreated()) {
                using (StreamWriter sw = File.CreateText(path)) { }    
            }
        }
    }
}
