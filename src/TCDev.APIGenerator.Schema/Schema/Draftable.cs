// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using EntityFramework.Triggers;

namespace TCDev.ApiGenerator.Schemes.Interfaces
{
   public abstract class Trackable
   {
      static Trackable()
      {
         Triggers<Trackable>.Inserting += entry => entry.Entity.Inserted = DateTime.UtcNow;
         Triggers<Trackable>.Updating += entry => entry.Entity.Updated = DateTime.UtcNow;
      }

      public virtual DateTime Inserted { get; private set; } = DateTime.UtcNow;
      public virtual DateTime? Updated { get; private set; }
   }

   public abstract class SoftDeletable : Trackable
   {
      static SoftDeletable()
      {
         Triggers<SoftDeletable>.Deleting += entry =>
         {
            entry.Entity.SoftDelete();
            entry.Cancel = true; // Cancels the deletion, but will persist changes with the same effects as EntityState.Modified
         };
      }

      public virtual DateTime? DeletedAt { get; private set; }

      public bool IsSoftDeleted => DeletedAt != null;

      public void SoftDelete()
      {
         DeletedAt = DateTime.UtcNow;
      }

      public void SoftRestore()
      {
         DeletedAt = null;
      }
   }
}