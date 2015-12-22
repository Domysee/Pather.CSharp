using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Pather.CSharp
{
    public class Resolver
    {
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
    }
}
