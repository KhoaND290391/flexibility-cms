using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace FlexCMS.Contents.Dto
{
    [AutoMapTo(typeof(Content))]
    public class CreateOrUpdateContentDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(Content.MaxPageNameLength)]
        public string PageName { get; set; }

        [Required]
        public string PageContent { get; set; }
    }
}
