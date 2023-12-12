namespace scg.Framework;

public class ChallengePost
{
    public string Subject { get; }
    public string Body { get; set; }

    public ChallengePost(string subject, string body)
    {
        Subject = subject;
        Body = body;
    }
}