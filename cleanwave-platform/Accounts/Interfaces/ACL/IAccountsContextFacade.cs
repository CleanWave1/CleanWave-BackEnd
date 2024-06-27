namespace cleanwave_platform.Accounts;

public interface IAccountsContextFacade
{
    Task<int> CreateAccount(string name, string lastName, string typeSuscription, float price,
        string emailAdress, string password, string typeAccount, string phone);

    Task<int> FetchAccountIdByEmail(string email);
}