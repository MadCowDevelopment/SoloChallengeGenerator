namespace scg.Framework
{
    internal class GenerationResultBuilder
    {
        private readonly GenerationResult _result;

        public GenerationResultBuilder()
        {
            _result = new GenerationResult();
        }

        public static GenerationResultBuilder Create()
        {
            return new GenerationResultBuilder();
        }

        public GenerationResultBuilder WithChallengePost(ChallengePost challengePost)
        {
            _result.ChallengePost = challengePost;
            return this;
        }

        public GenerationResult Build()
        {
            return _result;
        }
    }
}