![image](https://user-images.githubusercontent.com/4077759/162592498-d420906e-5eee-4d95-b0b2-c5c3c2b0c8d1.png)
[Getting Started](https://www.tcdev.de/tcdev-api-generator-getting-started) | [Samples](https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample) | [Walkthrough Video](https://youtu.be/TI5CeNq3-o8)

# Get fully working CRUD API's in an instant!
<a href="https://tcdev.gitbook.io/"><img src="https://img.shields.io/badge/Docs-0.0.9-orange"></a>
<a href="https://twitter.com/intent/follow?screen_name=timcadenbach"><img src="https://img.shields.io/badge/Twitter-follow-blue"></a>
<a href="https://www.github.com/sponsors/deejaytc"><img src="https://img.shields.io/github/sponsors/deejaytc?label=Lovely%20Sponsors" /> </a>


## Build  & Nuget Status

| Version | Build | Nuget 
|--------------|-----------------|-------------------|
| Main | <img src="https://img.shields.io/github/workflow/status/DeeJayTC/net-dynamic-api/.NET/main?label=Main"> | [0.6.0](https://www.nuget.org/packages/TCDev.ApiGenerator/0.6.0) | [![Build Status Installer pipeline](https://dev.azure.com/microsoft/Dart/_apis/build/status/microsoft.PowerToys?branchName=main)](https://dev.azure.com/microsoft/Dart/_build/latest?definitionId=76541&branchName=main) |
| VNext |  <img src="https://img.shields.io/github/workflow/status/DeeJayTC/net-dynamic-api/.NET/vnext?label=vnext"> | [0.6.1-RC1](https://www.nuget.org/packages/TCDev.ApiGenerator/0.6.1-RC1)

## About
The API Generator automatically generates a fully working CRUD Microservice from just your Model (C# Classes) or a JSON Definition. Everything from routes, database handling, migrations, openapi spec, OData etc is working magically out of the box! You just write your model and get a fully working CRUD api with filtering, sorting, selectable fields and everything else OData and classic REST offers.


By using the API Generator, this little code snippet is already a working CRUD API
```csharp
/// <summary>
/// This is the minimal sample, yes this is a working api ;)
/// </summary>
[Api("/minimal")]
public class MinimalSample : IObjectBase<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Value { get; set; }
}
```

Heres another sample:

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

# Getting Started & Docoumentation
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

### Documentation -> [https://tcdev.gitbook.io/](https://tcdev.gitbook.io/)

# Samples
[https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample](https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample)


