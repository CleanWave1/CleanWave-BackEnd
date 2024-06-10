namespace cleanwave_platform.Accounts;

public class AccountQueryService(IAccountRepository accountRepository) : IAccountQueryService
{
    public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery query)
    {
        return await accountRepository.ListAsync();
    }

    public async Task<Account?> Handle(GetAccountByEmailQuery query)
    {
        return await accountRepository.FindAccountByEmailAsync(query.Email);

    }

    public async Task<Account?> Handle(GetAccountByIdQuery query)
    {
        return await accountRepository.FindByIdAsync(query.AccountId);

    }
}