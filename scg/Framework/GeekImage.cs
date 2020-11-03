namespace scg.Framework
{
    public class GeekImage
    {
        public string Identifier { get; }
        public string Filename { get; }

        public GeekImage(string identifier, string filename)
        {
            Identifier = identifier;
            Filename = filename;
        }
    }
}