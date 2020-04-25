using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBMVC.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        [DisplayName("GenderName")]
        [Required(ErrorMessage = "Gender Name is Required.")]
        public string GenderName { get; set; }

    }
}