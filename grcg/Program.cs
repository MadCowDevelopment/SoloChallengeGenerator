using System;
using System.Globalization;
using System.IO;

namespace grcg
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
            
            GenerateNewPost();
        }

        private static void GenerateNewPost()
        {
            var generator = new Generator(BuildingData.Load(), ChallengeData.Load());
            var challengePost = generator.Generate();
            var outputFilename = @"ForumPost.txt";
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, outputFilename), challengePost);
            FileHelper.OpenFile(outputFilename);
        }
    }
}
