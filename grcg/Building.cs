using System.Collections.Generic;
using System.Linq;

namespace grcg
{
    internal class Building
    {
        private readonly Dictionary<string, string> _flags = new Dictionary<string, string>
        {
            {"English", "6887"},
            {"French", "6886"},
            {"German", "6922"},
            {"Spanish", "6889"}
        };

        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();
        public Building(Category category)
        {
            Category = category;
        }

        public Category Category { get; }

        public void AddTranslation(string language, string name)
        {
            _translations.Add(language, name);
        }

        public string ToPostFormat()
        {
            var translations = _translations.Select(p =>
            {
                var translation = string.Empty;
                if (_flags.ContainsKey(p.Key))
                {
                    translation += $"[microbadge={_flags[p.Key]}]";
                }

                translation += p.Value;
                return translation;
            });

            return string.Join(" - ", translations);
        }
    }
}