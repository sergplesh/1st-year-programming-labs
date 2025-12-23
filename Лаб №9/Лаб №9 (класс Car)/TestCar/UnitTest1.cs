using Microsoft.VisualBasic;
using Лаб__9_класс_Car;
namespace TestCar
{
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
            string expected = "|" + String.Format("{0,35}", 56.9) + "|" + String.Format("{0,37}", 678.3) + "|" + String.Format("{0,30}", 1192.091) + "|";

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

    [TestClass]
    public class CarArrayTests // ТЕСТИРОВАНИЕ CarArray
    {
        [TestMethod]
        public void Constructor_WithoutParametrs_Copy() // конструкторы без параметра и копирования коллекции
        {
            //Arrange
            CarArray temp1 = new CarArray();
            Car expected = temp1[0];
            //Act
            CarArray temp2 = new CarArray(temp1);
            Car actual = temp2[0];
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Constructor_Parametrs() // конструктор с параметром (случайные значения)
        {
            //Arrange
            CarArray temp = new CarArray(3, true);
            temp[2] = new Car(5, 10);
            Car expected = temp[2];
            //Act
            Car actual = new Car(5, 10);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetObjectWithRealIndex() // присваиваем существующему индексу новое значение
        {
            //Arrange
            CarArray temp = new CarArray();
            temp[0] = new Car(50, 100);
            Car expected = temp[0];
            //Act
            Car actual = new Car(50, 100);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmptyArray_ToString() // печать пустого массива
        {
            //Arrange
            CarArray carArray1 = new CarArray(0, true);
            string expected = "";
            //Act
            string actual = carArray1.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotEmptyArray_ToString() // печать непустого массива
        {
            // Arrange
            CarArray carArray = new CarArray(1, true);
            double fuelFlow = 56.9;
            double fuelVolume = 678.3;
            carArray[0] = new Car(fuelFlow, fuelVolume);
            string expected = "|" + String.Format("{0,35}", 56.9) + "|" + String.Format("{0,37}", 678.3) + "|" + String.Format("{0,30}", 1192.091) + "|" + "\n";

            // Act
            string actual = carArray.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}