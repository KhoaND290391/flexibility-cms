using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace FlexCMS.Contents.Dto
{
    [AutoMapTo(typeof(Content))]
    public class CreateContentDto
    {
        [Required]
        [StringLength(Content.MaxPageNameLength)]
        public string PageName { get; set; }

        [Required]
        public string PageContent { get; set; }
    }
}
