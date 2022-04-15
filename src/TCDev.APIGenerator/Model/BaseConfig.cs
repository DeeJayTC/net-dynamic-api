// TCDev.de 2022/03/16
// TCDev.APIGenerator.BaseConfig.cs
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.EntityFrameworkCore;

namespace TCDev.ApiGenerator.Model;

public enum DbTypes
{
   Sql = 0, Postgres = 1, MySql = 2
}

[Keyless]
public class BaseConfig
{
   public string DbConnection { get; set; }
   public DbTypes DbType { get; set; } = DbTypes.Sql;
}
