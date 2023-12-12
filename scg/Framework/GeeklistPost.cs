namespace scg.Framework;

public class GeeklistPost
{
    public string Comments { get; set; }

    public GeeklistPost(string comments)
    {
        Comments = comments;
    }

    public void IncludeThread(string threadId)
    {
        Comments = Comments.Replace("$THREAD_ID$", threadId);
    }
}