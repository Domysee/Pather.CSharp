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
            foreach (DictionaryEntry de in dictionary)
            {
                if (de.Key.ToString() == key)
                    return de.Value;
            }

            //if no value is returned by now, it means that the index is too high
            throw new ArgumentException($"The key {key} does not exist.");
        }
    }
}
