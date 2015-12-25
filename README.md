# Pather.CSharp
Pather.CSharp - A Path Resolution Library for C#

## Installation
Type in this command in *Package Manager Console*

>PM> Install-Package Pather.CSharp 

## Usage
Create a new `Resolver` and pass the object and path to its `Resolve` method.

```C#
var resolver = new Resolver();
var o = new { Property1 = new { Property2 = "value" } };
var path = "Property1.Property2";

object result = r.Resolve(o, path); //the result is "value"
```