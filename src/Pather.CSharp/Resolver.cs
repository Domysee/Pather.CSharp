using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Pather.CSharp.PathElements;

namespace Pather.CSharp
{
    public class Resolver : IResolver
    {
        public IList<IPathElementFactory> PathElementFactories { get; set; }    //more specific ones must be first

        public Resolver()
        {
            PathElementFactories = new List<IPathElementFactory>();
            PathElementFactories.Add(new PropertyFactory());
            PathElementFactories.Add(new EnumerableAccessFactory());
            PathElementFactories.Add(new DictionaryAccessFactory());
            PathElementFactories.Add(new SelectionFactory());
        }

        public IList<IPathElement> CreatePath(string path)
        {
            var pathElements = new List<IPathElement>();
            var tempPath = path;
            while (tempPath.Length > 0)
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
            return pathElements;
        }

        public object Resolve(object target, string path)
        {
            var pathElements = CreatePath(path);
            return Resolve(target, pathElements);
        }

        public object Resolve(object target, IList<IPathElement> pathElements)
        {
            var tempResult = target;
            foreach (var pathElement in pathElements)
            {
                if (tempResult is Selection)
                    tempResult = pathElement.Apply((Selection)tempResult);
                else
                    tempResult = pathElement.Apply(tempResult);
            }

            var result = tempResult;
            if (result is Selection)
                return ((Selection)result).AsEnumerable();
            else
                return result;
        }

        private IPathElement createPathElement(string path, out string newPath)
        {
            //get the first applicable path element type
            var pathElementFactory = PathElementFactories.Where(f => f.IsApplicable(path)).FirstOrDefault();

            if (pathElementFactory == null)
                throw new InvalidOperationException($"There is no applicable path element type for {path}");

            IPathElement result = pathElementFactory.Create(path, out newPath);
            return result;
        }
    }
}
