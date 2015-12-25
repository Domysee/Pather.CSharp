using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pather.CSharp.UnitTests
{
    public class ResolverTests
    {
        public ResolverTests()
        {
        }

        [Fact]
        public void SinglePropertyResolution_CorrectSetup_Success()
        {
            var value = "1";
            var r = new Resolver();
            var o = new { Property = value };
            var path = "Property";

            var result = r.Resolve(o, path);
            result.Should().Be(value);
        }

        [Fact]
        public void MultiplePropertyResolution_CorrectSetup_Success()
        {
            var value = "1";
            var r = new Resolver();
            var o = new { Property1 = new { Property2 = value } };
            var path = "Property1.Property2";

            var result = r.Resolve(o, path);
            result.Should().Be(value);
        }

        [Fact]
        public void ArrayIndexResolution_CorrectSetup_Success()
        {
            var r = new Resolver();
            var array = new[] { "1", "2" };
            var o = new { Array = array };
            var path = "Array[0]";

            var result = r.Resolve(o, path);
            result.Should().Be("1");
        }

        [Fact]
        public void SinglePropertyResolution_NoPathElementTypeForPath_FailWithNoApplicablePathElementType()
        {
            var value = "1";
            var r = new Resolver();
            var o = new { Property = value };
            var path = "Property^%#";

            r.Invoking(re => re.Resolve(o, path)).ShouldThrow<InvalidOperationException>();
        }
    }
}
