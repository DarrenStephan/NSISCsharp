namespace ProjetFormation
{
    public class Compte
    {
        private int _id;
        private decimal _solde;
        private int _limiteRetrait;
        private List<Transaction> _historiqueTransactions;

        internal Compte(int id, decimal solde, int limiteRetrait)
        {
            _id = id;
            _solde = solde;
            _limiteRetrait = limiteRetrait;
            _historiqueTransactions = new List<Transaction>();
        }

        public decimal Id
        {
            get { return _id; }
        }

        public decimal Solde
        {
            get { return _solde; }
            set { _solde = value; }
        }

        public int LimiteRetrait
        {
            get { return _limiteRetrait; }
        }

        public List<Transaction> HistoriqueTransactions
        {
            get { return _historiqueTransactions; }
        }

        public void AddTransaction(Transaction transaction)
        {
            _historiqueTransactions.Add(transaction);
        }

        public bool Depot(decimal montant)
        {
            if(montant < 0) return false;
            _solde+= montant;

            return true;
        }

        public bool Retrait(decimal montant)
        {
            if (montant < 0 || !VerificationLimiteRetrait(montant) || Solde < montant) return false;
            _solde -= montant; 
            return true;
        }

        public bool Virement(decimal montant, Compte compteDest)
        {
            if (montant < 0 || !VerificationLimiteRetrait(montant) || Solde < montant || this.Id == compteDest.Id) return false;
            _solde -= montant;
            compteDest.Solde += montant;
            return true;
        }

        public bool Prelevement(decimal montant, Compte compteSrc)
        {
            if (montant < 0 || !compteSrc.VerificationLimiteRetrait(montant) || compteSrc.Solde < montant || this.Id == compteSrc.Id) return false;
            _solde += montant;
            compteSrc.Solde -= montant;
            return true;
        }

        /* recupere les 9 derniers virement/retrait du compte, ajoute le montant en parametre et verifie que ce montant total 
         * ne depasse pas la limite de paiement du compte
         */
        public bool VerificationLimiteRetrait(decimal montant)
        {
            int rupt = 0;
            decimal montantTot = 0;
            for(int i = _historiqueTransactions.Count - 1; i >= 0; i--)
            {
                if (_historiqueTransactions[i].IdCompteSource == this._id && _historiqueTransactions[i].Statut)
                {
                    montantTot += _historiqueTransactions[i].Montant;
                    rupt++;
                    if (rupt == 9) break;
                }
            }
            return montantTot + montant < _limiteRetrait;
        }
    }
}
