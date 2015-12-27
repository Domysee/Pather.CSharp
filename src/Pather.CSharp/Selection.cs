using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp
{
    public class Selection
    {
        public IReadOnlyCollection<object> Entries { get; }

        public Selection(IEnumerable entries)
        {
            var list = new List<object>();
            foreach (var entry in entries)
                list.Add(entry);
            Entries = list;
        }
    }
}
