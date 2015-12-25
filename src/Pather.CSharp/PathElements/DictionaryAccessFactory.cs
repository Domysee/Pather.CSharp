using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class DictionaryAccessFactory : IPathElementFactory
    {
        public IPathElement Create(string path, out string newPath)
        {
            var matches = Regex.Matches(path, @"^\[(\w+)\]");
            Match match = matches[0];
            //0 is the whole match
            string key = match.Groups[1].Value; //the regex guarantees that the second group is an integer, so no further check is needed
            newPath = path.Remove(0, match.Value.Length);
            return new DictionaryAccess(key);
        }

        public bool IsApplicable(string path)
        {
            return Regex.IsMatch(path, @"^\[\w+\]");
        }
    }
}
