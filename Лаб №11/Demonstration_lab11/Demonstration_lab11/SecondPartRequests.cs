using GeometrucShapeCarLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demonstration_lab11
{
    public class SecondPartRequests
    {
        // метод для первого запроса: вывод площади всех квадратов
        // (использован typeof, as)
        public static double[] Square<K, T>(SortedDictionary<K, T> sortDict)
        {
            int count = 0; // считаем нужные значения
            double[] temp = new double[sortDict.Count];
            foreach (K item in sortDict.Keys)
            {
                if (typeof(Rectangle) == sortDict[item].GetType()) // рассматриваем только прямоугольники (квадрат - частный случай прямоугольника)
                {
                    Rectangle? square = sortDict[item] as Rectangle;
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
        public static Shape[] GetShapeArea<K, T>(SortedDictionary<K, T> sortDict, double area)
        {
            int count = 0; // считаем нужные значения
            Shape[] temp = new Shape[sortDict.Count];
            foreach (K item in sortDict.Keys)
            {
                if (sortDict[item] is not Parallelepiped) // площадь параллелепипеда вычислять не будем, так как это объёмная фигура
                {
                    Rectangle? shapeRectangle = sortDict[item] as Rectangle; // если прямоугольник
                    if (shapeRectangle != null)
                    {
                        if (shapeRectangle.GetArea() >= area) // площадь не меньше заданной
                        {
                            temp[count] = shapeRectangle;
                            count++;
                        }
                    }
                    else
                    {
                        Circle? shapeCircle = sortDict[item] as Circle; // если окружность
                        if (shapeCircle != null)
                        {
                            if (shapeCircle.GetArea() >= area) // площадь не меньше заданной
                            {
                                temp[count] = shapeCircle;
                                count++;
                            }
                        }
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
        public static Shape[] Radius<K, T>(SortedDictionary<K, T> sortDict, double radius)
        {
            int count = 0; // считаем нужные значения
            Shape[] temp = new Shape[sortDict.Count];
            foreach (K item in sortDict.Keys)
            {
                if (typeof(Rectangle) == sortDict[item].GetType()) // мы рассматриваем только прямоугольники, так как только около него можно описать окружность
                {
                    Rectangle? square = sortDict[item] as Rectangle;
                    // радиус описанной около прямоугольника окружности равен половине его диагонали - найдём его:
                    double radiusRectangle = 0.5 * Math.Sqrt(Math.Pow(square.Width, 2) + Math.Pow(square.Length, 2));
                    if (radiusRectangle == radius)
                    {
                        temp[count] = square;
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
    }
}
