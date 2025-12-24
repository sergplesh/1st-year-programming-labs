using GeometrucShapeCarLibrary;
using лаб_12._1_List;

namespace TestList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToBegin_AddsItemToBeginning() // добавление в начало
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            int expectedCount = 3;

            // Act
            list.AddToBegin(new Shape("элемент", 1));
            list.AddToBegin(new Shape("элемент", 2));
            list.AddToBegin(new Shape("элемент", 3));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("элемент", expectedCount - i));
                current = current.Next;
            }
        }
        [TestMethod]
        public void AddToEnd_AddsItemToEnd() // добавление в конец
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            int expectedCount = 3;

            // Act
            list.AddToEnd(new Shape("элемент", 1));
            list.AddToEnd(new Shape("элемент", 2));
            list.AddToEnd(new Shape("элемент", 3));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("элемент", i + 1));
                current = current.Next;
            }
        }
        //[TestMethod]
        //public void Remove_RemovesItem() // удаление элемента
        //{
        //    // Arrange
        //    MyList<Shape> list = new MyList<Shape>();
        //    list.AddToEnd(new Shape());
        //    int expectedCount = 0;

        //    // Act
        //    list.Remove(list.FindItem(new Shape()));

        //    // Assert
        //    Assert.AreEqual(expectedCount, list.Count);
        //}
        [TestMethod]
        public void RemoveItem_Middle() // удаление элемента в середине
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("элемент", 1));
            list.AddToEnd(new Shape("элемент", 2));
            list.AddToEnd(new Shape("элемент", 123456789));
            list.AddToEnd(new Shape("элемент", 3));
            int expectedCount = 3;

            // Act
            list.RemoveItem(new Shape("элемент", 123456789));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("элемент", i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void RemoveItem_Beg() // удаление элемента в начале
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("элемент", 123456789));
            list.AddToEnd(new Shape("элемент", 1));
            list.AddToEnd(new Shape("элемент", 2));
            list.AddToEnd(new Shape("элемент", 3));
            int expectedCount = 3;

            // Act
            list.RemoveItem(new Shape("элемент", 123456789));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Assert.AreEqual(list.beg.Data, new Shape("элемент", 1));
        }
        [TestMethod]
        public void RemoveItem_End() // удаление элемента в конце
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("элемент", 1));
            list.AddToEnd(new Shape("элемент", 2));
            list.AddToEnd(new Shape("элемент", 3));
            list.AddToEnd(new Shape("элемент", 123456789));
            int expectedCount = 3;

            // Act
            list.RemoveItem(new Shape("элемент", 123456789));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Assert.AreEqual(list.end.Data, new Shape("элемент", 3));
        }
        [TestMethod]
        public void RemoveItem_EmptyList() // удаление несуществующего элемента
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();

            // Act
            bool ok = list.RemoveItem(new Shape("элемент", 123456789));

            // Assert
            Assert.IsTrue(ok == false);
        }
        [TestMethod]
        public void RemoveName_EmptyList() // удаление несуществующего элемента (по названию)
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();

            // Act
            Shape seted = new Shape();
            seted.Name = "элумент";
            bool ok = list.RemoveName(seted);

            // Assert
            Assert.IsTrue(ok == false);
        }
        [TestMethod]
        public void AddItem_AddsItemAfterSpecifiedName_Middle() // добавление после элемента с заданным названием в середину
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("элемент1", 1));
            list.AddToEnd(new Shape("элемент2", 2));
            list.AddToEnd(new Shape("элемент4", 4));
            int expectedCount = 4;

            // Act
            Shape seted = new Shape("элемент2", 2);
            list.AddItem(new Shape("элемент3", 3), seted);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("элемент" + (i + 1).ToString(), i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void AddItem_AddsItemAfterSpecifiedName_End() // добавление после элемента с заданным названием в конец
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("элемент1", 1));
            list.AddToEnd(new Shape("элемент2", 2));
            list.AddToEnd(new Shape("элемент3", 3));
            int expectedCount = 4;

            // Act
            Shape seted = new Shape("элемент3", 3);
            list.AddItem(new Shape("элемент4", 4), seted);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("элемент" + (i +1).ToString(), i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void RemoveAllItems_RemovesAllItemsWithSpecifiedName() // удаление всех элементов с заданным названием
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("cherry", 66));
            list.AddToEnd(new Shape("apple", 87));
            list.AddToEnd(new Shape("apple", 56));
            list.AddToEnd(new Shape("apple", 0));
            list.AddToEnd(new Shape("banana", 23));
            int expectedCount = 2;

            // Act
            Shape deleted = new Shape();
            deleted.Name = "apple";
            list.RemoveAllItems(deleted);

            // Assert
            // должен поолучиться список из двух элементов: cherry в начале, banana в конце
            Assert.AreEqual(list.Count, expectedCount);
            Assert.AreEqual(list.beg.Data, new Shape("cherry", 66));
            Assert.AreEqual(list.end.Data, new Shape("banana", 23));
        }
        [TestMethod]
        public void Clone_CreatesDeepCopyOfList() // клонирование списка
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("элемент", 1));
            list.AddToEnd(new Shape("элемент", 2));
            list.AddToEnd(new Shape("элемент", 3));

            // Act
            MyList<Shape> cloneList = list.Clone();
            cloneList.end.Data.Name = "другой-элемент";

            // Assert
            // проверяем, правильно ли скопированы элементы и не изменился ли элемент в оригинальном списке вместе с клонированным 
            Assert.AreEqual(list.Count, cloneList.Count);
            Point<Shape>? current = cloneList.beg;
            for (int i = 0; current != null; i++)
            {
                if (i + 1 == 3) Assert.AreEqual(current.Data, new Shape("другой-элемент", i + 1));
                else Assert.AreEqual(current.Data, new Shape("элемент", i + 1));
                current = current.Next;
            }
            current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("элемент", i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void Clone_CreatesDeepCopyOfEmptyList() // клонирование списка
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();

            // Act
            MyList<Shape> cloneList = list.Clone();

            // Assert
            Assert.AreEqual(list.Count, cloneList.Count);
            Assert.AreEqual(cloneList.beg, null);
            Assert.AreEqual(cloneList.end, null);
        }
        [TestMethod]
        public void Clear_RemovesAllItemsFromList() // удаление всех элементов в списке
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("apple", 56));
            list.AddToEnd(new Shape("banana", 23));
            int expectedCount = 0;

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
        }
        [TestMethod]
        public void FindName_ReturnsCorrectItem() // Поиск объекта
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("Бабочка", 56));

            // Act
            Shape searched = new Shape();
            searched.Name = "Бабочка";
            Point<Shape>? result = list.FindName(searched);

            // Assert
            Assert.AreEqual(new Shape("Бабочка", 56), result?.Data);
        }
        [TestMethod]
        public void FindItem_ReturnsCorrectItem() // Поиск по названмию
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("Бабочка", 1));
            list.AddToEnd(new Shape("Бабочка", 2));
            list.AddToEnd(new Shape("Бабочка", 3));

            // Act
            Shape searched = new Shape("Бабочка", 2);
            Point<Shape>? result = list.FindItem(searched);

            // Assert
            Assert.AreEqual(new Shape("Бабочка", 2), result?.Data);
        }
        [TestMethod]
        public void FindItem_ReturnsNull() // Поиск по названмию
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("Бабочка", 1));
            list.AddToEnd(new Shape("Бабочка", 2));
            list.AddToEnd(new Shape("Бабочка", 3));

            // Act
            Shape searched = new Shape("Бабочка", 4);
            Point<Shape>? result = list.FindItem(searched);

            // Assert
            Assert.AreEqual(null, result?.Data);
        }
        [TestMethod]
        public void ExceptionListConstructor_NegativeSize() // конструктор по отрицательному размеру
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new MyList<Shape>(-1)));
        }
        [TestMethod]
        public void ExceptionListConstructor_NullCollection() // конструктор по null-массиву
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new MyList<Shape>(null)));
        }
        [TestMethod]
        public void ExceptionListConstructor_EmptyCollection() // конструктор по пустому массиву
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new MyList<Shape>(new Shape[0])));
        }
        [TestMethod]
        public void ListConstructorCollection() // конструктор на основе массива
        {
            // Arrange
            Shape[] array = new Shape[5];
            for (int i = 0; i < 5; i++)
            {
                Shape s = new Shape();
                s.RandomInit();
                array[i] = s;
            }
            int expectedCount = array.Length;

            // Act
            MyList<Shape> list = new MyList<Shape>(array);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, array[i]);
                current = current.Next;
            }
        }
        [TestMethod]
        public void ListConstructorSize() // конструктор, создающий лист заданного размера
        {
            // Arrange
            int expectedCount = 5;

            // Act
            MyList<Shape> list = new MyList<Shape>(5);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
        }
        [TestMethod]
        public void PointConstructor() // конструктор Point
        {
            // Arrange
            Point<Shape> point1 = new Point<Shape>();

            // Act
            Point<Shape> point2 = new Point<Shape>(null);

            // Assert
            Assert.AreEqual(point1.Previous, point2.Previous);
            Assert.AreEqual(point1.Data, point2.Data);
            Assert.AreEqual(point1.Next, point2.Next);
        }
        [TestMethod]
        public void NullPointToString() // null Point-строка
        {
            // Arrange
            Point<Shape> point1 = new Point<Shape>();

            // Act
            string s = "";

            // Assert
            Assert.AreEqual(s, point1.ToString());
        }
        [TestMethod]
        public void PointToString() // Point-строка
        {
            // Arrange
            Shape seted = new Shape("элемент", 2);
            Point<Shape> point1 = new Point<Shape>(seted);

            // Act
            string s = "id 2: " + "элемент";

            // Assert
            Assert.AreEqual(s, point1.ToString());
        }
    }
}