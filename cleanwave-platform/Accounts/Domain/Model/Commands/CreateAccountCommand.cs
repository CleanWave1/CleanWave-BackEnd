namespace cleanwave_platform.Accounts;

public record CreateAccountCommand(string name, string lastName, string typeSuscription, float price, 
    string emailAdress, string password, string typeAccount, string phone);