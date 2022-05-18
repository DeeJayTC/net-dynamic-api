// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.APIGenerator.Interfaces
{
    public interface IHasTenantId
    {
        public Guid TenantId { get; set; }
    }
}