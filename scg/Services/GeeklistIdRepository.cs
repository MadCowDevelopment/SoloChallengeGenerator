using System.IO;
using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace scg.Services;
public class GeeklistIdRepository
{
    public async Task<int> GetSubscriptionGeeklistId(int year)
    {
        var listId = await GetFromFile(year);
        if (listId != null) return listId.Value;

        Console.WriteLine($"Failed to find subscription geeklist ID locally. Downloading latest ID from mongodb.com...");
        listId = await GetFromMongoDb(year);

        Console.WriteLine($"Download finished. Storing it locally for future use.");
        await SaveIdToFile(year, listId.Value);
        return listId.Value;
    }

    private static async Task<int?> GetFromFile(int year)
    {
        var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MadCowDevelopment", "scg", Filename.GeeklistId);
        if (!File.Exists(filename)) return null;
        var content = await File.ReadAllTextAsync(filename);
        var savedYear = int.Parse(content.Split(",")[0]);
        if (savedYear == year) return int.Parse(content.Split(",")[1]);
        return null;
    }

    private static async Task<int> GetFromMongoDb(int year)
    {
        const string connectionUri = "mongodb+srv://scg:anonymous@madcowdevcluster.mtp5x8f.mongodb.net/?retryWrites=true&w=majority";
        var settings = MongoClientSettings.FromConnectionString(connectionUri);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);

        var db = client.GetDatabase("SoloChallengeGenerator");
        var collection = db.GetCollection<SubscriptionGeeklist>("SubscriptionGeeklist");
        var subscriptionGeeklist = await collection.Find(x => x.Year == year).FirstOrDefaultAsync();
        return subscriptionGeeklist.ListId;
    }

    private static async Task SaveIdToFile(int year, int listId)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MadCowDevelopment", "scg");
        Directory.CreateDirectory(path);

        var filename = Path.Combine(path, Filename.GeeklistId);
        await File.WriteAllTextAsync(filename, $"{year},{listId}");
    }
}

public record SubscriptionGeeklist(ObjectId Id, int Year, int ListId);
