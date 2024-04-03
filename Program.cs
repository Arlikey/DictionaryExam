using Dictionary.Scripts;
using Dictionary.UI;
using System.Text.Json;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Dictionary.json";
            DictionaryProgram dictionaryProgram;

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                Scripts.Dictionary dictionary = JsonSerializer.Deserialize<Scripts.Dictionary>(jsonString)!;
                dictionaryProgram = new DictionaryProgram(dictionary);
            }
            else
            {
                Scripts.Dictionary dictionary = new Scripts.Dictionary("");
                fileAccess.SerializeDictionary(dictionary);
                dictionaryProgram = new DictionaryProgram(dictionary);
            }

            dictionaryProgram.Start();
        }
    }
}
