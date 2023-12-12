using System;
using System.Collections.Generic;

namespace scg.Generators.Sprawlopolis;

public abstract class CardDetailsBase : Dictionary<int, string>
{
    protected static readonly string N = Environment.NewLine;

    public abstract string GameId { get; }
}