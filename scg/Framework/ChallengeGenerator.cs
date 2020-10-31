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
        private readonly Dictionary<string, ITemplateGenerator> _generators;

        public ChallengeGenerator(
            FileRepository repository,
            GameMetadata metadata,
            ChallengeData challengeData,
            IEnumerable<ITemplateGenerator> generators)
        {
            _repository = repository;
            _metadata = metadata;
            _challengeData = challengeData;
            _generators = generators.ToDictionary(p => p.Token, p => p);
        }

        public GenerationResult Generate()
        {
            return GenerationResultBuilder.Create()
                .WithChallengePost(new ChallengePost(GeneratePostSubject(_metadata.Name, _challengeData.Count), GeneratePostBody()))
                .WithGeeklistPost(new GeeklistPost(GenerateGeeklistPostComments()))
                .Build();
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