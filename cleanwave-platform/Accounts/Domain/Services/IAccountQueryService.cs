namespace cleanwave_platform.Accounts;

public interface IAccountQueryService
{
    Task<IEnumerable<Account>> Handle(GetAllAccountsQuery query);
    Task<Account?> Handle(GetAccountByEmailQuery query);
    Task<Account?> Handle(GetAccountByIdQuery query);
}