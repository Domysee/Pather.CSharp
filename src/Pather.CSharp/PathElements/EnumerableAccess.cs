using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class EnumerableAccess : IPathElement
    {
        private string property;
        private int index;

        public EnumerableAccess(string property, int index)
        {
            this.property = property;
            this.index = index;
        }

        public object Apply(object target)
        {
            PropertyInfo p = target.GetType().GetProperty(property);
            if (p == null)
                throw new ArgumentException($"The property {property} could not be found.");

            var enumerable = p.GetValue(target) as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException($"The property {property} is not an IEnumerable.");

            var enumerator = enumerable.GetEnumerator();
            for (var i = 0; i <= index; i++) enumerator.MoveNext();

            var result = enumerator.Current;
            return result; 
        }
    }
}
