﻿namespace ProjetFormation
{
    public class Transaction
    {
        private int _id;
        private decimal _montant;
        private int _idCompteSource;
        private int _idCompteDest;
        private bool _statut;

        public Transaction(int id, decimal montant, int idCompteSource, int idCompteDest, bool statut = true)
        {
            _id = id;
            _montant = montant;
            _idCompteSource = idCompteSource;
            _idCompteDest = idCompteDest;
            _statut = statut;
        }

        public int Id
        {
            get { return _id; }
        }

        public decimal Montant
        {
            get { return _montant; }
        }

        public int IdCompteSource
        {
            get { return _idCompteSource; }
        }

        public int IdCompteDest
        {
            get { return _idCompteDest; }
        }

        public bool Statut
        {
            get { return _statut; }
            set { _statut = value; }
        }
    }
}
