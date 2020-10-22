using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;
using scg.Generators;

namespace scg
{
    class Program
    {
        //static async Task Main(string[] args)
        //{
        //    var service = new BggApiService();
        //    var cookie = await service.Login("<<USER>>", "<<PASSWORD>>", new CookieContainer());
        //    await service.PostImage(cookie, @"D:\Incoming", "IMG_20201020_112002.jpg");
        //    await service.PostThread(cookie);
        //}

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Argument missing: A GameId is required.");
                Console.WriteLine("E.g. dotnet scg.dll GlassRoad");
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
                _kernel.Bind<GlobalRepository>().ToSelf().InSingletonScope();
                _kernel.Bind<FlagsDictionary>().ToSelf().InSingletonScope();
                _kernel.Bind<Generator>().ToSelf().InSingletonScope();
                _kernel.Bind<BuildingData>().ToSelf().InSingletonScope();
                _kernel.Bind<ChallengeData>().ToSelf().InSingletonScope();

                _kernel.Bind(s=>s.FromAssembliesMatching("scg.dll").IncludingNonPublicTypes()
                    .Select(type => type.GetInterfaces().Contains(typeof(ITemplateGenerator)))
                    .BindAllInterfaces()
                    .Configure(x => x.InSingletonScope()));
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
