using System;
using System.IO;
using System.Threading.Tasks;
using scg.App;
using scg.Services;
using scg.Utils;

namespace scg.Framework
{
    internal class ChallengeGenerationWorkflow
    {
        private readonly ChallengeGenerator _challengeGenerator;
        private readonly BggApiService _bggApiService;
        private readonly GameMetadata _metadata;

        public ChallengeGenerationWorkflow(ChallengeGenerator challengeGenerator, BggApiService bggApiService, GameMetadata metadata)
        {
            _challengeGenerator = challengeGenerator;
            _bggApiService = bggApiService;
            _metadata = metadata;
        }

        public async Task<int> Run(GenerateOptions options)
        {
            var generationResult = _challengeGenerator.Generate();
            if (options.Publish) await PublishToBGG(options, generationResult);
            else await SaveToFile(generationResult.ChallengePost.Body);
            return 0;
        }

        private async Task PublishToBGG(GenerateOptions options, GenerationResult generationResult)
        {
            var user = GetUser(options);
            var password = GetPassword();
            
            await _bggApiService.Login(user, password);

            //await service.PostImage(cookie, @"D:\Incoming", "IMG_20201020_112002.jpg");

            var threadUri = await _bggApiService.PostThread(generationResult.ChallengePost.Subject, generationResult.ChallengePost.Body,
                _metadata.PostFormData.ForumId, _metadata.PostFormData.ObjectId, _metadata.PostFormData.ObjectType);
            Console.WriteLine($"Challenge posted at '{threadUri.OriginalString}'.");
            threadUri.OpenInBrowser();
            
            generationResult.GeeklistPost.IncludeThread(BggUtils.GetThreadFromLocation(threadUri.ToString()));
            await _bggApiService.PostGeeklistItem(generationResult.GeeklistPost.Comments,
                GlobalIdentifiers.ListId, _metadata.GeeklistFormData.ObjectId,
                _metadata.GeeklistFormData.ObjectType, _metadata.GeeklistFormData.GeekItemName,
                _metadata.GeeklistFormData.ImageId);
            Console.WriteLine("Challenge added to solo challenges geeklist.");
            new Uri($"https://boardgamegeek.com/geeklist/{GlobalIdentifiers.ListId}").OpenInBrowser();
        }

        private static string GetPassword()
        {
            string password = null;
            while (string.IsNullOrEmpty(password))
            {
                Console.Write("Password: ");
                password = ConsoleUtils.ReadPassword();
            }

            return password;
        }

        private static string GetUser(GenerateOptions options)
        {
            var user = options.User;
            while (string.IsNullOrEmpty(user))
            {
                Console.Write("Username: ");
                user = Console.ReadLine();
            }

            return user;
        }

        private async Task SaveToFile(string challengePost)
        {
            var outputFilename = @"ForumPost.txt";
            await File.WriteAllTextAsync(Path.Combine(Environment.CurrentDirectory, outputFilename), challengePost);
            FileHelper.OpenFile(outputFilename);
        }
    }
}
