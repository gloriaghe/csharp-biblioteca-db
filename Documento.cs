public class Documento
{
    public int ID { get; set; }

    public string Codice { get; set; }
    public string Titolo { get; }

    public int Anno { get; set; }
    public string Settore { get; }
    public bool Stato { get; set; }
    public string Scaffale { get; set; }
    public string NomeAutore { get; }
    public int Durata { get; }
    public int Pagine { get; }


    public Documento(int Id, string codice, string titolo, string settore, bool stato, string scaffale, string nomeautore, int durata, int pagine)
    {
        this.ID = Id;
        this.Codice = codice;
        this.Titolo = titolo;
        //this.Anno = anno;
        this.Settore = settore;
        this.Stato = stato;
        this.Scaffale = scaffale;
        this.NomeAutore = nomeautore;
        this.Durata = durata;
        this.Pagine = pagine;

    }
    public override string ToString()
    {
        return Titolo + " Codice : " + Codice;
    }


}

