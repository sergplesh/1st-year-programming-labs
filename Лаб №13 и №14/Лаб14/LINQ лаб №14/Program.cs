using GeometrucShapeCarLibrary;
using System.Numerics;

namespace LINQ_лаб__14
{
    public class Program
    {
        static void Main(string[] args)
        {
            int answer;
            do
            {
                Console.WriteLine("1. Часть 1");
                Console.WriteLine("2. Часть 2");
                Console.WriteLine("3. Закончить программу");
                answer = EnterNumber.EnterIntNumber("Выберите часть", 0);
                switch (answer)
                {
                    case 1: // Часть 1
                        {
                            Stack<Page> copybook = new Stack<Page>(); // Создание коллекции
                            for (int i = 0; i < 3; i++)
                            {
                                Page page = new Page();
                                page.MakePage();
                                copybook.Push(page);
                            }
                            Console.WriteLine("\nКоллекция сформирована");
                            int answer1;
                            do
                            {
                                Console.WriteLine("\n1. Печать геометрических фигур в коллекциях");
                                Console.WriteLine("2. Max и Min длины среди прямоугольников");
                                Console.WriteLine("3. Пересечение первой и последней страниц");
                                Console.WriteLine("4. Группировка данных");
                                Console.WriteLine("5. Получение нового типа - обьем, вычисление среднего значения объёма");
                                Console.WriteLine("6. Соединение (Join)");
                                Console.WriteLine("7. Выборка");
                                Console.WriteLine("0. Назад");
                                answer1 = EnterNumber.EnterIntNumber("Выберите номер задания", 0);

                                switch (answer1)
                                {
                                    case 1: // печать коллекции
                                        {
                                            foreach (var page in copybook)
                                            {
                                                foreach (var shape in page.ContentPage.Values)
                                                {
                                                    Console.WriteLine(shape);
                                                }
                                            }

                                            break;
                                        }
                                    case 2: // Max/Min длина
                                        {
                                            Console.WriteLine("==========================================< MAX И MIN ДЛИНЫ >==========================================");

                                            // LINQ
                                            try
                                            {
                                                double MaxLength = Query.MaxLength(copybook);
                                                Console.WriteLine($"\nМаксимальная длина прямоугольника: {MaxLength} (LINQ)");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }

                                            // Методы расширения
                                            try
                                            {
                                                double MinLength = Query.MinLength(copybook);
                                                Console.WriteLine($"\nМинимальная температура звезды: {MinLength} (Методы расширения)");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            break;
                                        }
                                    case 3: //Пересечение страниц
                                        {
                                            Console.WriteLine("==========================================< ПЕРЕСЕЧЕНИЕ >==========================================");

                                            var page1 = copybook.First(); //Первый элемент стека
                                            var page2 = copybook.Last(); //Последний элемент стека
                                            Shape shape = new Shape("Общий", 1); //Общий элемент
                                            page1.Add(shape); //Добавление одинаковых элементов на страницу
                                            page2.Add(shape);

                                            Console.WriteLine("\nLINQ:");
                                            var intersect1 = Query.IntersectLINQ(page1, page2); //Пересечение двух страниц, LINQ
                                            Console.WriteLine("Пересечение двух страниц");
                                            foreach (var item in intersect1)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            var intersect2 = Query.Intersect(page1, page2); //Пересечение двух страниц
                                            Console.WriteLine("Пересечение двух страниц");
                                            foreach (var item in intersect2)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            break;
                                        }
                                    case 4: //Группировка
                                        {
                                            Console.WriteLine("\nLINQ:");
                                            var group1 = Query.GroupByRadius(copybook); //Группировка по радиусу, LINQ
                                            Console.WriteLine("Группировка данных по радиусу:");
                                            foreach (var group in group1)
                                            {
                                                Console.WriteLine(group.Key + $" - {group.Count()}"); //Печать ключа группировки и количества в группе
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            var group2 = Query.GroupByType(copybook); //Группировка данных по типу
                                            Console.WriteLine("Группировка данных по типу:");
                                            foreach (var group in group2)
                                            {
                                                Console.WriteLine(group.Key + $" - {group.Count()}"); //Печать ключа группировки и количества в группе
                                            }

                                            break;
                                        }
                                    case 5: //Новый тип данных
                                        {
                                            Console.WriteLine("\nLINQ:");
                                            var Volumes = Query.VolumeLINQ(copybook);
                                            foreach (var item in Volumes) //Печать обьема
                                            {
                                                Console.WriteLine($"{item.Name}, Объем: {item.volume}");
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            try
                                            {
                                                double averageVolume = Query.AverageVolume(copybook);
                                                Console.WriteLine($"Средний объём: {averageVolume}");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            break;
                                        }
                                    case 6:  //Соединение
                                        {
                                            List<EntryPage> entryPage = new List<EntryPage>(); //Лист для соединения 
                                            foreach (var page in copybook)
                                            {
                                                EntryPage entry = new EntryPage();
                                                entry.Number = page.Number; //Установка имени для соединения
                                                entryPage.Add(entry);
                                            }
                                            var joinInf = Query.JoinPageEntry(copybook, entryPage);

                                            Console.WriteLine("\nОбьединенная по номеру страницы информация");
                                            foreach (var item in joinInf)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            break;
                                        }
                                    case 7:  //Выборка
                                        {
                                            Console.WriteLine("\nLINQ:");
                                            var countCircle = Query.WhereRectangleLINQ(copybook);
                                            Console.WriteLine("Прямоугольники (LINQ)");
                                            foreach (var item in countCircle)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            var countParallelepiped = Query.WhereRectangle(copybook);
                                            Console.WriteLine("Прямоугольники (Методы расширения)");
                                            foreach (var item in countParallelepiped)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            break;
                                        }
                                }
                            } while (answer1 != 0);

                            break;
                        }
                    case 2: // Часть 2
                        {
                            MyCollection<Shape> collection = new MyCollection<Shape>(15);
                            // фигура Shape
                            for (int i = 0; i < 5; i++)
                            {
                                Shape s = new Shape();
                                s.RandomInit();
                                collection.Add(s); // добавляем
                            }
                            // окружности
                            for (int i = 5; i < 10; i++)
                            {
                                Circle c = new Circle();
                                c.RandomInit();
                                collection.Add(c); // добавляем
                            }
                            // прямоугольники
                            for (int i = 10; i < 15; i++)
                            {
                                Rectangle r = new Rectangle();
                                r.RandomInit();
                                collection.Add(r); // добавляем
                            }
                            // параллелепипеды
                            for (int i = 15; i < 20; i++)
                            {
                                Parallelepiped p = new Parallelepiped();
                                p.RandomInit();
                                collection.Add(p); // добавляем
                            }
                            Console.WriteLine("\nКоллекция сформирована");
                            int answer2;
                            do
                            {
                                Console.WriteLine("\n1. Печать геометрических фигур в коллекции");
                                Console.WriteLine("2. Выборка кругов и параллелепипедов");
                                Console.WriteLine("3. Средняя высота параллелепипеда");
                                Console.WriteLine("4. Группировка данных ");
                                Console.WriteLine("0. Назад");
                                answer2 = EnterNumber.EnterIntNumber("Выберите номер задания", 0);
                                switch (answer2)
                                {
                                    case 1: //Печать коллекции
                                        {
                                            foreach (var item in collection)
                                            {
                                                Console.WriteLine(item);
                                            }
                                            break;
                                        }
                                    case 2:  // Количество кругов и параллелепипедов
                                        {
                                            Console.WriteLine("\nLINQ:");
                                            var countCircle = Query.WhereCircle(collection);
                                            Console.WriteLine("Круги");
                                            foreach (var item in countCircle)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            var countParallelepiped = Query.WhereParallelepiped(collection);
                                            Console.WriteLine("Параллелепипеды");
                                            foreach (var item in countParallelepiped)
                                            {
                                                Console.WriteLine(item);
                                            }

                                            break;
                                        }
                                    case 3: // Количество кругов и сумма их радиусов
                                        {
                                            Console.WriteLine("\nLINQ:");
                                            try
                                            {
                                                double averageHeigth = Query.AverageHeigthParallelepiped(collection);
                                                Console.WriteLine($"Средняя высота параллелепипедов: {averageHeigth}");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            try
                                            {
                                                double sumRadius = Query.SumCircleRadius(collection);
                                                Console.WriteLine($"Сумма радиусов кругов: {sumRadius}");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }

                                            break;
                                        }
                                    case 4:  //Группировка данных по названию
                                        {
                                            Console.WriteLine("\nLINQ:");
                                            var group1 = Query.GroupByNameLINQ(collection);
                                            Console.WriteLine("Группировка фигур по названию (по убыванию):");
                                            foreach (var group in group1)
                                            {
                                                Console.WriteLine(group.Key + $" - {group.Count()}"); //Печать ключа группировки и количества в группе
                                            }

                                            Console.WriteLine("\nМетоды расширения:");
                                            var group2 = Query.GroupByName(collection);
                                            Console.WriteLine("Группировка фигур по названию (по возрастанию):");
                                            foreach (var group in group2)
                                            {
                                                Console.WriteLine(group.Key + $" - {group.Count()}"); //Печать ключа группировки и количества в группе
                                            }
                                            break;
                                        }
                                }
                            } while (answer2 != 0);
                            break;
                        }
                }
            } while (answer != 0);
        }
    }
}
