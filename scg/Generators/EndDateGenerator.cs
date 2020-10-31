using scg.Utils;

namespace scg.Generators
{
    public class EndDateGenerator : TemplateGenerator
    {
        private readonly IDateTime _dateTime;

        public EndDateGenerator(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public override string Token { get; } = "<<END_DATE>>";

        public override string Apply(string template, string[] arguments)
        {
            var months = int.Parse(arguments[0]);
            var today = _dateTime.Now;
            var endDate = today;
            if (today.Day >= 16) endDate = _dateTime.Now.AddMonths(months);
           
            while (endDate.AddDays(1).Month == endDate.Month)
            {
                endDate = endDate.AddDays(1);
            }

            return template.Replace(Token, endDate.ToShortDateString());
        }
    }
}