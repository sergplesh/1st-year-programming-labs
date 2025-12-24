using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GeometrucShapeCarLibrary;

namespace LINQ_лаб__14
{
    public class Page
    {
        //номер страницы
        private int number;
        //название тетради
        private string name;

        //// массив для рандомного названия тетради
        //static string[] Names = { "Геометрия", "Алгебра", "Математика", "Матанализ", "Линал", "ВышМат", "Траектория", "ЕГЭ", "ОГЭ", "Экзамен", "Контрольная", "Проверочная", "Самостоятельная" };

        // массив для рандомного названия страницы тетради
        static string[] Names = { "Векторы", "Интегралы", "Функции", "ФМП", "Ряды", "Производные", "Первообразные", "КомплексныеЧисла", "Графики", "Пределы", "Дифференциалы", "Системы", "Уравнения" };

        // свойство number
        public int Number { get; set; }

        // свойство для названия страницы тетради
        public string Name
        {
            get { return name; }
            set
            {
                Regex pattern1 = new Regex(@"^[А-Яа-я]{1}[0-9А-Яа-я-]*$"); // название на русском
                Regex pattern2 = new Regex(@"^[A-Za-z]{1}[0-9A-Za-z-]*$"); // название на английском
                bool isMatch1 = pattern1.IsMatch(value);
                bool isMatch2 = pattern2.IsMatch(value);
                if (isMatch1 || isMatch2)
                {
                    name = value;
                }
                else
                {
                    name = "NoName";
                }
            }
        }

        private static Random rand = new Random();

        public Dictionary<int, Shape> ContentPage { get; set; } // Словарь геометрических фигур

        public Page() //Конструктор без параметорв
        {
            Name = Names[rand.Next(Names.Length)];
            ContentPage = new Dictionary<int, Shape>();
            Number = rand.Next(0,10);
        }

        public void Add(Shape shape) //Добавление в страницу тетради уникальных обьектов
        {
            if (!ContentPage.ContainsKey(shape.id.Number))
            {
                ContentPage[shape.id.Number] = shape;
            }
        }

        /// <summary>
        /// Заполнение страницы рандомными фигурами
        /// </summary>
        public void MakePage()
        {
            // фигура Shape
            for (int i = 0; i < 5; i++)
            {
                Shape s = new Shape();
                s.RandomInit();
                Add(s); // добавляем
            }
            // окружности
            for (int i = 5; i < 10; i++)
            {
                Circle c = new Circle();
                c.RandomInit();
                Add(c); // добавляем
            }
            // прямоугольники
            for (int i = 10; i < 15; i++)
            {
                Rectangle r = new Rectangle();
                r.RandomInit();
                Add(r); // добавляем
            }
            // параллелепипеды
            for (int i = 15; i < 20; i++)
            {
                Parallelepiped p = new Parallelepiped();
                p.RandomInit();
                Add(p); // добавляем
            }
        }
    }
}
