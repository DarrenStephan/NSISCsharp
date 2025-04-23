using System.Transactions;

namespace ProjetFormation
{
    public class Banque
    {
        private List<Gestionnaire> _gestionnaires = new List<Gestionnaire>();

        private int _nbComptesCrees = 0;
        private int _nbTransaReussies= 0;
        private int _nbTransaEchec = 0;
        private decimal _mttTotTransaReussies= 0;

        public List<Gestionnaire> Gestionnaires { get { return _gestionnaires; } }
        public int NbComptesCrees {  get { return _nbComptesCrees; } }
        public int NbTransaReussies { get { return _nbTransaReussies; } }
        public int NBTransaEchec { get { return _nbTransaEchec; } }
        public decimal MttTotTransaReussies { get { return _mttTotTransaReussies; } }

        public Compte? CreerCompte(int id, decimal? solde, int idGestionnaire, DateTime dateCreation)
        {
            decimal cptSolde = solde == null ? 0 : (decimal)solde;
            if (solde < 0 || id <= 0 || !_gestionnaires.Any(g => g.Id==idGestionnaire) || _gestionnaires.Any(g => g.Comptes.Any(c => c.Id == id))) return null;
            Compte compte = new Compte(id, cptSolde, dateCreation);
            _gestionnaires.Find(g => g.Id == idGestionnaire).AddCompte(compte);
            _nbComptesCrees++;
            return compte;
        }

        public bool CloturerCompte(int idCompte, DateTime dateCloture)
        {
            Compte? compte = GetCompte(idCompte);
            if(compte == null) return false;
            compte.Cloturer(dateCloture);
            return true;
        }

        public Gestionnaire? CreerGestionnaire(int id, TypeGestionnaire typeGestionnaire, int nbTransa)
        {
            if (_gestionnaires.Any(g => g.Id == id) || nbTransa < 0 || id <= 0) return null;
            Gestionnaire gestionnaire = new Gestionnaire(id, typeGestionnaire, nbTransa);
            AjouterGestionnaire(gestionnaire);
            return gestionnaire;
        }

        public void AjouterGestionnaire(Gestionnaire gestionnaire)
        {
            _gestionnaires.Add(gestionnaire);
        }

        public void TraiterTransaction(Transaction transaction)
        {
            if(transaction.IdCompteSource == 0)
            {
                Compte? cptDest = GetCompte(transaction.IdCompteDest);
                if (cptDest == null)
                {
                    transaction.Statut = false;
                    _nbTransaEchec++;
                    return;
                }
                transaction.Statut = cptDest.Depot(transaction.Montant,transaction.DateEffet);
                cptDest.AddTransaction(transaction);
            } 
            else if(transaction.IdCompteDest == 0)
            {
                Compte? cptSrc = GetCompte(transaction.IdCompteSource);
                if (cptSrc == null)
                {
                    transaction.Statut = false;
                    _nbTransaEchec++;
                    return;
                }
                transaction.Statut = cptSrc.Retrait(transaction.Montant, transaction.DateEffet);
                cptSrc.AddTransaction(transaction);
            }
            else
            {
                Compte? cptSrc = GetCompte(transaction.IdCompteSource);
                Compte? cptDest = GetCompte(transaction.IdCompteDest);
                Gestionnaire? gestionnaireSrc = _gestionnaires.Find(g=> g.Comptes.Any(c=>c.Id ==  transaction.IdCompteSource));
                Gestionnaire? gestionnaireDest = _gestionnaires.Find(g=> g.Comptes.Any(c=>c.Id ==  transaction.IdCompteDest));
                if (cptSrc == null || cptDest == null || gestionnaireDest == null || gestionnaireSrc == null)
                {
                    transaction.Statut = false;
                    _nbTransaEchec++;
                    return;
                }
                transaction.Statut = cptSrc.Virement(transaction.Montant, cptDest, transaction.DateEffet, gestionnaireDest.Id != gestionnaireSrc.Id, gestionnaireSrc.TypeGestionnaire, (x=> gestionnaireSrc.MttTotFraisGestion += x));
                cptSrc.AddTransaction(transaction);
                cptDest.AddTransaction(transaction);
            }
            if(transaction.Statut)
            {
                _nbTransaReussies++;
                _mttTotTransaReussies += transaction.Montant;
            } else
            {
                _nbTransaEchec++;
            }
        }

        public bool TraiterOperationCompte(int idCompte, DateTime date, decimal solde, string entree, string sortie)
        {
            if(sortie == "")
            {
                int idGestionnaire;
                if (!int.TryParse(entree, out idGestionnaire)) return false;
                Gestionnaire? gestionnaire = _gestionnaires.Find(g => g.Id == idGestionnaire);
                if(gestionnaire == null) return false;
                Compte? compte = CreerCompte(idCompte, solde, idGestionnaire, date);
                if (compte == null) return false;
            }
            else if (entree == "")
            {
                return CloturerCompte(idCompte, date);
            }
            else
            {
                int idGestionnaire;
                if (!int.TryParse(entree, out idGestionnaire)) return false;
                Gestionnaire? gestionnaireSrc = _gestionnaires.Find(g => g.Id == idGestionnaire);
                if (!int.TryParse(sortie, out idGestionnaire)) return false;
                Gestionnaire? gestionnaireDest = _gestionnaires.Find(g => g.Id == idGestionnaire);
                if (gestionnaireSrc == null || gestionnaireDest == null) return false;
                return gestionnaireSrc.CessionCompte(idCompte, gestionnaireDest);
            }
            return true;
        }

        public Compte? GetCompte(int id)
        {
            Compte? compte = null;
            foreach(Gestionnaire gest in _gestionnaires)
            {
                compte = gest.Comptes.Find(c => c.Id == id);
                if (compte != null) break;
            }
            return compte;
        }
    }
}
