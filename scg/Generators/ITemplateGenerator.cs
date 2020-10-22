namespace scg.Generators
{
    internal interface ITemplateGenerator
    {
        string Token { get; }

        string Apply(string template, string[] arguments);
    }
}