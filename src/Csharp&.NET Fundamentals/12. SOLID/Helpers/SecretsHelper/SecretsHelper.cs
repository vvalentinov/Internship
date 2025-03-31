using Microsoft.Extensions.Configuration;

namespace _12._SOLID.Helpers.SecretsHelper;

public class SecretsHelper : ISecretsHelper
{
    private readonly IConfiguration _configuration;

    public SecretsHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetSecret(
        string key,
        string? section = null)
    {
        if (section is not null)
        {
            return _configuration.GetSection(section)[key] ?? string.Empty;
        }

        return _configuration[key];
    }
}
