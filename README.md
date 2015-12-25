# Pather.CSharp
Pather.CSharp - A Path Resolution Library for C#

## Usage
Create a new `Resolver` and pass the object and path to its `Resolve` method.

```C#
var resolver = new Resolver();
var o = new { Property1 = new { Property2 = "value" } };
var path = "Property1.Property2";

object result = r.Resolve(o, path); //the result is "value"
```