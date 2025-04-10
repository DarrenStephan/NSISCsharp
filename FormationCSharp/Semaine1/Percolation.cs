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
    internal class PercolationClass
    {
        /* reponses au questions du sujet:
         * 3b) la taille au carré
         * 3c) car il faudrait que toute les cases soit ouvertes sauf celle que l'on vient d'ajouter
         */
        static void Main(string[] args)
        {
            PclData data = PercolationSimulation.MeanPercolationValue(10, 100);
            Console.WriteLine(data.moyenne);
            Console.WriteLine(data.ecartType);

            Console.ReadKey();
        }

        struct Percolation
        {
            bool[][] open;
            bool[][] full;
            public int size;

            public Percolation(int size)
            {
                this.size = size;
                this.open = new bool[size][];
                this.full = new bool[size][];
                for (int i = 0; i < size; i++)
                {
                    this.open[i] = new bool[size];
                    this.full[i] = new bool[size];
                }
            }

            public bool IsOpen(int x, int y)
            {
                return open[x][y];
            }

            public bool IsFull(int x, int y)
            {
                return full[x][y];
            }

            /* ouvre une case du tableau et effectue les traitement necessaire
             * si une des cases adjacentes est rempli on rempli la case et on repete pour toute les cases
             * adjacentes qui sont ouvertes et non rempli
             */
            public void Open(int x, int y)
            {
                open[x][y] = true;
                if (x == 0) full[x][y] = true;
                List<KeyValuePair<int, int>> lst = CloseNeighbors(x, y);
                var self = this;
                if(lst.Any(kv => self.IsFull(kv.Key, kv.Value)))
                {
                    full[x][y] = true;

                    var qOpen = new Queue<KeyValuePair<int, int>>();
                    qOpen.Enqueue(new KeyValuePair<int, int>(x, y));
                    while (qOpen.Count() != 0)
                    {
                        var act = qOpen.Dequeue();
                        foreach(KeyValuePair<int, int> kv in CloseNeighbors(act.Key, act.Value))
                        {
                            int i = kv.Key;
                            int j = kv.Value;
                            if(IsOpen(i, j) && !IsFull(i, j))
                            {
                                full[i][j] = true;
                                qOpen.Enqueue(kv);
                            }
                        }
                    }
                }
            }

            public bool Percolate()
            {
                return full[size-1].Any(a => a); 
            }

            public List<KeyValuePair<int, int>> CloseNeighbors(int x, int y)
            {
                List<KeyValuePair<int, int>> res = new List<KeyValuePair<int, int>>();
                if (y > 0)
                {
                    res.Add(new KeyValuePair<int, int>(x, y-1));
                }
                if (y < size -1)
                {
                    res.Add(new KeyValuePair<int, int>(x, y + 1));
                }
                if (x > 0)
                {
                    res.Add(new KeyValuePair<int, int>(x - 1, y));
                }
                if (x < size - 1)
                {
                    res.Add(new KeyValuePair<int, int>(x + 1 , y));
                }
                return res;
            }

            public int NumberOpen()
            {
                int res = 0;
                for(int i = 0; i<size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (open[i][j]) res++;
                    }
                }
                return res;
            }

            /* fonction d'affichage d'un tableau 
             * ouvert : O
             * rempli : V
             * fermé : X
             */
            public void Display()
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (full[i][j]) Console.Write("V");
                        else if (open[i][j]) Console.Write("O");
                        else Console.Write("X");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        struct PercolationSimulation
        {
            public static double PercolationValue(int size)
            {
                Percolation percolation = new Percolation(size);
                Random rand = new Random();
                while (!percolation.Percolate())
                {
                    int x = rand.Next(size);
                    int y = rand.Next(size);
                    percolation.Open(x, y);
                }
                return (double)percolation.NumberOpen() / (size * size);
            }

            public static PclData MeanPercolationValue(int size, int count)
            {
                List<double> liste = new List<double>();
                for(int i = 0; i < count; i++)
                {
                    liste.Add(PercolationValue(size));
                }
                PclData pclData = new PclData();
                pclData.moyenne = liste.Sum() / count;
                double sommeDesCarres = liste.Sum(x => Math.Pow(x - pclData.moyenne, 2));
                double variance = sommeDesCarres / liste.Count();
                pclData.ecartType = (double)Math.Sqrt(variance);
                return pclData;
            }
        }

        struct PclData
        {
            public double moyenne;
            public double ecartType;

            public PclData(double moyenne, double ecartType)
            {
                this.moyenne = moyenne;
                this.ecartType = ecartType;
            }
        }
    }
}
