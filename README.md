# Turn your models into fully working APIs in minutes
<a href="https://tcdev.gitbook.io/"><img src="https://img.shields.io/badge/Docs-0.0.9-orange"></a>
<a href="https://twitter.com/intent/follow?screen_name=timcadenbach"><img src="https://img.shields.io/badge/Twitter-follow-blue"></a>
<img src="https://img.shields.io/github/workflow/status/DeeJayTC/net-dynamic-api/.NET/main?label=Main"> <img src="https://img.shields.io/github/workflow/status/DeeJayTC/net-dynamic-api/.NET/vnext?label=vnext"> <img src="https://img.shields.io/github/sponsors/deejaytc?label=Lovely%20Sponsors" />

Watch the video -> https://youtu.be/TI5CeNq3-o8

First of all this is a really early Alpha, consider things with care. 

The API Generator takes any class you like and generates a fully working CRUD API with Odata filter+select support, Database (SQL SQLLite or InMemory)
and also automatic migrations. 
In future the service will evolve into a full instant "Database to API" Microservice with no boilerplate code needed. 


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

# Getting Started & Docoumentation

[https://www.tcdev.de/tcdev-api-generator-getting-started](https://www.tcdev.de/tcdev-api-generator-getting-started)

[https://tcdev.gitbook.io/](https://tcdev.gitbook.io/)

# Samples
[https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample](https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample)


