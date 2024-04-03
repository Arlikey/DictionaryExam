using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dictionary.Scripts
{
    internal static class fileAccess
    {
        private static string path = "Dictionary.json";

        public static bool IsCreated()
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
        public static void SerializeDictionary(Dictionary dictionary)
        {
            string jsonString = JsonSerializer.Serialize(dictionary);
            File.WriteAllText(path, jsonString);
        }

        public static Dictionary? DeserializeDictionary()
        {
            if (IsCreated())
            {
                string jsonString = File.ReadAllText(path);
                Dictionary dictionary = JsonSerializer.Deserialize<Dictionary>(jsonString);
                return dictionary;
            }
            return null;
        }
    }
}
