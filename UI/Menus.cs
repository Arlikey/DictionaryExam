using Dictionary.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.UI
{
    internal class MainMenu : AbstractMenu
    {
        private CreateDictionarySubMenu createDictionarySubMenu = new CreateDictionarySubMenu();
        private GoToDictionarySubMenu goToDictionarySubMenu = new GoToDictionarySubMenu();

        new string mainText = $"""
                    Добро пожаловать в "Словарь"
                
                {(_Dictionary.IsCreated() ? $"Словарь создан:\n\tТип: " : "Словарь не создан!")}

                Выберите действие:


                """;
        new string[] menuItems = { "Создать словарь", "Перейти в словарь", "Выход" };
        public void StartMenu()
        { 
            DisplayMenu(mainText, menuItems);
                
            while (true)
            {
                MenuManagement(menuItems);

                DisplayMenu(mainText, menuItems);
            }
        }
        public override void HandleMenuItemSelection(int selectedItemIndex)
        {
            switch (selectedItemIndex)
            {
                case 0:
                    createDictionarySubMenu.StartMenu();
                    break;
                case 1:
                    goToDictionarySubMenu.StartMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    internal class CreateDictionarySubMenu : AbstractMenu
    {
        private bool isBack = false;
        new string mainText = """""""
                    Укажите тип словаря:

                """"""";
        new string[] menuItems = { "Русско-английский", "Англо-русский", "Назад" };
        public void StartMenu()
        {
            DisplayMenu(mainText, menuItems);

            while (!isBack)
            {
                MenuManagement(menuItems);

                DisplayMenu(mainText, menuItems);
            }

            isBack = false;
            selectedItemIndex = 0;
        }
        public override void HandleMenuItemSelection(int selectedItemIndex)
        {
            switch (selectedItemIndex)
            {
                case 0:
                    _Dictionary.CreateDictionary("Русско-английский");
                    break;
                case 1:
                    break;
                case 2:
                    isBack = true;
                    break;
            }
        }

    }

    internal class GoToDictionarySubMenu : AbstractMenu
    {
        private bool isBack = false;
        new string mainText = """""""
                    Выберите действия для словаря:

                """"""";
        new string[] menuItems = { "Добавить слово с переводом или перевод", "Заменить слово или перевод", "Удалить слово или перевод",
                               "Найти перевод слова", "Экспортировать в файл", "Назад" };
        public void StartMenu()
        {
            DisplayMenu(mainText, menuItems);

            while (!isBack)
            {
                MenuManagement(menuItems);

                DisplayMenu(mainText, menuItems);
            }

            isBack = false;
            selectedItemIndex = 0;
        }
        public override void HandleMenuItemSelection(int selectedItemIndex)
        {
            switch (selectedItemIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    isBack = true;
                    break;
            }
        }

    }
}
