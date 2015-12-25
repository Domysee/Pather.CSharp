using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Pather.CSharp.PathElements;

namespace Pather.CSharp
{
    public class Resolver
    {
        private IList<IPathElementFactory> pathElementTypes;

        public Resolver()
        {
            pathElementTypes = new List<IPathElementFactory>();
            pathElementTypes.Add(new PropertyFactory());
            pathElementTypes.Add(new EnumerableAccessFactory());
        }

        public object Resolve(object target, string path)
        {
            var pathElementStrings = path.Split('.');
            var pathElements = pathElementStrings.Select(pe => createPathElement(pe));
            var tempResult = target;
            foreach(var pathElement in pathElements)
            {
                tempResult = pathElement.Apply(tempResult);
            }
            var result = tempResult;
            return result;
        }

        private IPathElement createPathElement(string pathElement)
        {
            //get the first applicable path element type
            var pathElementFactory = pathElementTypes.Where(f => isApplicable(f, pathElement)).FirstOrDefault();

            if (pathElementFactory == null)
                throw new InvalidOperationException($"There is no applicable path element type for {pathElement}");

            IPathElement result = pathElementFactory.Create(pathElement);
            return result;
        }

        private bool isApplicable(IPathElementFactory factory, string pathElement)
        {
            return factory.IsApplicable(pathElement);
        }
    }
}
