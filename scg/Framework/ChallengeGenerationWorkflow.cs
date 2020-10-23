using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using scg.App;
using scg.Services;
using scg.Utils;

namespace scg.Framework
{
    internal class ChallengeGenerationWorkflow
    {
        private readonly ChallengeGenerator _challengeGenerator;

        public ChallengeGenerationWorkflow(ChallengeGenerator challengeGenerator)
        {
            _challengeGenerator = challengeGenerator;
        }

        public Task<int> Run(GenerateOptions options)
        {
            var challengePost = _challengeGenerator.Generate();
            var outputFilename = @"ForumPost.txt";
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, outputFilename), challengePost);
            FileHelper.OpenFile(outputFilename);

            return Task.FromResult(0);
        }

        private static async Task BggUploadSampleCode()
        {
            var service = new BggApiService();
            var cookie = await service.Login("<<USER>>", "<<PASSWORD>>", new CookieContainer());
            await service.PostImage(cookie, @"D:\Incoming", "IMG_20201020_112002.jpg");
            await service.PostThread(cookie);
        }
    }
}
