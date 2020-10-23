using scg.Framework;

namespace scg.Generators
{
    internal class ChallengeNumberGenerator : TemplateGenerator
    {
        private readonly ChallengeData _challengeData;

        public ChallengeNumberGenerator(ChallengeData challengeData)
        {
            _challengeData = challengeData;
        }

        public override string Token { get; } = "<<CHALLENGE_NUMBER>>";
        public override string Apply(string template, string[] arguments)
        {
            return template.Replace(Token, (_challengeData.Count + 1).ToString());
        }
    }
}