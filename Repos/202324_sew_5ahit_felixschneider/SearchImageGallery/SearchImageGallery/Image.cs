namespace SearchImageGallery;

public abstract class Image
{
    public string Tag { get; set; }
    public string Url { get; set; }

    public Image(string tag, string url)
    {
        Tag = tag;
        Url = url;
    }
}

public enum EImageType
{
    IMAGE,
    THUMBNAIL
}

public class RawImage : Image
{
    public EImageType Type = EImageType.IMAGE;

    public RawImage(string tag, string url) : base(tag, url)
    {
    }
}

public class ThumbnailImage : Image
{
    public EImageType Type = EImageType.THUMBNAIL;

    public ThumbnailImage(string tag, string url) : base(tag, url)
    {
    }
}