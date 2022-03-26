using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;

namespace ApiGeneratorSampleApI.Model
{

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
}
