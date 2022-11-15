using System.Data.SqlClient;



string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca_db;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


Console.WriteLine("Premi 1 per eseguire una ricerca");
Console.WriteLine("Premi 2 per effettuare un prestito");
Console.WriteLine("Premi 3 per cercare un prestito");
Console.WriteLine("Premi 4 per inserire un nuovo documento");


int sceltaUser = Convert.ToInt32(Console.ReadLine());
DateTime today = DateTime.Today;
try
{

    connessioneSql.Open();
    SqlCommand insertCommand = null;
    if (sceltaUser == 2)
    {

        string insertQuery = "INSERT INTO prestito (dataInizio,dataFine,id_documento,utente)" +
            " VALUES (@dataInizio,@dataFine,@id_documento,@utente)";

        insertCommand = new SqlCommand(insertQuery, connessioneSql);
        insertCommand.Parameters.Add(new SqlParameter("@dataInizio", today));
        insertCommand.Parameters.Add(new SqlParameter("@dataFine", today.AddMonths(1)));
        insertCommand.Parameters.Add(new SqlParameter("@id_documento", "5"));
        insertCommand.Parameters.Add(new SqlParameter("@utente", "Gloria Gherardi"));
        
    }
    if (sceltaUser == 4)
    {

        string insertQuery = "INSERT INTO documento (codice,titolo,anno,settore,stato_disponibilità,scaffale,nome_autore)" +
            " VALUES (@codice,@titolo,@anno,@settore,@stato_disponibilità,@scaffale, @nome_autore)";
        string randomCodice = Convert.ToString(new Random().Next(100000000, 999999999));

        insertCommand = new SqlCommand(insertQuery, connessioneSql);

        insertCommand.Parameters.Add(new SqlParameter("@codice", randomCodice));
        insertCommand.Parameters.Add(new SqlParameter("@titolo", "Piccolo giallo piccolo blu"));
        insertCommand.Parameters.Add(new SqlParameter("@anno", DateTime.Today));
        insertCommand.Parameters.Add(new SqlParameter("@settore", "Bambini"));
        insertCommand.Parameters.Add(new SqlParameter("@stato_disponibilità", "1"));
        insertCommand.Parameters.Add(new SqlParameter("@scaffale", "B7"));
        insertCommand.Parameters.Add(new SqlParameter("@nome_autore", "Leo Lionni"));
        insertCommand.Parameters.Add(new SqlParameter("@durata_minuti", "NULL"));
        insertCommand.Parameters.Add(new SqlParameter("@pagine", "NULL"));

    }

    int affectedRows = insertCommand.ExecuteNonQuery();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);

}
finally
{
    connessioneSql.Close();
}


return;







//if (sceltaUser == 1)
//{

//    Console.WriteLine("Premi 1 per cercare per codice");
//    Console.WriteLine("Premi 2 per cercare per titolo");
//    sceltaUser = Convert.ToInt32(Console.ReadLine());

//    if (sceltaUser == 1)
//    {
//        Console.WriteLine("Inserisci il codice");
//        string codiceRicerca = Console.ReadLine();

//        biblioteca.Search(sceltaUser, codiceRicerca);
//    }
//    else if (sceltaUser == 2)
//    {
//        Console.Clear();
//        Console.WriteLine("Inserisci il titolo");
//        string titoloRicerca = Console.ReadLine();
//        biblioteca.Search(sceltaUser, titoloRicerca);
//    }
//    else
//    {
//        Console.WriteLine("Errore ricerca");
//    }
//}
////else if (sceltaUser == 2)
////{
////    Console.Clear();
////    Console.WriteLine("Inserisci periodo da cui parte il prestito");
////    string inizioPrestito = Console.ReadLine();
////    Console.WriteLine("Inserisci periodo in cui finisce il prestito");
////    string finePrestito = Console.ReadLine();
////    Console.WriteLine("Titolo del documento da prenotare?");
////    string titoloRicerca = Console.ReadLine();
////    //Documento documentoPrestito = new Documento("", "", 0, "", "", "", "", "");
////    Documento documentoPrestito = null;

////    bool presente = true;

////    biblioteca.Prestiti(inizioPrestito, finePrestito, titoloRicerca, documentoPrestito, presente);
////}
////else if (sceltaUser == 3)
////{
////    Console.Clear();
////    Console.WriteLine("Inserisci il nome di chi devo cercare il prestito");
////    string nome = Console.ReadLine();
////    Console.WriteLine("Inserisci il cognome di chi devo cercare il prestito");
////    string cognome = Console.ReadLine();
////    biblioteca.SearchPrestito(nome, cognome);
////}
//else
//{
//    Console.WriteLine("Scelta errata");
//}


//public class Documento
//{
//    public string Codice { get; set; }
//    public string Titolo { get; }

//    public int Anno { get; set; }
//    public string Settore { get; }
//    public string Stato { get; set; }
//    public string Scaffale { get; set; }
//    public string NomeAutore { get; }
//    public int Durata { get; }
//    public int Pagine { get; }


//    public Documento(string codice, string titolo, int anno, string settore, string stato, string scaffale, string nomeautore, int durata, int pagine)
//    {
//        this.Codice = codice;
//        this.Titolo = titolo;
//        this.Anno = anno;
//        this.Settore = settore;
//        this.Stato = stato;
//        this.Scaffale = scaffale;
//        this.NomeAutore = nomeautore;
//        this.Durata = durata;
//        this.Pagine = pagine;

//    }
//    public override string ToString()
//    {
//        return Titolo + " Codice : " + Codice;
//    }
//    public void Search(int ricerca, string userSearch)
//    {
//        //foreach (Documento item in documenti)
//        //{
//            if (ricerca == 1)
//            {
//                if (item.Codice == userSearch)
//                    Console.WriteLine("Trovato {1}: {0} ", item, item.GetType().ToString());
//            }
//            else if (ricerca == 2)
//            {
//                if (item.Titolo == userSearch)
//                    Console.WriteLine("Trovato {1}: {0} ", item, item.GetType().ToString());
//            }
//        //}
//    }

//}

//public class Biblioteca
//{


//    public void Search(int ricerca, string userSearch)
//    {

//            if (ricerca == 1)
//            {
//                if (item.Codice == userSearch)
//                    Console.WriteLine("Trovato {1}: {0} ", item, item.GetType().ToString());
//            }
//            else if (ricerca == 2)
//            {
//                if (item.Titolo == userSearch)
//                    Console.WriteLine("Trovato {1}: {0} ", item, item.GetType().ToString());
//            }

//    }

//    //public void Prestiti(string inizioPrestito, string finePrestito, string titoloRicerca, Documento documentoPrestito, bool presente)
//    //{
//    //    bool nonTrovato = false;
//    //    foreach (Documento item in documenti)
//    //    {


//    //        if (item.Titolo == titoloRicerca)
//    //        {
//    //            Console.WriteLine("Trovato {1}: {0} ", item, item.GetType().ToString());
//    //            documentoPrestito = item;
//    //            nonTrovato = true;

//    //            if (item.Stato == "In prestito")
//    //            {
//    //                Console.Clear();
//    //                Console.WriteLine("Il documento non è al momento disponibile!");
//    //                presente = false;
//    //            }
//    //        }
//    //    }
//    //    //se documento non trovato
//    //    if (nonTrovato == false)
//    //    {
//    //        Console.Clear();
//    //        Console.WriteLine("Documento non trovato!");
//    //    }
//    //    //se presente in biblioteca
//    //    if (presente == true)
//    //    {
//    //        Console.WriteLine("Inserisci il nome di chi devo effettuare il prestito");
//    //        string nome = Console.ReadLine();
//    //        Console.WriteLine("Inserisci il cognome");
//    //        string cognome = Console.ReadLine();

//    //        foreach (Utente item in utenti)
//    //        {
//    //            if (item.Nome == nome && item.Cognome == cognome)
//    //            {

//    //                Utente utente = item;
//    //                Prestito prestito = new Prestito(inizioPrestito, finePrestito, documentoPrestito, utente);
//    //                Console.WriteLine("Inserito {1}: {0} ", prestito, prestito.GetType().ToString());
//    //                prestiti.Add(prestito);
//    //            }
//    //        }

//    //    }

//    //}

//    //public void SearchPrestito(string nome, string cognome)
//    //{
//    //    foreach (Prestito item in prestiti)
//    //    {
//    //        if (item.Utente.Nome == nome && item.Utente.Cognome == cognome)
//    //        {
//    //            Console.WriteLine("Trovato {1}: {0} ", item, item.GetType().ToString());
//    //        }

//    //    }
//    //}
//}