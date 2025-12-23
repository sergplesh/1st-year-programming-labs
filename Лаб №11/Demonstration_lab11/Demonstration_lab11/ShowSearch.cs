using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GeometrucShapeCarLibrary;

namespace Demonstration_lab11
{
    public class ShowSearch
    {
        public static long SearchSet(TestCollections collections, Rectangle search, ref bool ok, int choise)
        {
            Stopwatch sw = new Stopwatch();
            if (choise == 1)
            {
                sw.Restart();
                ok = collections.col1.Contains(search);
                sw.Stop();
            }
            else if (choise == 2)
            {
                string searched = search.ToString();
                sw.Restart();
                ok = collections.col2.Contains(searched);
                sw.Stop();
            }
            else if (choise == 3)
            {
                Shape searched = search.GetBase;
                sw.Restart();
                ok = collections.col3.Contains(searched);
                sw.Stop();
            }
            else if (choise == 4)
            {
                string searched = search.GetBase.ToString();
                sw.Restart();
                ok = collections.col4.Contains(searched);
                sw.Stop();
            }
            return sw.ElapsedTicks;
        }
        public static void Search(TestCollections collections, Rectangle first, Rectangle middle, Rectangle last, Rectangle noexist)
        {
            bool ok11 = false, ok12 = false, ok13 = false, ok14 = false;
            long timeOk11 = SearchSet(collections, first, ref ok11, 1);
            long timeOk12 = SearchSet(collections, middle, ref ok12, 1);
            long timeOk13 = SearchSet(collections, last, ref ok13, 1);
            long timeOk14 = SearchSet(collections, noexist, ref ok14, 1);
            bool ok21 = false, ok22 = false, ok23 = false, ok24 = false;
            long timeOk21 = SearchSet(collections, first, ref ok21, 2);
            long timeOk22 = SearchSet(collections, middle, ref ok22, 2);
            long timeOk23 = SearchSet(collections, last, ref ok23, 2);
            long timeOk24 = SearchSet(collections, noexist, ref ok24, 2);
            bool ok31 = false, ok32 = false, ok33 = false, ok34 = false;
            long timeOk31 = SearchSet(collections, first, ref ok31, 3);
            long timeOk32 = SearchSet(collections, middle, ref ok32, 3);
            long timeOk33 = SearchSet(collections, last, ref ok33, 3);
            long timeOk34 = SearchSet(collections, noexist, ref ok34, 3);
            bool ok41 = false, ok42 = false, ok43 = false, ok44 = false;
            long timeOk41 = SearchSet(collections, first, ref ok41, 4);
            long timeOk42 = SearchSet(collections, middle, ref ok42, 4);
            long timeOk43 = SearchSet(collections, last, ref ok43, 4);
            long timeOk44 = SearchSet(collections, noexist, ref ok44, 4);

            Console.WriteLine("|" + String.Format("{0,24}", "Коллекции|") + String.Format("{0,10}", "first|") + String.Format("{0,10}", "Нашёл|") + String.Format("{0,10}", "middle|") + String.Format("{0,10}", "Нашёл|") + String.Format("{0,10}", "last|") + String.Format("{0,10}", "Нашёл|") + String.Format("{0,10}", "noexist|") + String.Format("{0,10}", "Нашёл|"));
            Console.WriteLine("|" + String.Format("{0,24}", "SortedSet<Rectangle>|") + String.Format("{0,10}", timeOk11 + "|") + String.Format("{0,10}", ok11 + "|") + String.Format("{0,10}", timeOk12 + "|") + String.Format("{0,10}", ok12 + "|") + String.Format("{0,10}", timeOk13 + "|") + String.Format("{0,10}", ok13 + "|") + String.Format("{0,10}", timeOk14 + "|") + String.Format("{0,10}", ok14 + "|"));
            Console.WriteLine("|" + String.Format("{0,24}", "SortedSet<string>|") + String.Format("{0,10}", timeOk21 + "|") + String.Format("{0,10}", ok21 + "|") + String.Format("{0,10}", timeOk22 + "|") + String.Format("{0,10}", ok22 + "|") + String.Format("{0,10}", timeOk23 + "|") + String.Format("{0,10}", ok23 + "|") + String.Format("{0,10}", timeOk24 + "|") + String.Format("{0,10}", ok24 + "|"));
            Console.WriteLine("|" + String.Format("{0,24}", "HashSet<Shape>|") + String.Format("{0,10}", timeOk31 + "|") + String.Format("{0,10}", ok31 + "|") + String.Format("{0,10}", timeOk32 + "|") + String.Format("{0,10}", ok32 + "|") + String.Format("{0,10}", timeOk33 + "|") + String.Format("{0,10}", ok33 + "|") + String.Format("{0,10}", timeOk34 + "|") + String.Format("{0,10}", ok34 + "|"));
            Console.WriteLine("|" + String.Format("{0,24}", "HashSet<string>|") + String.Format("{0,10}", timeOk41 + "|") + String.Format("{0,10}", ok41 + "|") + String.Format("{0,10}", timeOk42 + "|") + String.Format("{0,10}", ok42 + "|") + String.Format("{0,10}", timeOk43 + "|") + String.Format("{0,10}", ok43 + "|") + String.Format("{0,10}", timeOk44 + "|") + String.Format("{0,10}", ok44 + "|"));
        }
    }
}

