using System.Runtime.CompilerServices;

namespace ProjetFormation
{
    public class Compte
    {
        private int _id;
        private decimal _solde;
        private DateTime _dateCreation;
        private DateTime _dateResiliation = DateTime.MaxValue;
        private List<Transaction> _historiqueTransactions;

        internal Compte(int id, decimal solde, DateTime dateCreation)
        {
            _id = id;
            _solde = solde;
            _dateCreation = dateCreation;
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

        public DateTime DateCreation { get { return _dateCreation; } }
        public DateTime DateResiliation { get { return _dateResiliation; } }

        public List<Transaction> HistoriqueTransactions
        {
            get { return _historiqueTransactions; }
        }

        public void AddTransaction(Transaction transaction)
        {
            _historiqueTransactions.Add(transaction);
        }

        public void Cloturer(DateTime dateCloture)
        {
            _dateResiliation = dateCloture;
        }

        public bool Depot(decimal montant, DateTime dateEffet)
        {
            if(montant <= 0 || dateEffet > _dateResiliation || dateEffet < _dateCreation) return false;
            _solde+= montant;

            return true;
        }

        public bool Retrait(decimal montant, DateTime dateEffet)
        {
            if (montant <= 0 || !VerificationLimiteRetrait(montant) || !VerificationLimiteRetraitHebdo(montant, dateEffet) || Solde < montant || dateEffet > _dateResiliation || dateEffet < _dateCreation) return false;
            _solde -= montant; 
            return true;
        }

        public bool Virement(decimal montant, Compte compteDest, DateTime dateEffet, bool isExogene, TypeGestionnaire typeGestionnaire, Func<decimal, decimal> ajoutFraisDeGestion)
        {
            if (montant <= 0 || !VerificationLimiteRetrait(montant) || !VerificationLimiteRetraitHebdo(montant, dateEffet) || Solde < montant || this.Id == compteDest.Id || dateEffet > _dateResiliation || dateEffet < _dateCreation || dateEffet > compteDest.DateResiliation || dateEffet < compteDest.DateCreation) return false;
            _solde -= montant;
            if(isExogene)
            {
                ajoutFraisDeGestion(ApplicationFraisGestion(typeGestionnaire, ref montant));
            }
            compteDest.Solde += montant;
            return true;
        }

        public bool Prelevement(decimal montant, Compte compteSrc, DateTime dateEffet, bool isExogene, TypeGestionnaire typeGestionnaire, Func<decimal, decimal> ajoutFraisDeGestion)
        {
            if (montant <= 0 || !compteSrc.VerificationLimiteRetrait(montant) || !compteSrc.VerificationLimiteRetraitHebdo(montant, dateEffet) || compteSrc.Solde < montant || this.Id == compteSrc.Id || dateEffet > _dateResiliation || dateEffet < _dateCreation || dateEffet > compteSrc.DateResiliation || dateEffet < compteSrc.DateCreation) return false;
            compteSrc.Solde -= montant;
            if (isExogene)
            {
                ajoutFraisDeGestion(ApplicationFraisGestion(typeGestionnaire, ref montant));
            }
            _solde += montant;
            return true;
        }

        //calcul et renvoie les frais de gestion en fonction du type de gestionnaire et les deduit du montant
        public decimal ApplicationFraisGestion(TypeGestionnaire typeGestionnaire, ref decimal montant)
        {
            decimal frais;
            if (typeGestionnaire == TypeGestionnaire.Particulier)
            {
                frais = montant * 0.01m;
            }
            else
            {
                frais = 10;
            }
            montant = montant - frais;
            return frais;
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
            return montantTot + montant < 1000;
        }

        /* verifie que sur la derniere semaine le montant total des transactions  
         * ne depasse pas la limite de paiement de 2000€ du compte
         */
        public bool VerificationLimiteRetraitHebdo(decimal montant, DateTime dateEffetTransa)
        {
            decimal montantTot = 0;
            foreach(Transaction transa in _historiqueTransactions)
            {
                if (Math.Abs((transa.DateEffet.Date - dateEffetTransa.Date).TotalDays) <= 7)
                {
                    montantTot += transa.Montant;
                }
            }
            return montantTot + montant < 2000;
        }
    }
}
