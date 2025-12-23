using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб__9_класс_Car
{
    public class Car
    {
        private static int count1 = 0;

        private static Random rnd1 = new Random();

        private double fuelFlow = 10; // расход топлива на 100 км должно быть положительным, так как иначе это  
        private double fuelVolume;

        public double FuelFlow // расход топлива в литрах на 100 км (положительное число)
        {
            get => fuelFlow;
            set
            {
                if (value <= 0)
                {
                    fuelFlow = 10;
                }
                else fuelFlow = value;
            }
        }
        public double FuelVolume // количество топлива в баке (неотрицательное число)
        {
            get => fuelVolume;
            set
            {
                if (value < 0)
                {
                    fuelVolume = 0;
                }
                else fuelVolume = value;
            }
        }

        // КОНСТРУКТОРЫ ОБЪЕКТА
        public Car() // конструктор без параметров
        {
            FuelFlow = rnd1.Next(0, 1000) + Math.Round(rnd1.NextDouble(), 2);
            FuelVolume = rnd1.Next(0, 1000) + Math.Round(rnd1.NextDouble(), 2);
            count1++;
        }
        public Car(double fuelFlow, double fuelVolume) // конструктор с параметрами
        {
            FuelFlow = fuelFlow;
            FuelVolume = fuelVolume;
            count1++;
        }
        public Car(Car c) // конструктор копирования
        {
            FuelFlow = c.FuelFlow;
            FuelVolume = c.FuelVolume;
            count1++;
        }

        // МЕТОДЫ
        public double GetLength() // метод класса (сколько км может проехать автомобиль)
        {
            return Math.Round((FuelVolume / FuelFlow) * 100, 3);
        }
        public static double GetLength(Car c) // статический метод (сколько км может проехать автомобиль)
        {
            return Math.Round((c.FuelVolume / c.FuelFlow) * 100, 3);
        }


        // УНАРНЫЕ ОПЕРАЦИИ
        public static Car operator ++(Car c) // увеличение расхода топлива автомобиля на 0,1 л / 100 км
                                             // !!!КОММЕНТЫ:(i=1 y=i++ y - ожидаем 1, i - ожидаем изменение) ( ТО ЕСТЬ С ТОЧКИ ЗРЕНИЯ ПРИСВАИВАНИЯ РЕЗУЛЬТАТОВ) (нельзя менять состояние самого объекта)!!!
        {
            double newFuelFlow = c.FuelFlow + 0.1;
            double newFuelVolume = c.FuelVolume;
            return new Car(newFuelFlow, newFuelVolume);
        }
        public static Car operator --(Car c) // уменьшение топлива в баке автомобиля на 1 л
        {
            double newFuelFlow = c.FuelFlow;
            double newFuelVolume = c.FuelVolume - 1;
            return new Car(newFuelFlow, newFuelVolume);
        }

        // БИНАРНЫЕ ОПЕРАЦИИ
        public static Car operator +(Car c, double fuelVolume) // левосторонняя операция добавления некоторого количества литров топлива в топливный бак автомобиля
        {
            double newFuelFlow = c.FuelFlow;
            double newFuelVolume = c.FuelVolume + fuelVolume;
            return new Car(newFuelFlow, newFuelVolume);
        }
        public static Car operator +(double fuelFlow, Car c) // правосторонняя операция, уменьшается расход топлива на заданное число
        {
            double newFuelFlow = c.FuelFlow - fuelFlow;
            double newFuelVolume = c.FuelVolume;
            return new Car(newFuelFlow, newFuelVolume);
        }
        public static bool operator ==(Car c1, Car c2) // автомобили имеют равные возможности, если равны их атрибуты
        {
            return (c1.FuelFlow == c2.FuelFlow && c1.FuelVolume == c2.FuelVolume);
        }
        public static bool operator !=(Car c1, Car c2) // автомобили не равносильны, если не равны их атрибуты
        {
            return !(c1.FuelFlow == c2.FuelFlow && c1.FuelVolume == c2.FuelVolume);
        }

        // ОПЕРАЦИИ ПРИВЕДЕНИЯ ТИПОВ
        public static explicit operator bool(Car c) // (явная) – результатом является true,
                                                    // если автомобиль сможет доехать до заправки (до заправки ровно 100 км),
                                                    // а в баке в момент заправки останется не меньше 5 л топлива, иначе – false;
        {
            return (c.FuelVolume - c.FuelFlow >= 5);
        }
        public static implicit operator double(Car c) // (неявная) – результатом является количество сотен километров до заправки,
                                                      // чтобы в момент заправки в баке осталось ровно 5 л топлива.
                                                      // Если в момент расчёта в баке меньше 5 л топлива, значит результатом операции будет число -1.

        {
            if (c.FuelVolume >= 5) return ((c + (-5)).FuelVolume / c.FuelFlow);
            else return -1;
        }

        // СТРОКА - ДАННЫЕ ОБЪЕКТА
        public override string ToString() // получение данных, содержащихся в полях объекта, в виде строки
        {
            return ("|" + String.Format("{0,35}", FuelFlow) + "|" + String.Format("{0,37}", FuelVolume) + "|" + String.Format("{0,30}", GetLength()) + "|");
        }

        // Количество созданных объектов
        public static int Count()
        {
            return count1;
        }

        // Equals
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Car) return false;
            return ((Car)obj).FuelFlow == FuelFlow && ((Car)obj).FuelVolume == FuelVolume;
        }
    }
}