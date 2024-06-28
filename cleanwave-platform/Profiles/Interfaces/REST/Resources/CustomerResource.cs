using cleanwave_platform.Profiles.Domain.Model.Entities;

namespace cleanwave_platform.Profiles.Interfaces.REST.Resources;

public record CustomerResource(
    int Id,
    string Name,
    string LastName,
    string Email,
    string Phone,
    SpaceDetails Space);
