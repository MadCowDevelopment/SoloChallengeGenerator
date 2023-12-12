namespace scg.Generators.Sprawlopolis;

public class AgropolisCardDetails : CardDetailsBase
{
    public override string GameId { get; } = "Agropolis";

    public AgropolisCardDetails()
    {
        Add(1, $"1 pt / Road that passes through 2 or more Vineyard blocks.{N}-1 pt / Road that passes through 0 or 1 Vineyard blocks.");
        Add(2, $"Score points based on the largest completed square group of blocks.{N}4x4 = -5 pts{N}5x5 = 2 pts{N}6x6 = 5 pts");
        Add(3, $"1 pt / Cow Pen not in the same row or column as any other Livestock block.{N}-2 pts / Cow Pen in the same row or column as any other Livestock block.");
        Add(4, $"1 pt / Chicken Pen directly across a straight road segment from at least 1 other Chicken Pen.{N} -4 pts if none of your Chicken Pens score as described above.");
        Add(5, $"1 pt / Pig Pen adjacent to your longest road.{N}-1 pt / Pig Pen not adjacent to your longest road.");
        Add(6, $"1 pt / Row or column with 1 or more Vineyard blocks and 1 or more Orchard blocks.{N}-1 pt / Row or column without both a Vineyard block and an Orchard block.");
        Add(7, $"2 pts / Single Cow Pen block adjacent to 2 or more Cornfield blocks.{N}2 pts / Double Cow Pen block adjacent to 2 or more Cornfield blocks.");
        Add(8, $"2 pts / Chicken Pen inside each completed road loop.");
        Add(9, $"2 pts / Cow Pen adjacent to 0 or 1 roads.{N}-1 pt / Cow Pen adjacent to 2 or more roads.");
        Add(10, $"2 pts / Pig Pen adjacent to your largest Vineyard group.{N}-2 pts / Pig Pen not adjacent to your largest Vineyard group.");
        Add(11, $"Count the number of left and right turns on your longest road. Score that many points.");
        Add(12, $"2 pts / Road that passes through more Cornfield blocks than any other block type.");
        Add(13, $"Score points for each Orchard group of a given size, regardless of shape.{N}Exactly 2 blocks = 1 pt{N}Exactly 3 blocks = 3 pts{N}Exactly 4 blocks = 5 pts");
        Add(14, $"1 pt / Pig Pen adjacent to 1 or more Chicken Blocks but not to another Pig Block.{N}1 pt / Chicken Pen adjacent to 1 or more Pig Blocks but not to another Chicken Block.");
        Add(15, $"2 pts / Cornfield block on a corner (with 2 exposed edges).{N}-2 pts / Cornfield block not on a corner.");
        Add(16, $"3 pts / Orchard group with a different number of blocks than any other Orchard group.{N}Bonus 5 pts if every Orchard group has a different number of blocks.");
        Add(17, $"3 pts / Livestock group that contains an even number of pens and at least 2 different Livestock types.");
        Add(18, $"Count all of the Livestock Pens in your longest row and in your longest column. Score that many points.");
    }
}