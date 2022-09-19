using System.Collections.Generic;
using System.Linq;

namespace scg.Framework
{
    public class Building
    {
        private readonly FlagsDictionary _flags;

        private readonly Dictionary<string, string> _translations = new();
        public Building(string category, string subcategory, FlagsDictionary flags)
        {
            _flags = flags;
            Id = NextId++;
            Category = category;
            Subcategory = subcategory;
        }

        private static int NextId { get; set; } = 1;

        public string Category { get; }
        public string Subcategory { get; }
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
            return FormatTranslations(_translations);
        }

        public string ToPostFormatWithoutDuplicateTranslations()
        {
            var englishTranslation = _translations["English"];
            return FormatTranslations(_translations.Where(p => p.Key == "English" || p.Value != englishTranslation));
        }

        private string FormatTranslations(IEnumerable<KeyValuePair<string, string>> translations)
        {
            return string.Join(" - ",
                translations.Select(p =>
                {
                    var translation = string.Empty;
                    if (_flags.Exists(p.Key))
                    {
                        translation += $"[microbadge={_flags[p.Key]}]";
                    }

                    translation += p.Value;
                    return translation;
                }));
        }
    }
}