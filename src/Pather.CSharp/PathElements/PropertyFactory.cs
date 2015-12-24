using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class PropertyFactory : IPathElementFactory
    {
        public IPathElement Create(string pathElement)
        {
            return new Property(pathElement);
        }

        public bool IsApplicable(string pathElement)
        {
            return Regex.IsMatch(pathElement, @"^\w+$");
        }
    }
}
