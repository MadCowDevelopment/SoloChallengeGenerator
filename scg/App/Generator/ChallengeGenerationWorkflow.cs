using System;
using System.IO;
using System.Threading.Tasks;
using scg.App.Options;
using scg.Framework;
using scg.Services;
using scg.Utils;

namespace scg.App.Generator
{
    internal class ChallengeGenerationWorkflow
    {
        private readonly ChallengeGenerator _challengeGenerator;
        private readonly BggApiService _bggApiService;
        private readonly GameMetadata _metadata;
        private readonly ScgOptions _options;

        public ChallengeGenerationWorkflow(ChallengeGenerator challengeGenerator, BggApiService bggApiService, GameMetadata metadata, ScgOptions options)
        {
            _challengeGenerator = challengeGenerator;
            _bggApiService = bggApiService;
            _metadata = metadata;
            _options = options;
        }

        public async Task<int> Run(GenerateOptions options)
        {
            var generationResult = _challengeGenerator.Generate();
            if (options.Publish) await PublishToBGG(options, generationResult);
            else await SaveToFile(generationResult);
            return 0;
        }

        private async Task PublishToBGG(GenerateOptions options, GenerationResult generationResult)
        {
            var user = _options.Username ?? ConsoleUtils.ReadValidString(options.User, "Username: ");
            var password = _options.Password ?? ConsoleUtils.ReadValidPassword(null, "Password: ");
            
            await _bggApiService.Login(user, password);

            foreach (var image in generationResult.Images)
            {
                var imageId = await _bggApiService.PostImage(@".\", image.Filename);
                generationResult.UpdateImageId(image.Identifier, imageId);
            }

            var forumId = _metadata.PostFormData.ForumId;

            var threadUri = await _bggApiService.PostThread(generationResult.ChallengePost.Subject, generationResult.ChallengePost.Body,
                forumId, _metadata.PostFormData.ObjectId, _metadata.PostFormData.ObjectType);
            Console.WriteLine($"Challenge posted at '{threadUri.OriginalString}'.");
            threadUri.OpenInBrowser();
            
            generationResult.GeeklistPost.IncludeThread(BggUtils.GetThreadFromLocation(threadUri.ToString()));
            await _bggApiService.PostGeeklistItem(
                GlobalIdentifiers.GeekListId,
                _metadata.GeeklistFormData.ObjectId,
                generationResult.GeeklistPost.Comments);
            Console.WriteLine("Challenge added to solo challenges geeklist.");
            new Uri($"https://boardgamegeek.com/geeklist/{GlobalIdentifiers.GeekListId}").OpenInBrowser();
        }

        private async Task SaveToFile(GenerationResult generationResult)
        {
            var outputFilename = @"ForumPost.txt";
            await System.IO.File.WriteAllTextAsync(Path.Combine(Environment.CurrentDirectory, outputFilename), generationResult.ChallengePost.Body);
            FileHelper.OpenFile(outputFilename);
        }
    }
}