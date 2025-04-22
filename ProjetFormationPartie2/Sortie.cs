using System.Text;

namespace ProjetFormation
{
    public class Sortie
    {
        private const string FichierStatutsTransactions= "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormationPartie2\\sttTransa.csv";
        private const string FichierStatutsOperations= "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormationPartie2\\sttOpe.csv";
        private const string FichierMetrologie= "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormationPartie2\\metrologie.txt";
        private StreamWriter streamWriter;

        public void OuvertureWriterStatutsTransactions()
        {
            streamWriter = new StreamWriter(FichierStatutsTransactions);
        }

        public void OuvertureWriterStatutsOperations()
        {
            streamWriter = new StreamWriter(FichierStatutsOperations);
        }

        public void OuvertureWriterMetrologie()
        {
            streamWriter = new StreamWriter(FichierMetrologie);
        }

        public void Ecriture(int id, bool statut)
        {
            if (streamWriter == null) throw new Exception("le streamWriter n'a pas été ouvert");
            streamWriter.WriteLine(id + ";" + statut + ";");
        }

        public void FermetureWriter()
        {
            streamWriter.Close();
        }
    }
}
