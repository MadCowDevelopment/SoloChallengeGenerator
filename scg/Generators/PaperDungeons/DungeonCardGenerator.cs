// © Baker Hughes Company. All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes Company.
// Do not use, copy or distribute without permission.

using scg.Utils;

namespace scg.Generators.PaperDungeons
{
    public class DungeonCardGenerator : TemplateGenerator
    {
        private readonly EndDateHelper _endDateHelper;
        public override string Token { get; } = "<<DUNGEON_CARD>>";

        public DungeonCardGenerator(EndDateHelper endDateHelper)
        {
            _endDateHelper = endDateHelper;
        }

        public override string Apply(string template, string[] arguments)
        {
            var month = _endDateHelper.GetEndDate(1).Month;
            char dungeonCard = (char)(month + 64);
            return template.Replace(Token, dungeonCard.ToString());
        }
    }
}