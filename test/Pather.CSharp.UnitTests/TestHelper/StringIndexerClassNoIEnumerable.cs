using System;
using System.Collections.Generic;
using System.Text;

namespace Pather.CSharp.UnitTests.TestHelper
{
    class StringIndexerClassNoIEnumerable
    {
        private readonly string value;

        public StringIndexerClassNoIEnumerable(string value)
        {
            this.value = value;
        }

        public string this[string index] => value + index;
    }
}
