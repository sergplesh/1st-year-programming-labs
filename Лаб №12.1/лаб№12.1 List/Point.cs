using GeometrucShapeCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб_12._1_List
{
    public class Point<T> where T : IInit, new()
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Previous { get; set; }

        public Point()
        {
            Data = default(T);
            Next = null;
            Previous = null;
        }
        public Point(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }

        public static Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }
        public static T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();
        }
    }
}
