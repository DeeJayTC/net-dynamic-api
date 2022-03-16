using Maximago.ApiGenerator.Attributes;
using Maximago.ApiGenerator.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGeneratorSampleApI.Model
{

	[GeneratedController(
		route: "/test/",
		requiredReadClaims: new string[] { "test.read" },
		requiredWriteClaims: new string[] { "test.write" },
		fireEvents: true,
		cacheDuration: 10000,
		cache: true
	)]
	public class Test :
		IObjectBase<string>,
		IEntityTypeConfiguration<Test>,
		IHasQueryFields
	{
		public string Id { get; set; }

		public string[] QueryFields => throw new System.NotImplementedException();

		public void Configure(EntityTypeBuilder<Test> builder)
		{
			builder.HasKey("Id");
		}
	}
}
