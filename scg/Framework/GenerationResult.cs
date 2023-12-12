using System.Collections.Generic;

namespace scg.Framework;

public class GenerationResult
{
    private readonly List<GeekImage> _images = new List<GeekImage>();

    public ChallengePost ChallengePost { get; set; }
    public GeeklistPost GeeklistPost { get; set; }

    public IEnumerable<GeekImage> Images => _images;

    public void AddImage(GeekImage image)
    {
        _images.Add(image);
    }

    public void UpdateImageId(string imageIdentifier, in int imageId)
    {
        ChallengePost.Body = ChallengePost.Body.Replace($"${imageIdentifier}$", imageId.ToString());
        GeeklistPost.Comments = GeeklistPost.Comments.Replace($"${imageIdentifier}$", imageId.ToString());
    }
}