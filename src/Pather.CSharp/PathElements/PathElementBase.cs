using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public abstract class PathElementBase : IPathElement
    {
        public IEnumerable Apply(Selection target)
        {
            var results = new List<object>();
            foreach (var entriy in target.Entries)
            {
                results.Add(Apply(entriy));
            }
            var result = new Selection(results);
            return result;
        }

        public abstract object Apply(object target);
    }
}
