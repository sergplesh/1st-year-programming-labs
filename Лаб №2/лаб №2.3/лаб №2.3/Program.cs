using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace лаб__2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length; // длина последовательности
            bool isConvert;
            Console.WriteLine("Введите длину числовой последовательности");
            do // вводим длину последовательности(она должна быть неотрицательной)
            {
                isConvert = int.TryParse(Console.ReadLine(), out length);
                if (!isConvert)
                    Console.WriteLine("Ошибка ввода! Вы ввели не число.\nНеобходимо ввести неотрицательное целое число не больше 2147483647. Повторите ввод.");
                if (length < 0)
                    Console.WriteLine("Ошибка ввода! Вы ввели отрицательное число.\nДлина последовательности должна быть неотрицательным целым числом не больше 2147483647. Повторите ввод.");
            } while (!isConvert || length < 0);
            if (length != 0) // проверяем на наличие последовательности элементов
            {
                int number; // элемент последовательности
                if (length != 1) // в случае последовательности длины 1 нельзя будет вычислить сумму элементов с чётными номерами
                {
                    long summa = 0; // сумма элементов с чётными номерами
                    for (int count = 1; count <= length; count++) // вводим последовательность чисел длины n
                    {
                        Console.WriteLine("Введите число");
                        do // вводим элементы последовательности
                        {
                            isConvert = int.TryParse(Console.ReadLine(), out number);
                            if (!isConvert)
                                Console.WriteLine("Ошибка ввода! \nНеобходимо ввести целое число в промежутке [-2147483648;2147483647]. Повторите ввод");
                        } while (!isConvert);
                        if (count % 2 == 0) // суммируем элементы с чётными номерами
                        {
                            summa += number;
                        }
                    }
                    Console.WriteLine("Сумма элементов последовательности с четными номерами =" + summa); //Выводим результат в случае непустой последовательности
                }
                else
                {
                    Console.WriteLine("Введите число");
                    do // вводим элемент последовательности
                    {
                        isConvert = int.TryParse(Console.ReadLine(), out number);
                        if (!isConvert)
                            Console.WriteLine("Ошибка ввода! \nНеобходимо ввести целое число в промежутке [-2147483648;2147483647]. Повторите ввод");
                    } while (!isConvert);
                    Console.WriteLine("Последовательность состоит только из одного элемента - /" +
                        "элементов с чётными номерами нет"); //Выводим результат в случае последовательности из одного элемента
                } 
            }
            else
            {
                Console.WriteLine("Последовательность пуста"); //Выводим результат в случае непустой последовательности
            }
        }
    }
}