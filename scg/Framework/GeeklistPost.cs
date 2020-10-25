namespace scg.Framework
{
    internal class GeeklistPost
    {
        public string Comments { get; private set; }

        public GeeklistPost(string comments)
        {
            Comments = comments;
        }

        public void IncludeThread(string threadId)
        {
            Comments = Comments.Replace("$THREAD_ID$", threadId);
        }
    }
}