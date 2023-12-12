using System;
using System.Linq;
using System.Threading.Tasks;
using scg.Framework;
using scg.Utils;

namespace scg.App.Scores;

internal class ScoreWorkflow
{
    private readonly FileRepository _fileRepository;

    public ScoreWorkflow(FileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public Task<int> Run(ScoreOptions options)
    {
        return options.Operation switch
        {
            "add" => AddScore(options),
            "remove" => RemoveScore(),
            "list" => ListScores(),
            _ => throw new InvalidOperationException("The specified operation is not supported.")
        };
    }

    private Task<int> AddScore(ScoreOptions options)
    {
        var thread = ConsoleUtils.ReadValidInt(options.Thread, "Thread ID: ");
        var score = ConsoleUtils.ReadValidDouble(options.Score, "Score    : ");
        var user = ConsoleUtils.ReadValidString(options.User, "Username : ");
        _fileRepository.AppendLine(Filename.PreviousChallenges, $"{thread},{score},{user}");
        return Task.FromResult(0);
    }

    private Task<int> RemoveScore()
    {
        var lines = _fileRepository.ReadAllLines(Filename.PreviousChallenges, true);
        if (lines.Length > 0)
        {
            _fileRepository.WriteAllLines(Filename.PreviousChallenges, lines.SkipLast(1));
        }

        return Task.FromResult(0);
    }

    private Task<int> ListScores()
    {
        var lines = _fileRepository.ReadAllLines(Filename.PreviousChallenges, true);
        Console.WriteLine("Previous challenge scores: ");
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }

        return Task.FromResult(0);
    }
}