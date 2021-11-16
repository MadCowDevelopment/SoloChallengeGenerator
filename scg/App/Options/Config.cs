using System.Threading.Tasks;
using Ninject;

namespace scg.App.Options
{
    public class Config
    {
        public static Task<int> Run(ConfigOptions configOptions)
        {
            var bootstrapper = new Bootstrapper();
            return bootstrapper.Execute(configOptions);
        }

        private class Bootstrapper
        {
            private readonly IKernel _kernel = new StandardKernel();

            public Task<int> Execute(ConfigOptions configOptions)
            {
                _kernel.Bind<ConfigWorkflow>().ToSelf().InSingletonScope();
                _kernel.Bind<ScgOptionsRepository>().ToSelf().InSingletonScope();

                return _kernel.Get<ConfigWorkflow>().Run(configOptions);
            }
        }
    }
}