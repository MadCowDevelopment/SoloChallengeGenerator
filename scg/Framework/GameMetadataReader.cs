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
