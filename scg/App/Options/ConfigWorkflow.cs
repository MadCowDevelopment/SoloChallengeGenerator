using System;
using System.Threading.Tasks;

namespace scg.App.Options
{
    internal class ConfigWorkflow
    {
        private readonly ScgOptionsRepository _optionsRepository;

        public ConfigWorkflow(ScgOptionsRepository optionsRepository)
        {
            _optionsRepository = optionsRepository;
        }

        public Task<int> Run(ConfigOptions configOptions)
        {
            return configOptions.Operation switch
            {
                "set" => SetOption(configOptions),
                "get" => GetOption(configOptions),
                _ => throw new InvalidOperationException("The specified operation is not supported.")
            };
        }

        private Task<int> SetOption(ConfigOptions configOptions)
        {
            _optionsRepository.Set(configOptions.Identifier, configOptions.Value);
            return Task.FromResult(0);
        }

        private Task<int> GetOption(ConfigOptions configOptions)
        {
            var value = _optionsRepository.Get(configOptions.Identifier);
            Console.WriteLine($"Value for option with identifier '{configOptions.Identifier}': {value}");
            return Task.FromResult(0);
        }
    }
}