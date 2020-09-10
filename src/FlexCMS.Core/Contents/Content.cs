using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexCMS.Contents
{
    [Table("Content")]
    public class Content : FullAuditedEntity<int>, IMustHaveTenant
    {
        public const int MaxPageNameLength = 1024;
        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxPageNameLength)]
        public virtual string PageName { get; protected set; }

        [Required]
        public virtual string PageContent { get; protected set; }

        public static Content CreateContent(string pageName, string pageContent, int tenantId)
        {
            return new Content
            {
                PageName = pageName,
                PageContent = pageContent,
                TenantId = tenantId
            };
        }
    }
}
