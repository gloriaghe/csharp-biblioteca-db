

Connessione connessione = new Connessione();

Console.WriteLine("Premi 1 per eseguire una ricerca");
Console.WriteLine("Premi 2 per effettuare un prestito");
Console.WriteLine("Premi 3 per cercare un prestito");
Console.WriteLine("Premi 4 per inserire un nuovo documento");


int sceltaUser = Convert.ToInt32(Console.ReadLine());
try
{

    
    if (sceltaUser == 1)
    {
        Console.WriteLine("Che libro vuoi cercare?");
        string titolo = Console.ReadLine();
        connessione.Ricerca(titolo);
        
    }
    else { }
    //if (sceltaUser == 2)
    //{
    //    Console.WriteLine("Titolo del documento da prenotare?");
    //    string titolo = Console.ReadLine();
    //    string insertQuery = "INSERT INTO prestito (dataInizio,dataFine,id_documento,utente)" +
    //        " VALUES (@dataInizio,@dataFine,@id_documento,@utente)";

    //    insertCommand = new SqlCommand(insertQuery, connessioneSql);
    //    insertCommand.Parameters.Add(new SqlParameter("@dataInizio", today));
    //    insertCommand.Parameters.Add(new SqlParameter("@dataFine", today.AddMonths(1)));
    //    insertCommand.Parameters.Add(new SqlParameter("@id_documento", "5"));
    //    insertCommand.Parameters.Add(new SqlParameter("@utente", "Gloria Gherardi"));

    //    int affectedRows = insertCommand.ExecuteNonQuery();

    //}
    //if(sceltaUser == 3)
    //{
    //    Console.WriteLine("Titolo del documento da prenotare?");
    //    string titolo = Console.ReadLine();

    //    string query = "SELECT * FROM documento where titolo=@Titolo";

    //    SqlCommand cmd = new SqlCommand(query, connessioneSql);
    //    cmd.Parameters.Add(new SqlParameter("@Titolo", titolo));

    //    SqlDataReader reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        Console.WriteLine("Id: " + reader.GetString(1));
    //        Console.WriteLine("Codice: " + reader.GetString(1));
    //        Console.WriteLine("Titolo: " + reader.GetString(2));
    //        string disponibilità = reader.GetString(6);
    //        if (disponibilità == "0")
    //            Console.WriteLine("Libro non Disponibile");
    //        else
    //            Console.WriteLine("Libro Disponibile");

    //        Console.WriteLine("Autore: " + reader.GetString(7));

    //    }

    //}
    if (sceltaUser == 4)
    {
        Console.Write("Titolo del documento");
        string titolo = Console.ReadLine();
        Console.Write("Codice del documento");
        string codice = Console.ReadLine();
        Console.Write("Settore del documento");
        string settore = Console.ReadLine(); 
        Console.Write("Scaffale del documento");
        string scaffale = Console.ReadLine();
        Console.Write("Autore del documento");
        string autore = Console.ReadLine();
        
        Documento documento = new Documento( codice,  titolo,  settore,  1,  scaffale, autore,  0,  0);
        connessione.CreaDocumento(documento);
    }


}
catch (Exception e)
{
    Console.WriteLine(e.Message);

}



return;

