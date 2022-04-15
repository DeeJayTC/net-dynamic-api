// TCDev.de 2022/03/16
// TCDev.APIGenerator.Schema.Trackable123.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using EntityFramework.Triggers;

namespace TCDev.ApiGenerator.Schemes
{
    public abstract class Trackable
    {
        public virtual DateTime Inserted { get; private set; } = DateTime.UtcNow;
        public virtual DateTime? Updated { get; private set; }

        static Trackable()
        {
            Triggers<Trackable>.Inserting += entry => entry.Entity.Inserted = DateTime.UtcNow;
            Triggers<Trackable>.Updating += entry => entry.Entity.Updated = DateTime.UtcNow;
        }
    }
}
