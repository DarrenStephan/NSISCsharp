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
    internal class Serie4
    {
        /* reponses au question : 
         * exercice 1 1. pour chaque code morse il faut pouvoir stocker la lettre correspondante 
         *               une liste n'est pas pratique à utiliser dans cette situation car les valeurs 
         *               sont recupérés à partir d'index avec un dictionnaire on peut recuperer une lettre
         *               à partir de sa valeur morse en faisant dct[stringMorse]. 
         * exercice 2 1. pour le stockage des parenthese ouvrante et leurs parenthese fermante correspondante le dictionnaire est 
         *               le plus interessant car il permet de stocker une clé et sa valeur <ouvert, fermé>
         *               pour le stockage des parenthese recupéré dans la phrase en parametre la Queue est tres pratique car elle
         *               va permettre de gerer les cas d'imbrications tres facilement en ajoutant une parenthese ouvrante et en la
         *               retirant quand on la ferme.
         * exercice 3 1. La structure adaptée à cette situation est le dictionnaire car il va permmetre de stocker
         *               le nom du contact pour un numéro de téléphone
         * exercice 4 1. debut: N milieu: N/2 fin: 0 car il faut echanger tout les elements apres celui qu'on a inseré
         * exercice 4 2. non-triés: on doit parcourir toute la liste jusqu'a trouver la valeur donc O(N)
         *               triés: recherche dichotomique donc O(logN)
         */
        const string SeparateurMot = ".....";
        const string SeparateurLettre = "...";

        public static Dictionary<char, string> morseCode = new Dictionary<char, string>()
            {
                {'A', "=.==="},
                {'B', "===.=.=.="},
                {'C', "===.=.===.="},
                {'D', "===.=.="},
                {'E', "="},
                {'F', "=.=.===.="},
                {'G', "===.===.="},
                {'H', "=.=.=.="},
                {'I', "=.="},
                {'J', "=.===.===.==="},
                {'K', "===.=.==="},
                {'L', "=.===.=.="},
                {'M', "===.==="},
                {'N', "===.="},
                {'O', "===.===.==="},
                {'P', "=.===.===.="},
                {'Q', "===.===.=.==="},
                {'R', "=.===.="},
                {'S', "=.=.="},
                {'T', "==="},
                {'U', "=.=.==="},
                {'V', "=.=.=.==="},
                {'W', "=.===.==="},
                {'X', "===.=.=.==="},
                {'Y', "===.=.===.==="},
                {'Z', "===.===.=.="}
            };
        // Inversion du dictionnaire : morse -> caractère
        public static Dictionary<string, char> reversedMorseCode = morseCode.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        static void Main(string[] args)
        {

            /*string code = "=.=.=.=...=...=.===.=.=...=.===.=.=...===.===.===.....=.===.===...===.===.===...=.===.=...=.===.=.=...===.=.=";
            string codeError = "=.=.=.=...=...=.===.=.=...=.===.=.=...===.===.===.....=.===.===...===.===.===...error...=.===.=...=.===.=.=...===.=.=";
            string codeImperfections = "=.=.=.=...=....=.===.=..=...=.===.=..=....===.===.===.......=.===.===...===.===.===....=.===.=...=.===.=.=...===.=.=";
            Console.WriteLine(LettersCount(code));
            Console.WriteLine(WordsCount(code));
            Console.WriteLine(MorseTranslation(code));
            Console.WriteLine(MorseTranslation(codeError));
            Console.WriteLine(MorseTranslation(codeImperfections));
            Console.WriteLine(MorseEncryption("HELLO WORLD"));
            Console.WriteLine(MorseTranslation(MorseEncryption("HELLO WORLD")));

            Console.WriteLine(BracketsControls("([{}])"));
            Console.WriteLine(BracketsControls("([]{})"));
            Console.WriteLine(BracketsControls("([]{)"));
            Console.WriteLine(BracketsControls("([bbb]{aa})"));*/

            //TestPhoneBook();

            BusinessSchedule businessSchedule = new BusinessSchedule(true);
            businessSchedule.Schedule.Add(new DateTime(2025, 4, 10, 10, 30, 0), new DateTime(2025, 4, 10, 12, 00, 0));
            businessSchedule.Schedule.Add(new DateTime(2025, 4, 11, 14, 30, 0), new DateTime(2025, 4, 11, 16, 30, 0));
            businessSchedule.Schedule.Add(new DateTime(2025, 4, 12, 10, 30, 0), new DateTime(2025, 4, 12, 12, 00, 0));
            businessSchedule.Schedule.Add(new DateTime(2025, 4, 13, 10, 30, 0), new DateTime(2025, 4, 12, 13, 00, 0));
            //businessSchedule.DisplayMeetings();
            /*KeyValuePair<DateTime, DateTime> kvp;
            kvp = businessSchedule.ClosestElements(new DateTime(2025, 4, 11, 8, 30, 0));
            Console.WriteLine(kvp.Key.ToString() + " - " + kvp.Value.ToString());
            kvp = businessSchedule.ClosestElements(new DateTime(2025, 4, 12, 8, 30, 0));
            Console.WriteLine(kvp.Key.ToString() + " - " + kvp.Value.ToString());
            kvp = businessSchedule.ClosestElements(new DateTime(2025, 4, 9, 8, 30, 0));
            Console.WriteLine(kvp.Key.ToString() + " - " + kvp.Value.ToString());
            kvp = businessSchedule.ClosestElements(new DateTime(2025, 4, 14, 8, 30, 0));
            Console.WriteLine(kvp.Key.ToString() + " - " + kvp.Value.ToString());*/
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 11, 17, 30, 0), new TimeSpan(1, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 9, 17, 30, 0), new TimeSpan(1, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 14, 17, 30, 0), new TimeSpan(1, 0, 0));
            
            businessSchedule.AddBusinessMeeting(new DateTime(2010, 4, 14, 17, 30, 0), new TimeSpan(1, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2040, 4, 14, 17, 30, 0), new TimeSpan(1, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 11, 15, 30, 0), new TimeSpan(2, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 11, 13, 30, 0), new TimeSpan(2, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 11, 15, 0, 0), new TimeSpan(1, 0, 0));
            businessSchedule.AddBusinessMeeting(new DateTime(2025, 4, 11, 14, 30, 0), new TimeSpan(2, 0, 0));
            businessSchedule.DisplayMeetings();

            businessSchedule.ClearMeetingPeriod(new DateTime(2025, 4, 11, 15, 0, 0), new DateTime(2025, 4, 12, 11, 00, 0));
            businessSchedule.DisplayMeetings();

            Console.ReadKey();
        }

        public static int LettersCount(string code)
        {
            return code.Split(new string[] { SeparateurLettre }, StringSplitOptions.None).Length;
        }

        public static int WordsCount(string code)
        {
            return code.Split(new string[] { SeparateurMot }, StringSplitOptions.None).Length;
        }

        public static string MorseTranslation(string code)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] tabMot = code.Split(new string[] { SeparateurMot }, StringSplitOptions.None);
            foreach (string mot in tabMot)
            {
                string[] tabLettre = mot.Split(new string[] { SeparateurLettre }, StringSplitOptions.None);
                foreach (string lettre in tabLettre)
                {
                    char traduction;
                    try
                    {
                        traduction = reversedMorseCode[lettre.TrimStart('.').Replace("..", ".")];
                    } catch (KeyNotFoundException )
                    {
                        traduction = '+';
                    }
                    stringBuilder.Append(traduction);
                }
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }

        public static string MorseEncryption(string sentence)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char lettre in sentence)
            {
                if (lettre == ' ')
                {
                    stringBuilder.Remove(stringBuilder.Length - SeparateurLettre.Length, SeparateurLettre.Length);
                    stringBuilder.Append(SeparateurMot);
                }
                else
                {
                    string traduction;
                    try
                    {
                        traduction = morseCode[lettre];
                    }
                    catch (KeyNotFoundException)
                    {
                        traduction = "+";
                    }
                    stringBuilder.Append(traduction);
                    stringBuilder.Append(SeparateurLettre);
                }
            }

            return stringBuilder.ToString().TrimEnd('.');
        }

        public static bool BracketsControls(string sentence)
        {
            Dictionary<char, char> dct = new Dictionary<char, char>()
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'}
            };

            Stack<char> stack = new Stack<char>();
            foreach (char c in sentence)
            {
                if (dct.Keys.Contains(c))
                {
                    stack.Push(c);
                }
                if (dct.Values.Contains(c))
                {
                    char open = stack.Pop();
                    if (dct[open] != c) return false;
                }
            }
            return true;
        }

        public static void TestPhoneBook()
        {
            PhoneBook phoneBook = new PhoneBook(true);
            Debug.Assert(phoneBook.IsValidPhoneNumber("0768228646") == true);
            Debug.Assert(phoneBook.IsValidPhoneNumber("3768228646") == false);
            Debug.Assert(phoneBook.IsValidPhoneNumber("0068228646") == false);
            Debug.Assert(phoneBook.IsValidPhoneNumber("0646") == false);

            Debug.Assert(phoneBook.AddPhoneNumber("0768228646", "darren") == true);
            Debug.Assert(phoneBook.AddPhoneNumber("3768228646", "gzabier") == false);
            Debug.Assert(phoneBook.AddPhoneNumber("0068228646", "gabi") == false);
            Debug.Assert(phoneBook.AddPhoneNumber("0646", "zveg") == false);
            Debug.Assert(phoneBook.AddPhoneNumber("0768228646", "zveg") == false);

            Debug.Assert(phoneBook.AddPhoneNumber("0666666666", "enamone") == true);
            Debug.Assert(phoneBook.AddPhoneNumber("0888888888", "maxou") == true);

            Debug.Assert(phoneBook.ContainsPhoneContact("0888888888") == true);
            Debug.Assert(phoneBook.ContainsPhoneContact("0999999999") == false);

            Debug.Assert(phoneBook.PhoneContact("0888888888") == "maxou");
            Debug.Assert(phoneBook.PhoneContact("0666666666") == "enamone");
            try
            {
                phoneBook.PhoneContact("0123456789");
                Debug.Assert(false, "exception non levé pour la lecture d'un contact non existant");
            }
            catch
            {
                Debug.Assert(true);
            }

            Debug.Assert(phoneBook.DeletePhoneNumber("0888888888") == true);
            Debug.Assert(phoneBook.DeletePhoneNumber("0999999999") == false);

            phoneBook.DisplayPhoneBook();
        }

        struct PhoneBook
        {
            public Dictionary<string, string> Book;

            public PhoneBook(bool init)
            {
                this.Book = new Dictionary<string, string>();
            }

            public bool IsValidPhoneNumber(string phoneNumber)
            {
                return phoneNumber.Length == 10 && phoneNumber[0] == '0' && phoneNumber[1] != '0';
            }

            public bool ContainsPhoneContact(string phoneNumber)
            {
                return Book.Keys.Contains(phoneNumber);
            }

            public string PhoneContact(string phoneNumber)
            {
                try
                {
                    return Book[phoneNumber];
                }
                catch
                {
                    throw new Exception("Numero non existant dans l'annuaire");
                }
            }

            public bool AddPhoneNumber(string phoneNumber, string name)
            {
                if (ContainsPhoneContact(phoneNumber) || !IsValidPhoneNumber(phoneNumber)) return false;
                try
                {
                    Book.Add(phoneNumber, name);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public bool DeletePhoneNumber(string phoneNumber)
            {
                if (!ContainsPhoneContact(phoneNumber)) return false;
                Book.Remove(phoneNumber);
                return true;
            }

            public void DisplayPhoneBook()
            {
                if (Book.Count() == 0)
                {
                    Console.WriteLine("Pas de numéros téléphoniques :(");
                    return;
                }
                Console.WriteLine("Annuaire téléphonique :");
                Console.WriteLine("-----------------------");
                foreach (KeyValuePair<string, string> kvp in Book)
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                }
                Console.WriteLine("-----------------------");
            }
        }

        struct BusinessSchedule
        {

            public DateTime Begin;
            public DateTime End;
            public SortedDictionary<DateTime, DateTime> Schedule;

            public BusinessSchedule(bool init)
            {
                Begin = new DateTime(2020, 1, 1);
                End = new DateTime(2030, 12, 31);
                Schedule = new SortedDictionary<DateTime, DateTime>();
            }

            public bool IsEmpty()
            {
                return Schedule.Count() == 0;
            }

            public void SetRangeOfDates(DateTime begin, DateTime end)
            {
                if (!IsEmpty()) throw new Exception("le schedule doit etre vide pour modifier les dates de debut et fin");
                if (begin > end) throw new Exception("la date de debut est supérieur à la date de fin");
                Begin = begin;
                End = end;
            }

            public void DisplayMeetings()
            {
                Console.WriteLine($"Emploi du temps : {Begin.ToString()} - {End.ToString()}");
                Console.WriteLine("-----------------------------------------------------------");
                int index = 1;
                foreach(KeyValuePair<DateTime, DateTime> kvp in Schedule)
                {
                    Console.WriteLine($"réunion {index}       : {kvp.Key.ToString()} - {kvp.Value.ToString()}");
                    index++;
                }
                if (IsEmpty()) Console.WriteLine("Pas de réunions programmées");
                Console.WriteLine("-----------------------------------------------------------");
            }

            public KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
            {
                int index = -1;
                for(int i=0; i<Schedule.Count; i++)
                {
                    if(Schedule.ElementAt(i).Key > beginMeeting)
                    {
                        index = i;
                        break;
                    }
                }
                if (index == -1)
                {
                    return new KeyValuePair<DateTime, DateTime>(Schedule.Last().Key, DateTime.MinValue);
                }
                if (index == 0)
                {
                    return new KeyValuePair<DateTime, DateTime>(DateTime.MinValue, Schedule.First().Key);
                }
                return new KeyValuePair<DateTime, DateTime>(Schedule.ElementAt(index - 1).Key, Schedule.ElementAt(index).Key);
            }
            
            public bool AddBusinessMeeting(DateTime date, TimeSpan duration)
            {
                DateTime endDate = date + duration;
                if (date < Begin || date > End || endDate < Begin || endDate > End) return false;
                KeyValuePair<DateTime, DateTime> closestDate = ClosestElements(date);
                if(closestDate.Key != DateTime.MinValue)
                {
                    if (Schedule[closestDate.Key] > date) return false;
                }
                if (closestDate.Value != DateTime.MinValue)
                {
                    if (closestDate.Value < endDate) return false;
                }
                Schedule[date] = endDate; 
                return true;
            }

            public bool DeleteBusinessMeeting(DateTime date)
            {
                return Schedule.Remove(date);
            }

            public int ClearMeetingPeriod(DateTime begin, DateTime end)
            {
                if (begin < Begin || end > End) throw new ArgumentException();
                int res = 0;

                for(int i=0; i < Schedule.Count; i++)
                {
                    if (Schedule.ElementAt(i).Value > begin && Schedule.ElementAt(i).Key < end)
                    {
                        Schedule.Remove(Schedule.ElementAt(i).Key);
                        res++;
                        i--;
                    }
                }

                return res;
            }
        }
    }
}
