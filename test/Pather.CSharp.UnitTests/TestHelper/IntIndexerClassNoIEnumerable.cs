using System;
using System.Collections.Generic;
using System.Text;

namespace Pather.CSharp.UnitTests.TestHelper
{
    class IntIndexerClassNoIEnumerable
    {
        private readonly string value;

        public IntIndexerClassNoIEnumerable(string value)
        {
            this.value = value;
        }

        public string this[int index] => value + index;
    }
}
