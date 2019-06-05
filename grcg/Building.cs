using System.Collections.Generic;
using System.Linq;

namespace grcg
{
    internal class Building
    {
        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();
        public Building(Category category)
        {
            Category = category;
        }

        public Category Category { get; }
        public IEnumerable<KeyValuePair<string, string>> Translations => _translations;

        public void AddTranslation(string language, string name)
        {
            _translations.Add(language, name);
        }

        public string ToPostFormat()
        {
            var translations = _translations.Select(p =>
            {
                var translation = string.Empty;
                if (BuildingData.Flags.Exists(p.Key))
                {
                    translation += $"[microbadge={BuildingData.Flags[p.Key]}]";
                }

                translation += p.Value;
                return translation;
            });

            return string.Join(" - ", translations);
        }
    }
}