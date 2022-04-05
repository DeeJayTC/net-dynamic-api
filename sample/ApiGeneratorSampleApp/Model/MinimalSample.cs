// TCDev.de 2022/03/24
// ApiGeneratorSampleApI.MinimalSample.cs
// https://www.github.com/deejaytc/dotnet-utils

using System.Text.Json.Serialization;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;

namespace ApiGeneratorSampleApI.Model;

/// <summary>
///    This is the minimal sample, yes this is a working api ;)
/// </summary>
[Api("/minimal")]
public class MinimalSample : IObjectBase<int>
{
   public string Name { get; set; }
   public int Value { get; set; }
   public int Id { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OperationEnum
{
   Insert,
   Update,
   Delete
}
