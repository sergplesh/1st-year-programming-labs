using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб__9_класс_Car
{
    internal class Interface // класс для общения с пользователем (ввод числа, вывод данных)
    {
        // ПОДПИСИ ДАННЫХ ОБЪЕКТОВ
        public static string hat = "|" + String.Format("{0,35}", "Расход топлива на 100 км (в литрах)|") + String.Format("{0,38}", "Количество топлива в баке (в литрах)|") + String.Format("{0,31}", "Оставшийся запас хода (в км)|");

        // количество вызовов конструкторов
        public static void Count(int count, string message)
        {
            Console.WriteLine(message + $"{count}");
        }

        public static void Show(Car c) // вывод атрибутов объекта
        {
            Console.WriteLine(hat);
            Console.WriteLine(c.ToString());
        }
        public static void Show(CarArray carArray) // вывод атрибутов объекта
        {
            if (carArray.Length == 0)
            {
                Console.WriteLine("Коллекция пуста");
            }
            else
            {
                Console.WriteLine(hat);
                Console.WriteLine(carArray.ToString());
            }
        }
    }
}