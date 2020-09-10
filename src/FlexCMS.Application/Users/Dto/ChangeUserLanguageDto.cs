using System.ComponentModel.DataAnnotations;

namespace FlexCMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}