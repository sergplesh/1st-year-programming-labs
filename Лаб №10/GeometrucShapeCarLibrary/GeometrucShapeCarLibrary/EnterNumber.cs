using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GeometrucShapeCarLibrary
{
    public class EnterNumber
    {
        // ввод целых чисел
        public static int EnterIntNumber(string message = "", int minLimit = int.MinValue, string errorMinLimit = "Вы ввели слишком маленькое число", int maxLimit = int.MaxValue, string errorMaxLimit = "Вы ввели слишком большое число") // ввод целого числа в указанных пределах
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
        // ввод дробных чисел
        public static double EnterDoubleNumber(string message = "", double minLimit = double.MinValue, string errorMinLimit = "Вы ввели слишком маленькое число", double maxLimit = double.MaxValue, string errorMaxLimit = "Вы ввели слишком большое число") // ввод целого числа в указанных пределах
        {
            bool isConvert;
            double number; // вводимое число
            while (true)
            {
                try
                {
                    do
                    {
                        isConvert = true;
                        Console.WriteLine(message);
                        number = Convert.ToDouble(Console.ReadLine()); // пытаемся конвертировать введённую строку
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
                    Console.WriteLine("Вы ввели не вещественное число");
                }
                catch (OverflowException) // ловим переполнение памяти
                {
                    Console.WriteLine("Вы ввели слишком маленькое или большое  число");
                }
            }
        }



        //// ввод целых чисел
        //public static int EnterIntNumber()
        //{
        //    try
        //    {
        //        return int.Parse(Console.ReadLine());
        //    }
        //    catch
        //    {
        //        return 1;
        //    }
        //}

        //// ввод дробных чисел
        //public static double EnterDoubleNumber()
        //{
        //    try
        //    {
        //        return double.Parse(Console.ReadLine());
        //    }
        //    catch
        //    {
        //        return 1;
        //    }
        //}
    }
}
