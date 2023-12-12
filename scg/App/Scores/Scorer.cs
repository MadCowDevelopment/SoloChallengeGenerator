using System.Threading.Tasks;
using Ninject;
using scg.App.Options;
using scg.Framework;

namespace scg.App.Scores;

public class Scorer
{
    public static Task<int> Add(ScoreOptions options)
    {
        var bootstrapper = new Bootstrapper();
        return bootstrapper.Execute(options);
    }

    private class Bootstrapper
    {
        private readonly IKernel _kernel = new StandardKernel();

        public Task<int> Execute(ScoreOptions options)
        {
            _kernel.Bind<ScgOptionsRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<ScgOptions>().ToMethod(p => _kernel.Get<ScgOptionsRepository>().Options);

            _kernel.Bind<FileRepository>().ToSelf().InSingletonScope().WithConstructorArgument("game", options.Game);
            _kernel.Bind<ScoreWorkflow>().ToSelf().InSingletonScope();
            return _kernel.Get<ScoreWorkflow>().Run(options);
        }
    }
}