namespace cleanwave_platform.Profiles.Interfaces.REST.Resources;

public record CreateCustomerResource(
    string Name,
    string LastName,
    string Email,
    string Phone,
    string PropertyType,
    string CleaningType,
    string SpaceSize,
    int? NumberRooms,
    string FloorType,
    string Instructions);
