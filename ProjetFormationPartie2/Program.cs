using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata;

namespace ProjetFormation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque();
            Entree entree = new Entree();
            Sortie sortie = new Sortie();

            CreationGestionnaires(banque, entree);
            OperationsCompte(banque, entree, sortie);
            GestionTransactions(banque, entree, sortie);
            
            entree.FermetureReader();
            sortie.FermetureWriter();
            Console.WriteLine("fini");
        }

        public static void CreationGestionnaires(Banque banque, Entree entree)
        {
            entree.OuvertureReaderGestionnaires();
            string[]? ligne = entree.Lecture();
            while (ligne != null)
            {
                int id;
                TypeGestionnaire typeGestionnaire;
                int nbTransa;
                if (!int.TryParse(ligne[0], out id)) continue;
                if (ligne[1] == "Particulier") typeGestionnaire = TypeGestionnaire.Particulier;
                else if (ligne[1] == "Entreprise") typeGestionnaire = TypeGestionnaire.Entreprise;
                else continue;
                if (!int.TryParse(ligne[2], out nbTransa)) continue;
                banque.AjouterGestionnaire(new Gestionnaire(id, typeGestionnaire, nbTransa));
                ligne = entree.Lecture();
            }
            entree.FermetureReader();
        }

        public static void OperationsCompte(Banque banque, Entree entree, Sortie sortie)
        {
            entree.OuvertureReaderComptes();
            sortie.OuvertureWriterStatutsOperations();
            string[]? ligne = entree.Lecture();
            while (ligne != null)
            {
                if (!DateTime.TryParseExact(ligne[1], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)) continue;
                if (!int.TryParse(ligne[0], out int id)) continue;
                if (ligne[2] == "") ligne[2] = "0";
                if (!decimal.TryParse(ligne[2], out decimal solde)) continue;

                bool statut = banque.TraiterOperationCompte(id, date, solde, ligne[3], ligne[4]);
                sortie.Ecriture(id, statut);
                ligne = entree.Lecture();
            }
            entree.FermetureReader();
            sortie.FermetureWriter();
        }

        public static void GestionTransactions(Banque banque, Entree entree, Sortie sortie)
        {
            entree.OuvertureReaderTransactions();
            sortie.OuvertureWriterStatutsTransactions();
            string[]? ligne = entree.Lecture();
            while (ligne != null)
            {
                if (!int.TryParse(ligne[0], out int id)) continue;
                if (!decimal.TryParse(ligne[2], out decimal montant)) continue;
                if (!int.TryParse(ligne[3], out int idSrc)) continue;
                if (!int.TryParse(ligne[4], out int idDest)) continue;
                if (!DateTime.TryParseExact(ligne[1], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)) continue;
                Transaction transaction = new Transaction(id, montant, idSrc, idDest, date);
                banque.TraiterTransaction(transaction);
                sortie.Ecriture(id, transaction.Statut);
                ligne = entree.Lecture();
            }
            entree.FermetureReader();
            sortie.FermetureWriter();
        }
        /*
        public static void TestBanque()
        {
            Banque banque = new Banque();
            Compte? cpt = banque.CreerCompte(1, 1000, 1200);
            //test des guetteurs
            Debug.Assert(cpt.Id == 1);
            Debug.Assert(cpt.Solde == 1000);
            Debug.Assert(cpt.LimiteRetrait == 1200);
            //test des depots
            Debug.Assert(cpt.Depot(-100) == false);
            Debug.Assert(cpt.Depot(100) == true);
            Debug.Assert(cpt.Solde == 1100);
            //test des retraits
            Debug.Assert(cpt.Retrait(-100) == false);
            Compte? cpt2 = banque.CreerCompte(2, 200, 2000);
            Debug.Assert(cpt2.Retrait(400) == false);
            Compte? cpt3 = banque.CreerCompte(3, 2000, 500);
            Debug.Assert(cpt3.Retrait(400) == true);
            Debug.Assert(cpt3.Solde == 1600);
            cpt3.AddTransaction(new Transaction(1, 400, 3, 0, true));
            Debug.Assert(cpt3.Retrait(400) == false);
            //test des virements
            Compte? cpt4 = banque.CreerCompte(4, 200, 2000);
            Compte? cpt5 = banque.CreerCompte(5, 2000, 200);
            Debug.Assert(cpt4.Virement(-500, cpt5) == false);
            Debug.Assert(cpt4.Virement(100, cpt4) == false);
            Debug.Assert(cpt4.Virement(500, cpt5) == false);
            Debug.Assert(cpt5.Virement(500, cpt4) == false);
            Debug.Assert(cpt5.Virement(100, cpt4) == true);
            Debug.Assert(cpt4.Solde == 300);
            Debug.Assert(cpt5.Solde == 1900);
            //test des prelevements
            Compte? cpt6 = banque.CreerCompte(6, 200, 2000);
            Compte? cpt7 = banque.CreerCompte(7, 2000, 200);
            Debug.Assert(cpt6.Prelevement(-500, cpt7) == false);
            Debug.Assert(cpt6.Prelevement(100, cpt6) == false);
            Debug.Assert(cpt7.Prelevement(500, cpt6) == false);
            Debug.Assert(cpt6.Prelevement(500, cpt7) == false);
            Debug.Assert(cpt6.Prelevement(100, cpt7) == true);
            Debug.Assert(cpt6.Solde == 300);
            Debug.Assert(cpt7.Solde == 1900);
        }*/
    }
}
