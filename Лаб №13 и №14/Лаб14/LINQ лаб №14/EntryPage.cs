using GeometrucShapeCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_лаб__14
{
    public class EntryPage
    {
        private static Random rand = new Random();

        //номер страницы, где расположена запись
        private int number;
        //запись
        private string entry;

        // массив для рандомного названия тетради
        static string[] Entries = { "Геометрия - это наука о геометрических фигурах",
            "Треугольник - это трёхугольная фигура",
            "Математика - матерь всех наук",
            "В первом полугодии - Линал, во втором - Матанализ",
            "ДЗ: прорешать задания в Траектории",
            "ЕГЭ - важный экзамен, надо постараться его сдать",
            "ОГЭ - экзамен для перехода в 10-11 классы",
            "Экзамен по матанализу пройдёт в этот четверг",
            "Контрольная будет на тему <Интегралы>",
            "Самостоятельная весит большую часть от общей оценки" };

        // свойство number
        public int Number { get; set; }

        // свойство для записи
        public string Entry
        {
            get { return entry; }
            set
            {
                Regex pattern1 = new Regex(@"^[А-Яа-я]{1}[0-9А-Яа-я-\s]*$"); // на русском
                Regex pattern2 = new Regex(@"^[A-Za-z]{1}[0-9A-Za-z-\s]*$"); // на английском
                bool isMatch1 = pattern1.IsMatch(value);
                bool isMatch2 = pattern2.IsMatch(value);
                if (isMatch1 || isMatch2)
                {
                    entry = value;
                }
                else
                {
                    entry = "NoName";
                }
            }
        }

        public EntryPage() //Конструктор без параметорв
        {
            Entry = Entries[rand.Next(Entries.Length)];
            Number = rand.Next(0, 10);
        }
    }
}
