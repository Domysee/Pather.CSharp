using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class SelectionAccess : IPathElement
    {
        public SelectionAccess()
        {
        }

        public object Apply(object target)
        {
            var enumerable = target as IEnumerable;
            var result = new Selection(enumerable);
            return result;
        }

        public IEnumerable Apply(Selection target)
        {
            var results = new List<object>();
            foreach(var entry in target.Entries)
            {
                var enumerable = entry as IEnumerable;
                if (enumerable == null)
                    results.Add(entry);
                else
                {
                    foreach (var element in enumerable)
                        results.Add(element);
                }
            }
            var result = new Selection(results);
            return result;
        }
    }
}
