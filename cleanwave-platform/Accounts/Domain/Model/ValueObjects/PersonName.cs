namespace cleanwave_platform.Accounts;

public record PersonName(string Name, string LastName)
{
    public PersonName() : this(string.Empty, string.Empty)
    {
        
    }
    public PersonName(string name) : this(name, string.Empty){}

    public string FullName => $"{Name} {LastName}";
}