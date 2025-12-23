using System.Net.Sockets;
using System.Runtime.InteropServices;
// КОММЕНТЫ МАРКВИРЕР:
// МОЖНО ОБЁЕДИНИТЬ ДСЧ И ВРУЧНУЮ(ТО ЕСТЬ В ОДНУ ФУНКЦИЮ, В КОТОРОЙ С ПОМОЩЬЮ ПАРАМЕТРА ПО УМОЛЧАНИЮ ВЫБИРАТЬ ЗАПОЛНЕНИЕ ВРУЧНУЮ ИЛИ ДСЧ)
// ПОЭКСПЕРИМЕНТИРОВАТЬ С ОБЛАСТЬЮ ПАМЯТИ(ДЛЯ ОДНОГО ОБЪЕКТА И ДЛЯ НЕСКОЛЬКИХ ОДНА ОБЛАСТЬ ПАМЯТИ (ПРИ КОПИРОВАНИИ РВАНОГО МАССИВА, ТО ЕСТЬ ЕГО СТРОК, С ПОМОЩЬЮ ПРИКРЕПЛЕНИЯ НЕСКОЛЬКИХ ССЫЛОК К ОДНОЙ СТРОКЕ))
// МОЖНО НЕ СОЗДАВАТЬ ФУНКЦИЮ-ПРОВЕРКУ НА ПУСТОТУ (ПОТОМУ ЧТО ПРОГРАММЕ ПОТРЕБУЕТСЯ БОЛЬШЕ УСИЛИЙ ВЫЗВАТЬ ФУНКЦИЮ, ЧЕМ ВЫПОЛНИТЬ ОДНУ ЛОГИЧЕСКУЮ ОПЕРАЦИЮ)
// ПО ЗНАЧЕНИЮ И ПО ССЫЛКЕ ПОЭКСПЕРИМЕНТИРОВАТЬ (ПОЧЕМУ ТО МОЖНО В ВОЙД ФОРМИРОВАНИИ МАССИВА ИСПОЛЬЗОВАТЬ ПАРАМЕТР-МАССИВ ПО ЗНАЧЕНИЮ, НЕ ВОЗВРАЩАЯ СФОРМИРОВАННЫЙ МАССИВ??? КАК???)
namespace лаб_5
{ 
    internal class Program
    {
        // ДАННАЯ ПРОГРАММА РАБОТАЕТ С МАССИВАМИ(ОДНОМЕРНЫМИ, ДВУМЕРНЫМИ, РВАНЫМИ), СОДЕРЖАЩИМИ НЕ БОЛЕЕ 10 ЭЛЕМЕНТОВ В СТРОКЕ (ЦЕЛЫЕ ЧИСЛА ТИПА INT) ДЛЯ УДОБНОГО ВЫВОДА
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
        // МОЖНО НЕ СОЗДАВАТЬ НА ПУСТОТУ - ПОТОМУ ЧТО ЛЕГЧЕ ВЫПОЛНИТЬ ЭТО УСЛОВИЕ В ПРОГРАММЕ, ЧЕМ ВЫЗЫВАТЬ ДЛЯ ЭТОГО ФУНКЦИЮ
        static bool IsEmpty(int[] arr) // проверка одномерного массива на пустоту
        {
            return (arr == null || arr.Length == 0);
        }
        static bool IsEmpty(int[,] arr) // проверка двумерного массива на пустоту
        {
            return (arr == null || arr.Length == 0);
        }
        static bool IsEmpty(int[][] arr) // проверка рваного массива на пустоту
        {
            return (arr == null || arr.Length == 0);
        }
        static void EnterLength(ref int[] arr, ref int length)
        {
            // ввод длины одномерного массива
            length = EnterIntNumber("Введите количество элементов в одномерном массиве, оно должно быть в пределах от 0 до 10.", 0, "Длина массива не может быть отрицательным числом.", 10, "Длина массива не должна превышать 10.");
            if (length == 0) // создание пустого массива
            {
                Console.WriteLine("Вы создали пустой массив");
            }
            arr = new int[length]; // создаём массив введённой длины
        } // выделение памяти для одномерного массива введённой длины
        // МОЖНО ОБЁЕДИНИТЬ ДСЧ И ВРУЧНУЮ
        static void CreateHandArr(ref int[] arr, ref int length) // создание вручную одномерного массива
        {
            EnterLength(ref arr, ref length);
            int number; // элемент массива
            for (int i = 0; i < length; i++) // последовательно заполняем массив
            {
                // вводим целые значения в массив вручную
                number = EnterIntNumber("Введите элемент массива"); // элементы одномерного массива - все числа типа Int
                arr[i] = number;
            }
            Console.WriteLine("Одномерный массив сформирован"); // сообщаем о выполнении команды
        }
        static void CreateArr(ref int[] arr, ref int length) //создание ДСЧ одномерного массива
        {
            Random rand = new Random(); // используем класс Random
            EnterLength(ref arr, ref length);
            for (int i = 0; i < length; i++) // последовательно заполняем массив с помощью ДСЧ
                arr[i] = rand.Next(-9999, 9999);
            Console.WriteLine("Одномерный массив сформирован"); // сообщаем о выполнении команды
        }
        static void PrintArr(int[] arr) // печать одномерного массива
        {
            if (IsEmpty(arr)) // массив пуст?
                Console.WriteLine("Одномерный массив пуст");
            else
                Console.WriteLine("Массив выглядит так:");
            foreach (int item in arr) // по очереди вытаскиваем из масива значения
                Console.Write(item + " "); // выводим значения друг за другом через пробел
            Console.WriteLine(); // дописываем, чтобы перейти на следующую строчку
        }
        static int[] DeleteValue(int[] arr, ref int length) // удалить из одномерного массива первый элемент с заданным значением
        {
            if (IsEmpty(arr)) // в случае пустого массива удалять нечего
            {
                Console.WriteLine("Одномерный массив пуст"); // предупреждаем
            }
            else
            {
                // вводим значение удаляемого элемента
                int value = EnterIntNumber("Введите элемент, который хотите удалить из массива");
                if (arr.Length == 1 && arr[0] == value) // если массив состоит из одного элемента, который нужно удалить
                {
                    Console.WriteLine("Элемент удалён, в массиве не осталось элементов");
                    arr = new int[0];
                    return arr; // возвращаем пустой массив
                }
                int[] temp = new int[arr.Length - 1]; // новый массив без удалённого элемента будет иметь длину на единицу меньше
                int j = 0; // нумерация для последующего массива (асинхронная нумерация)
                bool flag = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == value && flag == false) // если наткнулись в массиве на первый элемент с введённым значением
                    {
                        flag = true; // фиксируем, что первый элемент с введённым значением уже найден
                    }
                    else // переписываем в новый массив все элементы исходного, кроме удаляемого
                    {
                        temp[j] = arr[i];
                        j++;
                    }
                }
                if (!flag) // если в массиве не оказалось элементов с введённым значением
                {
                    Console.WriteLine("Такого значения в массиве нет");
                    PrintArr(arr);
                    return arr; // возвращаем исходный массив
                }
                arr = temp; // получаем новый преобразованный массив
                length = length - 1;
                Console.WriteLine("Первый встретившийся в массиве элемент с данным значением был удалён"); // выводим сообщение о завершении удаления
                PrintArr(arr);
            }
            return arr;
        }
        static void EnterLength(ref int[,] arr, ref int str, ref int col)
        {
            str = EnterIntNumber("Введите количество строк в двумерном массиве", 0, "Количество строк не может быть отрицательным числом.");
            col = EnterIntNumber($"Введите количество столбцов в двумерном массиве, оно должно быть в пределах от 0 до 10.", 0, "Количество столбцов не может быть отрицательным числом.", 10, "Количество столбцов не должна превышать 10.");
            arr = new int[str, col]; // создаём матрицу с введённым количеством строк и столбцов
        } // выделение памяти для матрицы с введённым количеством строк и столбцов
        static void CreateHandArr(ref int[,] arr, ref int str, ref int col) // создание вручную двумерного массива
        {
            EnterLength(ref arr, ref str, ref col);
            int number; // элемент матрицы
            for (int i = 0; i < str; i++) // по очереди заполняем строки матрицы
                for (int j = 0; j < col; j++) // идём по текущей строке и заполняем её
                {
                    // ввод элемента матрицы
                    number = EnterIntNumber($"Введите элемент матрицы в {i + 1} строке, {j + 1} столбце от -9999 до 9999", -9999, "Введённое значение элемента матрицы слишком маленькое", 9999, "Введённое значение элемента матрицы слишком большое");
                    arr[i, j] = number;
                }
            Console.WriteLine("Матрица сформирована");
        }
        static void CreateArr(ref int[,] arr, ref int str, ref int col) // создание ДСЧ двумерного массива
        {
            EnterLength(ref arr, ref str, ref col);
            Random rand = new Random(); // используем класс Random
            for (int i = 0; i < str; i++) // по очереди заполняем строки матрицы
                for (int j = 0; j < col; j++) // идём по текущей строке и заполняем её
                {
                    arr[i, j] = rand.Next(-9999, 9999); // элемент матрицы
                }
            Console.WriteLine("Матрица сформирована");
        }
        static void PrintArr(int[,] arr) // печать двумерного массива
        {
            if (IsEmpty(arr)) // массив пуст?
                Console.WriteLine("Матрица пуста");
            else
                Console.WriteLine("Массив выглядит так:");
            for (int i = 0; i < arr.GetLength(0); i++) // перебираем строки матрицы
            {
                for (int j = 0; j < arr.GetLength(1); j++) // идём по текущей строке
                {
                    Console.Write($"{arr[i, j],5}" + " "); // отводим 5 символов на вывод элемента матрицы
                }
                Console.WriteLine();
            }
        }
        static int[,] Copy(int[,] arr)
        {
            int[,] temp = new int[arr.GetLength(0) + 1, arr.GetLength(1)]; // создаём матрицу с количеством строк на 1 больше, чем у исходной
            // переписываем исходный массив в новый
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    temp[i, j] = arr[i, j];
            return temp;
        }  // копируем в новую матрицу исходную, но последняя строка остаётся пуста для добавления
        static int[,] AddHandStr(int[,] arr, ref int str) // добавить строку в конец матрицы (вручную)
        {
            int[,] temp = Copy(arr);
            int number;
            for (int j = 0; j < temp.GetLength(1) - 1; j++) // заполняем добавленную в конец матрицы строку
            {
                // ввод элемента матрицы
                number = EnterIntNumber($"Введите элемент матрицы в {temp.GetLength(0)} строке, {j + 1} столбце от -9999 до 9999", -9999, "Элемент матрицы не должен быть меньше -9999.", 9999, "Элемент матрицы не должен быть больше 9999.");
                temp[temp.GetLength(0) - 1, j] = number;
            }
            arr = temp; // приравниваем исходный массив к новому
            str = str + 1;
            Console.WriteLine("В конец матрицы добавлена строка");
            PrintArr(arr);
            return arr;
        }
        static int[,] AddStr(int[,] arr, ref int str) // добавить строку в конец матрицы (ДСЧ)
        {
            int[,] temp = Copy(arr);
            Random rand = new Random(); // используем класс Random
            for (int j = 0; j < arr.GetLength(1); j++) // заполняем добавленную в конец матрицы строку
            {
                temp[temp.GetLength(0) - 1, j] = rand.Next(-9999, 9999);
            }
            arr = temp; // приравниваем исходный массив к новому
            str = str + 1;
            Console.WriteLine("В конец матрицы добавлена строка");
            PrintArr(arr);
            return arr;
        }
        static void EnterJagStr(ref int[][] arr, ref int jagStr) // ввод количество строк рваного массива
        {
            jagStr = EnterIntNumber("Введите количество строк в рваном массиве", 0, "Количество строк не может быть отрицательным числом.");
            if (jagStr == 0) // если в рваном массиве ноль  строк, то он пуст
            {
                Console.WriteLine("Вы создали пустой массив, так как количество строк равно нулю");
            }
            arr = new int[jagStr][]; // создание рваного массива с введённым количеством строк
        }
        static int[][] CreateHandArr(int[][] arr, ref int jagStr) // создание вручную рваного массива
        {
            EnterJagStr(ref arr, ref jagStr);
            for (int i = 0; i < jagStr; i++) // перебираем строки рваного массива, чтобы заполнить их
            {
                // вводим количество элементов в текущей строке рваного массива
                int jagCol = EnterIntNumber($"Введите длину {i + 1} строки в рваном массиве. Оно не должно превышать 10", 0, "Количество строк не может быть отрицательным числом.", 10, "Введённое значение количества строк стишком большое");
                arr[i] = new int[jagCol]; // создаём строку с введённым количеством элементов(столбцов)
                int number; // элемент строки рваного массива
                for (int j = 0; j < jagCol; j++) // идём по строке рваного массива
                {
                    // вводим элемент строки рваного массива
                    number = EnterIntNumber($"Введите элемент {i + 1} строки от -9999 до 9999", -9999, "Введённое значение элемента слишком маленькое", 9999, "Введённое значение элемента слишком большое");
                    arr[i][j] = number;
                }
            }
            Console.WriteLine("Рваный массив сформирован"); // сообщаем о выполнении команды
            return arr;
        }
        static int[][] CreateArr(int[][] arr, ref int jagStr) // создание ДСЧ рваного массива
        {
            EnterJagStr(ref arr, ref jagStr);
            Random rand = new Random(); // используем класс Random
            for (int i = 0; i < jagStr; i++) // перебираем строки рваного массива, чтобы заполнить их
            {
                int jagCol = rand.Next(0, 10);
                arr[i] = new int[jagCol]; // создаём строку с введённым количеством элементов(столбцов)
                for (int j = 0; j < jagCol; j++) // идём по текущей строке
                {
                    arr[i][j] = rand.Next(-9999, 9999);
                }
            }
            Console.WriteLine("Рваный массив сформирован"); // сообщаем о выполнении команды
            return arr;
        }
        static void PrintArr(int[][] arr) // печать рваного массива
        {
            if (IsEmpty(arr)) // массив пуст?
                Console.WriteLine("Рваный массив пуст");
            else
            {
                Console.WriteLine("Массив выглядит так:");
                for (int i = 0; i < arr.GetLength(0); i++) // перебираем строки 
                {
                    if (IsEmpty(arr[i])) // если строка рваного массива пуста, то отображаем это
                    {
                        Console.WriteLine($"{i + 1} строка - пуста");
                    }
                    else
                    {
                        for (int j = 0; j < arr[i].GetLength(0); j++) // идём по текущей строке
                        {
                            Console.Write($"{arr[i][j],5}" + " "); // выводим элемент рваного массива
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        static int[][] DeleteNullStr(int[][] arr, ref int jagStr) // удалить из рваного массива строчки, содержащие нули
        {
            if (IsEmpty(arr))
            {
                PrintArr(arr);
            }
            else
            {
                int count = 0; // будем считать количество строк, которые потребуется удалить
                int[] deleteStr = new int[jagStr]; // создадим массив, в который будем заносить номера строчек, которые требуется удалить
                for (int i = 0; i < jagStr; i++) // перебираем строки рваного массива
                {
                    for (int j = 0; j < arr[i].GetLength(0); j++) // идём по строке рваного массива
                    {
                        if (arr[i][j] == 0) // если в текущей строчке натыкаемся на ноль
                        {
                            deleteStr[count] = i; // добавляем номер удаляемой строки
                            count++; // увеличиваем количество удаляемых строк
                            break; // перебираем элементы в следующей строке
                        }
                    }
                }
                if (count == 0) // в случае, когда в массиве не оказалось строк, которые потребуется удалить, возвращаем исзодный массив
                {
                    Console.WriteLine("В массиве нет строчек, содержащих нули");
                    PrintArr(arr);
                    return arr;
                }
                int[][] temp = new int[jagStr - count][]; // удалив строки с нулями, получим массив длины меньше исходного на количество удаляеммых строк
                int u = 0; // для ассинхронной нумерации массива без строк, которые необходимо удалить
                count = 0; // для ассинхронной нумерации массива с номерами строк, которые необходимо удалить
                for (int i = 0; i < jagStr; i++) // идём по строкам исходного массива
                {
                    if (deleteStr[count] != i) // если это не удаляемая строка, то переписываем её в новый массив
                    {
                        temp[u] = new int[arr[i].GetLength(0)];
                        for (int j = 0; j < arr[i].GetLength(0); j++)
                        {
                            temp[u][j] = arr[i][j];
                        }
                        u++;
                        count++;
                    }
                }
                arr = temp; // приравниваем исходный массив к получившемуся
                Console.WriteLine("Из массива удалены все строчки, содержащие нули"); // сообщаем о выполнении действия
                PrintArr(arr);
                jagStr = jagStr - count;
            }
            return arr;
        }
        static void Main(string[] args)
        {
            int answer; // переменная для выбора действия из меню
            int[] arr = new int[0]; // инициализируем одномерный массив
            int length = 0; // длина одномерного массива
            int[,] matr = new int[0, 0]; // инициализируем двумерный массив
            int str = 0, col = 0; // строки и столбцы матрицы
            int[][] jag = new int[0][]; // инициализируем рваный массив
            int jagStr = 0; // строки и столбцы рваного массива
            do // не закрываем меню, пока не введём 0
            {
                // отображаем меню с выбором действия
                Console.WriteLine("1.Работа с одномерным массивом");
                Console.WriteLine("2.Работа с двумерным массивом(матрицей)");
                Console.WriteLine("3.Работа с рваным массивом");
                Console.WriteLine("0.Выход из программы");
                answer = EnterIntNumber("Выберите действие из меню"); // выбираем действие
                switch (answer) // в зависимости от введённого ответа программа выполняет одно из действий
                {
                    case 1: // работа с одномерным массивом
                        {
                            int answer1; // ответ пользователя для выбора действия для одномерного массива
                            do
                            {
                                Console.WriteLine("1.Сформировать одномерный массив вручную");
                                Console.WriteLine("2.Сформировать одномерный массив с помощью ДСЧ");
                                Console.WriteLine("3.Напечатать одномерный массив");
                                Console.WriteLine("4.Удалить элемент с заданным значением из одномерного массива");
                                Console.WriteLine("0.Назад в главное меню");
                                answer1 = EnterIntNumber("Выберите действие из меню"); // выбираем действие
                                switch (answer1)
                                {
                                    case 1: // создание одномерного массива(ДСЧ)
                                        {
                                            CreateHandArr(ref arr, ref length);
                                            break;
                                        }
                                    case 2: // создание одномерного массива(вручную)
                                        {
                                            CreateArr(ref arr, ref length);
                                            break;
                                        }
                                    case 3: // печать оодномерного массива
                                        {
                                            PrintArr(arr);
                                            break;
                                        }
                                    case 4: // удалить знначение из одномерного массива
                                        {
                                            arr = DeleteValue(arr, ref length);
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
                            } while (answer1 != 0); // не возвращаемся в главное меню, пока не введём 0
                            break;
                        }
                    case 2: // работа с двумерным массивом
                        {
                            int answer2; // ответ пользователя для выбора действия для двумерного массива
                            do
                            {
                                Console.WriteLine("1.Сформировать двумерный массив(матрицу) вручную");
                                Console.WriteLine("2.Сформировать двумерный массив(матрицу) с помощью ДСЧ");
                                Console.WriteLine("3.Напечатать двумерный массив(матрицу)");
                                Console.WriteLine("4.Добавить строку в конец матрицы");
                                Console.WriteLine("0.Назад в главное меню");
                                answer2 = EnterIntNumber("Выберите действие из меню"); // выбираем действие
                                switch (answer2)
                                {
                                    case 1: // создание матрицы(вручную)
                                        {
                                            CreateHandArr(ref matr, ref str, ref col);
                                            break;
                                        }
                                    case 2: // создание матрицы(ДСЧ)
                                        {
                                            CreateArr(ref matr, ref str, ref col);
                                            break;
                                        }
                                    case 3: // печать матрицы
                                        {
                                            PrintArr(matr);
                                            break;
                                        }
                                    case 4: // добавление строчки в конец матрицы
                                        {
                                            int answer21; // ответ пользователя для выбора того, каким образом добавить строчку в двумерный массив
                                            do
                                            {
                                                Console.WriteLine("1.Добавить строчку в конец матрицы вручную");
                                                Console.WriteLine("2.Добавить строчку в конец матрицы с помощью ДСЧ");
                                                Console.WriteLine("0.Назад");
                                                answer21 = EnterIntNumber("Выберите действие из меню"); // выбираем действие
                                                switch (answer21)
                                                {
                                                    case 1: // добавление строчки в конец матрицы(вручную)
                                                        {
                                                            matr = AddHandStr(matr, ref str);
                                                            break;
                                                        }
                                                    case 2: // добавление строчки в конец матрицы(ДСЧ)
                                                        {
                                                            matr = AddStr(matr, ref str);
                                                            break;
                                                        }
                                                    case 0: // возврат к действиям над матрицей
                                                        {
                                                            Console.WriteLine("Вы вернулись к выбору действия над двумерным массивом:");
                                                            break;
                                                        }
                                                    default: // введённое число не подошло ни к одному пункту
                                                        {
                                                            Console.WriteLine("Неправильно задан пункт меню");
                                                            break;
                                                        }
                                                }
                                            } while (answer21 != 0); // не возвращаемся в главное меню, пока не введём 0
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
                    case 3: // работа с рваным массивом
                        {
                            int answer3; // ответ пользователя для выбора действия для рваного массива
                            do
                            {
                                Console.WriteLine("1.Сформировать рваный массив вручную");
                                Console.WriteLine("2.Сформировать рваный массив с помощью ДСЧ");
                                Console.WriteLine("3.Напечатать рваный массив");
                                Console.WriteLine("4.Удалить из рваного массива все строки, в которых встречаются нули");
                                Console.WriteLine("0.Назад в главное меню");
                                answer3 = EnterIntNumber("Выберите действие из меню"); // выбираем действие
                                switch (answer3)
                                {
                                    case 1: // создание вручную рваного массива
                                        {
                                            jag = CreateHandArr(jag, ref jagStr);
                                            break;
                                        }
                                    case 2: // создание ДСЧ рваного массива
                                        {
                                            jag = CreateArr(jag, ref jagStr);
                                            break;
                                        }
                                    case 3: // печать рваного массива
                                        {
                                            PrintArr(jag);
                                            break;
                                        }
                                    case 4: // удаление строчек с нулём из рваного массива
                                        {
                                            jag = DeleteNullStr(jag, ref jagStr);
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
                            } while (answer3 != 0); // не возвращаемся в главное меню, пока не введём 0
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