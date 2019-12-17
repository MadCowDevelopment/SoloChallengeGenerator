using System;
using System.Collections.Generic;
using System.IO;

namespace grcg
{
    public class FlagsDictionary
    {
        public FlagsDictionary()
        {
            var flagData = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Flags.dat"));
            foreach (var f in flagData)
            {
                var tuple = f.Split(',');
                _flags.Add(tuple[0], tuple[1]);
            }
        }

        private static readonly Dictionary<string, string> _flags = new Dictionary<string, string>();

        public string this[string str] => _flags[str];

        public bool Exists(string key)
        {
            return _flags.ContainsKey(key);
        }
    }
}