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
    if (sceltaUser == 1)
    {
        Console.WriteLine("Che libro vuoi cercare?");
        string titolo = Console.ReadLine();
        string query = "SELECT * FROM documento where titolo=@Titolo";

        SqlCommand cmd = new SqlCommand(query, connessioneSql);
        cmd.Parameters.Add(new SqlParameter("@Titolo", titolo));

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("Id: " + reader.GetString(1));
            Console.WriteLine("Codice: " + reader.GetString(1));
            Console.WriteLine("Titolo: " + reader.GetString(2));
            string disponibilità = reader.GetString(6);
            if (disponibilità == "0")
                Console.WriteLine("Libro non Disponibile");
            else
                Console.WriteLine("Libro Disponibile");

            Console.WriteLine("Autore: " + reader.GetString(7));

        }
    }
    if (sceltaUser == 2)
    {

        string insertQuery = "INSERT INTO prestito (dataInizio,dataFine,id_documento,utente)" +
            " VALUES (@dataInizio,@dataFine,@id_documento,@utente)";

        insertCommand = new SqlCommand(insertQuery, connessioneSql);
        insertCommand.Parameters.Add(new SqlParameter("@dataInizio", today));
        insertCommand.Parameters.Add(new SqlParameter("@dataFine", today.AddMonths(1)));
        insertCommand.Parameters.Add(new SqlParameter("@id_documento", "5"));
        insertCommand.Parameters.Add(new SqlParameter("@utente", "Gloria Gherardi"));

        int affectedRows = insertCommand.ExecuteNonQuery();

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

        int affectedRows = insertCommand.ExecuteNonQuery();
    }


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

