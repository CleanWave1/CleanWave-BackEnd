namespace cleanwave_platform.Accounts;

public record Suscription(string TypeSuscription, float Price)
{
    public Suscription() : this(string.Empty, float.NaN)
    {
        
    }
    public Suscription(string typeSuscription) : this(typeSuscription, float.NaN)
    {
        
    }

    public string FullSuscription => $"{TypeSuscription} {Price}";
}