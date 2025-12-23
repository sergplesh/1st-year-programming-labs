using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeometrucShapeCarLibrary;

namespace Demonstration_lab11
{
    public class TestCollections
    {
        public SortedSet<Rectangle> col1 = new SortedSet<Rectangle>();
        public SortedSet<string> col2 = new SortedSet<string>();
        public HashSet<Shape> col3 = new HashSet<Shape>();
        public HashSet<string> col4 = new HashSet<string>();

        Rectangle? first, middle, last, noexist;

        //int count = 0;
        //public int Count => count;

        // первый элемент коллекций
        public Rectangle First { get; set; }
        // центральный элемент коллекций
        public Rectangle Middle { get; set; }
        // последний элемент коллекций
        public Rectangle Last { get; set; }
        // элемент коллекций, не входящий в коллекции
        public Rectangle Noexist { get; set; }

        public TestCollections(int length)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.RandomInit();
                    rectangle.Name += i.ToString();
                    col3.Add(rectangle.GetBase);
                    col4.Add(rectangle.GetBase.ToString());
                    col1.Add(rectangle);
                    col2.Add(rectangle.ToString());
                    if (i == 0)
                        First = (Rectangle)rectangle.Clone();
                    if (i == length/2)
                        Middle = (Rectangle)rectangle.Clone();
                    if (i == length - 1)
                        Last = (Rectangle)rectangle.Clone();
                    //count++;
                }
                catch
                {
                    i--;
                }
            }
            Noexist = new Rectangle("Бабочка", 777, 77, 7);
        }
    }
}
