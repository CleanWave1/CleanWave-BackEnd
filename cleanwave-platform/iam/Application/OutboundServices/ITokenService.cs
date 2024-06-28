using cleanwave_platform.iam.Domain.Model.Aggregates;

namespace cleanwave_platform.iam.Application.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}