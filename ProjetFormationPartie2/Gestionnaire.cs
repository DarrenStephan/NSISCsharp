namespace ProjetFormation
{
    public enum TypeGestionnaire
    {
        Particulier,
        Entreprise
    }

    public class Gestionnaire
    {
        private int _id;
        private TypeGestionnaire _typeGestionnaire;
        private int _nbTransaLimite;
        private decimal _totFraisgestion;
        private List<Compte> _comptes = new List<Compte>();

        public int Id { get { return _id; } }
        public TypeGestionnaire TypeGestionnaire { get { return _typeGestionnaire; } }
        public int NbTransaLimite { get {  return _nbTransaLimite; } }
        public decimal TotFraisGestion { get { return _totFraisgestion; } }
        public List<Compte> Comptes { get { return _comptes; } }
        public void AddCompte(Compte compte) {  _comptes.Add(compte); }
        public void RemoveCompte(Compte compte) {  _comptes.Remove(compte); }

        public void CessionCompte(int idCompte, Gestionnaire gestionnaireDest)
        {
            Compte? compte = _comptes.Find(c => c.Id == idCompte);
            if (compte == null) return;
            _comptes.Remove(compte);
            gestionnaireDest.AddCompte(compte);
        }

        public void receptionCompte(int idCompte, Gestionnaire gestionnaireSrc)
        {
            Compte? compte = _comptes.Find(c => c.Id == idCompte);
            if (compte == null) return;
            _comptes.Add(compte);
            gestionnaireSrc.RemoveCompte(compte);
        }
    }
}
