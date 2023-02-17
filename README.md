![image](https://user-images.githubusercontent.com/4077759/162592498-d420906e-5eee-4d95-b0b2-c5c3c2b0c8d1.png)
[Getting Started](https://www.tcdev.de/tcdev-api-generator-getting-started) | [Samples](https://github.com/DeeJayTC/api-generator-samples) | [Walkthrough Video](https://youtu.be/TI5CeNq3-o8)

# Get fully working CRUD API's in an instant!
<a href="https://docs.rasepi.com"><img src="https://img.shields.io/badge/Docs-0.7.0-orange"></a>
<a href="https://twitter.com/intent/follow?screen_name=timcadenbach"><img src="https://img.shields.io/badge/Twitter-follow-blue"></a>
<a href="https://www.github.com/sponsors/deejaytc"><img src="https://img.shields.io/github/sponsors/deejaytc?label=Lovely%20Sponsors" /> </a>


## Build  & Nuget Status

| Version | Build | Nuget 
|--------------|-----------------|-------------------|
| Main | <img src="https://github.com/DeeJayTC/net-dynamic-api/actions/workflows/dotnet.yml/badge.svg"> | [0.7.0](https://www.nuget.org/packages/TCDev.ApiGenerator/0.7.0) | [![Build Status Installer pipeline](https://github.com/DeeJayTC/net-dynamic-api/actions/workflows/dotnet.yml/badge.svg)](https://dev.azure.com/microsoft/Dart/_build/latest?definitionId=76541&branchName=main) |
| VNext |  <img src="https://github.com/DeeJayTC/net-dynamic-api/actions/workflows/dotnet.yml/badge.svg"> | [0.8.0](https://www.nuget.org/packages/TCDev.ApiGenerator/0.8.0)

## About
The API Generator is a tool that helps you create fully functioning CRUD microservices with ease. Whether you use C# classes or a JSON definition, the API Generator takes care of all the necessary components, such as routes, database handling, migrations, openapi spec, and OData. All you have to do is write your model, and you'll have a CRUD API complete with filtering, sorting, selectable fields, and all the other features offered by both OData and classic REST.


Creating a CRUD API has never been easier. With just a few lines of code, you can have a working API in no time. Here's a simple example:
```csharp
/// <summary>
/// This is as simple as it gets, yes this is a working api ;)
/// </summary>
[Api("/simple")]
public class SimpleSample : IObjectBase<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Value { get; set; }
}
```

Or, if you prefer using JSON:

```csharp
 [Api("/people", ApiMethodsToGenerate.All )]
 public class Person : Trackable, 
    IObjectBase<Guid>,
    IBeforeUpdate<Person>, // Before Update Hook
    IBeforeDelete<Person>, // BeforeDelete Hook
 {
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
    public Guid Id { get; set; }
 }
```

And this is also the FULL code for a working API using the JSON mode:

```json
[
    {
      "name": "Car",
      "route": "/cars",
      "caching": true,
      "cacheLiveTime": 1000,
      "events": "POST,PUT,DELETE",
      "idType":  "int", 
      "Fields": [
        {
          "name": "Name",
          "type": "String",
          "maxLength": "200",
          "nullable": false
        }
      ]
    }
  ]
 ```

# Getting Started & Documentation
Read this for a more detailed guide -> [https://www.tcdev.de/tcdev-api-generator-getting-started](https://www.tcdev.de/tcdev-api-generator-getting-started)
Or just follow these steps:

* Install the package
```csharp
dotnet add package TCDev.ApiGenerator --prerelease
```
after the package is installed add this to your program.cs (or startup.cs)

```csharp
// Add API Generator and load data
builder.Services.AddApiGeneratorServices()
                //From Assembly with OData .AddAssemblyWithOData(Assembly.GetExecutingAssembly())
                //or as JSON from Uri .AddAssemblyWithODataFromUri("https://raw.githubusercontent.com/DeeJayTC/net-dynamic-api/main/sample/SampleAppJson/ApiDefinition.json","")
                //Or without OData .AddAssembly(Assembly.GetExecutingAssembly())
                .AddDataContextSQL() // or Postgres or SQLite
                .AddOData()
                .AddSwagger(true);
```

### Documentation 
[https://docs.rasepi.com/](https://docs.rasepi.com/)

# Samples
You can find samples for using the library in the samples repository, constantly updated to match latest version and features:

[https://github.com/DeeJayTC/api-generator-samples](https://github.com/DeeJayTC/api-generator-samples)


