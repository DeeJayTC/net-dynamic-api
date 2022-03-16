# Generate CRUD API with ODATA enabled by just writing class files
First of all this is a really early Alpha, consider things with care. 

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
...et voila start your app and you're done. 
