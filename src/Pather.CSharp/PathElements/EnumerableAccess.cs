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
        private int index;

        public EnumerableAccess(int index)
        {
            this.index = index;
        }

        public object Apply(object target)
        {
            var enumerable = target as IEnumerable;

            var enumerator = enumerable.GetEnumerator();
            for (var i = 0; i <= index; i++) enumerator.MoveNext();

            var result = enumerator.Current;
            return result; 
        }
    }
}
