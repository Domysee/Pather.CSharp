# Pather.CSharp
Pather.CSharp - A Path Resolution Library for C#

## Installation
Type in this command in *Package Manager Console*

>PM> Install-Package Pather.CSharp

## Basic Usage
Create a new `Resolver` and pass the object and path to its `Resolve` method.

```C#
IResolver resolver = new Resolver();
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

## Selections

Pather.CSharp can also operate on collections of objects. If you have an array of objects, 
and each has a property called `P`, you can access it and get the values of `P` for all objects
in the array.  
This behavior can be triggered using `[]` in the path on a `IEnumerable`.

For **example**:  
```C#
var r = new Resolver();
var array = new[]
{
    new { P1 = "1" },
    new { P1 = "2" }
};
var path = "[].P1";

var result = r.Resolve(array, path);    
//result is a collection that contains the values "1" and "2"
```

## Teaching Pather.CSharp new Tricks

#### Preamble

There are 2 interfaces you have to know about if you want to extend Pather.CSharp:

1. `IPathElementFactory`
2. `IPathElement`

**IPathElementFactory** has an `IsApplicable` method, which determines if it can create an `IPathElement`
for the given path.  
Its `Create` method creates an `IPathElement` object for the given path and 
outputs a new path, which is the old path stripped by the parts `Create` used to create the PathElement.  

An **example**:  
>Input path &nbsp;&nbsp;&nbsp;`Property1.Property2`  
>Output path `.Property2`

**IPathElement** only has an `Apply` method, which extracts an object from the given target.

The main class, **Resolver**, has a List of `IPathElementFactory` objects. It uses the first one that
is applicable to create an `IPathElement`. These `IPathElement`s are then applied in order on the 
target.

#### Extending Pather.CSharp

To extend it 3 steps are needed:

1. Create a class that implements `IPathElement`
2. Create a class that implements `IPathElementFactory`
3. Add an instance of your `IPathElementFactory` to the instance of `Resolver`

The *naming convention* is to name classes that implement IPathElement after what they do, 
and their factories with the suffix *Factory*.  

For example: `Property` resolves property accessing, and `PropertyFactory` is its factory.

It is probably easiest to look at the [existing implementations][1], to get some ideas how to implement it. They are very straightforward, `DictionaryAccessFactory` for example has only 7 (interesting) lines of code, the rest of the 27 LOC are boilerplate.

[1]: https://github.com/Domysee/Pather.CSharp/tree/master/src/Pather.CSharp/PathElements