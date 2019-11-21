namespace grcg.Generators
{
    internal abstract class TemplateGenerator : ITemplateGenerator
    {
        public abstract string Token { get; }

        public abstract string Apply(string template, string[] arguments);
    }
}