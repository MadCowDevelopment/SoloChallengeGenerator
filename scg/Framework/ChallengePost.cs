namespace scg.Framework
{
    internal class ChallengePost
    {
        public string Subject { get; }
        public string Body { get; }

        public ChallengePost(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}