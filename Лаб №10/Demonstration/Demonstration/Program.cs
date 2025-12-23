using GeometrucShapeCarLibrary;
using System;
using System.IO.Compression;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demonstration
{
    public class Program
    {
        // метод для первого запроса: вывод площади всех квадратов
        // (использован typeof, as)
        public static double[] Square(Shape[] array)
        {
            int count = 0; // считаем нужные значения
            double[] temp = new double[array.Length];
            foreach (Shape shape in array)
            {
                if (typeof(Rectangle) == shape.GetType()) // рассматриваем только прямоугольники (квадрат - частный случай прямоугольника)
                {
                    Rectangle? square = shape as Rectangle;
                    if (square != null)
                    {
                        if (square.Length == square.Width)
                        {
                            temp[count] = square.GetArea();
                            count++;
                        }
                    }
                }
            }
            // переписываем найденные значения
            double[] newArray = new double[count];
            for (int i = 0; i < newArray.Length; i++)
                newArray[i] = temp[i];
            return newArray;
        }

        // метод для второго запроса: Информация обо всех фигурах с площадью не меньше заданной
        // (использован is)
        public static Shape[] GetShapeArea(Shape[] array, double area)
        {
            int count = 0; // считаем нужные значения
            Shape[] temp = new Shape[array.Length];
            foreach (Shape shape in array)
            {
                if (shape is not Parallelepiped) // площадь параллелепипеда вычислять не будем, так как это объёмная фигура
                {
                    if (shape.GetArea() >= area) // площадь не меньше заданной
                    {
                        temp[count] = shape;
                        count++;
                    }
                }
            }
            // переписываем найденные значения
            Shape[] newArray = new Shape[count];
            for (int i = 0; i < newArray.Length; i++) 
                newArray[i] = temp[i];
            return newArray;
        }

        // метод для третьего запроса: Информация обо всех фигурах с радиусом описанной окружности, равной заданной
        // (использован typeof, as)
        public static Shape[] Radius(Shape[] array, double radius)
        {
            int count = 0; // считаем нужные значения
            Shape[] temp = new Shape[array.Length];
            foreach (Shape shape in array)
            {
                if (typeof(Rectangle) == shape.GetType()) // мы рассматриваем только прямоугольники, так как только около него можно описать окружность
                {
                    Rectangle? square = shape as Rectangle;
                    // радиус описанной около прямоугольника окружности равен половине его диагонали - найдём его:
                    double radiusRectangle = 0.5 * Math.Sqrt(Math.Pow(square.Width, 2) + Math.Pow(square.Length, 2));
                    if (radiusRectangle == radius)
                    {
                        temp[count] = shape;
                        count++;
                    }
                }
            }
            // переписываем найденные значения
            Shape[] newArray = new Shape[count];
            for (int i = 0; i < newArray.Length; i++)
                newArray[i] = temp[i];
            return newArray;
        }

        static void Main(string[] args)
        {
            // 1 ЧАСТЬ
            // --------------------------------------------------------------------------------------------------------
            //  Генерация массива из 20 элементов разных классов из иерархии
            // --------------------------------------------------------------------------------------------------------
            Console.WriteLine("МАССИВ ТИПА Shape (базовый) С 20 ОБЪЕКТАМИ РАЗНЫХ КЛАССОВ ИЕРАРХИИ");
            Shape[] array1 = new Shape[20];
            // финура Shape
            for (int i = 0; i < 5; i++)
            {
                Shape s = new Shape();
                s.RandomInit();
                array1[i] = s;
            }
            // окружности
            for (int i = 5; i < 10; i++)
            {
                Circle c = new Circle();
                c.RandomInit();
                array1[i] = c;
            }
            // прямоугольники
            for (int i = 10; i < 13; i++)
            {
                Rectangle r = new Rectangle();
                r.RandomInit();
                array1[i] = r;
            }
            // для первого запроса: создадим квадрат, площадь которого программа должна будет вывести
            for (int i = 13; i < 14; i++) 
            {
                Rectangle r = new Rectangle("ABCD", 43, 40, 40);
                array1[i] = r;
            }
            // для третьего запроса: создадим прямоугольник, радиус которого программа должна будет вывести (радиус будет равен 50)
            for (int i = 14; i < 15; i++) 
            {
                Rectangle r = new Rectangle("EHLP", 34, 60, 80);
                array1[i] = r;
            }
            // параллелепипеды
            for (int i = 15; i < 20; i++)
            {
                Parallelepiped p = new Parallelepiped();
                p.RandomInit();
                array1[i] = p;
            }

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  Просмотр элементов массива с помощью обычных функций
            // --------------------------------------------------------------------------------------------------------

            // так как массив типа Shape, а виртуальные функции не используются -
            // то и выводятся только те данные, которые есть в данном базовом классе Shape
            Console.WriteLine("Просмотр элементов массива обычным (не virtual) методом:");
            foreach (Shape item in array1)
            {
                item.Show();
                Console.WriteLine();
            }

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  Просмотр элементов массива с помощью виртуальных функций
            // --------------------------------------------------------------------------------------------------------

            // благодаря virtual выводятся данные в соответствии с типом элемента(не только Shape, а каждый класс иерархии отдельно)
            // это выполняется благодаря ссылкам на конкретную таблицу виртуальных методов, прикреплённую к конкретному классу иерархии
            Console.WriteLine("Просмотр элементов массива с использованием virtual методов:");
            foreach (Shape item in array1)
            {
                item.ShowVirtual();
                Console.WriteLine();
            }

            Console.WriteLine();

            // 2 ЧАСТЬ
            // --------------------------------------------------------------------------------------------------------
            //  ЗАПРОСЫ
            // --------------------------------------------------------------------------------------------------------
            Console.WriteLine("ЗАПРОСЫ:");

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  1. Вывести площади всех квадратов
            // --------------------------------------------------------------------------------------------------------
            Console.WriteLine("Первый запрос");
            Console.WriteLine("Площади всех квадратов:");
            double[] request1 = Square(array1);
            if (request1.Length != 0) 
            {
                foreach (double item in request1)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("По запросу ничего не найдено");

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  2. Информация обо всех фигурах с площадью не меньше заданной
            // --------------------------------------------------------------------------------------------------------
            Console.WriteLine("Второй запрос");
            Console.WriteLine("Фигуры с площадью не меньше заданной (площадь >= 300):");
            Shape[] request2 = GetShapeArea(array1, 300);
            if (request2.Length != 0)
            {
                foreach (Shape item in request2)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("По запросу ничего не найдено");

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  3. Информация обо всех фигурах с радиусом описанной окружности, равной заданной
            // --------------------------------------------------------------------------------------------------------
            Console.WriteLine("Третий запрос");
            Console.WriteLine("Фигуры с радиусом описанной окружности, равным заданному (радиус = 50):");
            Shape[] request3 = Radius(array1, 50);
            if (request3.Length != 0)
            {
                foreach (Shape item in request3)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("По запросу ничего не найдено");

            Console.WriteLine();

            // 3 ЧАСТЬ
            // --------------------------------------------------------------------------------------------------------
            //  Работа интерфейса IInit
            // --------------------------------------------------------------------------------------------------------
            int countCar = 0, countShape = 0, countCircle = 0, countRectangle = 0, countParallelepiped = 0;
            Console.WriteLine("ИНТЕРФЕЙС IInit");
            IInit[] array2 = new IInit[20];
            // автомобили
            for (int i = 0; i < 4; i++)
            {
                Car c = new Car();
                c.RandomInit();
                array2[i] = c;
                countCar++;
            }
            // фигура Shape
            for (int i = 4; i < 8; i++)
            {
                Shape s = new Shape();
                s.RandomInit();
                array2[i] = s;
                countShape++;
            }
            // окружности
            for (int i = 8; i < 12; i++)
            {
                Circle c = new Circle();
                c.RandomInit();
                array2[i] = c;
                countCircle++;
            }
            // прямоугольники
            for (int i = 12; i < 16; i++)
            {
                Rectangle r = new Rectangle();
                r.RandomInit();
                array2[i] = r;
                countRectangle++;
            }
            // параллелепипеды
            for (int i = 16; i < 20; i++)
            {
                Parallelepiped p = new Parallelepiped();
                p.RandomInit();
                array2[i] = p;
                countParallelepiped++;
            }

            Console.WriteLine();

            Console.WriteLine("Просмотр объектов классов из разных иерархий:");
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Объектов Car: {countCar} штук");
            Console.WriteLine($"Объектов Shape: {countShape} штук");
            Console.WriteLine($"Объектов Circle: {countCircle} штук");
            Console.WriteLine($"Объектов Rectangle: {countRectangle} штук");
            Console.WriteLine($"Объектов Parallelepiped: {countParallelepiped} штук");

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  Работа интерфейса IComparable, ICompare
            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("ДЛЯ РАБОТЫ С ИНТЕРФЕЙСАМИ IComparable, ICompare ИСПОЛЬЗУЕМ ПЕРВЫЙ МАССИВ С КЛАССАМИ ИЕРАРХИИ Shape");

            Console.WriteLine();

            // для бинарного поиска введён элементы которые будем искать:
            Shape shape = new Shape("Цилиндр", 68);
            array1[5] = shape;
            Rectangle rectangle = new Rectangle("EHLP", 56, 345, 124);
            array1[10] = rectangle;

            // IComparable
            Array.Sort(array1);
            Console.WriteLine("Массив  отсортирован по названию фигуры:");
            foreach (var item in array1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // бинарный поиск
            int pos1 = Array.BinarySearch(array1, new Shape("Цилиндр", 87)); // без разницы какое значение будет у id, так как сравнение всё равно будет осуществляться по названию (в 10 лабораторной CompareTo сравнивал только по названию, сейчас не работает потому что теперь CompareTo сравнивает также id)
            Console.WriteLine($"Бинарный поиск: Цилиндр находится на позиции {pos1 + 1}");

            Console.WriteLine();

            // IComparer
            Array.Sort(array1, new LengthComparer());
            Console.WriteLine("Массив  отсортирован по длине:");
            foreach (var item in array1)
            {
                Console.WriteLine(item);
            }

            // бинарный поиск
            int pos2 = Array.BinarySearch(array1, new Rectangle("просто", 94, 345, 124), new LengthComparer()); // название, id и ширину можем написать любыми, так как сравнение будет осуществляться по длине
            Console.WriteLine($"Бинарный поиск: прямоугольник с длиной 345 находится на позиции {pos2 + 1}");

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  Работа интерфейса IClonable
            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("Работа интерфейса IClonable");

            Console.WriteLine();

            Console.WriteLine("Создадим объект, его копию и клона:");
            Circle circle = new Circle();
            circle.RandomInit();
            Console.WriteLine(circle + " - ОБЪЕКТ");
            Circle copy = (Circle)circle.ShallowCopy();
            Console.WriteLine(copy + " - КОПИЯ");
            Circle clon = (Circle)circle.Clone();
            Console.WriteLine(clon + " - КЛОН");

            Console.WriteLine();

            Console.WriteLine("Изменим копию (присвоим id = 777) и клона (присвоим id = 999)");
            copy.Name = "copy-" + circle.Name.ToLower();
            copy.id.Number = 777;
            clon.Name = "clon-" + circle.Name.ToLower();
            clon.id.Number = 999;
            Console.WriteLine(circle);
            Console.WriteLine(copy);
            Console.WriteLine(clon);
        }
    }
}