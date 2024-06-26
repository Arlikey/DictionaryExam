﻿using Dictionary.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dictionary.UI
{
    internal class MainMenu : AbstractMenu
    {
        private CreateDictionarySubMenu createDictionarySubMenu;
        private GoToDictionarySubMenu goToDictionarySubMenu;

        string menuText;
        string[] menuItems = { "Создать словарь", "Перейти в словарь", "Выход" };

        public MainMenu(Scripts.Dictionary dictionary) : base(dictionary) { }

        public void StartMenu()
        {

            DisplayMenu(menuText, menuItems);

            while (true)
            {
                
                menuText = $"""
                    Добро пожаловать в "Словарь"    
                   
                {RefreshDictionaryStatus()}

                Выберите действие:

                """;
                DisplayMenu(menuText, menuItems);

                MenuManagement(menuItems);

            }
        }
        public override void HandleMenuItemSelection(int selectedItemIndex)
        {
            switch (selectedItemIndex)
            {
                case 0:
                    createDictionarySubMenu = new CreateDictionarySubMenu(dictionary);
                    createDictionarySubMenu.StartMenu();
                    break;
                case 1:
                    goToDictionarySubMenu = new GoToDictionarySubMenu(dictionary);
                    goToDictionarySubMenu.StartMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

        public string RefreshDictionaryStatus()
        {
            return $"""
             {(!string.IsNullOrWhiteSpace(dictionary.TypeOfDictionary) ? $"Словарь создан:\n\tТип: {dictionary.TypeOfDictionary}" +
            $"\n\tКоличество слов: {dictionary.WordsAndTranslations.Count}" : "Словарь не создан!")}
            """;
        }
    }

    internal class CreateDictionarySubMenu : AbstractMenu
    {
        private bool isBack = false;
        new string menuText = """""""
                    Укажите тип словаря:

                """"""";
        new string[] menuItems = { "Русско-английский", "Англо-русский", "Назад" };

        public CreateDictionarySubMenu(Scripts.Dictionary dictionary) : base(dictionary) { }

        public void StartMenu()
        {
            DisplayMenu(menuText, menuItems);

            while (!isBack)
            {
                MenuManagement(menuItems);

                DisplayMenu(menuText, menuItems);
            }

            isBack = false;
            selectedItemIndex = 0;
        }
        public override void HandleMenuItemSelection(int selectedItemIndex)
        {
            switch (selectedItemIndex)
            {
                case 0:
                    dictionary = new Scripts.Dictionary("Русско-Англиский");
                    break;
                case 1:
                    dictionary = new Scripts.Dictionary("Англо-Русский");
                    break;
                case 2:
                    isBack = true;
                    break;
            }
            fileAccess.SerializeDictionary(dictionary);
        }

    }

    internal class GoToDictionarySubMenu : AbstractMenu
    {
        private ShowDictionarySubMenu showDictionarySubMenu;
        private bool isBack = false;
        new string menuText = """""""
                    Выберите действия для словаря:

                """"""";
        new string[] menuItems = { "Просмотреть словарь", "Добавить слово с переводом", "Заменить слово или перевод", "Удалить слово или перевод",
                               "Найти переводы слова", "Экспортировать в файл", "Назад" };

        public GoToDictionarySubMenu(Scripts.Dictionary dictionary) : base(dictionary) { }

        public void StartMenu()
        {
            DisplayMenu(menuText, menuItems);

            while (!isBack)
            {
                MenuManagement(menuItems);

                DisplayMenu(menuText, menuItems);
            }

            isBack = false;
            selectedItemIndex = 0;
        }
        public override void HandleMenuItemSelection(int selectedItemIndex)
        {
            switch (selectedItemIndex)
            {
                case 0:
                    showDictionarySubMenu = new ShowDictionarySubMenu(dictionary);
                    showDictionarySubMenu.StartMenu();
                    break;
                case 1:
                    dictionary.Add();
                    break;
                case 2:
                    dictionary.ReplaceWord();
                    break;
                case 3:
                    dictionary.RemoveWordOrTranslation();
                    break;
                case 4:
                    dictionary.FindWordTranslations();
                    break;
                case 5:
                    dictionary.ExportToFile();
                    break;
                case 6:
                    isBack = true;
                    break;
            }
        }

        public class ShowDictionarySubMenu : AbstractMenu
        {
            private bool isBack = false;
            new string[] menuItems = { "Назад" };
            new string menuText;

            public ShowDictionarySubMenu(Scripts.Dictionary dictionary) : base(dictionary) { }

            public void StartMenu()
            {
                menuText = $""" 
                    Список слов:

                    {dictionary.GetAllWords()}
                    """;
                DisplayMenu(menuText, menuItems);

                while (!isBack)
                {

                    MenuManagement(menuItems);

                    DisplayMenu(menuText, menuItems);
                }

                isBack = false;
                selectedItemIndex = 0;
            }
            public override void HandleMenuItemSelection(int selectedItemIndex)
            {
                switch (selectedItemIndex)
                {
                    case 0:
                        isBack = true;
                        break;
                }
            }
        }    
    }
}
