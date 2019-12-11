using System;
using System.Globalization;
using System.IO;
using grcg.Generators;
using Ninject;

namespace grcg
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Argument missing: A GameId is required.");
                Console.WriteLine("E.g. dotnet grcg.dll GlassRoad");
                Environment.Exit(-1);
            }

            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
            
            GenerateNewPost(args[0]);
        }

        private static void GenerateNewPost(string gameId)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Initialize(gameId);
            bootstrapper.Run();
        }

        private class Bootstrapper
        {
            private readonly IKernel _kernel = new StandardKernel();

            public void Initialize(string game)
            {
                _kernel.Bind<FileRepository>().ToSelf().WithConstructorArgument("game", game);
                _kernel.Bind<Generator>().ToSelf().InSingletonScope();
                _kernel.Bind<BuildingData>().ToSelf().InSingletonScope();
                _kernel.Bind<ChallengeData>().ToSelf().InSingletonScope();
                
                _kernel.Bind<ITemplateGenerator>().To<EndDateGenerator>().InSingletonScope();
                _kernel.Bind<ITemplateGenerator>().To<ChallengeNumberGenerator>().InSingletonScope();
                _kernel.Bind<ITemplateGenerator>().To<PreviousResultsGenerator>().InSingletonScope();
                _kernel.Bind<ITemplateGenerator>().To<StartingBuildingsGenerator>().InSingletonScope();
                _kernel.Bind<ITemplateGenerator>().To<OfferBuildingsGenerator>().InSingletonScope();
            }

            public void Run()
            {
                var challengePost = _kernel.Get<Generator>().Generate();
                var outputFilename = @"ForumPost.txt";
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, outputFilename), challengePost);
                FileHelper.OpenFile(outputFilename);
            }
        }
    }
}
