using GeometrucShapeCarLibrary;
using LINQ_лаб__14;

namespace TestQuery
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MaxLength()
        {
            // Arrange
            List<Page> pages = new List<Page>
                {
                    new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 10, 20) }, { 2, new Circle("элемент", 1, 15) } } },
                    new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 5, 15) }, { 2, new Circle("элемент", 1, 25) } } }
                };

            // Act
            double result = Query.MaxLength(pages);

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void MinLength()
        {
            // Arrange
            List<Page> pages = new List<Page>
                {
                    new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 10, 20) }, { 2, new Circle("элемент", 1, 15) } } },
                    new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 5, 15) }, { 2, new Circle("элемент", 1, 25) } } }
                };

            // Act
            double result = Query.MinLength(pages);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Volume()
        {
            // Arrange
            List<Page> pages = new List<Page>
                {
                    new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Parallelepiped("элемент", 1, 10, 20, 30) }, { 2, new Circle("элемент", 1, 15) } } },
                    new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 5, 15) }, { 2, new Circle("элемент", 1, 25) } } }
                };

            // Act
            double result = Query.AverageVolume(pages);

            // Assert
            Assert.AreEqual(6000, result);
        }

        [TestMethod]
        public void TestIntersectLINQ()
        {
            // Arrange
            Page page1 = new Page();
            page1.ContentPage.Add(1, new Rectangle("Rectangle1", 1, 5, 10));
            page1.ContentPage.Add(2, new Circle("Circle1", 2, 15));

            Page page2 = new Page();
            page2.ContentPage.Add(1, new Rectangle("Rectangle1", 1, 5, 10));
            page2.ContentPage.Add(2, new Circle("Circle1", 2, 15));

            // Act
            var intersect = Query.IntersectLINQ(page1, page2);

            // Assert
            Assert.AreEqual(2, intersect.Count());
            Assert.IsTrue(intersect.Any(s => s.Name == "Rectangle1"));
            Assert.IsTrue(intersect.Any(s => s.Name == "Circle1"));
        }

        [TestMethod]
        public void TestIntersect()
        {
            // Arrange
            Page page1 = new Page();
            page1.ContentPage.Add(1, new Rectangle("Rectangle1", 1, 5, 10));
            page1.ContentPage.Add(2, new Circle("Circle1", 2, 15));

            Page page2 = new Page();
            page2.ContentPage.Add(1, new Rectangle("Rectangle1", 1, 5, 10));
            page2.ContentPage.Add(2, new Circle("Circle1", 2, 15));

            // Act
            var intersect = Query.Intersect(page1, page2);

            // Assert
            Assert.AreEqual(2, intersect.Count());
            Assert.IsTrue(intersect.Any(s => s.Name == "Rectangle1"));
            Assert.IsTrue(intersect.Any(s => s.Name == "Circle1"));
        }

        [TestMethod]
        public void TestGroupByRadius()
        {
            // Arrange
            List<Page> pages = new List<Page>
            {
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Circle("Circle1", 1, 105) }, { 2, new Circle("Circle2", 2, 505) } } },
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Circle("Circle3", 1, 355) }, { 2, new Circle("Circle4", 2, 765) } } }
            };

            // Act
            var groups = Query.GroupByRadius(pages);

            // Assert
            Assert.AreEqual(4, groups.Count()); // Ожидаем 4 группы, так как у нас 4 круга
        }

        [TestMethod]
        public void TestVolumeLINQ()
        {
            // Arrange
            List<Page> pages = new List<Page>
            {
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Parallelepiped("Parallelepiped1", 1, 5, 10, 15) } } },
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Parallelepiped("Parallelepiped2", 1, 8, 12, 18) } } }
            };

            // Act
            var volumes = Query.VolumeLINQ(pages);

            // Assert
            Assert.AreEqual(2, volumes.Count()); // Ожидаем 2 объема
        }

        [TestMethod]
        public void TestMaxLength()
        {
            // Arrange
            List<Page> pages = new List<Page>
            {
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 10, 20) }, { 2, new Circle("элемент", 1, 15) } } },
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 5, 15) }, { 2, new Circle("элемент", 1, 25) } } }
            };

            // Act
            double result = Query.MaxLength(pages);

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TestMinLength()
        {
            // Arrange
            List<Page> pages = new List<Page>
            {
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 10, 20) }, { 2, new Circle("элемент", 1, 15) } } },
                new Page { ContentPage = new Dictionary<int, Shape> { { 1, new Rectangle("элемент", 1, 5, 15) }, { 2, new Circle("элемент", 1, 25) } } }
            };

            // Act
            double result = Query.MinLength(pages);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestWhereCircle()
        {
            // Arrange
            List<Shape> shapes = new List<Shape>
            {
                new Circle { Name = "Circle1", Radius = 10 },
                new Rectangle { Name = "Rectangle1", Width = 5, Length = 10 }
            };

            // Act
            var result = Query.WhereCircle(shapes);

            // Assert
            var resultList = result.ToList();
            Assert.AreEqual(1, resultList.Count);
            Assert.IsTrue(resultList[0] is Circle);
            Assert.AreEqual("Circle1", resultList[0].Name);
        }

        [TestMethod]
        public void TestWhereParallelepiped()
        {
            // Arrange
            List<Shape> shapes = new List<Shape>
            {
                new Parallelepiped { Name = "Parallelepiped1", Height = 10 },
                new Circle { Name = "Circle1", Radius = 5 }
            };

            // Act
            var result = Query.WhereParallelepiped(shapes);

            // Assert
            var resultList = result.ToList();
            Assert.AreEqual(1, resultList.Count);
            Assert.IsTrue(resultList[0] is Parallelepiped);
            Assert.AreEqual("Parallelepiped1", resultList[0].Name);
        }

        [TestMethod]
        public void TestAverageHeigthParallelepiped()
        {
            // Arrange
            List<Shape> shapes = new List<Shape>
            {
                new Parallelepiped { Name = "Parallelepiped1", Height = 10 },
                new Parallelepiped { Name = "Parallelepiped2", Height = 20 }
            };

            // Act
            double result = Query.AverageHeigthParallelepiped(shapes);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestSumCircleRadius()
        {
            // Arrange
            List<Shape> shapes = new List<Shape>
            {
                new Circle { Name = "Circle1", Radius = 5 },
                new Circle { Name = "Circle2", Radius = 10 }
            };

            // Act
            double result = Query.SumCircleRadius(shapes);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestGroupByName()
        {
            // Arrange
            List<Shape> shapes = new List<Shape>
            {
                new Circle { Name = "Circle1" },
                new Circle { Name = "Circle2" },
                new Rectangle { Name = "Rectangle1" }
            };

            // Act
            var groups = Query.GroupByName(shapes);

            // Assert
            var groupList = groups.ToList();
            Assert.AreEqual(3, groupList.Count);
            Assert.AreEqual("Circle1", groupList[0].Key);
            Assert.AreEqual("Circle2", groupList[1].Key);
            Assert.AreEqual("Rectangle1", groupList[2].Key);
        }

        [TestMethod]
        public void TestGroupByNameLINQ()
        {
            // Arrange
            List<Shape> shapes = new List<Shape>
            {
                new Circle { Name = "Circle1" },
                new Circle { Name = "Circle2" },
                new Rectangle { Name = "Rectangle1" }
            };

            // Act
            var groups = Query.GroupByNameLINQ(shapes);

            // Assert
            var groupList = groups.ToList();
            Assert.AreEqual(3, groupList.Count);
            Assert.AreEqual("Circle2", groupList[1].Key);
            Assert.AreEqual("Circle1", groupList[2].Key);
            Assert.AreEqual("Rectangle1", groupList[0].Key);
        }

        [TestMethod]
        public void Add_UniqueShape_AddsShapeToContentPage()
        {
            // Arrange
            var page = new Page();
            var shape = new Shape { id = new IdNumber { Number = 1 }, Name = "Shape1" };

            // Act
            page.Add(shape);

            // Assert
            Assert.AreEqual(1, page.ContentPage.Count);
            Assert.IsTrue(page.ContentPage.ContainsKey(shape.id.Number));
            Assert.AreEqual(shape, page.ContentPage[shape.id.Number]);
        }

        [TestMethod]
        public void Add_DuplicateShape_DoesNotAddShapeToContentPage()
        {
            // Arrange
            var page = new Page();
            var shape1 = new Shape { id = new IdNumber { Number = 1 }, Name = "Shape1" };
            var shape2 = new Shape { id = new IdNumber { Number = 1 }, Name = "Shape2" };
            page.Add(shape1);

            // Act
            page.Add(shape2);

            // Assert
            Assert.AreEqual(1, page.ContentPage.Count);
            Assert.IsTrue(page.ContentPage.ContainsKey(shape1.id.Number));
            Assert.AreEqual(shape1, page.ContentPage[shape1.id.Number]);
        }

        [TestMethod]
        public void Name_ValidRussianName_SetsName()
        {
            // Arrange
            var page = new Page();
            string validRussianName = "Страница1";

            // Act
            page.Name = validRussianName;

            // Assert
            Assert.AreEqual(validRussianName, page.Name);
        }

        [TestMethod]
        public void Name_ValidEnglishName_SetsName()
        {
            // Arrange
            var page = new Page();
            string validEnglishName = "Page1";

            // Act
            page.Name = validEnglishName;

            // Assert
            Assert.AreEqual(validEnglishName, page.Name);
        }

        [TestMethod]
        public void Name_InvalidName_SetsNameToNoName()
        {
            // Arrange
            var page = new Page();
            string invalidName = "123InvalidName";

            // Act
            page.Name = invalidName;

            // Assert
            Assert.AreEqual("NoName", page.Name);
        }

        [TestMethod]
        public void NumberProperty_ShouldSetAndGetNumber()
        {
            // Arrange
            EntryPage entryPage = new EntryPage();
            int expectedNumber = 5;

            // Act
            entryPage.Number = expectedNumber;

            // Assert
            Assert.AreEqual(expectedNumber, entryPage.Number);
        }

        [TestMethod]
        public void EntryProperty_ShouldSetAndGetEntry()
        {
            // Arrange
            EntryPage entryPage = new EntryPage();
            string expectedEntry = "Test entry";

            // Act
            entryPage.Entry = expectedEntry;

            // Assert
            Assert.AreEqual(expectedEntry, entryPage.Entry);
        }

        [TestMethod]
        public void GroupByType_ShouldGroupShapesByType()
        {
            // Arrange
            var pages = new List<Page>
            {
                new Page
                {
                    ContentPage = new Dictionary<int, Shape>
                    {
                        { 1, new Circle { Name = "Circle1" } },
                        { 2, new Rectangle { Name = "Rectangle1" } }
                    }
                },
                new Page
                {
                    ContentPage = new Dictionary<int, Shape>
                    {
                        { 3, new Circle { Name = "Circle2" } },
                        { 4, new Parallelepiped { Name = "Parallelepiped1" } }
                    }
                }
            };

            // Act
            var result = Query.GroupByType(pages);

            // Assertьо
            var groups = result.ToList();
            Assert.AreEqual(3, groups.Count);

            var circleGroup = groups.FirstOrDefault(g => g.Key == nameof(Circle));
            var rectangleGroup = groups.FirstOrDefault(g => g.Key == nameof(Rectangle));
            var parallelepipedGroup = groups.FirstOrDefault(g => g.Key == nameof(Parallelepiped));

            Assert.IsNotNull(circleGroup);
            Assert.AreEqual(2, circleGroup.Count());
            Assert.IsTrue(circleGroup.Any(s => s.Name == "Circle1"));
            Assert.IsTrue(circleGroup.Any(s => s.Name == "Circle2"));

            Assert.IsNotNull(rectangleGroup);
            Assert.AreEqual(1, rectangleGroup.Count());
            Assert.IsTrue(rectangleGroup.Any(s => s.Name == "Rectangle1"));

            Assert.IsNotNull(parallelepipedGroup);
            Assert.AreEqual(1, parallelepipedGroup.Count());
            Assert.IsTrue(parallelepipedGroup.Any(s => s.Name == "Parallelepiped1"));
        }
    }
}