using GeometrucShapeCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_лаб__14
{
    public class Query
    {
        // ------------------------------------------------------------------------------------------------------------------------------------
        // 1 ЧАСТЬ
        // ------------------------------------------------------------------------------------------------------------------------------------

        // ВЫБОРКА

        /// <summary>
        /// Выборка прямоугольников (LINQ-запрос)
        /// </summary>
        public static IEnumerable<dynamic> WhereRectangleLINQ(IEnumerable<Page> collection) //LINQ-запрос
        {
            return from shape in collection
                   where shape is Rectangle
                   select shape;
        }

        /// <summary>
        /// Выборка прямоугольников (Методы расширения)
        /// </summary>
        public static IEnumerable<dynamic> WhereRectangle(IEnumerable<Page> collection) //Методы расширения
        {
            return collection.Where(shape => shape is Rectangle)
                .Select(shape => shape);
        }

        // НЕОТЛОЖЕННЫЕ ЗАПРОСЫ АГРЕГАЦИИ

        /// <summary>
        /// Запрос - максимальная длина прямоугольника (LINQ-запрос)
        /// </summary>
        public static double MaxLength(IEnumerable<Page> pages)  //LINQ-запрос, максимальная длина прямоугольника
        {
            return (from page in pages
                    from shape in page.ContentPage.Values
                    where shape is Rectangle
                    select ((Rectangle)shape).Length).Max();
        }

        /// <summary>
        /// Запрос - минимальная ширина прямоугольника (Метод расширения)
        /// </summary>
        public static double MinLength(IEnumerable<Page> pages) //Метод расширения, минимальная ширина прямоугольника
        {
            return pages
                .SelectMany(page => page.ContentPage.Values)
                .Where(shape => shape is Rectangle)
                .Select(rectangle => ((Rectangle)rectangle).Length)
                .Min();
        }

        // ПЕРЕСЕЧЕНИЯ

        /// <summary>
        /// Пересечение двух страниц (LINQ-запрос)
        /// </summary>
        public static IEnumerable<Shape> IntersectLINQ(Page page1, Page page2)  //LINQ-запрос, пересечение двух страниц
        {
            return (from shape in page1.ContentPage.Values select shape).Intersect(from shape in page2.ContentPage.Values select shape);
        }

        /// <summary>
        /// Пересечение двух страниц (Методы расширения)
        /// </summary>
        public static IEnumerable<Shape> Intersect(Page page1, Page page2)  //Методы расширения, пересечение двух страниц
        {
            return page1.ContentPage.Values.Intersect(page2.ContentPage.Values);
        }

        // ГРУППИРОВКА

        /// <summary>
        /// Группировка окружностей по радиусу (LINQ-запрос)
        /// </summary>
        public static IEnumerable<IGrouping<string, Shape>> GroupByRadius(IEnumerable<Page> pages)  //LINQ-запрос, Группировка по радиусу
        {
            return from page in pages
                   from shape in page.ContentPage.Values
                   where shape is Circle
                   orderby ((Circle)shape).Radius
                   group shape by ((Circle)shape).Radius < 200 ? "Радиус меньше 200" :
                       ((Circle)shape).Radius >= 200 && ((Circle)shape).Radius < 500 ? "Радиус от 200 до 500" :
                       ((Circle)shape).Radius >= 500 && ((Circle)shape).Radius < 700 ? "Радиус от 500 до 700" :
                       "Радиус больше 700";
        }

        /// <summary>
        /// Группировка данных по типу (Методы расширения)
        /// </summary>
        public static IEnumerable<IGrouping<string, Shape>> GroupByType(IEnumerable<Page> pages) //Методы расширения, группировка по типу данных
        {
            return pages.SelectMany(page => page.ContentPage.Values)
                .GroupBy(shape => shape.GetType().Name);
        }

        // ПОЛУЧЕНИЕ НОВОГО ТИПА

        /// <summary>
        /// Вычисление обьемов параллелепипедов (LINQ-запрос)
        /// </summary>
        public static IEnumerable<dynamic> VolumeLINQ(IEnumerable<Page> pages)  //LINQ-запрос, Вычисление обьема
        {
            return from page in pages
                   from shape in page.ContentPage.Values
                   where shape is Parallelepiped
                   let volume = ((Parallelepiped)shape).Length * ((Parallelepiped)shape).Width * ((Parallelepiped)shape).Height //Вычисление обьема
                   select new { Name = shape.Name, Volume = volume };
        }

        /// <summary>
        /// Вычисление среднего обьема параллелепипеда (Методы расширения)
        /// </summary>
        public static double AverageVolume(IEnumerable<Page> pages)  //Методы расширения, вычисление обьема
        {
            return pages.SelectMany(page => page.ContentPage.Values)
                .Where(shape => shape is Parallelepiped)
                .Select(shape => ((Parallelepiped)shape).Length * ((Parallelepiped)shape).Width * ((Parallelepiped)shape).Height)
                .Average();
        }

        /// <summary>
        /// Соединение записи со страницей (LINQ-запрос)
        /// </summary>
        public static IEnumerable<dynamic> JoinPageEntry(IEnumerable<Page> pages, IEnumerable<EntryPage> entryPage)  //LINQ-запрос, Вычисление обьема
        {
            return from page in pages
                   join entry in entryPage on page.Number equals entry.Number
                   select new
                   {
                       Name = "На странице " + "<" + page.Name + ">",
                       Number = " под номером " + entry.Number,
                       Entry = " запись: " + "<" + entry.Entry + ">",
                   };
        }






        // ------------------------------------------------------------------------------------------------------------------------------------
        // 2 ЧАСТЬ
        // ------------------------------------------------------------------------------------------------------------------------------------

        // ВЫБОРКА 

        /// <summary>
        /// Выборка кругов (LINQ-запрос)
        /// </summary>
        public static IEnumerable<dynamic> WhereCircle(IEnumerable<Shape> collection) //LINQ-запрос
        {
            return from shape in collection
                   where shape is Circle
                   select shape;
        }

        /// <summary>
        /// Выборка кругов (Методы расширения)
        /// </summary>
        public static IEnumerable<dynamic> WhereParallelepiped(IEnumerable<Shape> collection) //Методы расширения
        {
            return collection.Where(shape => shape is Parallelepiped)
                .Select(shape => shape);
        }

        // АГРЕГИРОВАНИЕ 

        /// <summary>
        /// Средняя высота параллелепипедов (LINQ-запрос)
        /// </summary>
        public static double AverageHeigthParallelepiped(IEnumerable<Shape> collection) // LINQ-запрос
        {
            return (from shape in collection
                    where shape is Parallelepiped
                    select ((Parallelepiped)shape).Height).Average();
        }

        /// <summary>
        /// Сумма радиусов окружностей (Методы расширения)
        /// </summary>
        public static double SumCircleRadius(IEnumerable<Shape> collection) // Методы расширения
        {
            return collection
                .Where(shape => shape is Circle)
                .Select(planet => ((Circle)planet).Radius)
                .Sum();
        }

        // ГРУППИРОВКА

        /// <summary>
        /// Группировка по Name (LINQ-запрос)
        /// </summary>
        public static IEnumerable<IGrouping<string, Shape>> GroupByNameLINQ(IEnumerable<Shape> collection) // LINQ-запрос
        {
            return from shape in collection
                   orderby shape.Name descending
                   group shape by shape.Name;
        }

        /// <summary>
        /// Группировка по Name (Методы расширения)
        /// </summary>
        public static IEnumerable<IGrouping<string, Shape>> GroupByName(IEnumerable<Shape> collection) // Методы расширения
        {
            return collection
                .OrderBy(shape => shape.Name)  //Сортировка по названию
                .GroupBy(shape => shape.Name);
        }
    }
}
