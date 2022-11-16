
Connessione connessione = new Connessione();

bool lavora = true;
while (lavora)
{


    Console.WriteLine("Premi 1 per eseguire una ricerca");
    Console.WriteLine("Premi 2 per effettuare un prestito");
    Console.WriteLine("Premi 3 per cercare un prestito");
    Console.WriteLine("Premi 4 per inserire un nuovo documento");


    int sceltaUser = Convert.ToInt32(Console.ReadLine());
    try
    {


        if (sceltaUser == 1)
        {
            Console.Write("Che libro vuoi cercare? ");
            string titolo = Console.ReadLine();
            connessione.Ricerca(titolo);

        }
        if (sceltaUser == 2)
        {
            Console.Write("Titolo del documento da prenotare: ");
            string titolo = Console.ReadLine();
            Console.Write("Nome di chi prenota: ");
            string nome = Console.ReadLine();
            Documento documento = connessione.Ricerca(titolo);
            Prestito prestito = new Prestito(documento, nome);

            connessione.CreaPrestito(prestito, documento.ID, nome);

        }
        if (sceltaUser == 3)
        {
            Console.WriteLine("Titolo del documento da prenotare: ");
            string titolo = Console.ReadLine();
            Documento documento = connessione.Ricerca(titolo);

            connessione.CercaPrestito(documento.ID);

        }
        if (sceltaUser == 4)
        {
            Console.Write("Titolo del documento: ");
            string titolo = Console.ReadLine();
            Console.Write("Codice del documento: ");
            string codice = Console.ReadLine();
            Console.Write("Settore del documento: ");
            string settore = Console.ReadLine();
            Console.Write("Scaffale del documento: ");
            string scaffale = Console.ReadLine();
            Console.Write("Autore del documento: ");
            string autore = Console.ReadLine();

            Documento documento = new Documento(10, codice, titolo, settore, true, scaffale, autore, 0, 0);
            connessione.CreaDocumento(documento);
        }
        else
        {
            lavora = false;
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);

    }



    return;

}
