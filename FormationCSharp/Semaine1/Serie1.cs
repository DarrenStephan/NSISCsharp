using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine1
{
    internal class Serie1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercice 1: opérations de base");
            BasicOperation(7, 8, '+');
            BasicOperation(7, 8, '-');
            BasicOperation(7, 8, '*');
            BasicOperation(8, 4, '/');
            BasicOperation(8, 0, '/');
            Console.WriteLine("Exercice 1: division entiere");
            IntegerDivision(12, 5);
            IntegerDivision(12, 4);
            IntegerDivision(12, 0);
            Console.WriteLine("Exercice 1: POW");
            Pow(2, 3);
            Pow(3, 3);
            Pow(6, 5);
            Pow(3, 0);
            Pow(3, -1);
            Console.WriteLine("Exercice 2: Horloge parlante");
            GoodDay(0);
            GoodDay(2);
            GoodDay(6);
            GoodDay(8);
            GoodDay(11);
            GoodDay(12);
            GoodDay(13);
            GoodDay(16);
            GoodDay(18);
            GoodDay(20);
            GoodDay(24);
            Console.WriteLine("Exercice 3: pyramide");
            PyramidConstruction(10, false);
            PyramidConstruction(10, true);
            Console.WriteLine("Exercice 4: Factoriell");
            Console.WriteLine(Factorielle(5));
            Console.WriteLine(Factorielle(7));
            Console.WriteLine(Factorielle(8));
            Console.WriteLine(Factorielle(0));
            Console.WriteLine(FactorielleRecursive(5));
            Console.WriteLine(FactorielleRecursive(7));
            Console.WriteLine(FactorielleRecursive(8));
            Console.WriteLine(FactorielleRecursive(0));
            Console.WriteLine("Exercice 5: Prime");
            DisplayPrimes(100);
            Console.WriteLine("Exercice 6: PGCD");
            Console.WriteLine(Gcd(10, 5));
            Console.WriteLine(Gcd(7, 3));
            Console.WriteLine(Gcd(15, 25));
            Console.WriteLine(Gcd(36, 60));
            Console.WriteLine(Gcd(1, 5));
            Console.WriteLine(Gcd(45, 45));
            Console.WriteLine(Gcd(29, 97));
            Console.WriteLine(Gcd(12, 36));
            Console.ReadKey();
        }

        static void BasicOperation(int a, int b, char ope)
        {
            switch(ope){
                case '+':
                    Console.WriteLine($"{a} {ope} {b} = {a + b}");
                    break;
                case '-':
                    Console.WriteLine($"{a} {ope} {b} = {a - b}");
                    break;
                case '*':
                    Console.WriteLine($"{a} {ope} {b} = {a * b}");
                    break;
                case '/':
                    if(b == 0)
                    {
                        Console.WriteLine($"{a} {ope} {b} = Opération invalide");
                    } 
                    else
                    {
                        Console.WriteLine($"{a} {ope} {b} = {a / b}");
                    }
                    break;
                default:
                    Console.WriteLine($"{a} {ope} {b} Opération invalide");
                    break;
            }
        }
        
        static void IntegerDivision(int a, int b)
        {
            if(b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération invalide");
                return;
            }
            int q = a / b; 
            int r = a % b;
            if(r == 0)
            {
                Console.WriteLine($"{a} = {q} * {b}");
            }else
            {
                Console.WriteLine($"{a} = {q} * {b} + {r}");
            }
        }

        static void Pow(int a, int b)
        {
            if (b < 0)
            {
                Console.WriteLine("Opération invalide");
                return;
            }
            int res = 1;
            for(int i=0; i < b; i++) {
                res *= a;
            }
            Console.WriteLine($"{a} ^ {b} = {res}");
        }

        static void GoodDay(int heure)
        {
            string message = "";
            switch(heure)
            {
                case int n when (heure < 6 || heure == 24):
                    message = "Merveilleuse nuit!";
                    break;
                case int n when (heure < 12):
                    message = "Bonne matinée!";
                    break;
                case int n when (heure == 12):
                    message = "Bon apétit!";
                    break;
                case int n when (heure < 18):
                    message = "Profitez de votre après-midi!";
                    break;
                case int n when (heure < 24):
                    message = "A mimir!";
                    break;

            }
            Console.WriteLine($"Il est {heure} heure, {message}");
        }

        static void PyramidConstruction(int n, bool isSmooth)
        {
            char c = '+';
            for(int i=1; i <= n; i++)
            {
                if (!isSmooth)
                {
                    if(i % 2 == 0)
                    {
                        c = '-';
                    } else
                    {
                        c = '+';
                    }
                }
                for(int j=0; j<= n-i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i * 2 - 1); j++)
                {
                    Console.Write(c);
                }
                for (int j = 0; j <= n - i; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        static int Factorielle(int n)
        {
            int res = 1;
            for(int i=1; i <= n; i++)
            {
                res *= i;
            }
            return res;
        }

        static int FactorielleRecursive(int n)
        {
            if(n == 0) return 1;
            return n * FactorielleRecursive(n - 1);
        }

        static bool isPrime(int value)
        {
            if (value == 1) return false;
            for(int i = 2; i <= Math.Sqrt(value); i++)
            {
                if(value % i == 0) return false;
            }
            return true;
        }

        static void DisplayPrimes(int n)
        {
            for(int i=1; i<n; i++)
            {
                if (isPrime(i)) Console.WriteLine(i);
            }
        }

        static int Gcd(int a, int b)
        {
            return a % b == 0 ? b : Gcd(b, a % b);
        }
    }
}
