using System;
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
        public enum Genre
        {
            M,
            F,
            N,
        }

        public struct Person
        {
            public string nom;
            public string prenom;
            public int age;
            public Genre genre;

            public string toString()
            {
                return "zaza";
            }

            public Person(string Nom, string Prenom, int Age, char genre)
            {
                nom = Nom;
                prenom = Prenom;    
                age = Age;
                switch (genre)
                {
                    case 'M': this.genre = Genre.M; break;
                    case 'F': this.genre = Genre.F; break;
                    case 'N': this.genre = Genre.N; break;
                    default: this.genre = Genre.N; break;
                }
            }
        }

        public struct Car
        {
            string marque;
            string modele;
            bool isElectric;
            bool isManual;
            bool siegeChauffant;
            bool is4WD;
            int chevaux;
        }
        static void Main(string[] args)
        {
            /*
            int[] tableau1 = new int[5]; // Tableau de taille 5 , valeurs des é l é ments à 0.
            int[] tableau2 = new int[] { 1, 3, 5, 7, 9 }; // Initialisation des é l é ments .
            int[] tableau3 = { 1, 3, 5, 7, 9, 11, 13 }; // Notation alternative .

            Person george;
            george.prenom = "Gerard";
            george.nom = "Menvuca";
            george.age = 25;
            george.genre = Genre.M;

            //Console.WriteLine("ee");
            //Console.WriteLine(george.toString());

            //maFonction(8, 5, 6, 45);

            List<string> lstMot = new List<string>()
            {
                "enamone",
                "maxouille",
                "Raph",
                "Zizou",
                "gzavier"
            };


            string str1 = "zaza";
            string str2 = str1;

            Console.WriteLine(str1);
            str2 = "pop";
            Console.WriteLine(str1);


            int testa = 2;
            Console.WriteLine(testa);
            aaa(ref testa);
            Console.WriteLine(testa);
            */
            /*
            int[] tableau = { 1, 3, 5, 7, 9, 11, 13 }; // Notation alternative 
            Console.WriteLine(Linearsearch(tableau, 5));
            Console.WriteLine(Linearsearch(tableau, 7));
            Console.WriteLine(Linearsearch(tableau, 9));
            Console.WriteLine(Dichotomie(tableau, 5));
            Console.WriteLine(Dichotomie(tableau, 7));
            Console.WriteLine(Dichotomie(tableau, 9));
            matrice();
            int[] eratosthene = Eratosthene(100);
            Console.WriteLine("Nombres preimer entre 2 et 100");
            for (int i = 0; i < eratosthene.Length; i++) Console.Write(eratosthene[i] + ",");
            Console.ReadKey();
            QuestionPourUnPicon();*/

            int[] tableau = { 1, 3, 5, 7, 10, 11, 13 };

            Console.WriteLine(Linearsearch(tableau, 6));
            Console.WriteLine(Linearsearch(tableau, 3));
            Console.ReadKey();
        }

        public static void maFonction(params int[] tab)
        {
            int res = 0;
            foreach (int i in tab)
            {
                res += i;
            }
            Console.WriteLine(res);
        }

        public static void aaa(ref int a)
        {
            a = 3;
        }

        public static bool Linearsearch(int[] tab, int val)
        {
            return tab.Any(n => n % 2 == 0);
            /*for(int i=0; i<tab.Length;i++)
            {
                if (tab[i] == val) return i;
            }
            return -1;*/
        }

        public static int Dichotomie(int[] tab, int val)
        {
            int min = 0;
            int max = tab.Length-1;
            while (true)
            {
                int middle = (min + max) / 2;
                if (tab[middle] == val) return middle;
                if (tab[middle] > val)
                {
                    max = middle;
                }
                if (tab[middle] < val)
                {
                    min = middle;
                }
            }
        }

        public static void matrice()
        {
            /*int[] leftvector = { 1, 2, 3 };
            int[] rightvector = { -1, -4, 0 };
            int[] leftvector2 = { 3, 2, -2 };
            int[] rightvector2 = { 4, 2, 5 };
            int[][] matrice = BuildingMatrix(leftvector, rightvector);
            int[][] matrice2 = BuildingMatrix(leftvector2, rightvector2);
            int[][] matriceAdd = AdditionMatrice(matrice, matrice2);
            int[][] matriceSub = SoustractionMatrice(matrice, matrice2);
            Console.WriteLine("matrice 1");
            AfficherMatrice(matrice);
            Console.WriteLine("matrice 2");
            AfficherMatrice(matrice2);
            Console.WriteLine("matrice addition");
            AfficherMatrice(matriceAdd);
            Console.WriteLine("matrice soustraction");
            AfficherMatrice(matriceSub);
            int[][] matriceMult1 = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 4, 6 },
                new int[] { -1, 8 }
            };
            int[][] matriceMult2 = new int[][]
            {
                new int[] { -1, 5, 0 },
                new int[] { -4, 0, 1 }
            };
            Console.WriteLine("matrice multiplication");
            AfficherMatrice(MultiplicationMatrice(matriceMult1, matriceMult2));
            AfficherMatrice(matriceMult1);
            AfficherMatrice(matriceMult2);*/

        }

        public static void AfficherMatrice(int[][] matrice)
        {
            for (int i = 0; i < matrice.Length; i++)
            {
                for (int j = 0; j < matrice[0].Length; j++)
                {
                    Console.Write(matrice[i][j] + "|");
                }
                Console.WriteLine();
            }
        }

        public static int[][] BuildingMatrix(int[] leftvector, int[] rightvector)
        {
            int leftLength = leftvector.Length;
            int rightLength = rightvector.Length;
            int[][] res = new int[leftLength][];
            for(int i = 0; i < leftLength; i++)
            {
                res[i] = new int[rightLength];
            }

            for (int i = 0; i < leftLength; i++)
            {
                for (int j = 0; j < rightLength; j++)
                {
                    res[i][j] = leftvector[i] * rightvector[j];
                }
            }
            return res;
        }

        public static int[][] AdditionMatrice(int[][] leftMatrice, int[][] rightMatrice)
        {
            int leftLength = leftMatrice.Length;
            int rightLength = rightMatrice.Length;
            int[][] res = new int[leftLength][];
            for (int i = 0; i < leftLength; i++)
            {
                res[i] = new int[rightLength];
            }

            for (int i = 0; i < leftLength; i++)
            {
                for (int j = 0; j < rightLength; j++)
                {
                    res[i][j] = leftMatrice[i][j] + rightMatrice[i][j];
                }
            }
            return res;
        }

        public static int[][] SoustractionMatrice(int[][] leftMatrice, int[][] rightMatrice)
        {
            int leftLength = leftMatrice.Length;
            int rightLength = rightMatrice.Length;
            int[][] res = new int[leftLength][];
            for (int i = 0; i < leftLength; i++)
            {
                res[i] = new int[rightLength];
            }

            for (int i = 0; i < leftLength; i++)
            {
                for (int j = 0; j < rightLength; j++)
                {
                    res[i][j] = leftMatrice[i][j] -  rightMatrice[i][j];
                }
            }
            return res;
        }

        public static int[][] MultiplicationMatrice(int[][] leftMatrice, int[][] rightMatrice)
        {
            int leftLength = leftMatrice.Length;
            int rightLength = rightMatrice.Length;
            int[][] res = new int[leftLength][];
            for (int i = 0; i < leftLength; i++)
            {
                res[i] = new int[leftLength];
            }
            if (leftLength != rightMatrice[0].Length || rightLength != leftMatrice[0].Length) return res;

            for (int i = 0; i < leftLength; i++)
            {
                for (int j = 0; j < leftLength; j++)
                {
                    for(int n=0; n<rightLength; n++)
                    {
                        res[i][j] += leftMatrice[i][n] * rightMatrice[n][j];
                    }
                }
            }
            return res;
        }

        public static int[] Eratosthene(int n)
        {
            //initialisation du tableau de valeurs
            int[] tab = new int[n];
            for(int i=0; i< n; i++)
            {
                tab[i] = i+1;
            }
            tab[0] = 0;
            //algorithme d'eratosthene
            for(int i=1; i<Math.Sqrt(n);i++)
            {
                if (tab[i] != 0)
                {
                    for(int j=i+1; j<n; j++)       
                    {                              
                        if (tab[j] % tab[i] == 0)  
                        {
                            tab[j] = 0;
                        }
                    }
                }
            }
            //calcul du nombre de chiffre premier dans le tableau de valeurs
            int nbChiffrePremier = 0;
            for (int i = 0; i < n; i++)
            {
                if (tab[i] != 0) nbChiffrePremier++;
            }
            //initialisation du tableau de retour avec les chiffres premier du tableau de valeurs
            int[] res = new int[nbChiffrePremier];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if (tab[i] != 0)
                {
                    res[index] = tab[i];
                    index++;
                }
            }
            return res;
        }

        public struct Qcm
        {
            public string question;
            public string[] reponses;
            public int solution;
            public int poids;

            public Qcm(string question, string[] reponses, int solution, int poids)
            {
                this.question = question;
                this.reponses = reponses;
                this.solution = solution;
                this.poids = poids;
            }
        }

        public static void QuestionPourUnPicon()
        {
            Qcm[] questions = new Qcm[]
            {
                new Qcm("zaza", new string[]{"2", "3", "4"}, -1, 1),
                new Qcm("zaza", new string[]{"2", "3", "4"}, 10, 1),
                new Qcm("zaza", new string[]{"2", "3", "4"}, -1, 1),
                new Qcm("D'ou vient Yannick ?", new string[]{"Normandie", "Nord pas de Calais", "Espagne", "Bretagne"}, 4, 1),
                new Qcm("Quel age a Darren?", new string[]{"12", "20", "38", "22"}, 2, 1),
                new Qcm("Quel est la passion de Nicolas?", new string[]{"Les voitures", "Le whiskey", "Les avions", "Le padle"}, 3, 1),
                new Qcm("Quel est la marque de voiture de Raph?", new string[]{"Nissan >-<", "Citroen", "Skoda", "Peugeot"}, 3, 2),
                new Qcm("Quel jour Sullivan devient il fou?", new string[]{"lundi", "mardi", "mercredi", "jeudi", "vendredi"}, 5, 2),
                new Qcm("Ou Franck part-il en vacance?", new string[]{"Ecosse", "Lille", "Irlande", "Espagne"}, 3, 2),
            };
            int resultat = 0;
            foreach(Qcm qcm in questions)
            {
                try
                {
                    resultat += AskQuestion(qcm);
                } catch (ArgumentException){
                    Console.WriteLine("question invalide : " + qcm.question);
                }
            }
            int noteMax = 0;
            foreach (Qcm qcm in questions) if (QcmValidity(qcm)) noteMax += qcm.poids;
            Console.WriteLine($"Resultat du questionnaire : {resultat} / {noteMax}");
        }

        public static bool QcmValidity(Qcm qcm)
        {
            return (qcm.solution >= 0 && qcm.solution <= qcm.reponses.Length && qcm.poids > 0);
        }

        public static int AskQuestion(Qcm qcm) 
        {
            if (!QcmValidity(qcm)) throw new ArgumentException();
            Console.WriteLine(qcm.question);
            for(int i=0; i< qcm.reponses.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + qcm.reponses[i]);
            }
            Console.Write("Reponse : ");
            int reponse = int.Parse(Console.ReadLine());
            while ((reponse < 0 || reponse > qcm.reponses.Length))
            {
                Console.WriteLine("Reponse Invalide!");
                Console.Write("Reponse : ");
                reponse = int.Parse(Console.ReadLine());
            }
            if (reponse == qcm.solution) return qcm.poids;
            return 0;
        }
    }
}
