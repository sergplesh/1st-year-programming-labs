using Microsoft.VisualBasic;
using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
// КОММЕНТЫ МАРКВИРЕР:
// ПОСЛЕ ВВОДА ".", ЕСЛИ ЗАТЕМ НАЖАТЬ ЭНТЕР - ВЫВЕДЕТ ИСКЛЮЧЕНИЕ
namespace Эксперементируем_6_лаб
{
    internal class Program
    {
        static int EnterIntNumber(string message = "", int minLimit = int.MinValue, string errorMinLimit = "", int maxLimit = int.MaxValue, string errorMaxLimit = "") // ввод целого числа в указанных пределах
        {
            bool isConvert;
            int number; // вводимое число
            while (true)
            {
                try
                {
                    do
                    {
                        isConvert = true;
                        Console.WriteLine(message);
                        number = Convert.ToInt32(Console.ReadLine()); // пытаемся конвертировать введённую строку
                        if (number < minLimit) // выход числа за минимальную указанную границу
                        {
                            Console.WriteLine(errorMinLimit); // сообщение о выходе за min границу
                            isConvert = false;
                        }
                        if (number > maxLimit) // выход числа за максимальную указанную границу
                        {
                            Console.WriteLine(errorMaxLimit); // сообщение о выходе за max границу
                            isConvert = false;
                        }
                    } while (!isConvert);
                    return number; // возвращаем введённое число
                }
                catch (FormatException) // ловим ввод не того формата
                {
                    Console.WriteLine("Вы ввели не целое число");
                }
                catch (OverflowException) // ловим переполнение памяти
                {
                    Console.WriteLine("Вы ввели слишком маленькое или большое  число");
                }
            }
        }
        static string CheckSentence(string input, out bool isCorrect) // проверка ввода корректной строки
        {
            string msg = "";
            isCorrect = true;
            // проверяем, не состоит строка из одних пробелов и знаков препинания
            Regex nonLetters = new Regex(@"[\s\!\.\,\?\;\:]");
            string words = nonLetters.Replace(input, "");
            if (words.Length == 0)
            {
                msg += "Строка должна содержать цифры, английские буквы, а не только знаки препинания и пробелы.\n";
                isCorrect = false;
            }
            char lastChar = input[input.Length - 1];
            if (lastChar != '.' && lastChar != '!' && lastChar != '?')
            {
                msg += "Строка должна оканчиваться одним из символов: точка, восклицательный знак или вопросительный знак.\n";
                isCorrect = false;
            }
            int count = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (count == 0)
                {
                    if (input[i] == ' ' || input[i] == '.' || input[i] == '!' || input[i] == '?' || input[i] == ';' || input[i] == ':' || input[i] == ',')
                    {
                        if (input[i + 1] == '.' || input[i + 1] == '!' || input[i + 1] == '?' || input[i + 1] == ';' || input[i + 1] == ':' || input[i + 1] == ',')
                        {
                            // if (input[i] + input[i + 1] != "??" || input[i] + input[i + 1] != "!!" || input[i] + input[i + 1] != "!?" || input[i] + input[i + 1] != "?!")
                            msg += "Знаки препинания не должны повторяться и перед ними не должно быть пробелов.\n";
                            isCorrect = false;
                            count = 1;
                        }
                    }
                }
            }
            // проверяем, есть ли в строке русские буквы
            MatchCollection matches = Regex.Matches(input, @"[А-Яа-я]");
            if (matches.Count != 0)
            {
                msg += "Слова могут содержать только английские буквы, цифры и знак нижнего подчёркивания\n";
                isCorrect = false;
            }
            if (isCorrect)
                msg = "Строка введена правильно";
            else
                msg += "Попробуйте ввести строку заново";
            return msg;
        }
        static void NullStr(ref string input) // в случае РУЧНОГО ввода пустой строки просим снова ввести, чтобы программе было, с чем работать
        {
            Regex empty = new Regex(@"[\s]");
            string words = empty.Replace(input, "");
            if (words.Length == 0)
            {
                Console.WriteLine("Вы ввели пустую строку. Попробуйте ввести строку заново.");
                input = Console.ReadLine();
            }
        }
        static void NullStr(ref string input, out bool isCorrect) // ДЛЯ ТЕСТОВ в случае ввода пустой строки запоминаем это в isCorrect
        {
            isCorrect = true;
            Regex empty = new Regex(@"[\s]");
            string words = empty.Replace(input, "");
            if (words.Length == 0)
            {
                Console.WriteLine("Вы ввели пустую строку.");
                isCorrect = false;
            }
        }
        static void Result(string input, string pattern, string exceptions) // СОСТАВЛЯЕМ ОТВЕТ
        {
            input = " " + input;
            MatchCollection matches = Regex.Matches(input, pattern); // получаем все подстроки, соответствие шаблону (все идентификаторы)
            // Проверка наличия идентификаторов в строке
            if (matches.Count > 0)
            {
                int maxLength = 0;
                foreach (Match match in matches) // перебираем все найденные в строке идентификаторы
                {
                    // сначала найдём среди них самую большую длину
                    string identifier = match.Value;
                    if (identifier.Length > maxLength)
                    {
                        maxLength = identifier.Length;
                    }
                }
                string result = ""; // сюда будем записывать ответ
                foreach (Match match in matches) // перебираем все найденные в строке идентификаторы
                {
                    string identifier = match.Value;
                    if (identifier.Length == maxLength) // если у идентификатора найденная нами самая большая длина, то он нам нужен в ответе
                    {
                        if (!exceptions.Contains(identifier))
                        {
                            result += identifier + ", "; // записываем все самые длинные идентификаторы через запятую
                        }
                    }
                }
                if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 2); // обрезаем последнюю лишнюю запятую
                    Console.WriteLine("Самые длинные идентификаторы: " + result); // выводим в ответе
                }
                else Console.WriteLine("В строке нет идентификаторов");
            }
            else
            {
                Console.WriteLine("В строке нет идентификаторов");
            }
        }
        static void FindIdentifier(ref string input, string pattern, string exceptions) // ДЛЯ РУЧНОГО ВВОДА (находим идентификаторы в введённой строке)
        {
            NullStr(ref input); // до тех пор пока введённая строка пуста, вводим снова
            bool isCorrect; // переменная для проверки корректности ввода строки
            string msg = CheckSentence(input, out isCorrect); // корректно ли введена строка?
            Console.WriteLine(msg);
            while (!isCorrect) // Вводим строку до тех пор, пока не получаем корректный ввод
            {
                input = Console.ReadLine();
                NullStr(ref input); // до тех пор пока введённая строка пуста, вводим снова
                msg = CheckSentence(input, out isCorrect); // снова: корректно ли введена строка?
                Console.WriteLine(msg);
            }
            Result(input, pattern, exceptions); // если строка набрана корректно - выводим ответ
        }
        static void FindIdentifierTest(ref string input, string pattern, string exceptions) // ДЛЯ ТЕСТОВ (находим идентификаторы в введённой строке)
        {
            bool isCorrect; // переменная для проверки корректности ввода строки
            NullStr(ref input, out isCorrect);  // проверяем на пустоту
            if (!isCorrect) return; // Строка не корректна(пуста) - выходим
            string msg = CheckSentence(input, out isCorrect); // корректно ли введена строка?
            Console.WriteLine(msg);
            if (!isCorrect) return; // Строка не корректна - выходим
            Result(input, pattern, exceptions); // если всё хорошо - ответ
        }
        static void Test(string pattern, ref int answer2, string exceptions, string test)
        {
            Console.WriteLine($"{answer2} ТЕСТ: " + test);
            FindIdentifierTest(ref test, pattern, exceptions);
        }
        static void Main(string[] args)
        {
            string input; // вводимая строка
            string exceptions = "abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void volatile while";
            string pattern = @"\s+[a-zA-Z][a-zA-Z0-9_]*|\s+[_]+[a-zA-Z0-9]+[a-zA-Z0-9_]*"; // шаблон для идентификаторов
            //string pattern = @"[a-zA-Z_][a-zA-Z0-9_]*"; // шаблон для идентификаторов
            string test;
            int answer; // переменная для выбора действия из меню
            do // не закрываем меню, пока не введём 0
            {
                // отображаем меню с выбором действия
                Console.WriteLine("Выберете ввод строки:");
                Console.WriteLine("1.Вручную");
                Console.WriteLine("2.Автоматический");
                Console.WriteLine("0.Выход из программы");
                answer = EnterIntNumber("Выберите действие из меню"); // выбираем действие
                switch (answer) // в зависимости от введённого ответа программа выполняет одно из действий
                {
                    case 1: // ручной ввод строки
                        {
                            // вводим строку
                            Console.WriteLine("Введите строку:");
                            input = Console.ReadLine();
                            FindIdentifier(ref input, pattern, exceptions);
                            Console.WriteLine();
                            break;
                        }
                    case 2: // тесты
                        {
                            int answer2; // ответ пользователя для выбора теста
                            do
                            {
                                Console.WriteLine("1. Первый тест");
                                Console.WriteLine("2. Второй тест");
                                Console.WriteLine("3. Третий тест");
                                Console.WriteLine("4. Четвёртый тест");
                                Console.WriteLine("5. Пятый тест");
                                Console.WriteLine("6. Шестой тест");
                                Console.WriteLine("7. Седьмой тест");
                                Console.WriteLine("8. Восьмой тест");
                                Console.WriteLine("9. Девятый тест");
                                Console.WriteLine("10. Десятый тест");
                                Console.WriteLine("11. Одиннадцатый тест");
                                Console.WriteLine("12. Двенадцатый тест");
                                Console.WriteLine("13. Тринадцатый тест");
                                Console.WriteLine("0. Назад");
                                answer2 = EnterIntNumber("Выберите действие из меню"); // выбираем тест
                                switch (answer2)
                                {
                                    case 1:
                                        {
                                            test = "static void PrintUpper string info12346: WriteLine ToUpper info, 1234info.";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 2:
                                        {
                                            test = "";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 3:
                                        {
                                            test = "привет";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 4:
                                        {
                                            test = "Donald Duck34 privet_1234 joker.";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 5:
                                        {
                                            test = "___.";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 6:
                                        {
                                            test = "Dark 132Alleys.";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 7:
                                        {
                                            test = "Global warming or climate change is a major contributing factor to environmental damage." +
                                                " Because of global warming, we have seen an increase in melting ice caps, a rise in sea levels," +
                                                " and the formation of new weather patterns. These weather patterns have caused stronger storms," +
                                                " droughts, and flooding in places that they formerly did not occur.";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 8:
                                        {
                                            test = "What a pity!!! What a pity!!!";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 9:
                                        {
                                            test = "C !?";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 10:
                                        {
                                            test = "C!";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 11:
                                        {
                                            test = "     ";
                                            Console.WriteLine("(тест состоит из пяти пробелов)");
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 12:
                                        {
                                            test = "     !";
                                            Console.WriteLine("(тест состоит из пяти пробелов и восклицательного знака)");
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 13:
                                        {
                                            test = "!";
                                            Test(pattern, ref answer2, exceptions, test);
                                            break;
                                        }
                                    case 0: // возврат к главному меню
                                        {
                                            Console.WriteLine("Вы вернулись в главное меню:");
                                            break;
                                        }
                                    default: // введённое число не подошло ни к одному пункту
                                        {
                                            Console.WriteLine("Неправильно задан пункт меню");
                                            break;
                                        }
                                }
                            } while (answer2 != 0); // не возвращаемся в главное меню, пока не введём 0
                            break;
                        }
                    case 0: // Выход из программы
                        {
                            Console.WriteLine("Работа завершена");
                            break;
                        }
                    default: // введённое число не подошло ни к одному пункту
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer != 0); // не закрываем меню, пока не введём 0
        }
    }
}
