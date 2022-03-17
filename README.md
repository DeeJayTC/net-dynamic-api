# Generate CRUD API with ODATA enabled by just writing class files

<a href="https://discord.gg/vBPpJkS"><img src="https://img.shields.io/badge/chat-discord-brightgreen.svg?logo=discord&style=flat"></a>
<a href="https://twitter.com/intent/follow?screen_name=timcadenbach"><img src="https://img.shields.io/badge/Twitter-follow-blue"></a>

First of all this is a really early Alpha, consider things with care. 
Currently it only supports SQL Server

By using the API Generator, this little code snippet is a fully working CRUD API

![image](https://user-images.githubusercontent.com/4077759/158908404-9298f82a-1cbe-4a5a-822a-536714123d75.png)



# How to use:
* Download sources and link to your project (Nuget soon!)
* Create a class as you wish
* Add the "GeneratedController" attribute and set the route name you'd love to use
* Add the "IObjectBase<T>" interface and implement it

* Your class will look similar to this:

```
   [GeneratedController("/people")]
   public class Person : Trackable, IObjectBase<Guid>
   {
      public string Name { get; set; }
      public DateTime Date { get; set; }
      public string Description { get; set; }
      public int Age { get; set; }

      public IEnumerable<PersonLink> Links { get; set; }
      public Guid Id { get; set; }
   }
```
  
* Add the initialization to your startup.cs or program.cs (when using the new .NET 6 approach)
```
  // Add the API Generator Services, point to the assembly where the classes are you want to use
  services.AddApiGeneratorServices(Configuration, Assembly.GetExecutingAssembly());
```

* Add a connection string in appsettings.json named 'ApiGeneratorDatabase'

```
  "ConnectionStrings": {
    "ApiGeneratorDatabase": "Server=localhost;database=maximago_dev_222222;user=sa;password=Password123;"
  },
```

   
...et voila start your app and you're done. 
