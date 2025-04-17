namespace ProjetFormation
{
    public class Banque
    {
        private List<Compte> _comptes = new List<Compte>();
        public List<Compte> Comptes { get { return _comptes; } }

        public Compte? CreerCompte(int id, decimal? solde, int limiteRetrait = 1000)
        {
            decimal cptSolde = solde == null ? 0 : (decimal)solde;
            if (solde < 0 || _comptes.Any(c => c.Id == id)) return null;
            Compte compte = new Compte(id, cptSolde, limiteRetrait);
            _comptes.Add(compte);
            return compte;
        }

        public void TraiterTransaction(Transaction transaction)
        {
            if(transaction.IdCompteSource == 0)
            {
                Compte? cptDest = _comptes.Find(c => c.Id == transaction.IdCompteDest);
                if (cptDest == null)
                {
                    transaction.Statut = false;
                    return;
                }
                transaction.Statut = cptDest.Depot(transaction.Montant);
                cptDest.AddTransaction(transaction);
            } 
            else if(transaction.IdCompteDest == 0)
            {
                Compte? cptSrc = _comptes.Find(c => c.Id == transaction.IdCompteSource);
                if (cptSrc == null)
                {
                    transaction.Statut = false;
                    return;
                }
                transaction.Statut = cptSrc.Retrait(transaction.Montant);
                cptSrc.AddTransaction(transaction);
            }
            else
            {
                Compte? cptSrc = _comptes.Find(c => c.Id == transaction.IdCompteSource);
                Compte? cptDest = _comptes.Find(c => c.Id == transaction.IdCompteDest);
                if (cptSrc == null || cptDest == null)
                {
                    transaction.Statut = false;
                    return;
                }
                transaction.Statut = cptSrc.Virement(transaction.Montant, cptDest);
                cptSrc.AddTransaction(transaction);
                cptDest.AddTransaction(transaction);
            }
        }
    }
}
