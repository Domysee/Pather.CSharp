using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class Property : PathElementBase
    {
        private string property;

        public Property(string property)
        {
            this.property = property;
        }

        public override object Apply(object target)
        {
            PropertyInfo p = target.GetType().GetTypeInfo().GetDeclaredProperty(property);
            if (p == null)
                throw new ArgumentException($"The property {property} could not be found.");

            var result = p.GetValue(target);
            return result;
        }
    }
}
