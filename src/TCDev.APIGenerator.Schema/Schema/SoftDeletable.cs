// TCDev.de 2022/04/07
// TCDev.APIGenerator.Schema.SoftDeletable.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using EntityFramework.Triggers;

namespace TCDev.ApiGenerator.Schemes.Interface
{
    public abstract class SoftDeletable : Trackable
    {
        public virtual DateTime? DeletedAt { get; private set; }

        public bool IsSoftDeleted => this.DeletedAt != null;

        public void SoftDelete()
        {
            this.DeletedAt = DateTime.UtcNow;
        }

        public void SoftRestore()
        {
            this.DeletedAt = null;
        }

        static SoftDeletable()
        {
            Triggers<SoftDeletable>.Deleting += entry =>
            {
                entry.Entity.SoftDelete();
                entry.Cancel = true; // Cancels the deletion, but will persist changes with the same effects as EntityState.Modified
            };
        }
    }
}
