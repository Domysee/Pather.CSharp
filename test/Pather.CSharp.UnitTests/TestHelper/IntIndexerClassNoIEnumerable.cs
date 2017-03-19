using System;
using System.Collections.Generic;
using System.Text;

namespace Pather.CSharp.UnitTests.TestHelper
{
    class IndexerClassNoIEnumerable
    {
        private readonly string value;

        public IndexerClassNoIEnumerable(string value)
        {
            this.value = value;
        }

        public string this[int index] => value + index;
    }
}
