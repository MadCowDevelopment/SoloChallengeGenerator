using System.IO;
using System;
using System.Collections.Generic;
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

        listId = await GetFromMongoDb(year);
        await SaveIdToFile(year, listId.Value);
        return listId.Value;
    }

    private static async Task<int?> GetFromFile(int year)
    {
        var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MadCowDevelopment", "scg", Filename.GeeklistId);
        if (!File.Exists(filename)) return null;
        var content = await File.ReadAllTextAsync(filename);
        var savedYear = int.Parse(content.Split(",")[0]);
        if (savedYear == year) return int.Parse(content.Split(",")[0]);
        return null;
    }

    private static async Task<int> GetFromMongoDb(int year)
    {
        var username = "scg";
        var password = "anonymous";
        var mongoDbAuthMechanism = "SCRAM-SHA-1";
        var internalIdentity = new MongoInternalIdentity("admin", username);
        var passwordEvidence = new PasswordEvidence(password);
        var mongoCredential = new MongoCredential(mongoDbAuthMechanism, internalIdentity, passwordEvidence);
        var credentials = new List<MongoCredential>() { mongoCredential };


        var settings = new MongoClientSettings();
        settings.Credentials = credentials;

        var mongoHost = "mongodb+srv://madcowdevcluster.mtp5x8f.mongodb.net";
        var address = new MongoServerAddress(mongoHost);
        settings.Server = address;

        var client = new MongoClient(settings);

        var db = client.GetDatabase("SoloChallengeGenerator");
        var collection = db.GetCollection<SubscriptionGeeklist>("SubscriptionGeeklist");
        return (await collection.Find(p => p.Year == year).SingleOrDefaultAsync()).ListId;
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
