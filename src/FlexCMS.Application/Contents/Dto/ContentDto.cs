using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace FlexCMS.Contents.Dto
{
    [AutoMapFrom(typeof(Content))] 
    public class ContentDto : EntityDto<int>
    {
        [Required]
        [StringLength(Content.MaxPageNameLength)]
        public string PageName { get; set; }

        [Required]
        public string PageContent { get; set; }
    }
}
