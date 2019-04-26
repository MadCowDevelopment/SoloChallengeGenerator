using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace grcg
{
    internal class ChallengeData : List<ChallengeResult>
    {
        public static ChallengeData Load()
        {
            var data = new ChallengeData();
            foreach (var line in File.ReadAllLines(@Path.Combine(Environment.CurrentDirectory, @"PreviousChallenges.dat")).Select(p=>p.Split(",")))
            {
                data.Add(new ChallengeResult(line[0], line[1], line[2]));
            }

            return data;
        }
    }
}