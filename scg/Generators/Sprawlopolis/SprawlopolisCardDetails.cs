namespace scg.Generators.Sprawlopolis
{
    public class SprawlopolisCardDetails : CardDetailsBase
    {
        public override string GameId { get; } = "Sprawlopolis";

        public SprawlopolisCardDetails()
        {
            Add(1, $"1 pt / Road that does not end at the edge of the city.{N}-1 pt / Road that ends at the edge of the city.");
            Add(2, $"1 pt / Each row & column with exactly 3 Park blocks in it.{N}-1 pt / Each row & column with exactly 0 Park blocks in it.");
            Add(3, $"1 pt / Park block in your city.{N}-3 pts / Industrial block in your city.");
            Add(4, $"Score points per group of 4 \"corner to corner\" blocks of the same type. You may score multiple groups of the same type and a block may apply to more than one group." +
                   $"{N}[c]# of groups:  0  1  2  3  4  5+" +
                   $"{N}     Points: -8 -5 -2  1  4  7[/c]");
            Add(5, $"2 pts / Industrial block adjacent to only Commercial and Industrial blocks.");
            Add(6, $"Subtract the number of blocks in your largest Industrial group from the number of blocks in your largest Residential group. Score that many points.");
            Add(7, $"1pt / Park block located on the interior of the city.{N}-2 pts / Park block on the edge of the city.");
            Add(8, $"1 pt / Park block adjacent to your largest group of Residential blocks.{N}-2 pts / Industrial block adjacent to your largest group of Residential blocks.");
            Add(9, $"1 pt / Industrial block that shares a corner with at least 1 other Industrial block.");
            Add(10, $"1 pt / Commercial block in any 1 Row or Column of your choice. You may only score for 1 Row or Column." );
            Add(11, $"2 pts / Commercial block directly between two Residential blocks with the same road connecting all three blocks. Blocks may be a straight line or in a \"stepped\" pattern.");
            Add(12, $"1 pt / every 2 Road sections (rounded down) that are part of your longest road.");
            Add(13, $"3 pts / Road that begins at one Park and ends at a different Park.");
            Add(14, $"1 pt / Road section in a completed loop. You may score multiple loops in your city.");
            Add(15, $"2 pts / Residential block adjacent to 2 or more Industrial blocks.");
            Add(16, $"2 pts / Road that passes through both a Residential block and a Commercial block.");
            Add(17, $"1 pt / Commercial block on the edge of the city.{N}Additional 1 pt / Commercial block on a corner edge.");
            Add(18, $"Add the number of blocks in your longest Row to the number of blocks in your longest Column (skipping any gaps). Score that many points.");
        }
    }
}
