using System;

namespace лаб__1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y; // координаты точки на плоскости
            bool isConvert;
            Console.WriteLine("Введите координату x (вещественное число)");
            do // вводим координату x
            {
                isConvert = double.TryParse(Console.ReadLine(), out x);
                if (isConvert == false)
                    Console.WriteLine("Неверный формат ввода! Необходимо ввести вещественное число. Повторите ввод координаты x.");
            } while (isConvert == false);
            Console.WriteLine("Введите координату y (вещественное число)");
            do // вводим координату y
            {
                isConvert = double.TryParse(Console.ReadLine(), out y);
                if (isConvert == false)
                    Console.WriteLine("Неверный формат ввода! Необходимо ввести вещественное число. Повторите ввод координаты y.");
            } while (isConvert == false);
            bool pointInShape = (-x + 2) >= y && (x + 2) >= y && (x - 2) <= y && (-x - 2) <= y; // проверяем точку на принадлежность заданной плоскости
            bool border = ((-x + 2) == y && x >= 0 && y >= 0) || ((x + 2) == y && x <= 0 && y >= 0) || 
                ((-x - 2) == y && x <= 0 && y <= 0) || ((x - 2) == y && x >= 0 && y <= 0); // определяем, лежит ли точка на границе области
            if (pointInShape)
                if (border) // вывод в том случае, когда точка лежит на границе области
                    Console.WriteLine("Точка с введёнными вами координатами лежит на границе заданной плоскости");
                else // вывод в том случае, когда точка лежит внутри области
                    Console.WriteLine("Точка с введёнными вами координатами лежит внутри заданной плоскости");
            else // вывод в том случае, когда точка не принадлежит области
                Console.WriteLine("Точка с введёнными вами координатами находится вне заданной плоскости");
        }
    }
}