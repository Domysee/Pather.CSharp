using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class EnumerableAccessFactory : IPathElementFactory
    {
        public IPathElement Create(string pathElement)
        {
            var matches = Regex.Matches(pathElement, @"^(\w+)\[(\d+)\]$");
            Match match = matches[0];
            //0 is the whole match
            string property = match.Captures[1].Value;
            int index = int.Parse(match.Captures[2].Value); //the regex guarantees that the second group is an integer, so no further check is needed

            return new EnumerableAccess(property, index);
        }

        public bool IsApplicable(string pathElement)
        {
            return Regex.IsMatch(pathElement, @"^\w+\[\d+\]$");
        }
    }
}
