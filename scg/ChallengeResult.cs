namespace scg
{
    internal class ChallengeResult
    {
        public string ThreadId { get; }
        public string Score { get; }
        public string User { get; }

        public ChallengeResult(string threadId, string score, string user)
        {
            ThreadId = threadId;
            Score = score;
            User = user;
        }
    }
}