using System;
using System.Security.Cryptography;
using System.Text;

namespace HashGeneratorConsole
{
    class Program
    {
        private static string currentLanguage = "en";

        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
                
                ShowLanguageMenu();
                
                while (true)
                {
                    ShowMainMenu();
                    string choice = Console.ReadLine();

                    if (choice == "0") break;

                    switch (choice)
                    {
                        case "6":
                            ShowAboutInfo();
                            continue;
                        case "7":
                            ShowLanguageMenu();
                            continue;
                        default:
                            ProcessHashChoice(choice);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical error: " + ex.Message);
                Console.ReadKey();
            }
        }

        static void ShowLanguageMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите язык/Оберіть мову:");
            Console.WriteLine("1. Беларуская");
            Console.WriteLine("2. Русский");
            Console.WriteLine("3. Українська");
            Console.Write("Выбор (1-3): ");
            
            string langChoice = Console.ReadLine();
            switch (langChoice)
            {
                case "1": currentLanguage = "by"; break;
                case "2": currentLanguage = "ru"; break;
                case "3": currentLanguage = "uk"; break;
                default: currentLanguage = "en"; break;
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            string title;
            switch (currentLanguage)
            {
                case "by": title = "ГЕНЕРАТАР ХЭШАЎ"; break;
                case "ru": title = "ГЕНЕРАТОР ХЕШЕЙ"; break;
                case "uk": title = "ГЕНЕРАТОР ХЕШІВ"; break;
                default: title = "HASH GENERATOR"; break;
            }
            Console.WriteLine(title);
            Console.WriteLine("---------------------");

            string menuPrompt;
            switch (currentLanguage)
            {
                case "by": menuPrompt = "\nДаступныя алгарытмы:"; break;
                case "ru": menuPrompt = "\nДоступные алгоритмы:"; break;
                case "uk": menuPrompt = "\nДоступні алгоритми:"; break;
                default: menuPrompt = "\nAvailable algorithms:"; break;
            }
            Console.WriteLine(menuPrompt);

            Console.WriteLine("1. MD5");
            Console.WriteLine("2. SHA1");
            Console.WriteLine("3. SHA256");
            Console.WriteLine("4. SHA384");
            Console.WriteLine("5. SHA512");
            
            string aboutText;
            switch (currentLanguage)
            {
                case "by": aboutText = "Аб праграме"; break;
                case "ru": aboutText = "О программе"; break;
                case "uk": aboutText = "Про програму"; break;
                default: aboutText = "About"; break;
            }
            Console.WriteLine("6. " + aboutText);
            
            string langText;
            switch (currentLanguage)
            {
                case "by": langText = "Змяніць мову"; break;
                case "ru": langText = "Изменить язык"; break;
                case "uk": langText = "Змінити мову"; break;
                default: langText = "Change language"; break;
            }
            Console.WriteLine("7. " + langText);
            
            string exitText;
            switch (currentLanguage)
            {
                case "by": exitText = "Выйсці"; break;
                case "ru": exitText = "Выход"; break;
                case "uk": exitText = "Вихід"; break;
                default: exitText = "Exit"; break;
            }
            Console.WriteLine("0. " + exitText);

            string selectPrompt;
            switch (currentLanguage)
            {
                case "by": selectPrompt = "\nВыберыце варыянт (0-7): "; break;
                case "ru": selectPrompt = "\nВыберите вариант (0-7): "; break;
                case "uk": selectPrompt = "\nОберіть варіант (0-7): "; break;
                default: selectPrompt = "\nSelect option (0-7): "; break;
            }
            Console.Write(selectPrompt);
        }

        static void ShowAboutInfo()
        {
            Console.Clear();
            string aboutTitle;
            switch (currentLanguage)
            {
                case "by": aboutTitle = "=== Генератар хэшаў ==="; break;
                case "ru": aboutTitle = "=== Генератор хешей ==="; break;
                case "uk": aboutTitle = "=== Генератор хешів ==="; break;
                default: aboutTitle = "=== Hash Generator ==="; break;
            }
            Console.WriteLine(aboutTitle);
            
            string versionText;
            switch (currentLanguage)
            {
                case "by": versionText = "Версія: 1.1"; break;
                case "ru": versionText = "Версия: 1.1"; break;
                case "uk": versionText = "Версія: 1.1"; break;
                default: versionText = "Version: 1.1"; break;
            }
            Console.WriteLine(versionText);
            
            string createdText;
            switch (currentLanguage)
            {
                case "by": createdText = "Створана з дапамогай:"; break;
                case "ru": createdText = "Создано с помощью:"; break;
                case "uk": createdText = "Створено за допомогою:"; break;
                default: createdText = "Created with:"; break;
            }
            Console.WriteLine(createdText);
            
            Console.WriteLine("  deepseek: 99% (написание кода)");
            Console.WriteLine("  cackemc: 1% (вставка кода)");
            
            string continueText;
            switch (currentLanguage)
            {
                case "by": continueText = "Націсніце любую клавішу для працягу..."; break;
                case "ru": continueText = "Нажмите любую клавишу для продолжения..."; break;
                case "uk": continueText = "Натисніть будь-яку клавішу для продовження..."; break;
                default: continueText = "Press any key to continue..."; break;
            }
            Console.WriteLine("\n" + continueText);
            Console.ReadKey();
        }

        static void ProcessHashChoice(string choice)
        {
            string inputPrompt;
            switch (currentLanguage)
            {
                case "by": inputPrompt = "Увядзіце тэкст для хэшавання: "; break;
                case "ru": inputPrompt = "Введите текст для хеширования: "; break;
                case "uk": inputPrompt = "Введіть текст для хешування: "; break;
                default: inputPrompt = "Enter text to hash: "; break;
            }
            Console.Write(inputPrompt);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                string errorText;
                switch (currentLanguage)
                {
                    case "by": errorText = "Памылка: Увод не можа быць пустым!"; break;
                    case "ru": errorText = "Ошибка: Ввод не может быть пустым!"; break;
                    case "uk": errorText = "Помилка: Введення не може бути порожнім!"; break;
                    default: errorText = "Error: Input cannot be empty!"; break;
                }
                Console.WriteLine(errorText);
                Console.ReadKey();
                return;
            }

            try
            {
                string algorithm = GetAlgorithmName(choice);
                if (algorithm == null)
                {
                    string invalidChoiceText;
                    switch (currentLanguage)
                    {
                        case "by": invalidChoiceText = "Няслушны выбар алгарытму!"; break;
                        case "ru": invalidChoiceText = "Неверный выбор алгоритма!"; break;
                        case "uk": invalidChoiceText = "Невірний вибір алгоритму!"; break;
                        default: invalidChoiceText = "Invalid algorithm choice!"; break;
                    }
                    Console.WriteLine(invalidChoiceText);
                    Console.ReadKey();
                    return;
                }

                string hash = GenerateHash(input, algorithm);
                string hashText;
                switch (currentLanguage)
                {
                    case "by": hashText = "Хэш:"; break;
                    case "ru": hashText = "Хеш:"; break;
                    case "uk": hashText = "Хеш:"; break;
                    default: hashText = "Hash:"; break;
                }
                Console.WriteLine("\n" + algorithm + " " + hashText + " " + hash);
            }
            catch (Exception ex)
            {
                string errorPrefix;
                switch (currentLanguage)
                {
                    case "by": errorPrefix = "Памылка: "; break;
                    case "ru": errorPrefix = "Ошибка: "; break;
                    case "uk": errorPrefix = "Помилка: "; break;
                    default: errorPrefix = "Error: "; break;
                }
                Console.WriteLine(errorPrefix + ex.Message);
            }
            Console.ReadKey();
        }

        static string GetAlgorithmName(string choice)
        {
            switch (choice)
            {
                case "1": return "MD5";
                case "2": return "SHA1";
                case "3": return "SHA256";
                case "4": return "SHA384";
                case "5": return "SHA512";
                default: return null;
            }
        }

        static string GenerateHash(string input, string algorithm)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes;

            HashAlgorithm hashAlgorithm;
            switch (algorithm)
            {
                case "MD5": hashAlgorithm = MD5.Create(); break;
                case "SHA1": hashAlgorithm = SHA1.Create(); break;
                case "SHA256": hashAlgorithm = SHA256.Create(); break;
                case "SHA384": hashAlgorithm = SHA384.Create(); break;
                case "SHA512": hashAlgorithm = SHA512.Create(); break;
                default: throw new ArgumentException("Invalid algorithm");
            }

            using (hashAlgorithm)
            {
                hashBytes = hashAlgorithm.ComputeHash(bytes);
            }

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}