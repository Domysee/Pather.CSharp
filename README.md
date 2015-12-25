# Pather.CSharp
Pather.CSharp - A Path Resolution Library for C#

## Installation
Type in this command in *Package Manager Console*

>PM> Install-Package Pather.CSharp 

## Basic Usage
Create a new `Resolver` and pass the object and path to its `Resolve` method.

```C#
var resolver = new Resolver();
var o = new { Property1 = new { Property2 = "value" } };
var path = "Property1.Property2";

object result = r.Resolve(o, path); //the result is "value"
```

## Possible Paths

Property, array (per index) and dictionary (per key) resolution are supported out of the box.

#### Examples

> Property
> Property1.Property2
> ArrayProperty[5]
> DictionaryProperty[Key]
> [0]   //just an array index
> [Key] //just a dictionary index
> NestedArray[2][1]
> NestedDictionary[Key1][Key2]