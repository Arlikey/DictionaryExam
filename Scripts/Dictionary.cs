using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dictionary.Scripts
{
    internal class Dictionary
    {
        public string TypeOfDictionary { get; set; }
        public Dictionary<string, string[]> WordsAndTranslations { get; set; }

        public Dictionary(string typeOfDictionary)
        {
            TypeOfDictionary = typeOfDictionary;
            WordsAndTranslations = new Dictionary<string, string[]>();
        }
        public void Add()
        {
            Console.Clear();
            Console.WriteLine("Добавление слова в словарь:\n");
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(word))
            {
                Console.Write("Введите перевод(-ы), разделенные запятой: ");
                string translationInput = Console.ReadLine();
                string[] translations = translationInput.Split(',') ;
                WordsAndTranslations[word.Trim()] = translations;
                fileAccess.SerializeDictionary(this);
                Console.WriteLine("Слово успешно добавлено!");
            }
            else
            {
                Console.WriteLine("Вы ввели пустую строку!");
            }
            Console.WriteLine("\nНажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }

        public void ReplaceWord()
        {
            Console.Clear();
            Console.WriteLine("Замена слова или перевода в словаре:");
            Console.Write("Введите слово, которое вы хотите заменить или его переводы: ");
            string wordToReplace = Console.ReadLine();

            if (IsInDictionary(wordToReplace))
            {
                Console.Write("Введите новое слово (оставьте после пустым чтобы не заменять слово): ");
                string newWord = Console.ReadLine();
                if(string.IsNullOrEmpty(newWord))
                {
                    newWord = wordToReplace;
                }

                Console.Write("Введите новый перевод(-ы), разделенные запятой (оставьте после пустым чтобы не заменять переводы): ");
                string newTranslationsInput = Console.ReadLine();
                string[] newTranslations = newTranslationsInput.Split(',');
                if (string.IsNullOrWhiteSpace(newTranslationsInput))
                {
                    newTranslations = WordsAndTranslations[wordToReplace];
                }

                WordsAndTranslations.Remove(wordToReplace);
                WordsAndTranslations.Add(newWord, newTranslations);

                Console.WriteLine("Слово или перевод успешно заменены!");
            }
            else
            {
                Console.WriteLine($"Слово '{wordToReplace}' не найдено в словаре.");
            }

            Console.WriteLine("\nНажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();

        }

        public void RemoveWordOrTranslation()
        {
            Console.Clear();
            Console.WriteLine("Удаление слова или перевода в словаре:\n");
            Console.Write("Введите слово, которое вы хотите удалить или удалить его перевод: ");
            string wordToRemove = Console.ReadLine();
            Console.Write("Введите перевод, который вы хотите удалить: ");
            string translationToRemove = Console.ReadLine();
            if (IsInDictionary(wordToRemove))
            {
                if (string.IsNullOrEmpty(translationToRemove))
                {
                    WordsAndTranslations.Remove(wordToRemove);
                    Console.WriteLine($"Слово '{wordToRemove}' и все его переводы успешно удалены из словаря.");
                }
                else
                {
                    if (WordsAndTranslations[wordToRemove].Contains(translationToRemove))
                    {
                        if (WordsAndTranslations[wordToRemove].Length == 1)
                        {
                            WordsAndTranslations.Remove(wordToRemove);
                            Console.WriteLine($"Слово '{wordToRemove}' и его последний перевод успешно удалены из словаря.");
                        }
                        else
                        {
                            var translationsList = WordsAndTranslations[wordToRemove].ToList();
                            translationsList.Remove(translationToRemove);
                            WordsAndTranslations[wordToRemove] = translationsList.ToArray();
                            Console.WriteLine($"Перевод '{translationToRemove}' слова '{wordToRemove}' успешно удалён из словаря.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Указанный перевод не существует для данного слова.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Указанное слово не существует в словаре.");
            }
            Console.WriteLine("\nНажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }

            public void FindWordTranslations()
        {
            Console.Clear();
            Console.WriteLine("Поиск переводов слова в словаре:\n");
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(word) && IsInDictionary(word))
            {
                string[] translations = WordsAndTranslations[word.Trim()];
                Console.Write($"Переводы слова {word}: ");
                for (int i = 0; i < translations.Length; i++)
                {
                    if (i == translations.Length - 1)
                    {
                        Console.WriteLine(translations[i]);
                        break;
                    }
                    Console.Write(translations[i] + ", ");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели пустую строку или такого слова нет в словаре!");
            }
            Console.WriteLine("\nНажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }

        public bool IsInDictionary(string userWord)
        {
            if (WordsAndTranslations.ContainsKey(userWord))
            {
                return true;
            }

            return false;
        }

        public string GetAllWords()
        {
            string allWords = "";
            foreach (var keyValuePair in WordsAndTranslations)
            {
                allWords += $"{keyValuePair.Key} - ";

                foreach (string value in keyValuePair.Value)
                {
                    allWords += $"{value}, ";
                }
                allWords = allWords.TrimEnd(',', ' ') + "\n";
            }
            return allWords;
        }

        public void ExportToFile()
        {
            Console.Clear();
            Console.Write("Введите название файла для сохранения текущего словаря: ");
            string fileName = Console.ReadLine();
            if (fileName != null)
            {
                string filePath = fileName + ".txt";
                File.WriteAllText(filePath, GetAllWords());
                Console.WriteLine($"Содержимое словаря было успешно экспортировано в файл {filePath}");
            }

            Console.WriteLine("\nНажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }
    }
}
