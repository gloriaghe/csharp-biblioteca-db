using System.Data.SqlClient;

public class Connessione
{
    private SqlConnection connessioneSql;
    DateTime today = DateTime.Today;

    public Connessione()
    {
        string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca_db;Integrated Security=True";
        connessioneSql = new SqlConnection(stringaDiConnessione);
    }

    public Documento Ricerca(string titolo)
    {
        try
        {
            connessioneSql.Open();
            string query = "SELECT * FROM documento where titolo=@Titolo";
            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            cmd.Parameters.Add(new SqlParameter("@Titolo", titolo));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string codice = reader.GetString(1);
                string titoloLibro = reader.GetString(2);
                string settore = reader.GetString(4);
                bool stato = reader.GetBoolean(5);
                string scaffale = reader.GetString(6);
                string nomeautore = reader.GetString(7);
                //int durata = reader.GetInt32(8);
                //int pagine = reader.GetInt32(9);

                Console.WriteLine("Id: " + reader.GetInt32(0));
                Console.WriteLine("Codice: " + reader.GetString(1));
                Console.WriteLine("Titolo: " + reader.GetString(2));
                string disponibilità = reader.GetString(6);
                if (disponibilità == "0")
                    Console.WriteLine("Libro non Disponibile");
                else
                    Console.WriteLine("Libro Disponibile");

                Console.WriteLine("Autore: " + reader.GetString(7));
                return new Documento( id,  codice,  titoloLibro,  settore,  stato,  scaffale,  nomeautore,  0,  0);
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
        return null;
    }


    public void CreaDocumento(Documento documento)
    {
        try
        {
            connessioneSql.Open();
            string insertQuery = "INSERT INTO documento (codice,titolo,settore,stato_disponibilità,scaffale,nome_autore)" +
           " VALUES (@codice,@titolo,@settore,@stato_disponibilità,@scaffale, @nome_autore)";
            string randomCodice = Convert.ToString(new Random().Next(100000000, 999999999));

            SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

            insertCommand.Parameters.Add(new SqlParameter("@codice", documento.Codice));
            insertCommand.Parameters.Add(new SqlParameter("@titolo", documento.Titolo));
            //insertCommand.Parameters.Add(new SqlParameter("@anno", documento.Anno));
            insertCommand.Parameters.Add(new SqlParameter("@settore", documento.Settore));
            insertCommand.Parameters.Add(new SqlParameter("@stato_disponibilità", "1"));
            insertCommand.Parameters.Add(new SqlParameter("@scaffale", documento.Scaffale));
            insertCommand.Parameters.Add(new SqlParameter("@nome_autore", documento.NomeAutore));
            insertCommand.Parameters.Add(new SqlParameter("@durata_minuti", documento.Durata));
            insertCommand.Parameters.Add(new SqlParameter("@pagine", documento.Pagine));

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
    }

    public void CreaPrestito(Prestito prestito, int idDocumento, string nome)
    {
        try
        {
            connessioneSql.Open();
            string insertQuery = "INSERT INTO prestito (dataInizio,dataFine,id_documento,utente)" +
                " VALUES (@dataInizio,@dataFine,@id_documento,@utente)";

            SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);


            insertCommand = new SqlCommand(insertQuery, connessioneSql);
            insertCommand.Parameters.Add(new SqlParameter("@dataInizio", prestito.PrestitoDal));
            insertCommand.Parameters.Add(new SqlParameter("@dataFine", prestito.PrestitoAl));
            insertCommand.Parameters.Add(new SqlParameter("@id_documento", idDocumento));
            insertCommand.Parameters.Add(new SqlParameter("@utente", nome));

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
    }

    public void CercaPrestito(int id)
    {
        try
        {
            connessioneSql.Open();
            string query = "SELECT * FROM prestito where id=@id";

            SqlCommand cmd = new SqlCommand(query, connessioneSql);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id: " + reader.GetString(0));
                Console.WriteLine("Nome: " + reader.GetString(1));
                Console.WriteLine("Titolo: " + reader.GetString(2));
                

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
    }


}