namespace cleanwave_platform.Accounts;

public record EmailAdress(string Email)
{
    public EmailAdress() : this(string.Empty){}
}