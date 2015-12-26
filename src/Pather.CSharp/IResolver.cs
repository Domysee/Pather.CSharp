using System.Collections.Generic;
using Pather.CSharp.PathElements;

namespace Pather.CSharp
{
    public interface IResolver
    {
        IList<IPathElementFactory> PathElementFactories { get; set; }

        object Resolve(object target, string path);
    }
}