namespace Лаб__9_класс_Car
{
    internal class Program
    {
        // (вспомогательный метод) ввод вещественного числа в указанных пределах
        public static double EnterIntNumber(bool strictMin, string message = "", double minLimit = double.MinValue, string errorMinLimit = "", double maxLimit = double.MaxValue, string errorMaxLimit = "")
        {
            bool isConvert;
            double number; // вводимое число
            while (true)
            {
                try
                {
                    do
                    {
                        isConvert = true;
                        Console.WriteLine(message);
                        number = Convert.ToDouble(Console.ReadLine()); // пытаемся конвертировать введённую строку
                        if (!strictMin)
                        {
                            if (number < minLimit) // выход числа за минимальную указанную границу (строгое неравенство)
                            {
                                Console.WriteLine(errorMinLimit); // сообщение о выходе за min границу
                                isConvert = false;
                            }
                        }
                        else
                        {
                            if (number <= minLimit) // выход числа за минимальную указанную границу (нестрогое неравенство)
                            {
                                Console.WriteLine(errorMinLimit); // сообщение о выходе за min границу
                                isConvert = false;
                            }
                        }
                        if (number > maxLimit) // выход числа за максимальную указанную границу
                        {
                            Console.WriteLine(errorMaxLimit); // сообщение о выходе за max границу
                            isConvert = false;
                        }
                    } while (!isConvert);
                    return number; // возвращаем введённое число
                }
                catch (FormatException) // ловим ввод не того формата
                {
                    Console.WriteLine("Вы ввели не целое число");
                }
                catch (OverflowException) // ловим переполнение памяти
                {
                    Console.WriteLine("Вы ввели слишком маленькое или большое  число");
                }
            }
        }
        // ФУНКЦИЯ ДЛЯ КОЛЛЕКЦИИ (Найти автомобиль с наименьшим запасом хода)
        public static Car MinCar(CarArray carArray)
        {
            Car minCar = new Car(carArray[0]);
            for (int i = 0; i < (carArray.Length - 1); i++)
            {
                if (Car.GetLength(carArray[i]) < Car.GetLength(carArray[i + 1])) minCar = carArray[i];
                else minCar = carArray[i + 1];
            }
            return minCar;
        }
        public static void MinCarLength(CarArray carArray) // проверка коллекции на пустоту перед тем, как вызвать метод MinCar
        {
            if (carArray.Length == 0) Console.WriteLine("Коллекция пуста");
            else
            {
                Interface.Show(MinCar(carArray));
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("====================================<ДЕМОНСТРАЦИОННАЯ ПРОГРАММА>====================================");
            Console.WriteLine("================================<КОНСТРУКТОРЫ ОБЪЕКТОВ КЛАССА Car>================================");
            // первый объект
            Car c1 = new Car();
            Console.WriteLine("первый объект с1 (без параметров):");
            Console.WriteLine(Interface.hat);
            Console.WriteLine(c1.ToString());
            // второй объект
            Car c2 = new Car(34.5, 190.76);
            Console.WriteLine("второй объект с2 (с параметрами):");
            Interface.Show(c2);
            // третий объект
            Car c3 = new Car(c2);
            Console.WriteLine("третий объект с3 (копирование):");
            Interface.Show(c3);

            Interface.Count(Car.Count(), "Количество созданных объектов: ");

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("====================================<МЕТОД (СТАТИК И КЛАССА)>====================================");
            Console.WriteLine("метод класса:");
            Console.WriteLine(c1.GetLength());
            Console.WriteLine("метод статик:");
            Console.WriteLine(Car.GetLength(c1));

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("=========================================<УНАРНЫЕ ОПЕРАЦИИ>=========================================");


            Console.WriteLine("c2++ - увеличение расхода топлива автомобиля на 0,1 л / 100 км");
            c2++;
            Console.WriteLine("с2");
            Interface.Show(c2);
            Console.WriteLine("c10 = ++c2");
            Car c10 = ++c2;
            Console.WriteLine("с2");
            Interface.Show(c2);
            Console.WriteLine("с10");
            Interface.Show(c10);
            Console.WriteLine("ПОКАЖЕМ, ЧТО ПРИ ИЗМЕНЕНИИ С10 НЕ МЕНЯЕТСЯ С2");
            Console.WriteLine("меняем c10: с10++");
            c10++;
            Console.WriteLine("с2");
            Interface.Show(c2);
            Console.WriteLine("с10");
            Interface.Show(c10);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("c3-- - уменьшение топлива в баке автомобиля на 1 л (топлива в баке не может быть меньше 0)");
            c3--;
            Interface.Show(c3);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("=================================<БИНАРНЫЕ ОПЕРАЦИИ>=================================");
            Console.WriteLine("(c + вещ.число) - Car c, вещественное число (количество литров топлива)" +
                " (левосторонняя операция добавления некоторого количества литров топлива в топливный бак автомобиля)." +
                " Результат должен быть типа Car");
            Console.WriteLine("c4 = c2 + 6.4");
            Car c4 = new(c2 + 6.4);
            Interface.Show(c4);
            Console.WriteLine("(вещ.число + c) - вещественное число, Car c (правосторонняя операция, уменьшается расход топлива на заданное число)." +
                " Результат должен быть типа Car");
            Console.WriteLine("c5 = 6.4 + c2");
            Car c5 = new(6.4 + c2);
            Interface.Show(c5);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("РАВЕНСТВО/НЕРАВЕНСТВО объектов c2 и с3");
            Console.WriteLine("с2:");
            Interface.Show(c2);
            Console.WriteLine("с3:");
            Interface.Show(c3);
            Console.WriteLine("(c2 == c3) - автомобили имеют равные возможности, если равны их атрибуты. Результат:");
            Console.WriteLine(c2 == c3);
            Console.WriteLine("(c2 != c3) - автомобили не равносильны, если не равны их атрибуты. Результат:");
            Console.WriteLine(c2 != c3);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("====================================<ОПЕРАЦИИ ПРИВЕДЕНИЯ ТИПОВ>====================================");
            Console.WriteLine("операции производятся над объектом c3:");
            Interface.Show(c3);
            Console.WriteLine("bool (явная) – результатом является true, если автомобиль сможет доехать до заправки (до заправки ровно 100 км)," +
                " а в баке в момент заправки останется не меньше 5 л топлива, иначе – false");
            bool t = (bool)c3;
            Console.WriteLine($"Результат для с3: {t}");
            Console.WriteLine("double (неявная) – результатом является количество сотен километров до заправки," +
                " чтобы в момент заправки в баке осталось ровно 5 л топлива. Если в момент расчёта в баке меньше 5 л топлива, значит результатом операции будет число -1");
            double x = c3;
            Console.WriteLine($"Результат для с3: {x}");

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("================================<КОНСТРУКТОРЫ КОЛЛЕКЦИИ CarArray>================================");
            Console.WriteLine("Первая коллекция carArray1 (без параметров)");
            CarArray carArray1 = new CarArray();
            Interface.Show(carArray1);
            Console.WriteLine("Вторая коллекция carArray2 (копирование)");
            CarArray carArray2 = new CarArray(carArray1);
            Interface.Show(carArray2);
            Console.WriteLine("ПОКАЖЕМ ГЛУБОКОЕ КОПИРОВАНИЕ!\nПереприсвоим первому объекту первой коллекции другие значения: carArray1[0] = new Car(10, 3)");
            carArray1[0] = new Car(10, 3);
            Console.WriteLine("Первая коллекция carArray1:");
            Interface.Show(carArray1);
            Console.WriteLine("Вторая коллекция carArray2:");
            Interface.Show(carArray2);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("машина с наименьшим запасом хода во второй коллекции:");
            MinCarLength(carArray2);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("КОНСТРУКТОРЫ С ПАРАМЕТРАМИ");
            Console.WriteLine("Третья коллекция carArray3 (с параметрами (случайные значения))");
            CarArray carArray3 = new CarArray(2, true);
            Interface.Show(carArray3);
            Console.WriteLine("Четвертая коллекция carArray4 (с параметрами (вводимые значения))");
            CarArray carArray4 = new CarArray(2, false);
            Interface.Show(carArray4);
            Console.WriteLine("Пятая коллекция carArray5 (с параметрами (вводимые значения))");
            CarArray carArray5 = new CarArray(0, false);
            Interface.Show(carArray5);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("машина с наименьшим запасом хода в пятой коллекции:");
            MinCarLength(carArray5);

            Console.WriteLine(); // ПРОБЕЛ

            Console.WriteLine("================================<ПРОВЕРКА РАБОТЫ С ИНДЕКСАМИ>================================");

            Console.WriteLine("Запись объекта с существующим индексом: carArray4[1] = new Car(400, 50)");
            carArray4[1] = new Car(400, 50);
            Interface.Show(carArray4);
            Console.WriteLine("Получение объекта с существующим индексом: Interface.Show(carArray4[1])");
            Interface.Show(carArray4[1]);

            try
            {
                Console.WriteLine("Запись объекта с несуществующим индексом carArray4[100] = new Car(400, 50)");
                carArray4[100] = new Car(400, 50);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine("Получение объекта с несуществующим индексом Interface.Show(carArray4[100])");
                Interface.Show(carArray4[100]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Interface.Count(CarArray.Count(), "Всего создано коллекций: ");
        }
    }
}