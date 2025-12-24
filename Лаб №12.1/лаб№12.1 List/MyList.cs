using GeometrucShapeCarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб_12._1_List
{
    public class MyList<T> where T : IInit, ICloneable, INameEquatable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;

        int count = 0;

        public int Count => count;

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Previous = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Previous = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList() { }

        public MyList(int size)
        {
            if (size < 0) throw new Exception("size less zero");
            beg = Point<T>.MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = Point<T>.MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }
        public MyList(T[] collection)
        {
            if (collection == null) throw new Exception("empty collection: null");
            if (collection.Length == 0) throw new Exception("empty collection");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
            count = collection.Length;
        }
        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("the list is empty");
            Point<T> current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
        public Point<T>? FindItem(T item)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }
        private bool Remove(Point<T> pos)
        {
            count--;
            if (beg == end) // если паблик: в демонстрационной удаляем собаку, а список из одного элемента КОТ -список окажется пустым, что некорректно
            {
                beg = end = null;
                return true;
            }
            if (pos.Previous == null)
            {
                beg = beg.Next;
                beg.Previous = null;
                return true;
            }
            if (pos.Next == null)
            {
                end = end.Previous;
                end.Next = null;
                return true;
            }
            Point<T> next = pos.Next;
            Point<T> previous = pos.Previous;
            pos.Next.Previous = previous;
            pos.Previous.Next = next;
            return true;
        }
        // удаление конкретного объекта
        public bool RemoveItem(T item)
        {
            if (beg == null) return false;
            Point<T> pos = FindItem(item);
            if (pos == null) return false;
            return Remove(pos);
        }
        // удаление по инфополю-названию
        public bool RemoveName(T named)
        {
            if (beg == null) return false;
            Point<T>? pos = FindName(named);
            if (pos == null) return false;
            return Remove(pos);
        }
        // поиск по инфополю-названию
        public Point<T>? FindName(T named)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data.NameEquals(named))
                    return current;
                current = current.Next;
            }
            return null;
        }

        // Формулировка задания: Добавить в список элемент после элемента с заданным информационным полем (например, с заданным именем).
        // Что делаю: Добавляю после ПОЛНОСТЬЮ заданного элемента
        public bool AddItem(T added, T named)
        {
            if (beg == null) return false;
            Point<T>? pos = FindName(named);
            if (pos == null) return false;
            count++;
            Point<T> newItem = new Point<T>(added);
            if (pos.Next == null)
            {
                pos.Next = newItem;
                newItem.Previous = pos;
                end = newItem;
                return true;
            }
            Point<T> next = pos.Next;
            newItem.Next = next;
            newItem.Previous = pos;
            next.Previous = newItem;
            pos.Next = newItem;
            return true;
        }

        // Формулировка задания: Удалить из списка все элементы с заданным информационным полем (например, с заданным именем).
        // Что делаю: Удаляю все объекты с заданным названием
        public bool RemoveAllItems(T named)
        {
            bool isRemove = RemoveName(named);
            while (isRemove)
            {
                isRemove = RemoveName(named);
            }
            return true;
        }

        public MyList<T> Clone()
        {
            MyList<T> cloneList = new MyList<T>();
            if (count == 0) return cloneList;
            Point<T> current = beg;
            for (int i = 0; current != null; i++)
            {
                cloneList.AddToEnd(current.Data);
                current = current.Next;
            }
            return cloneList;
        }

        public void Clear()
        {
            Point<T> current = beg;
            for (int i = 0; current != null; i++)
            {
                Remove(current);
                current = current.Next;
            }
            count = 0;
        }
    }
}
