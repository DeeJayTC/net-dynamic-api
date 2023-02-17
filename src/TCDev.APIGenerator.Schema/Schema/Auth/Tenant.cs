using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCDev.APIGenerator.Model
{
    public class Tenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TenantId { get; set; } = new Guid();
        public string TenantName { get; set; } = string.Empty;
        public string TenantDomain { get; set; } = string.Empty;

        public Guid OwnerId { get; set; }

    }
}
