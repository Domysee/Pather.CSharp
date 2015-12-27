using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class SelectionFactory : IPathElementFactory
    {
        private const string selectionIndicator = "[]";
        public IPathElement Create(string path, out string newPath)
        {
            newPath = path.Remove(0, selectionIndicator.Length);
            return new SelectionAccess();
        }

        public bool IsApplicable(string path)
        {
            return path.StartsWith(selectionIndicator);
        }
    }
}
