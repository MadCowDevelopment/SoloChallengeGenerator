using System;

namespace grcg.Generators
{
    internal class EndDateGenerator : TemplateGenerator
    {
        public override string Token { get; } = "<<END_DATE>>";

        public override string Apply(string template, string[] arguments)
        {
            var endDate = DateTime.Now.AddMonths(1);
            while (endDate.AddDays(1).Month == endDate.Month)
            {
                endDate = endDate.AddDays(1);
            }

            return template.Replace("<<END_DATE>>", endDate.ToShortDateString());
        }
    }
}