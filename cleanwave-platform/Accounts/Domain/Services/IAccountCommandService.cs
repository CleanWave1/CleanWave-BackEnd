namespace cleanwave_platform.Accounts;

public interface IAccountCommandService
{
    Task<Account> Handle(CreateAccountCommand command);
}