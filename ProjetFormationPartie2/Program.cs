using System.Diagnostics;

namespace ProjetFormation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque();
            Entree entree = new Entree();
            Sortie sortie = new Sortie();
            
            CreationCompte(banque, entree);
            GestionTransactions(banque, entree, sortie);
            
            entree.FermetureReader();
            sortie.FermetureWriter();
        }

        public static void CreationCompte(Banque banque, Entree entree)
        {
            entree.OuvertureReaderComptes();
            string[]? ligne = entree.Lecture();
            while (ligne != null)
            {
                //banque.CreerCompte(int.Parse(ligne[0]), ligne[1] == "" ? 0 : decimal.Parse(ligne[1]));
                ligne = entree.Lecture();
            }
            entree.FermetureReader();
        }

        public static void GestionTransactions(Banque banque, Entree entree, Sortie sortie)
        {
            //sortie.OuvertureWriterSortie();
            entree.OuvertureReaderTransactions();
            string[]? ligne = entree.Lecture();
            while (ligne != null)
            {
                //Transaction transaction = new Transaction(int.Parse(ligne[0]), decimal.Parse(ligne[1]), int.Parse(ligne[2]), int.Parse(ligne[3]));
              //  banque.TraiterTransaction(transaction);
              //  sortie.Ecriture(transaction, banque.Comptes);
                ligne = entree.Lecture();
            }
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
