// TCDev.de 2022/03/16
// TCDev.APIGenerator.GenericDbContext.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TCDev.APIGenerator.Services;

namespace TCDev.APIGenerator.Data
{
    public class AuthDbContext : DbContext
    {
    }
}