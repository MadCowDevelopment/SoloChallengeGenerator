using Newtonsoft.Json;

namespace scg.Framework
{
    public class GameMetadataReader
    {
        private readonly FileRepository _repository;

        public GameMetadataReader(FileRepository repository)
        {
            _repository = repository;
        }

        public GameMetadata Read()
        {
            return JsonConvert.DeserializeObject<GameMetadata>(_repository.ReadAllText("Metadata.json", false));
        }
    }

    public class GameMetadata
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public PostFormData PostFormData { get; set; }
        public GeeklistFormData GeeklistFormData { get; set; }
    }

    public class GeeklistFormData
    {
        public int ObjectId { get; }
        public string ObjectType { get; }
        public string GeekItemName { get; }
        public int ImageId { get; }

        public GeeklistFormData(int objectId, string objectType, string geekItemName, int imageId)
        {
            ObjectId = objectId;
            ObjectType = objectType;
            GeekItemName = geekItemName;
            ImageId = imageId;
        }
    }

    public class PostFormData
    {
        public int ForumId { get; }
        public int ObjectId { get; }
        public string ObjectType { get; }

        public PostFormData(int forumId, int objectId, string objectType)
        {
            ForumId = forumId;
            ObjectId = objectId;
            ObjectType = objectType;
        }
    }
}
