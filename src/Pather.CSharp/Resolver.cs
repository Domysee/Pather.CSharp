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
        private IList<Type> pathElementTypes;

        public Resolver()
        {
            pathElementTypes = new List<Type>();
            pathElementTypes.Add(typeof(Property));
        }

        public object Resolve(object target, string path)
        {
            var pathElements = path.Split('.');
            var tempResult = target;
            foreach(var pathElement in pathElements)
            {
                PropertyInfo p = tempResult.GetType().GetProperty(pathElement);
                if (p == null)
                    throw new ArgumentException($"The property {pathElement} could not be found.");

                tempResult = p.GetValue(tempResult);
            }
            var result = tempResult;
            return result;
        }

        private object createPathElement(string pathElement)
        {
            //get the first applicable path element type
            var pathElementType = pathElementTypes.Where(t => isApplicable(t, pathElement)).FirstOrDefault();

            if (pathElementType == null)
                throw new InvalidOperationException($"There is no applicable path element type for {pathElement}");

            var result = Activator.CreateInstance(pathElementType, pathElement); //each path element type must have a constructor that takes a string parameter
            return result;
        }

        private bool isApplicable(Type t, string pathElement)
        {
            MethodInfo applicableMethod = t.GetMethod("IsApplicable", BindingFlags.Static | BindingFlags.Public);
            if (applicableMethod == null)
                throw new InvalidOperationException($"The type {t.Name} does not have a static method IsApplicable");

            bool? applicable = applicableMethod.Invoke(null, new[] { pathElement }) as bool?;
            if (applicable == null)
                throw new InvalidOperationException($"IsApplicable of type {t.Name} does not return bool");

            return applicable.Value;
        }
    }
}
