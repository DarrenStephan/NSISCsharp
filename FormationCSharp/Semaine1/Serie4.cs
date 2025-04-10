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
         *              une liste n'est pas pratique à utiliser dans cette situation car les valeurs 
         *              sont recupérés à partir d'index avec un dictionnaire on peut recuperer une lettre
         *              à partir de sa valeur morse en faisant dct[stringMorse] 
         */


        static void Main(string[] args)
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>()
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
            var reversedMorseCode = morseCode.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

            string code = "=.=.=.=...=...=.===.=.=...=.===.=.=...===.===.===.....=.===.===...===.===.===...=.===.=...=.===.=.=...===.=.=";
            Console.WriteLine(WordsCount(code));
            
            Console.ReadKey();
        }

        public static int LettersCount(string code)
        {
            return 0;
        }

        public static int WordsCount(string code)
        {

        }
    }
}
