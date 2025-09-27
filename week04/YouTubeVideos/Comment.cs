public class Comment
{
    public string _commenterName { get; private set; }
    public string _commentText { get; private set; }

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }
}
