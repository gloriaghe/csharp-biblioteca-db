
public class Prestito
{
    public DateTime PrestitoDal { get; }
    public DateTime PrestitoAl { get; }
    public string Utente { get; }

    public int idDoc; 
    public Prestito( Documento documento, string utente)
    {
        DateTime Today = DateTime.Today;
        this.PrestitoDal = Today;
        this.PrestitoAl = Today.AddMonths(1);
        this.idDoc = documento.ID;
    }
    public override string ToString()
    {
        return "prestito dal " + PrestitoDal + " al " + PrestitoAl + ". Per l'utente " + Utente + ". Del documento " /*+ Documento.Titolo + "."*/;
    }
}

