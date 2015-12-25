using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class EnumerableAccessFactory : IPathElementFactory
    {
        public IPathElement Create(string path, out string newPath)
        {
            var matches = Regex.Matches(path, @"^\[(\d+)\]");
            Match match = matches[0];
            //0 is the whole match
            int index = int.Parse(match.Groups[1].Value); //the regex guarantees that the second group is an integer, so no further check is needed
            newPath = path.Remove(0, match.Value.Length);
            return new EnumerableAccess(index);
        }

        public bool IsApplicable(string path)
        {
            return Regex.IsMatch(path, @"^\[\d+\]");
        }
    }
}
