using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using scg.Utils;

namespace scg.App.Options;

internal class ScgOptionsRepository
{
    private const string PassPhrase = "NotReallyASecret";
    private readonly ScgOptions _options;

    public ScgOptionsRepository()
    {
        if (System.IO.File.Exists("appsettings.json"))
        {
            _options = JsonConvert.DeserializeObject<ScgOptions>(System.IO.File.ReadAllText("appsettings.json"));
            foreach (var prop in typeof(ScgOptions).GetProperties().Where(p=>p.GetCustomAttribute<EncryptedAttribute>() != null))
            {
                string decrypted;
                try
                {

                    decrypted = StringCipher.Decrypt((string)prop.GetValue(_options), PassPhrase);
                    prop.SetValue(_options, decrypted);
                }
                catch (Exception)
                {
                    decrypted = null;
                }

                prop.SetValue(_options, decrypted);
            }
        }
        else
        {
            _options = new ScgOptions();
        }
    }

    public ScgOptions Options => _options;

    public void Set(string identifier, string value)
    {
        var property = typeof(ScgOptions).GetProperty(identifier, BindingFlags.Public | BindingFlags.Instance);
        if (property == null)
        {
            Console.WriteLine($"Setting with identifier '{identifier}' was not found.");
            return;
        }

        property.SetValue(_options, value);
        Save();
    }

    public string Get(string identifier)
    {
        var property = typeof(ScgOptions).GetProperty(identifier, BindingFlags.Public | BindingFlags.Instance);
        if (property == null)
        {
            Console.WriteLine($"Setting with identifier '{identifier}' was not found.");
            return string.Empty;
        }

        return property.GetValue(_options)?.ToString();
    }

    private void Save()
    {
        var optionsToSave = _options with { };
        foreach (var prop in typeof(ScgOptions).GetProperties().Where(p=>p.GetCustomAttribute<EncryptedAttribute>() != null))
        {
            prop.SetValue(optionsToSave, StringCipher.Encrypt((string)prop.GetValue(optionsToSave), PassPhrase));
        }

        System.IO.File.WriteAllText("appsettings.json", JsonConvert.SerializeObject(optionsToSave));
    }
}