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
            //index lower than 0 doesn't have to be checked, because the IsApplicable check doesn't apply to negative values

            var enumerable = target as IEnumerable;

            var i = 0;
            foreach (var value in enumerable)
            {
                if (i == index)
                    return value;
                i++;
            }

            //if no value is returned by now, it means that the index is too high
            throw new IndexOutOfRangeException($"The index {index} is too high. Maximum index is {i - 1}.");
        }
    }
}
