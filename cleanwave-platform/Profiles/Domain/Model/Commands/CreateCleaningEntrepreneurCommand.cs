namespace cleanwave_platform.Profiles.Domain.Model.Commands;

public record CreateCleaningEntrepreneurCommand(
    string Name,
    string Email,
    string Username);
