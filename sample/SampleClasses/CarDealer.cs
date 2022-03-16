using Maximago.ApiGenerator.Attributes;
using Maximago.ApiGenerator.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiGeneratorSampleApp
{
	[GeneratedController(
		route: "/cardealer",
		authorize: false
	)]
	public class CarDealer : IObjectBase<string>, IEntityTypeConfiguration<CarDealer>
	{
		[Key]
		public string Id { get; set; } = System.Guid.NewGuid().ToString();

		public virtual List<Car>? Cars { get; set; } = new List<Car>();


		public void Configure(EntityTypeBuilder<CarDealer> builder)
		{
			builder.HasKey(p => p.Id);

			builder.HasMany(p => p.Cars).WithOne(p => p.Dealer);
		}

	}


}
