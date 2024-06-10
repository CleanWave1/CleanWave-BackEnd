using cleanwave_platform.Shared.Domain.Repositories;

namespace cleanwave_platform.Accounts;

public class AccountCommnadService(IAccountRepository accountRepository, IUnitOfWork unitOfWork) :IAccountCommandService
{
    public async Task<Account> Handle(CreateAccountCommand command)
    {
        var account = new Account(command);
        try
        {
            await accountRepository.AddSync(account);
            await unitOfWork.CompleteAsync();
            return account;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while creating the account:  {e.Message}");
            return null;
        }
    }
}