namespace cleanwave_platform.Accounts;

public record AccountResource(
    int Id,
    string Suscription,
    string FullName,
    string Email,
    string Password,
    string TypeAccount,
    string Phone);
