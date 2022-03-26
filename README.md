# Turn your models into fully working APIs in minutes

<a href="https://tcdev.gitbook.io/"><img src="https://img.shields.io/badge/Docs-0.0.4-orange"></a>
<a href="https://discord.gg/vBPpJkS"><img src="https://img.shields.io/badge/chat-discord-brightgreen.svg?logo=discord&style=flat"></a>
<a href="https://twitter.com/intent/follow?screen_name=timcadenbach"><img src="https://img.shields.io/badge/Twitter-follow-blue"></a>


First of all this is a really early Alpha, consider things with care. 

By using the API Generator, this little code snippet is a fully working CRUD API

```
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
The API Generator takes any class you like and generates a fully working CRUD API with Odata filter+select enabled. 
In future the service will evolve into a full instant "Database to API" Microservice with no boilerplate code needed. 

Heres another sample:

```
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


# How to use:
```
dotnet add package TCDev.ApiGenerator --version 0.0.4-alpha
```

# Getting Started & Docoumentation

[https://tcdev.gitbook.io/](https://tcdev.gitbook.io/)

# Samples
[https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample](https://github.com/DeeJayTC/net-dynamic-api/tree/main/sample)


