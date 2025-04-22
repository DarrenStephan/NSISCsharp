namespace ProjetFormation
{
    public class Entree
    {
        private const string FichierGestionnairesPath = "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormationPartie2\\gestionnaires.csv";
        private const string FichierComptesPath = "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormationPartie2\\comptes.csv";
        private const string FichierTransactionsPath = "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormationPartie2\\transactions.csv";
        private StreamReader streamReader;

        public void OuvertureReaderComptes()
        {
            streamReader = new StreamReader(FichierComptesPath);
        }

        public void OuvertureReaderTransactions()
        {
            streamReader = new StreamReader(FichierTransactionsPath);
        }

        public void OuvertureReaderGestionnaires()
        {
            streamReader = new StreamReader(FichierGestionnairesPath);
        }

        public string[]? Lecture()
        {
            if (streamReader == null) throw new Exception("le streamreader n'a pas été ouvert");
            string? ligne  = streamReader.ReadLine();
            if (ligne == null) return null;
            return ligne.Split(';');
        }

        public void FermetureReader()
        {
            streamReader.Close();
        }
    }
}
