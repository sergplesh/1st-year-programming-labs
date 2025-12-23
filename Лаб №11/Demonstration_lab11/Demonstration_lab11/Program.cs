using GeometrucShapeCarLibrary;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace Demonstration_lab11
{
    internal class Program
    {
        // сортировка стека
        public static Stack SortStack(Stack stack)
        {
            object[] tempArrSortStackFirst = stack.ToArray(); // Возвращает массив, который содержит копии элементов вызывающего стека
            Shape[] tempArrSortStackSecond = new Shape[tempArrSortStackFirst.Length]; // в этом массиве будут находиться фигуры из иерархии Shape, перенесём в него все элементы и испльзуем Sort (сортировка по названию)
            for (int i = 0; i < tempArrSortStackFirst.Length; i++)
            {
                Shape? element = tempArrSortStackFirst[i] as Shape;
                if (element != null) tempArrSortStackSecond[i] = element;
            }
            Array.Sort(tempArrSortStackSecond); // Массив  отсортирован по названию фигуры
            Stack newStack = new Stack();
            for (int i = tempArrSortStackSecond.Length - 1; i >= 0; i--) // идём от последнего элемента массива к первому, чтобы заполнить стек в порядке возрастания
            {
                newStack.Push((Shape)tempArrSortStackSecond[i].Clone());
            }
            return newStack;
        }
        // выбор фигуры для добавления/удаления/поиска
        public static void MenuChoise(Shape obj)
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
        public static void MenuRequests(double[] arr1, Shape[] arr2, Shape[] arr3)
        {
            int answer;
            do
            {
                Console.WriteLine("1.Вывести площади всех квадратов");
                Console.WriteLine("2.Получить информацию обо всех фигурах с площадью не меньше 300");
                Console.WriteLine("3.Получить информацию обо всех фигурах с радиусом описанной окружности, равной 50");
                Console.WriteLine("0.Закрыть запросы");
                Console.WriteLine("Выберите пункт меню");
                answer = EnterNumber.EnterIntNumber(); // выбираем действие
                switch (answer)
                {
                    case 1: // первый запрос
                        {
                            Requests.ShowSquare(arr1);
                            break;
                        }
                    case 2: // второй запрос
                        {
                            Requests.ShowGetShapeArea(arr2);
                            break;
                        }
                    case 3: // третий запрос
                        {
                            Requests.ShowRadius(arr3);
                            break;
                        }
                    case 0: // программа продолжит работу
                        {
                            Console.WriteLine("Запросы закрыты");
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
            //// убеждаюсь, что хэш код при каждом запуске программы - разный
            //Shape n = new Shape();
            //Console.WriteLine(n.GetHashCode());
            //Console.WriteLine(n.GetHashCode());
            //Console.WriteLine(n.GetHashCode());
            //n.Name = "аваьв";
            //Console.WriteLine(n.GetHashCode());
            //Console.WriteLine(n.GetHashCode());
            //n.Name = "NoName";
            //Console.WriteLine(n.GetHashCode());
            //Console.WriteLine(n.GetHashCode());
            //n.id.Number = 2;
            //Console.WriteLine(n.GetHashCode());
            //Console.WriteLine(n.GetHashCode());
            //n.id.Number = 0;
            //Console.WriteLine(n.GetHashCode());
            //Console.WriteLine(n.GetHashCode());


            // --------------------------------------------------------------------------------------------------------
            //  Stack
            // --------------------------------------------------------------------------------------------------------
            //1.Создать универсальную коллекцию, добавить в нее объекты из созданной иерархии классов(см.лаб.раб. 10).
            //2.Реализовать в программе добавление и удаление объектов коллекции.
            //3.Разработать и реализовать три запроса(количество элементов определенного вида, печать элементов определенного вида и т.п.), можно взять запросы из лаб.раб. 10.
            //4.Выполнить перебор элементов коллекции с помощью метода foreach.
            //5.Выполнить клонирование коллекции.
            //6.Выполнить сортировку коллекции(если коллекция не отсортирована) и поиск заданного элемента в коллекции.
            Console.WriteLine("===============================================< STACK >===============================================");
            Console.WriteLine("СТЕК С 10 ОБЪЕКТАМИ РАЗНЫХ КЛАССОВ ИЕРАРХИИ:");
            Stack stack = new Stack();
            Rectangle r1 = new Rectangle("EHLP", 34, 60, 80); // для третьего запроса: создадим прямоугольник, радиус которого программа должна будет вывести (радиус будет равен 50)
            Rectangle r2 = new Rectangle("ABCD", 43, 40, 40); // для первого запроса: создадим квадрат, площадь которого программа должна будет вывести
            stack.Push(r1);
            stack.Push(r2);
            // финура Shape
            for (int i = 0; i < 2; i++)
            {
                Shape s = new Shape();
                s.RandomInit();
                stack.Push(s);
            }
            // окружности
            for (int i = 2; i < 4; i++)
            {
                Circle c = new Circle();
                c.RandomInit();
                stack.Push(c);
            }
            // прямоугольники
            for (int i = 4; i < 6; i++)
            {
                Rectangle r = new Rectangle();
                r.RandomInit();
                stack.Push(r);
            }
            // параллелепипеды
            for (int i = 6; i < 8; i++)
            {
                Parallelepiped p = new Parallelepiped();
                p.RandomInit();
                stack.Push(p);
            }

            // перебор и вывод элементов полученного через foreach
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("===============================================< ДОБАВЛЕНИЕ >===============================================");
            // добавление
            Shape addedStack = new Shape();
            Console.WriteLine("Введите элемент, который хотите добавить в стек");
            addedStack.Init(); // задаем параметры для элемента, который хотим добавить
            stack.Push(addedStack); // добавляем в стек
            // перебор и вывод элементов полученного через foreach
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"В стек добавлен элемент {addedStack}");

            Console.WriteLine();

            //удаление
            Console.WriteLine("===============================================< УДАЛЕНИЕ >===============================================");
            Shape deletedStack = new Shape();
            // выбираем фигуру для удаления
            MenuChoise(deletedStack);
            Console.WriteLine("Введите элемент, который хотите удалить из стека");
            deletedStack.Init(); // задаем параметры для элемента, который хотим удалить
            Stack temp = new Stack(); // вспомогательный стек
            // переписываем все объекты, кроме удаляемого, из исходного стека в вспомогательный
            while (stack.Count != 0)
            {
                object shape = stack.Pop(); // Pop - возвращает элемент на "верхушке" стека и сразу удаляет его оттуда
                if (!deletedStack.Equals(shape)) temp.Push(shape); // если это не удаляемый элемент - пепреписываем
            }
            // перемещаем объекты обратно в исходный стек в том порядке, в каком они были
            while (temp.Count != 0)
            {
                object shape = temp.Pop(); // достаём и удаляем из вспомогательного
                stack.Push(shape); // возвращаем в исходный
            }

            Console.WriteLine();

            Console.WriteLine($"Полученный стек без удалённого элемента ({deletedStack}) :");
            // перебор и вывод элементов полученного через foreach
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.Write($"Удалённый элемент '{deletedStack}' : ");
            if (!stack.Contains(deletedStack))
                Console.WriteLine("Не найден");
            else Console.WriteLine("Найден");

            Console.WriteLine();

            Console.WriteLine("===============================================< ЗАПРОСЫ >===============================================");
            // ЗАПРОСЫ
            MenuRequests(FirstPartRequests.Square(stack), FirstPartRequests.GetShapeArea(stack, 300), FirstPartRequests.Radius(stack, 50));

            Console.WriteLine();

            Console.WriteLine("===============================================< КЛОНИРОВАНИЕ >===============================================");
            object[] tempArrClonStack = stack.ToArray(); // Возвращает массив, который содержит копии элементов вызывающего стека
            Stack cloneStack = new Stack();
            for (int i = tempArrClonStack.Length - 1; i >= 0; i--) // идём от последнего элемента массива к первого, чтобы заполнить стек в том же порядке
            {
                Shape? shape = tempArrClonStack[i] as Shape;
                if (shape != null) cloneStack.Push(shape.Clone());
            }
            Console.WriteLine("Стек склонирован, докажем это изменив название первого элемента стека-клона на 'Бабочка'");
            // докажем клонирование
            Shape? firstElement = cloneStack.Peek() as Shape; // Peek - возвращает элемент с "верхушки" стека, но не удаляет его
            if (firstElement != null) firstElement.Name = "Бабочка";
            // перебор и вывод элементов исходного через foreach
            Console.WriteLine("ИСХОДНЫЙ СТЕК:");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }
            // перебор и вывод элементов полученного клона через foreach
            Console.WriteLine("СКЛОНИРОВАННЫЙ СТЕК:");
            foreach (object item in cloneStack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("===============================================< СОРТИРОВКА >===============================================");
            stack = SortStack(stack);
            // перебор и вывод элементов полученного через foreach
            Console.WriteLine("СОРТИРОВАННЫЙ В ПОРЯДКЕ ВОЗРАСТАНИЯ НАЗВАНИЯ СТЕК:");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("===============================================< ПОИСК >===============================================");
            Shape searchedStack = new Shape();
            // выбираем фигуру для поиска
            MenuChoise(searchedStack);
            Console.WriteLine("Введите элемент, который хотите найти в стеке");
            searchedStack.Init(); // задаем параметры для элемента, который хотим найти
            Console.Write($"Искомый элемент элемент '{searchedStack}' :");
            if (!stack.Contains(searchedStack)) Console.WriteLine("Не найден");
            else
            {
                Console.Write("Найден");
                object[] tempArrSearcStack = stack.ToArray(); // Возвращает массив, который содержит копии элементов вызывающего стека
                for (int i = 0; i < tempArrSearcStack.Length; i++)
                {
                    if (searchedStack.Equals(tempArrSearcStack[i]))
                    {
                        Console.WriteLine($" на позиции {i + 1}");
                        break;
                    }
                }
            }

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  SortedDictionary<K, T>
            // --------------------------------------------------------------------------------------------------------
            //1.Создать обобщенную коллекцию, добавить в нее объекты созданной иерархии классов(см.лаб.раб. 10).
            //2.Реализовать в программе добавление и удаление объектов коллекции.
            //3.Разработать и реализовать три запроса(количество элементов определенного вида, печать элементов определенного вида и т.п.), можно взять запросы из лаб.раб. 10..
            //4.Выполнить перебор элементов коллекции с помощью метода foreach.                                                        
            //5.Выполнить клонирование коллекции.
            //6.Выполнить сортировку коллекции(если коллекция не отсортирована) и поиск заданного элемента в коллекции.
            Console.WriteLine("===============================================< SortedDictionary<K,V> >===============================================");
            Console.WriteLine("СОРТИРОВАННЫЙ СЛОВАРЬ С 12 ПАРАМИ SHAPE(КЛЮЧ)/RECTANGLE(ЗНАЧЕНИЕ)");
            SortedDictionary<Shape, Rectangle> sortDict = new SortedDictionary<Shape, Rectangle>();
            //Rectangle r1 = new Rectangle("EHLP", 34, 60, 80); // для третьего запроса: создадим прямоугольник, радиус которого программа должна будет вывести (радиус будет равен 50)
            //Rectangle r2 = new Rectangle("ABCD", 43, 40, 40); // для первого запроса: создадим квадрат, площадь которого программа должна будет вывести
            sortDict.Add(new Shape(r1.Name, r1.id.Number), r1);
            sortDict.Add(new Shape(r2.Name, r2.id.Number), r2);
            // заполняем
            // так как возможно добавлять фигуры только с уникальными ключами, используем try-catch
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Rectangle r = new Rectangle(); // значение Value
                    r.RandomInit();
                    Shape s = new Shape(r.Name, r.id.Number); // ключ Key
                    sortDict.Add(s, r);
                }
                catch
                {
                    i--;
                }
            }

            // перебор и вывод foreach
            foreach (Shape item in sortDict.Keys)
            {
                Console.WriteLine(sortDict[item]);
            }

            Console.WriteLine();

            Console.WriteLine("===============================================< ДОБАВЛЕНИЕ >===============================================");
            // добавление
            Rectangle addedSortDict = new Rectangle();
            bool isCorrect1;
            do
            {
                Console.WriteLine("Введите прямоугольник, который хотите добавить в сортированный словарь");
                isCorrect1 = true;
                try
                {
                    addedSortDict.Init();
                    Shape key = new Shape(addedSortDict.Name, addedSortDict.id.Number);
                    sortDict.Add(key, addedSortDict);
                }
                catch
                {
                    isCorrect1 = false;
                    Console.WriteLine("Данный объект невозможно добавить, так как его ключ не будет уникален. Попробуйте ввести другой прямоугольник");
                }
            } while (!isCorrect1);

            // перебор и вывод foreach
            foreach (Shape item in sortDict.Keys)
            {
                Console.WriteLine(sortDict[item]);
            }
            Console.WriteLine($"В сортированный словарь добавлен элемент {addedSortDict}");

            Console.WriteLine();

            //удаление
            Console.WriteLine("===============================================< УДАЛЕНИЕ >===============================================");
            Rectangle deletedSortDict = new Rectangle();
            bool isCorrect2;
            do
            {
                Console.WriteLine("Введите прямоугольник, который хотите удалить из сортированного словаря");
                isCorrect2 = true;
                deletedSortDict.Init();
                Shape key = new Shape(deletedSortDict.Name, deletedSortDict.id.Number);
                isCorrect2 = sortDict.Remove(key);
                if (!isCorrect2)
                    Console.WriteLine("Данный объект невозможно удалить, так как его ключ отсутствует в словаре. Попробуйте ввести другой прямоугольник");
            } while (!isCorrect2);

            Console.WriteLine();

            Console.WriteLine($"Полученный сортированный словарь без удалённого элемента ({deletedSortDict}) :");
            // перебор и вывод foreach
            foreach (Shape item in sortDict.Keys)
            {
                Console.WriteLine(sortDict[item]);
            }

            Console.WriteLine();

            Console.Write($"Удалённый элемент '{deletedSortDict}' : ");
            if (!sortDict.ContainsKey(deletedSortDict))
                Console.WriteLine("Не найден");
            else Console.WriteLine("Найден");

            Console.WriteLine();

            Console.WriteLine("===============================================< ЗАПРОСЫ >===============================================");
            // ЗАПРОСЫ
            MenuRequests(SecondPartRequests.Square(sortDict), SecondPartRequests.GetShapeArea(sortDict, 300), SecondPartRequests.Radius(sortDict, 50));

            Console.WriteLine();

            Console.WriteLine("===============================================< КЛОНИРОВАНИЕ >===============================================");
            SortedDictionary<Shape, Rectangle> clonSortDict = new SortedDictionary<Shape, Rectangle>();
            foreach (Shape item in sortDict.Keys)
            {
                //isCorrect1 = true;
                //try
                //{
                Rectangle clonValue = new Rectangle(sortDict[item]);
                Shape clonKey = new Shape(clonValue);
                clonSortDict.Add(clonKey, clonValue);
                //}
                //catch
                //{
                //    isCorrect1 = false;
                //    Console.WriteLine("Данный объект невозможно добавить, так как его ключ не будет уникален. Попробуйте ввести другой прямоугольник");
                //}
            }

            Console.WriteLine("Докажем глубокое клонирование, заменив на бабочку все элементы в склонированном");
            foreach (Shape item in clonSortDict.Keys)
            {
                clonSortDict[item].Name = "Бабочка";
            }

            // перебор и вывод элементов исходного через foreach
            Console.WriteLine("ИСХОДНЫЙ СОРТИРОВАННЫЙ СЛОВАРЬ:");
            foreach (Shape item in sortDict.Keys)
            {
                Console.WriteLine(sortDict[item]);
            }
            // перебор и вывод элементов полученного клона через foreach
            Console.WriteLine("СКЛОНИРОВАННЫЙ СОРТИРОВАННЫЙ СЛОВАРЬ:");
            foreach (Shape item in clonSortDict.Keys)
            {
                Console.WriteLine(clonSortDict[item]);
            }

            Console.WriteLine();

            Console.WriteLine("===============================================< СОРТИРОВКА >===============================================");
            Console.WriteLine("Сортированный словарь уже отсортирован по ключу(по названию прямоугольника)");

            Console.WriteLine();

            Console.WriteLine("===============================================< ПОИСК (по ключу) >===============================================");
            Shape searchedSortDict = new Shape();
            Console.WriteLine("Введите ключ элемента (название фигуры и id), который хотите найти в стеке");
            searchedSortDict.Init(); // задаем параметры для ключа элемента, который хотим найти
            Console.Write($"Ключ искомого элемент '{searchedSortDict}' :");
            if (!sortDict.ContainsKey(searchedSortDict)) Console.WriteLine("Не найден");
            else
            {
                Console.Write("Найден");
                int pos = 0; // найдем позицию найденного элемента
                foreach (Shape item in sortDict.Keys)
                {
                    pos++;
                    if (searchedSortDict.Equals(sortDict[item]))
                    {
                        Console.WriteLine($" на позиции {pos}");
                        break;
                    }
                }
            }

            Console.WriteLine();

            // --------------------------------------------------------------------------------------------------------
            //  TestCollections
            // --------------------------------------------------------------------------------------------------------
            Console.WriteLine("===============================================< TestCollections >===============================================");
            Console.WriteLine("TestCollections: КОЛЛЕКЦИИ С 1000 ОБЪЕКТАМИ:");
            // создаём коллекции из 1000 элементов
            TestCollections collections = new TestCollections(1000);

            // искать будет объекты, а не ссылки. Поэтому создаём копии:
            Rectangle first = new Rectangle(collections.First);
            Rectangle middle = new Rectangle(collections.Middle);
            Rectangle last = new Rectangle(collections.Last);
            Rectangle noexist = new Rectangle(collections.Noexist);

            Stopwatch sw = Stopwatch.StartNew();

            //Console.WriteLine(collections.Count);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1} раз:");
                ShowSearch.Search(collections, first, middle, last, noexist);
            }

            //// смотрю, можно ли добавить в SortedSet полностью одинаковые объекты
            //SortedSet<Shape> k = new SortedSet<Shape>();
            //k.Add(new Shape());
            //k.Add(new Shape());
            //Console.WriteLine("проо");
        }
    }
}