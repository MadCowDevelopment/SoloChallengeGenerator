using System.Collections.Generic;
using System.Linq;

namespace scg.Framework
{
    public class Building
    {
        private readonly FlagsDictionary _flags;

        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();
        public Building(string category, FlagsDictionary flags)
        {
            _flags = flags;
            Id = NextId++;
            Category = category;
        }

        private static int NextId { get; set; } = 1;

        public string Category { get; }
        public IEnumerable<KeyValuePair<string, string>> Translations => _translations;
        public int Id { get; }

        public void AddTranslation(string language, string name)
        {
            _translations.Add(language, name);
        }

        public string ToEnglish()
        {
            return $"[microbadge={_flags["English"]}] - {_translations["English"]}";
        }

        public string ToPostFormat()
        {
            var translations = _translations.Select(p =>
            {
                var translation = string.Empty;
                if (_flags.Exists(p.Key))
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