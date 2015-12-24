using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public interface IPathElementFactory
    {
        bool IsApplicable(string pathElement);
        IPathElement Create(string pathElement);
    }
}
