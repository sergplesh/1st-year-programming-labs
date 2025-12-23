using GeometrucShapeCarLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demonstration_lab11
{
    public class Requests
    {
        public static void ShowSquare(double[] arr)
        {
            Console.WriteLine("Первый запрос");
            Console.WriteLine("Площади всех квадратов:");
            if (arr.Length != 0)
            {
                foreach (double item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("По запросу ничего не найдено");
        }
        public static void ShowGetShapeArea(Shape[] arr)
        {
            Console.WriteLine("Второй запрос");
            Console.WriteLine("Фигуры с площадью >= 300:");
            if (arr.Length != 0)
            {
                foreach (Shape item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("По запросу ничего не найдено");
        }
        public static void ShowRadius(Shape[] arr)
        {
            Console.WriteLine("Третий запрос");
            Console.WriteLine("Фигуры с радиусом описанной окружности, равным  50:");
            if (arr.Length != 0)
            {
                foreach (Shape item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("По запросу ничего не найдено");
        }
    }
}
