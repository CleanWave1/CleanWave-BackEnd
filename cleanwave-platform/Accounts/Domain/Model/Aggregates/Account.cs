namespace cleanwave_platform.Accounts;

public partial class Account
{
    public int Id { get; }
    public Suscription PersonSuscription { get; private set; }
    public PersonName Name { get; private set; }
    public EmailAdress Email { get; private set; }
    
    public string FullSuscription => PersonSuscription.FullSuscription;
    public string FullName => Name.FullName;
    public string EmailA => Email.Email;
    
    public string Password { get; private set; }
    public string TypeAccount { get; private set; }
    public string Phone { get; private set; }

    public Account()
    {
        PersonSuscription = new Suscription();
        Name = new PersonName();
        Email = new EmailAdress();
    }

    public Account(string name, string lastName, string typeSuscription, float price, string emailAdress, string password, string typeAccount, string phone)
    {
        PersonSuscription = new Suscription(typeSuscription, price);
        Name = new PersonName(name, lastName);
        Email = new EmailAdress(emailAdress);
        Password = password;
        TypeAccount = typeAccount;
        Phone = phone;
    }

    public Account(CreateAccountCommand command)
    {
        PersonSuscription = new Suscription(command.typeSuscription, command.price);
        Name = new PersonName(command.name, command.lastName);
        Email = new EmailAdress(command.emailAdress);
        Password = command.password;
        TypeAccount = command.typeAccount;
        Phone = command.phone;
    }
}