namespace cleanwave_platform.Accounts;

public class AccountsContextFacade(
    IAccountCommandService accountCommandService,
    IAccountQueryService accountQueryService): IAccountsContextFacade
{
    public async Task<int> CreateAccount(string name, string lastName, string typeSuscription, float price, string emailAdress,
        string password, string typeAccount, string phone)
    {
        var createAccountCommand = new CreateAccountCommand(name, lastName, typeSuscription, price, emailAdress,
            password, typeAccount, phone);
        var account = await accountCommandService.Handle(createAccountCommand);
        return account?.Id ?? 0;
    }

    public async Task<int> FetchAccountIdByEmail(string email)
    {
        var getAccountByEmailQuery = new GetAccountByEmailQuery(new EmailAdress(email));
        var account = await accountQueryService.Handle(getAccountByEmailQuery);
        return account?.Id ?? 0;
    }
}