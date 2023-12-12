using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Conventions;
using scg.App.Options;
using scg.Framework;
using scg.Generators;
using scg.Services;
using scg.Utils;

namespace scg.App.Generator;

public class Generator
{
    public static Task<int> Generate(GenerateOptions options)
    {
        var bootstrapper = new Bootstrapper();
        return bootstrapper.Execute(options);
    }

    private class Bootstrapper
    {
        private readonly IKernel _kernel = new StandardKernel();

        public Task<int> Execute(GenerateOptions options)
        {
            _kernel.Bind<ScgOptionsRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<ScgOptions>().ToMethod(p => _kernel.Get<ScgOptionsRepository>().Options);

            _kernel.Bind<FileRepository>().ToSelf().InSingletonScope().WithConstructorArgument("game", options.Game);
            _kernel.Bind<GameMetadataReader>().ToSelf().InSingletonScope();
            _kernel.Bind<GameMetadata>().ToConstant(_kernel.Get<GameMetadataReader>().Read());
            _kernel.Bind<GenerationResult>().ToConstant(new GenerationResult());
            _kernel.Bind<BggApiService>().ToSelf();
            _kernel.Bind<GeeklistIdRepository>().ToSelf().InSingletonScope();

            _kernel.Bind<IDateTime>().To<DateTimeWrapper>();

            _kernel.Bind<GlobalRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<FlagsDictionary>().ToSelf().InSingletonScope();
            _kernel.Bind<ChallengeGenerationWorkflow>().ToSelf().InSingletonScope();
            _kernel.Bind<ChallengeGenerator>().ToSelf().InSingletonScope();
            _kernel.Bind<BuildingData>().ToSelf().InSingletonScope();
            _kernel.Bind<ChallengeData>().ToSelf().InSingletonScope();
            _kernel.Bind<GameOptions>().ToSelf().InSingletonScope();

            _kernel.Bind(s => s.FromAssembliesMatching("scg.dll").IncludingNonPublicTypes()
                .Select(type => type.GetInterfaces().Contains(typeof(ITemplateGenerator)))
                .BindAllInterfaces()
                .Configure(x => x.InSingletonScope()));

            return _kernel.Get<ChallengeGenerationWorkflow>().Run(options);
        }
    }
}