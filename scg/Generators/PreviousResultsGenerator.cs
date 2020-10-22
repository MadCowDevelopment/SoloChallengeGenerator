using System.Text;

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
            var builder = new StringBuilder();
            foreach (var challenge in _challengeData)
            {
                builder.AppendLine($":chalice:[thread={challenge.ThreadId}][/thread] -- high score {challenge.Score} by {challenge.User}:chalice:");
            }

            return template.Replace(Token, builder.ToString());
        }
    }
}