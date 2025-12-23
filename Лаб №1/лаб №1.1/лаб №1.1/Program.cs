namespace лаб__1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            double x;
            bool isConvert;
            bool canCalculate;
            Console.WriteLine("Введите целое число n");
            do // ввод числа n
            {
                isConvert = int.TryParse(Console.ReadLine(), out n);
                if (!isConvert)
                    Console.WriteLine("Ошибка ввода! Необходимо ввести целое число n. Повторите ввод.");
            } while (!isConvert);
            Console.WriteLine("Введите целое число m");
            do // ввод числа m
            {
                isConvert = int.TryParse(Console.ReadLine(), out m);
                if (!isConvert)
                    Console.WriteLine("Ошибка ввода! Необходимо ввести целое число m. Повторите ввод.");
            } while (!isConvert);
            Console.WriteLine("Введите вещественное число x от -1 до 1");
            do // ввод числа x в пределах от -1 до 1, так как в дальнейшем мы будем вычислять его арксинус 
            {
                isConvert = double.TryParse(Console.ReadLine(), out x);
                canCalculate = (x >= (-1)) && (x <= 1);
                if (!isConvert)
                    Console.WriteLine("Ошибка ввода! Вы ввели не число. Необходимо ввести вещественное число x от -1 до 1. Повторите ввод.");
                if (!canCalculate)
                    Console.WriteLine("Ошибка ввода! Вы ввели число, выходящее за область определения вычисляемого выражения.\nНеобходимо ввести вещественное x число от -1 до 1. Повторите ввод.");
            } while (!isConvert || !canCalculate);
            int res1 = m-- -n; // вычисляем значение первого выражения
            Console.WriteLine("Значение первого выражения (m-- - n) = " + res1 + ", n = " + n + ", m = " + m);
            bool res2 = m++ < n; // вычисляем значение второго выражения
            Console.WriteLine("Значение второго выражения (m++ < n) = " + res2 + ", n = " + n + ", m = " + m);
            bool res3 = n++ > m; // вычисляем значение третьего выражения
            Console.WriteLine("Значение третьего выражения (n++ > m) = " + res3 + ", n = " + n + ", m = " + m);
            double res4 = Math.Pow(x,4) - Math.Cos(Math.Asin(x)); // вычисляем значение четвертого выражения
            Console.WriteLine("Значения выражения (x^4-cos(arcsin(x))) = " + res4);
        }
    }
}