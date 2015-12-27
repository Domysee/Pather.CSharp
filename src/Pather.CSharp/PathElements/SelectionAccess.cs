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
    }
}
