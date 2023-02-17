// TCDev.de 2022/03/24
// ApiGeneratorSampleApI.MinimalSample.cs
// https://github.com/DeeJayTC/net-dynamic-api

using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Events;
using TCDev.APIGenerator.Interfaces;

namespace ApiGeneratorSampleApI.Model
{
    /// <summary>
    ///     This is the minimal sample, yes this is a working api ;)
    /// </summary>
    [Api("/minimal")]
    [Cachable("minimal_{0}",60)]
    public class MinimalSample : IObjectBase<int>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
