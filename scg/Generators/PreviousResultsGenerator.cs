using System.Text;
using scg.Framework;

namespace scg.Generators
{
    internal class PreviousResultsGenerator : TemplateGenerator
    {
        private readonly ChallengeData _challengeData;

        public PreviousResultsGenerator(ChallengeData challengeData)
        {
            _challengeData = challengeData;
        }

        public override string Token { get; } = "<<PREVIOUS_RESULTS>>";
        public override string Apply(string template, string[] arguments)
        {
            var scoringTemplate = arguments.Length > 0 ? arguments[0] : "high score {0} by {1}";

            var builder = new StringBuilder();
            foreach (var challenge in _challengeData)
            {
                var score = string.Format(scoringTemplate, challenge.Score, challenge.User);
                builder.AppendLine($":chalice:[thread={challenge.ThreadId}][/thread] -- {score}:chalice:");
            }

            return template.Replace(Token, builder.ToString());
        }
    }
}