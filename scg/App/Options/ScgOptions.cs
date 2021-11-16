namespace scg.App.Options;

public record ScgOptions
{
    public string Username { get; set; }

    [Encrypted]
    public string Password { get; set; }

    public string DataFolder { get; set; }
}