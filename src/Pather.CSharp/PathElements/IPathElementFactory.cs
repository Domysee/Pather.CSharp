using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public interface IPathElementFactory
    {
        /// <summary>
        /// checks if the factory can create a path element from the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool IsApplicable(string path);

        /// <summary>
        /// creates a path element from the given path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newPath">outputs the path removed by the bit that was used to create the path element</param>
        /// <returns></returns>
        IPathElement Create(string path, out string newPath);
    }
}
