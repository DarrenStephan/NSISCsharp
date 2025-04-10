using System;
using System.Diagnostics;
using System.IO;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Semaine1
{
    internal class Serie2
    {
        
        static void Main(string[] args)
        {
            /*
            string str = "  zazaz ttt";
            string[] t = str.Split('t');
            string z = String.Join(";", t);
            Console.WriteLine(str.TrimStart(' ').TrimEnd('t'));

            StringBuilder stringBuilder = new StringBuilder();
            for(int i=1; i <= 100; i++)
            {
                stringBuilder.Append(i + "-");
            }
            Console.WriteLine(stringBuilder.ToString());
            
            Console.ReadKey();

            using (FileStream fs = File.Create("C:\\Users\\Formation\\Documents\\test.txt"))
            {
                fs.Close();
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Formation\\Documents\\test.txt") )
            {
                string ligne;
                while ((ligne = Console.ReadLine()) != "")
                {
                    writer.WriteLine(ligne);
                }
            }

            using (StreamReader reader = new StreamReader("C:\\Users\\Formation\\Documents\\test.txt"))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {
                    Console.WriteLine(ligne);
                }
            }*/
            //SchoolMeans("C:\\Users\\Formation\\Documents\\notes.csv", "C:\\Users\\Formation\\Documents\\resultat.csv");

            //QuickSort(lst, 0, lst.Count()-1);
            //for (int i = 0; i < lst.Count(); i++) Console.Write(lst[i] + "|");
            //List<List<int>> lsts = ArraysGenerator(10000);
            //Console.WriteLine(useQuickSort(lsts[0]));
            //Console.WriteLine(useInsertionSort(lsts[1]));

            List<int> sizes = new List<int>() { 2000, 5000, 10000, 20000 }; //50000, 100000 };
            DisplayPerformances(sizes, 50);

            Console.ReadKey();
        }

        public static void SchoolMeans(string input, string output)
        {
            List<string> lstMatiere = new List<string>();
            List<float> lstNotes = new List<float>();
            List<int> lstNbNotes = new List<int>();
            using (StreamReader reader = new StreamReader(input))
            {
                string ligne;
                while ((ligne = reader.ReadLine()) != null)
                {
                    string[] ligneTab = ligne.Split(';');
                    int index = lstMatiere.IndexOf(ligneTab[1]);
                    if (index == -1)
                    {
                        lstMatiere.Add(ligneTab[1]);
                        lstNotes.Add(float.Parse(ligneTab[2].Replace('.', ',')));
                        lstNbNotes.Add(1);
                    }
                    else
                    {
                        lstNotes[index] += float.Parse(ligneTab[2].Replace('.', ','));
                        lstNbNotes[index] += 1;
                    }
                }
                using (StreamWriter writer = new StreamWriter(output))
                {
                    for(int i = 0; i < lstMatiere.Count(); i++)
                    {
                        float moyenne = (float)Math.Round(lstNotes[i] / lstNbNotes[i], 1);
                        writer.WriteLine(lstMatiere[i] + ";" + moyenne);
                    }
                }
            }
        }

        public static void InsertionSort(List<int> lst)
        {
            for(int i=1; i < lst.Count(); i++)
            {
                int index = i;
                int value = lst[i];
                while (index != 0 && lst[index-1] > value)
                {
                    index--;
                }
                lst.RemoveAt(i);
                lst.Insert(index, value);
            }
        }

        public static void QuickSort(List<int> lst, int low, int high)
        {
            if (low < high)
            {
                int pivot = lst[high];
                int i = (low - 1);

                for (int j = low; j <= high - 1; j++)
                {
                    if (lst[j] < pivot)
                    {
                        i++;
                        Swap(lst, i, j);
                    }
                }

                Swap(lst, i + 1, high);

                int pivotIndex = i + 1;

                QuickSort(lst, low, pivotIndex - 1); 
                QuickSort(lst, pivotIndex + 1, high);
            }
        }

        public static void Swap(List<int> lst, int indexA, int indexB)
        {
            int temp = lst[indexA];
            lst[indexA] = lst[indexB];
            lst[indexB] = temp;
        }

        public static long useQuickSort(List<int> lst)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            QuickSort(lst, 0, lst.Count()-1);

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static long useInsertionSort(List<int> lst)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            InsertionSort(lst);

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public static List<List<int>> ArraysGenerator(int size)
        {
            List<List<int>> res = new List<List<int>>();
            res.Add(new List<int>());
            res.Add(new List<int>());
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                int rand = random.Next();
                res[0].Add(rand);
                res[1].Add(rand);
            }

            return res;
        }

        public struct SortData
        {
            public long InsertionMean;
            public long InsertionStd;
            public long QuickMean;
            public long QuickStd;
        }
        public static SortData PerformanceTest(int size, int count)
        {
            List<List<int>> lsts;
            List<long> quickRes = new List<long>();
            List<long> insertRes = new List<long>();
            for (int i = 0; i < count; i++)
            {
                lsts = ArraysGenerator(size);
                quickRes.Add(useQuickSort(lsts[0]));
                insertRes.Add(useInsertionSort(lsts[1]));
            }
            SortData sortData = new SortData();
            sortData.QuickMean = quickRes.Sum() / count;
            sortData.InsertionMean = insertRes.Sum() / count;
            sortData.QuickStd = CalculerEcartType(quickRes);
            sortData.InsertionStd = CalculerEcartType(insertRes);
            return sortData;
        }

        static long CalculerEcartType(List<long> liste)
        {
            double moyenne = liste.Sum() / liste.Count();
            double sommeDesCarres = liste.Sum(x => Math.Pow(x - moyenne, 2));
            double variance = sommeDesCarres / liste.Count();

            return (long)Math.Sqrt(variance);
        }

        public static List<SortData> PerformancesTest(List<int> sizes, int count)
        {
            
            List<SortData> res = new List<SortData>();
            foreach (int size in sizes)
            {
                res.Add(PerformanceTest(size, count));
            }
            return res;
        }
        
        public static void DisplayPerformances(List<int> sizes, int count)
        {
            List<SortData> lst = PerformancesTest(sizes, count);
            Console.WriteLine("n;MeanInsertion;StdInsertion;MeanQuick;StdQuick");
            int index = 0;
            foreach(SortData sortData in lst)
            {
                Console.WriteLine($"{sizes[index]};{sortData.InsertionMean};{sortData.InsertionStd};{sortData.QuickMean};{sortData.QuickStd};");
                index++;
            }
        }
    }
}
