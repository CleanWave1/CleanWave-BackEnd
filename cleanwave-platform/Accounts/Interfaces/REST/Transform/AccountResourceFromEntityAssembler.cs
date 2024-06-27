namespace cleanwave_platform.Accounts;
public class AccountResourceFromEntityAssembler
{
    public static AccountResource ToResourceFromEntity(Account entity)
    {
        return new AccountResource(entity.Id, entity.FullSuscription, entity.FullName, entity.EmailA, entity.Password,
            entity.TypeAccount, entity.Phone);
    }
}