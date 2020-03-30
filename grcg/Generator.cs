using System;
using System.Collections.Generic;
using System.Linq;
using grcg.Generators;

namespace grcg
{
    internal class Generator
    {
        private readonly FileRepository _repository;
        private readonly Dictionary<string, ITemplateGenerator> _generators;

        public Generator(FileRepository repository, IEnumerable<ITemplateGenerator> generators)
        {
            _repository = repository;
            _generators = generators.ToDictionary(p => p.Token, p => p);
        }

        public string Generate()
        {
            var templateString = _repository.ReadAllText("ForumPost.template", true);
            var definitions = _repository.ReadAllLines("Generator.def", false);
            foreach (var definition in definitions)
            {
                var splitDefinitions = definition.Split(',');
                var token = splitDefinitions[0];
                var arguments = splitDefinitions.Skip(1).ToArray();
                if (_generators.ContainsKey(token))
                {
                    templateString = _generators[token].Apply(templateString, arguments);
                }
                else
                {
                    throw new InvalidOperationException($"No generator defined for token '{token}'.");
                }
            }

            return templateString;
        }
    }
}