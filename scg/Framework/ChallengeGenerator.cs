using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using scg.Generators;

namespace scg.Framework
{
    internal class ChallengeGenerator
    {
        private readonly FileRepository _repository;
        private readonly GameMetadata _metadata;
        private readonly ChallengeData _challengeData;
        private readonly GenerationResult _generationResult;
        private readonly GameOptions _gameOptions;
        private readonly Dictionary<string, ITemplateGenerator> _generators;

        public ChallengeGenerator(
            FileRepository repository,
            GameMetadata metadata,
            ChallengeData challengeData,
            GenerationResult generationResult,
            GameOptions gameOptions,
            IEnumerable<ITemplateGenerator> generators)
        {
            _repository = repository;
            _metadata = metadata;
            _challengeData = challengeData;
            _generationResult = generationResult;
            _gameOptions = gameOptions;
            _generators = generators.ToDictionary(p => p.Token, p => p);
        }

        public GenerationResult Generate()
        {
            InitializeGeneratorOptions(_metadata.Id);
            _generationResult.ChallengePost =
                new ChallengePost(GeneratePostSubject(_metadata.Name, _challengeData.Count), GeneratePostBody());
            _generationResult.GeeklistPost = new GeeklistPost(GenerateGeeklistPostComments());
            return _generationResult;
        }

        private void InitializeGeneratorOptions(string gameId)
        {
            _gameOptions.Initialize(gameId);
        }

        private string GeneratePostSubject(string gameName, int challengeNumber)
        {
            var date = DateTime.Now.Day > 16 ? DateTime.Now.AddMonths(1) : DateTime.Now;
            var dateString = date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
            return $"{gameName} Solo Challenge #{challengeNumber+1} - {dateString}";
        }

        private string ApplyGeneratorsToTemplate(string templateFile, string generatorFile)
        {
            var templateString = _repository.ReadAllText(templateFile, true);
            var definitions = _repository.ReadAllLines(generatorFile, false);
            foreach (var definition in definitions)
            {
                if (string.IsNullOrWhiteSpace(definition)) continue;

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

        private string GeneratePostBody()
        {
            return ApplyGeneratorsToTemplate(File.ForumPostTemplate, File.ForumPostGenerators);
        }

        private string GenerateGeeklistPostComments()
        {
            return ApplyGeneratorsToTemplate(File.GeeklistPostTemplate, File.GeeklistPostGenerators);
        }
    }
}
