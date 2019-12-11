using System;

namespace grcg.Generators
{
    internal class EndDateGenerator : TemplateGenerator
    {
        public override string Token { get; } = "<<END_DATE>>";

        public override string Apply(string template, string[] arguments)
        {
            var months = int.Parse(arguments[0]);
            var endDate = DateTime.Now.AddMonths(months);
            while (endDate.AddDays(1).Month == endDate.Month)
            {
                endDate = endDate.AddDays(1);
            }

            return template.Replace(Token, endDate.ToShortDateString());
        }
    }
}