using scg.Utils;

namespace scg.Generators
{
    public class EndDateGenerator : TemplateGenerator
    {
        private readonly EndDateHelper _endDateHelper;

        public EndDateGenerator(EndDateHelper endDateHelper)
        {
            _endDateHelper = endDateHelper;
        }

        public override string Token { get; } = "<<END_DATE>>";

        public override string Apply(string template, string[] arguments)
        {
            var months = int.Parse(arguments[0]);
            var endDate = _endDateHelper.GetEndDate(months);
            return template.Replace(Token, endDate.ToShortDateString());
        }
    }
}