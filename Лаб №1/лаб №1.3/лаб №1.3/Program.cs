namespace лаб__1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double c1, c2, c3; // промежуточные результаты типа double
            float c1f, c21f, c22f, c31f, c32f; // промежуточные результаты типа float
            double a1 = 1000;
            double b1 = 0.0001;

            // исходные флоат

            double res1, res2; // значение выражения при типе double
            float resf1, resf2; // значение выражения при типе float
            c1 = Math.Pow((a1 + b1), 3);
            c2 = Math.Pow(a1, 3) + 3 * Math.Pow(a1, 2) * b1;
            c3 = 3 * a1 * Math.Pow(b1, 2) + Math.Pow(b1, 2);
            c1f = (float)((a1 + b1)* (a1 + b1) * (a1 + b1));
            c21f = (float)(a1 * a1 * a1);
            c22f = (float)(3 * a1 * a1 * b1);
            c31f = (float)(3 * a1 * b1 * b1);
            c32f = (float)(b1 * b1);
            res1 = (Math.Pow((a1 + b1), 3) - (Math.Pow(a1, 3) + 3 * Math.Pow(a1, 2) * b1)) / (3 * a1 * Math.Pow(b1, 2) + Math.Pow(b1, 2));
            res2 = (c1 - c2) / c3; // посчитав все промежуточные резултаты, находим значение выражение типа double
            resf1 = (c1f - (c21f + c22f)) / (c31f + c32f);
            resf2 = (float)res1;
            
            // из-за того, что тип float обрезает промежуточные результаты, то посчитав с помощью них резултат,
            // мы получим ноль, так как числитель обнулится. Поэтому мы преобразуем res типа double в тип float
            Console.WriteLine("Промежуточные значения типа double: " + c1 + ", " + c2 + ", " + c3);
            Console.WriteLine("Промежуточные значения типа float: " + c1f + ", " + c21f + ", " + c22f + ", " + c31f + ", " + c32f);
            Console.WriteLine("Значение выражения типа double = " + res1);
            Console.WriteLine("Значение выражения типа double (через промежуточные значения) = " + res2);
            Console.WriteLine("Значение выражения типа float (через промежуточные значения) = " + resf1);
            Console.WriteLine("Значение выражения типа float (через приведения значения выражения типа double в тип float)= " + resf2);
        }
    }
}