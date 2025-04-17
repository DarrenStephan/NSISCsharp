using System.Text;

namespace ProjetFormation
{
    public class Sortie
    {
        private const string FichierSortiesPath = "C:\\Users\\Formation\\source\\repos\\DarrenStephan\\NSISCsharp\\ProjetFormation\\sortie.csv";
        private StreamWriter streamWriter;

        public void OuvertureWriterSortie()
        {
            streamWriter = new StreamWriter(FichierSortiesPath);
        }

        public void EcriturePremiereLigne(List<Compte> lstComptes)
        {
            if (streamWriter == null) throw new Exception("le streamWriter n'a pas été ouvert");
            StringBuilder sb = new StringBuilder();
            sb.Append(";;");
            foreach (Compte compte in lstComptes )
            {
                sb.Append(compte.Solde + ";");
            }
            streamWriter.WriteLine(sb.ToString().TrimEnd(';'));
        }

        public void Ecriture(Transaction transaction, List<Compte> lstComptes)
        {
            if (streamWriter == null) throw new Exception("le streamWriter n'a pas été ouvert");
            StringBuilder sb = new StringBuilder();
            sb.Append(transaction.Id);
            sb.Append(";");
            sb.Append(transaction.Statut ? "OK" : "KO");
            sb.Append(";");
            foreach (Compte compte in lstComptes)
            {
                sb.Append(compte.Solde + ";");
            }
            streamWriter.WriteLine(sb.ToString().TrimEnd(';'));
        }

        public void FermetureWriter()
        {
            streamWriter.Close();
        }
    }
}
