using System.Collections.Generic;
using Pather.CSharp.PathElements;

namespace Pather.CSharp
{
    public interface IResolver
    {
        IList<IPathElementFactory> PathElementFactories { get; set; }

        IList<IPathElement> CreatePath(string path);
        object Resolve(object target, IList<IPathElement> pathElements);
        object Resolve(object target, string path);
    }
}