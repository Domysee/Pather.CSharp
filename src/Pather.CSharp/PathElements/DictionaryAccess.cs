using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public class DictionaryAccess : PathElementBase
    {
        private string key;

        public DictionaryAccess(string key)
        {
            this.key = key;
        }

        public override object Apply(object target)
        {
            var dictionary = target as IDictionary;
            if (dictionary != null)
            {
                foreach (DictionaryEntry de in dictionary)
                {
                    if (de.Key.ToString() == key)
                        return de.Value;
                }
                //if no value is returned by now, it means that the index is too high
                throw new ArgumentException($"The key {key} does not exist.");
            }
            else
            {
                //if the object is no dictionary, it may have an indexer
                var indexProperties = target.GetType().GetRuntimeProperties().Where(p => p.GetIndexParameters().Length > 0);
                var appropriateIndexProperty = indexProperties.Where(p => p.GetIndexParameters().Length == 1 && p.GetIndexParameters()[0].ParameterType == typeof(string)).FirstOrDefault();
                if (appropriateIndexProperty == null) throw new ArgumentException("The target does not have an indexer that takes exactly 1 string parameter");
                return appropriateIndexProperty.GetValue(target, new object[] { key });
            }
        }
    }
}
