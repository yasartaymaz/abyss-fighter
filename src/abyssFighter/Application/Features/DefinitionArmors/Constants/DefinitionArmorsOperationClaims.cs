namespace Application.Features.DefinitionArmors.Constants;

public static class DefinitionArmorsOperationClaims
{
    private const string _section = "DefinitionArmors";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}