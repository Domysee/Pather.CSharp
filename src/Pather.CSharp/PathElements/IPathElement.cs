using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public interface IPathElement
    {
        object Apply(object target);
        IEnumerable Apply(Selection target);
    }
}
