using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using TCDev.APIGenerator.Attributes;

namespace TCDev.APIGenerator.Model
{
    public class Auth0User
    {
        [JsonProperty("sub")]
        public string Sub { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public Uri Picture { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }
    }
    public interface IAppUser
    {
        Guid AppUserId { get; set; }
        DateTime Created { get; set; }
        DateTime? LastModified { get; set; }
        DateTime? Deleted { get; set; }
        string LastModifiedById { get; set; }
        string DeletedById { get; set; }
        public bool IsDeleted { get; set; }
        public Guid TenantId { get; set; }
        public string ObjectId { get; set; }
        public string PrimaryEmail { get; set; }
        public string SID { get; set; }
        public string LastIPAddress { get; set; }
        public bool IsNewUser { get; set; }
    }

    public class AppUser : IAppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AppUserId { get; set; } = new Guid();

        public string UserLookup { get; set; } = string.Empty;

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Deleted { get; set; }
        public string LastModifiedById { get; set; }
        public string DeletedById { get; set; }
        public bool IsDeleted { get; set; }
        public Guid TenantId { get; set; }
        public string ObjectId { get; set; }
        public string PrimaryEmail { get; set; }
        public string SID { get; set; }
        public string LastIPAddress { get; set; }
        public bool IsNewUser { get; set; }

    }
}
