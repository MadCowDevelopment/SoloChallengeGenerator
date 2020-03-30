using System.Collections.Generic;
using System.Linq;

namespace grcg
{
    internal class ChallengeData : List<ChallengeResult>
    {
        private readonly FileRepository _repository;

        public ChallengeData(FileRepository repository)
        {
            _repository = repository;
            Load();
        }

        private void Load()
        {
            foreach (var line in _repository.ReadAllLines("PreviousChallenges.dat", true).Select(p=>p.Split(",")))
            {
                Add(new ChallengeResult(line[0], line[1], line[2]));
            }
        }
    }
}