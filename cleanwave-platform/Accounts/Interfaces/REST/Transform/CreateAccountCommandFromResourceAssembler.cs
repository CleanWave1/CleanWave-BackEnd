namespace cleanwave_platform.Accounts;

public class CreateAccountCommandFromResourceAssembler
{
    public static CreateAccountCommand ToCommandFromResource(CreateAccountResource resource)
    {
        return new CreateAccountCommand(resource.Name, resource.LastName, resource.TypeSuscription, resource.Price,
            resource.EmailAddress, resource.Password, resource.TypeAccount, resource.Phone);
    }
}