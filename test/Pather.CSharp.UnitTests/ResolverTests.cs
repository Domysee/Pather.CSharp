using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pather.CSharp.UnitTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ResolverTests
    {
        public ResolverTests()
        {
        }

        [Fact]
        public void SinglePropertyResolution()
        {
            var value = "1";
            var r = new Resolver();
            var o = new { Property = value };

            var result = r.Resolve(o, "Property");
            result.Should().Be(value);
        }

        [Fact]
        public void MultiplePropertyResolution()
        {
            var value = "1";
            var r = new Resolver();
            var o = new { Property1 = new { Property2 = value } };

            var result = r.Resolve(o, "Property1.Property2");
            result.Should().Be(value);
        }
    }
}
