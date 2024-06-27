namespace cleanwave_platform.Accounts;

public record CreateAccountResource(string Name, string LastName, string TypeSuscription, 
    float Price, string EmailAddress, string Password, string TypeAccount, string Phone);