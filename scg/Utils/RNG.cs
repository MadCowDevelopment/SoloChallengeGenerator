using System;

namespace scg.Utils;

public static class RNG
{
    private static readonly Random _rng = new Random((int)DateTime.Now.Ticks);

    public static int Between(int inclusiveLowerBound, int inclusiveUpperBound)
    {
        return _rng.Next(inclusiveLowerBound, inclusiveUpperBound + 1);
    }

    public static bool Bool()
    {
        return Between(0, 1) == 1;
    }
}