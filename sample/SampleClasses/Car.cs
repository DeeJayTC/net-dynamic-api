using EntityFramework.Triggers;
using Maximago.ApiGenerator.Attributes;
using Maximago.ApiGenerator.Interfaces;
using Maximago.ApiGenerator.Schemes;
using Maximago.ApiGenerator.Schemes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGeneratorSampleApp
{

	[GeneratedController(
		route: "/cars/",
		requiredReadClaims: new string[] { "car.read" },
		requiredWriteClaims: new string[] { "car.write" },
		fireEvents: true,
		cacheDuration: 10000,
		cache: true
	)]
	public class Car :
		Trackable,
		IObjectBase<int>,
		IEntityTypeConfiguration<Car>,
		IHasQueryFields
	{

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; } 

		[Required]
		public string Name { get; set; }

		[Required]
		public string Brand { get; set; }

		[Required]
		public string Make { get; set; }

		public CarDealer? Dealer { get; set; }
		
		/// <summary>
		/// All Fields of the class that are querried by q param on controller
		/// </summary>
		public string[] QueryFields { get { return new string[] { "Name", "Brand", "Make" }; } }

		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasKey("Id");
			builder.ToTable("car");
			builder.HasOne("Dealer").WithMany("Cars");

		}
	}
}
