namespace ProjetFormation
{
    public class Entree
    {
        private const string FichierComptesPath = "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormation\\comptes.csv";
        private const string FichierTransactionsPath = "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormation\\transactions.csv";
        private StreamReader streamReader;

        public void OuvertureReaderComptes()
        {
            streamReader = new StreamReader(FichierComptesPath);
        }

        public void OuvertureReaderTransactions()
        {
            streamReader = new StreamReader(FichierTransactionsPath);
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
