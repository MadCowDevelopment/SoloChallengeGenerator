using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CommandLine;
using Ninject;
using Ninject.Extensions.Conventions;
using scg.Framework;
using scg.Generators;

namespace scg.App
{
    public class Generator
    {
        public static Task<int> Generate(GenerateOptions options)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

            return GenerateNewPost(options);
        }

        private static Task<int> GenerateNewPost(GenerateOptions options)
        {
            var bootstrapper = new Bootstrapper();
            return bootstrapper.Execute(options);
        }

        private class Bootstrapper
        {
            private readonly IKernel _kernel = new StandardKernel();

            public Task<int> Execute(GenerateOptions options)
            {
                _kernel.Bind<FileRepository>().ToSelf().WithConstructorArgument("game", options.Game);
                _kernel.Bind<GlobalRepository>().ToSelf().InSingletonScope();
                _kernel.Bind<FlagsDictionary>().ToSelf().InSingletonScope();
                _kernel.Bind<ChallengeGenerationWorkflow>().ToSelf().InSingletonScope();
                _kernel.Bind<ChallengeGenerator>().ToSelf().InSingletonScope();
                _kernel.Bind<BuildingData>().ToSelf().InSingletonScope();
                _kernel.Bind<ChallengeData>().ToSelf().InSingletonScope();

                _kernel.Bind(s => s.FromAssembliesMatching("scg*dll").IncludingNonPublicTypes()
                    .Select(type => type.GetInterfaces().Contains(typeof(ITemplateGenerator)))
                    .BindAllInterfaces()
                    .Configure(x => x.InSingletonScope()));

                return _kernel.Get<ChallengeGenerationWorkflow>().Run(options);
            }
        }
    }

    [Verb("generate", isDefault:true, HelpText = "Generate a new challenge post.")]
    public class GenerateOptions
    {
        [Value(0, HelpText = "The identifier of the game. E.g. GlassRoad", Required = true)]
        public string Game { get; set; }
    }
}
