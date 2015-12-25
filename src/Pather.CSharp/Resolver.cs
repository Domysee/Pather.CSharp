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
            var pathElements = new List<IPathElement>();
            var tempPath = path;
            while(tempPath.Length > 0)
            {
                var pathElement = createPathElement(tempPath, out tempPath);
                pathElements.Add(pathElement);
                //remove the dots chaining properties 
                //no PathElement could do this reliably
                //the only appropriate one would be Property, but there doesn't have to be a dot at the beginning (if it is the first PathElement, e.g. "Property1.Property2")
                //and I don't want that knowledge in PropertyFactory
                if (tempPath.StartsWith("."))
                    tempPath = tempPath.Remove(0, 1);
            }

            var tempResult = target;
            foreach(var pathElement in pathElements)
            {
                tempResult = pathElement.Apply(tempResult);
            }
            var result = tempResult;
            return result;
        }

        private IPathElement createPathElement(string path, out string newPath)
        {
            //get the first applicable path element type
            var pathElementFactory = pathElementTypes.Where(f => isApplicable(f, path)).FirstOrDefault();

            if (pathElementFactory == null)
                throw new InvalidOperationException($"There is no applicable path element type for {path}");

            IPathElement result = pathElementFactory.Create(path, out newPath);
            return result;
        }

        private bool isApplicable(IPathElementFactory factory, string pathElement)
        {
            return factory.IsApplicable(pathElement);
        }
    }
}
