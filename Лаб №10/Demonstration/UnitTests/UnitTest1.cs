using GeometrucShapeCarLibrary;
using System.Security.Cryptography;

namespace UnitTests
{
    [TestClass]
    public class UnitTestGeometricShapeLibrary
    {
        [TestMethod]
        public void IdNumber_NumberProperty() // свойство Number IdNumber для некорректно введённого id
        {
            // Arrange
            IdNumber expected = new IdNumber();

            // Act
            IdNumber actual = new IdNumber(-100);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_NameProperty() // свойство Name Shape для некорректного названия
        {
            // Arrange
            Shape expected = new Shape();

            // Act
            Shape actual = new Shape("", 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_RadiusProperty() // свойство Radius Circle для некорректно введённого радиуса
        {
            // Arrange
            Circle expected = new Circle();

            // Act
            Circle actual = new Circle("NoName",0, -1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_LengthProperty() // свойство Length Rectangle для некорректно введённой длины
        {
            // Arrange
            Rectangle expected = new Rectangle();

            // Act
            Rectangle actual = new Rectangle("NoName", 0, -1, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_WidthProperty() // свойство Width Rectangle для некорретно введённой ширины
        {
            // Arrange
            Rectangle expected = new Rectangle();

            // Act
            Rectangle actual = new Rectangle("NoName", 0, 1, -1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parallelepiped_HeigthProperty() // свойство Heigth Parallelepiped для некорретно введённой высоты
        {
            // Arrange
            Parallelepiped expected = new Parallelepiped();

            // Act
            Parallelepiped actual = new Parallelepiped("NoName", 0, 1, 1, -1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_ConstructorWithoutParametrs() // конструктор без параметров Shape
        {
            // Arrange
            Shape expected = new Shape();

            // Act
            Shape actual = new Shape("NoName", 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_ConstructorWithoutParametrs() // конструктор без параметров Circle
        {
            // Arrange
            Circle expected = new Circle();

            // Act
            Circle actual = new Circle("NoName", 0, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_ConstructorWithoutParametrs() // конструктор без параметров Rectangle
        {
            // Arrange
            Rectangle expected = new Rectangle();

            // Act
            Rectangle actual = new Rectangle("NoName", 0, 1, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parallelepiped_ConstructorWithoutParametrs() // конструктор без параметров Parallelepiped
        {
            // Arrange
            Parallelepiped expected = new Parallelepiped();

            // Act
            Parallelepiped actual = new Parallelepiped("NoName", 0, 1, 1, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_ConstructorParametrs() // конструктор с параметрами Shape
        {
            // Arrange
            Shape expected = new Shape();
            expected.Name = "Шар";
            expected.id = new IdNumber(56);

            // Act
            Shape actual = new Shape("Шар", 56);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_ConstructorParametrs() // конструктор с параметрами Circle
        {
            // Arrange
            Circle expected = new Circle();
            expected.id = new IdNumber(45);
            expected.Radius = 78;

            // Act
            Circle actual = new Circle("NoName", 45, 78);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_ConstructorParametrs() // конструктор с параметрами Rectangle
        {
            // Arrange
            Rectangle expected = new Rectangle();
            expected.id = new IdNumber(60);
            expected.Length = 87;
            expected.Width = 95;

            // Act
            Rectangle actual = new Rectangle("NoName", 60, 87, 95);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parallelepiped_ConstructorParametrs() // конструктор с параметрами Parallelepiped
        {
            // Arrange
            Parallelepiped expected = new Parallelepiped();
            expected.id = new IdNumber(74);
            expected.Length = 23;
            expected.Width = 48;
            expected.Height = 92;

            // Act
            Parallelepiped actual = new Parallelepiped("NoName", 74, 23, 48, 92);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IdNumber_ToString() // печать id
        {
            // Arrange
            string expected = "id 0: ";

            // Act
            IdNumber id = new IdNumber();
            string actual = id.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_ToString() // печать Shape
        {
            // Arrange
            string expected = "id 0: NoName";

            // Act
            Shape s = new Shape();
            string actual = s.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_ToString() // печать Circle
        {
            // Arrange
            string expected = "id 0: NoName, радиус 1";

            // Act
            Circle c = new Circle();
            string actual = c.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_ToString() // печать Rectangle
        {
            // Arrange
            string expected = "id 0: NoName, длина 1, ширина 1";

            // Act
            Rectangle r = new Rectangle();
            string actual = r.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parallelepiped_ToString() // печать Parallelepiped
        {
            // Arrange
            string expected = "id 0: NoName, длина 1, ширина 1, высота 1";

            // Act
            Parallelepiped id = new Parallelepiped();
            string actual = id.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_GetArea() // площадь Shape
        {
            // Arrange
            double expected = -1;

            // Act
            Shape s = new Shape();
            double actual = s.GetArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_GetArea() // площадь Circle
        {
            // Arrange
            double expected = Math.Pow(5, 2) * Math.PI;

            // Act
            Circle circle = new Circle("O", 0, 5);
            double actual = circle.GetArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_GetArea() // площадь Rectangle
        {
            // Arrange
            double expected = 80 * 90;

            // Act
            Rectangle rectangle = new Rectangle("NoName", 0, 80, 90);
            double actual = rectangle.GetArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_Clone() // клонирование для Shape
        {
            // Arrange
            Shape s1 = new Shape("Фигура", 97);
            Shape expected = s1;

            // Act
            Shape s2 = (Shape)s1.Clone();
            s2.Name = "Ромб";
            Shape actual = s2;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_Clone() // клонирование для Circle
        {
            // Arrange
            Circle s1 = new Circle("O", 97, 45);
            Circle expected = s1;

            // Act
            Circle s2 = (Circle)s1.Clone();
            s2.Radius = 46;
            Circle actual = s2;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_Clone() // клонирование для Rectangle
        {
            // Arrange
            Rectangle s1 = new Rectangle("NoName", 97, 45,34);
            Rectangle expected = s1;

            // Act
            Rectangle s2 = (Rectangle)s1.Clone();
            s2.Length = 23;
            Shape actual = s2;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Parallelepiped_Clone() // клонирование для Parallelepiped
        {
            // Arrange
            Parallelepiped s1 = new Parallelepiped("ABCDA1B1C1D1",97, 45, 63, 70);
            Parallelepiped expected = s1;

            // Act
            Parallelepiped s2 = (Parallelepiped)s1.Clone();
            s2.Height = 68;
            Parallelepiped actual = s2;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_ShallowCopy() // поверхностное копирование для Shape
        {
            // Arrange
            Shape s1 = new Shape("Фигура", 97);
            Shape expected = s1;

            // Act
            Shape s2 = (Shape)s1.ShallowCopy();
            s2.id.Number = 87;
            Shape actual = s2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Circle_ShallowCopy() // поверхностное копирование для Circle
        {
            // Arrange
            Circle s1 = new Circle("O", 97, 45);
            Circle expected = s1;

            // Act
            Circle s2 = (Circle)s1.ShallowCopy();
            s2.id.Number = 87;
            Circle actual = s2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_ShallowCopy() // поверхностное копирование для Rectangle
        {
            // Arrange
            Rectangle s1 = new Rectangle("NoName", 97, 45, 34);
            Rectangle expected = s1;

            // Act
            Rectangle s2 = (Rectangle)s1.ShallowCopy();
            s2.id.Number = 87;
            Shape actual = s2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parallelepiped_ShallowCopy() // поверхностное копирование для Parallelepiped
        {
            // Arrange
            Parallelepiped s1 = new Parallelepiped("NoName", 97, 45, 63, 70);
            Parallelepiped expected = s1;

            // Act
            Parallelepiped s2 = (Parallelepiped)s1.ShallowCopy();
            s2.id.Number = 87;
            Parallelepiped actual = s2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shape_CompareTo() // сортировка по названию для Shape
        {
            // Arrange
            Shape[] array = new Shape[3];
            array[0] = new Shape("Цилиндр", 2);
            array[1] = new Circle("Окружность", 0, 3);
            array[2] = new Rectangle("Прямоугольник", 7, 9, 6);

            // Act
            Array.Sort(array);

            // Assert
            Assert.IsTrue(array[0].Name == "Окружность");
            Assert.IsTrue(array[1].Name == "Прямоугольник");
            Assert.IsTrue(array[2].Name == "Цилиндр");
        }

        [TestMethod]
        public void Shape_Comparer() // сортировка по длине для Rectangle
        {
            // Arrange
            Rectangle[] array = new Rectangle[3];
            array[0] = new Rectangle("NoName", 0, 34, 56);
            array[1] = new Parallelepiped("NoName", 7, 11, 34, 45);
            array[2] = new Rectangle("NoName", 5, 82, 87);

            // Act
            Array.Sort(array, new LengthComparer());

            // Assert
            Assert.IsTrue(array[0].Length == 11);
            Assert.IsTrue(array[1].Length == 34);
            Assert.IsTrue(array[2].Length == 82);
        }
    }

    // ------------------------------------------------------------------------------------------------------------------
    // ТЕСТЫ ДЛЯ КЛАССА CAR ИЗ 9 ЛАБ.РАБОТЫ ВЗЯТЫ ИЗ 9 ЛАБ.РАБОТЫ
    // ------------------------------------------------------------------------------------------------------------------

    [TestClass]
    public class CarTests // ТЕСТИРОВАНИЕ КЛАССА Car
    {
        [TestMethod]
        public void SetFuelFlow_ValidValueInRange_SetSuccessfully() // присваивание корректного для свойства значения расхода топлива
        {
            // Arrange
            double validFuelFlow = 50;
            Car car = new Car();

            // Act
            car.FuelFlow = validFuelFlow;

            // Assert
            Assert.AreEqual(validFuelFlow, car.FuelFlow);
        }

        [TestMethod]
        public void SetFuelFlow_LowerValueOutOfRange_SetNotSuccessfully() // присваивание некорректного для свойства значения расхода топлива
        {
            // Arrange
            double invalidFuelFlow = -50;
            Car car = new Car();

            // Act
            car.FuelFlow = invalidFuelFlow;

            // Assert
            Assert.AreNotEqual(invalidFuelFlow, car.FuelFlow);
        }

        [TestMethod]
        public void SetFuelVolume_ValidValueInRange_SetSuccessfully() // присваивание корректного для свойства значения количества топлива
        {
            // Arrange
            double validFuelVolume = 100;
            Car car = new Car();

            // Act
            car.FuelVolume = validFuelVolume;

            // Assert
            Assert.AreEqual(validFuelVolume, car.FuelVolume);
        }

        [TestMethod]
        public void SetFuelVolume_LowerValueOutOfRange_SetNotSuccessfully() // присваивание некорректного для свойства значения количества топлива
        {
            // Arrange
            double invalidFuelVolume = -100;
            Car car = new Car();

            // Act
            car.FuelVolume = invalidFuelVolume;

            // Assert
            Assert.AreNotEqual(invalidFuelVolume, car.FuelVolume);
        }

        [TestMethod]
        public void MethodOfClass_GetLength_ValidFuel_ReturnsCorrectGetLength() // работа метода класса
        {
            // Arrange
            Car car = new Car(64, 523);

            // Act
            double length = car.GetLength();

            // Assert
            Assert.AreEqual(817.188, length, 0.001); // погрешность 0.001 км (817.188 - самостоятельно посчитанное значение)
        }

        [TestMethod]
        public void StaticMethod_GetLength_ValidFuel_ReturnsCorrectGetLength() // работа статического метода
        {
            // Arrange
            Car car = new Car(83, 942);

            // Act
            double length = Car.GetLength(car);

            // Assert
            Assert.AreEqual(1134.94, length, 0.001); // погрешность 0.001 км (1134.94 - самостоятельно посчитанное значение)
        }

        [TestMethod]
        public void IncrementOperator_IncreasesFuelFlow() // операция инкремента
        {
            // Arrange
            Car car = new Car(40, 75);

            // Act
            car++;

            // Assert
            Assert.AreEqual(40.1, car.FuelFlow); // Проверяем увеличение расхода на 0.1
        }

        [TestMethod]
        public void IncrementOperator_IncreasesFuelFlow_Postfix_DifferenceOfValues() // создания нового объекта с помощью постфиксного инкремента
        {
            // Arrange
            Car car1 = new Car(40, 75);

            // Act
            Car car2 = car1++;

            // Assert
            Assert.AreNotEqual(car1, car2); // Проверяем, что объекты не равны из за постфиксного выполнения инкремента
        }

        [TestMethod]
        public void IncrementOperator_IncreasesFuelFlow_Prefix() // создания нового объекта с помощью префиксного инкремента
        {
            // Arrange
            Car car1 = new Car(40, 75);

            // Act
            Car car2 = ++car1;

            // Assert
            Assert.AreEqual(car1, car2); // Проверяем, что объекты равны из за префиксного выполнения инкремента
        }

        [TestMethod]
        public void DecrementOperator_DecreasesFuelVolume() // операция декремента
        {
            // Arrange
            Car car = new Car(40, 75);

            // Act
            car--;

            // Assert
            Assert.AreEqual(74, car.FuelVolume); // Проверяем уменьшение топлива на 1
        }

        [TestMethod]
        public void CopyConstructor_ReturnsTrue() // конструктор копирования
        {
            // Arrange
            Car car1 = new Car();

            // Act
            Car car2 = new Car(car1);

            // Assert
            Assert.AreEqual(car1, car2);
        }

        [TestMethod]
        public void DeepCopy() // проверяем глубокое копирование
        {
            // Arrange
            Car car1 = new Car();

            // Act
            Car car2 = new Car(car1);
            car2++;

            // Assert
            Assert.AreNotEqual(car1, car2);
        }

        [TestMethod]
        public void CopyConsttructor_EqualOperator_ReturnsTrue() // проверяем работу операции == с помощью конструктора копирования
        {
            // Arrange
            Car car1 = new Car();
            Car car2 = new Car(car1);

            // Act
            bool result = car1 == car2;

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CopyConsttructor_NotEqualOperator_ReturnsFalse() // проверяем работу операции != с помощью конструктора копирования
        {
            // Arrange
            Car car1 = new Car();
            Car car2 = new Car(car1);

            // Act
            bool result = car1 != car2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat() // преобразовать объект в строку
        {
            // Arrange
            double fuelFlow = 56.9;
            double fuelVolume = 678.3;
            Car car = new Car(fuelFlow, fuelVolume);
            string expected = ("|" + String.Format("{0,35}", "Расход топлива на 100 км (в литрах)|") + String.Format("{0,38}", "Количество топлива в баке (в литрах)|") + String.Format("{0,31}", "Оставшийся запас хода (в км)|")) +"\n" + ("|" + String.Format("{0,35}", 56.9) + "|" + String.Format("{0,37}", 678.3) + "|" + String.Format("{0,30}", Math.Round((678.3 / 56.9) *100, 3)) + "|");

            // Act
            string result = car.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LeftBinaryOperation() // операция + (левосторонняя)
        {
            //Arrange
            Car expected = new Car(20, 30);
            //Act
            Car temp = new Car(20, 20);
            Car actual = new Car(temp + 10);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightBinaryOperation() // операция + (правосторонняя)
        {
            //Arrange
            Car expected = new Car(20, 30);
            //Act
            Car temp = new Car(29.9, 30);
            Car actual = new Car(9.9 + temp);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExplicitTypeConversionOperation_Bool() // операция явного преобразования типов bool
        {
            //Arrange
            Car car = new Car(20, 30);
            //Act
            bool result = (bool)car;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ImplicitTypeConversionOperation_Double() // операция неявного преобразования типов double
        {
            //Arrange
            Car car = new Car(20, 30);
            //Act
            double result = car;
            //Assert
            Assert.AreEqual(1.25, result);
        }
    }
}