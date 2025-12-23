using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб__9_класс_Car
{
    public class CarArray
    {
        private static int count2 = 0;

        private static Random rnd2 = new Random();

        Car[] carArray;

        public int Length // свойство
        {
            get => carArray.Length;
        }

        // ИНДЕКСИРОВАНИЕ
        public Car this[int index]
        {
            get
            {
                if (index >= 0 && index < carArray.Length)
                    return carArray[index];
                else throw new IndexOutOfRangeException("Индекс выходит за пределы коллекции");
            }
            set
            {
                if (index >= 0 && index < carArray.Length)
                    carArray[index] = value;
                else throw new IndexOutOfRangeException("Индекс выходит за пределы коллекции");
            }
        }

        // КОНСТРУКТОРЫ КОЛЛЕКЦИИ
        public CarArray() // конструктор без параметров 
        {
            carArray = new Car[3];
            for (int i = 0; i < carArray.Length; i++)
            {
                carArray[i] = new Car();
            }
            count2++;
        }
        public CarArray(int length, bool answer) // конструктор с параметрами, заполняющий элементы случайными значениями
                                                 // конструктор с параметрами, позволяющий заполнить массив элементами, заданными пользователем с клавиатуры;
        {
            if (answer)
            {
                carArray = new Car[length];
                for (int i = 0; i < length; i++)
                {
                    carArray[i] = new Car((rnd2.Next(0, 1000) + Math.Round(rnd2.NextDouble(), 2)), (rnd2.Next(0, 1000) + Math.Round(rnd2.NextDouble(), 2)));
                }
            }
            else
            {
                double fuelFlow, fuelVolume;
                carArray = new Car[length];
                for (int i = 0; i < length; i++)
                {
                    Car c = new Car();
                    fuelFlow = Program.EnterIntNumber(true, "Введите расход литров на 100 км", 0, "Расход литров топлива на 100 км не может быть меньше или равен нулю. Вечный двигатель всё ещё не изобрели");
                    c.FuelFlow = fuelFlow;
                    fuelVolume = Program.EnterIntNumber(false, "Введите количество топлива в баке", 0, "Топлива не может быть отрицательное количество литров");
                    c.FuelVolume = fuelVolume;
                    carArray[i] = c;
                }
            }
            count2++;
        }
        public CarArray(CarArray other) // конструктор копирования, позволяющий создать копию коллекции
        {
            carArray = new Car[other.Length];
            for (int i = 0; i < Length; i++)
            {
                carArray[i] = new Car(other[i]);
            }
            count2++;
        }

        public override string ToString()
        {
            string data = "";
            for (int i = 0; i < carArray.Length; i++)
            {
                data += carArray[i].ToString() + "\n";
            }
            return data;
        }

        // Количество созданных коллекций
        public static int Count()
        {
            return count2;
        }
    }
}