using GeometrucShapeCarLibrary;

namespace лаб_12._1_List
{
    internal class Program
    {
        // выбор фигуры для добавления/удаления/поиска
        public static void MenuChoise(ref Shape obj)
        {
            int answer;
            do
            {
                Console.WriteLine("1.Неопределённую фигуру");
                Console.WriteLine("2.Прямоугольник");
                Console.WriteLine("3.Параллелепипед");
                Console.WriteLine("4.Окружность");
                Console.WriteLine("0.Выбор сделан - закрыть меню");
                Console.WriteLine("Выберите фигуру");
                answer = EnterNumber.EnterIntNumber(); // выбираем действие
                switch (answer)
                {
                    case 1: // первый выбор
                        {
                            obj = new Shape();
                            break;
                        }
                    case 2: // второй выбор
                        {
                            obj = new Rectangle();
                            break;
                        }
                    case 3: // третий выбор
                        {
                            obj = new Parallelepiped();
                            break;
                        }
                    case 4: // третий выбор
                        {
                            obj = new Circle();
                            break;
                        }
                    case 0: // программа продолжит работу
                        {
                            Console.WriteLine("Выбор закрыт");
                            break;
                        }
                    default: // введённое число не подошло ни к одному пункту
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer != 0); // не закрываем запросы, пока не введём 0
        }
        static void Main(string[] args)
        {
            // --------------------------------------------------------------------------------------------------------
            //  MyList
            // --------------------------------------------------------------------------------------------------------
            MyList<Shape> list = new MyList<Shape>();
            int answer;
            do
            {
                Console.WriteLine("1.Сформировать двунаправленный список вручную");
                Console.WriteLine("2.Сформировать рандомный список из 20 объектов иерархии");
                Console.WriteLine("3.Распечатать список");
                Console.WriteLine("4.Добавить в список элемент после первого в списке элемента с заданным названием фигуры");
                Console.WriteLine("5.Удалить из списка все элементы с заданным названием фигуры");
                Console.WriteLine("6.Клонировать список");
                Console.WriteLine("7.Удалить список");
                Console.WriteLine("0.Закончить работу со списком");
                Console.WriteLine("Выберите пункт меню");
                answer = EnterNumber.EnterIntNumber(); // выбираем действие
                switch (answer)
                {
                    case 1: // первый выбор
                        {
                            Console.WriteLine("Введите количество объектов");
                            int count = EnterNumber.EnterIntNumber(); // вводим количество элементов, которыми будем заполнять список
                            while (count < 0)
                            {
                                Console.WriteLine("Количество элементов не может быть отрицательным. Введите количество снова.");
                                count = EnterNumber.EnterIntNumber(); // вводим количество элементов, которыми будем заполнять список
                            }
                            Shape[] array = new Shape[count]; // на основе данного массива затем создадим связанный список
                            Shape added = new Shape();
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine($"Ввод {i + 1} фигуры");
                                // выбираем фигуру для добавления
                                MenuChoise(ref added);
                                Console.WriteLine("Введите данные для объекта:");
                                added.Init(); // задаем параметры для элемента, который хотим удалить
                                array[i] = (Shape)added.Clone();
                            }
                            try
                            {
                                list = new MyList<Shape>(array);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                list = new MyList<Shape>();
                            }
                            Console.WriteLine("Сформированный вами массив:");
                            list.PrintList();
                            break;
                        }
                    case 2: // второй выбор
                        {
                            Shape[] array1 = new Shape[20];
                            // фигура Shape
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
                            list = new MyList<Shape>(array1);
                            Console.WriteLine("Сформированный вами массив:");
                            list.PrintList();
                            break;
                        }
                    case 3: // третий выбор
                        {
                            list.PrintList();
                            break;
                        }
                    case 4: // четвертый выбор
                        {
                            Console.WriteLine("Введите фигуру, которую хотите добавить");
                            Shape added = new Shape();
                            MenuChoise(ref added); // выбираем фигуру для добавления
                            Console.WriteLine("Введите данные для объекта:");
                            added.Init(); // задаем параметры для элемента, который хотим удалить
                            Console.WriteLine("Введите название фигуры, после которой хотите добавить введённую вами фигуру");
                            Shape? addedName = new Shape();
                            MenuChoise(ref addedName); // выбираем фигуру
                            Console.WriteLine("Введите данные для объекта:");
                            addedName.Init(); // задаем параметры для элемента, после которого хотим добавить
                            bool isAdd = list.AddItem(added, addedName);
                            if (isAdd) Console.WriteLine("Элемент добавлен");
                            else Console.WriteLine("Элементов с заданным вами инфополем нет");
                            Console.WriteLine("Полученный список:");
                            list.PrintList();
                            break;
                        }
                    case 5: // пятый выбор
                        {
                            if (list.Count == 0) Console.WriteLine("Лист пуст, для удаления добавьте в него элементы");
                            else
                            {
                                Console.WriteLine("Введите название фигур, которые хотите удалить");
                                Shape? removedName = new Shape(Console.ReadLine(), 0);
                                list.RemoveAllItems(removedName);
                                Console.WriteLine("Удаление завершено");
                                Console.WriteLine("Полученный список:");
                                list.PrintList();
                            }
                            break;
                        }
                    case 6: // шестой выбор
                        {
                            MyList<Shape> cloneList = list.Clone();
                            Console.WriteLine("Оригинал :");
                            list.PrintList();
                            Console.WriteLine("Клон :");
                            cloneList.PrintList();
                            break;
                        }
                    case 7: // седьмой выбор
                        {
                            list.Clear();
                            Console.WriteLine("Удаление списка завершено");
                            break;
                        }
                    case 0: // программа продолжит работу
                        {
                            Console.WriteLine("Выбор закрыт");
                            break;
                        }
                    default: // введённое число не подошло ни к одному пункту
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer != 0); // не закрываем запросы, пока не введём 0
        }
    }
}
