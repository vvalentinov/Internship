namespace _12._SOLID.Helpers.SecretsHelper;

public interface ISecretsHelper
{
    string GetSecret(string key, string? section = null);
}
