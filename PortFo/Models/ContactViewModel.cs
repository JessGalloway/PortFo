using System.ComponentModel.DataAnnotations;

namespace PortFo.Models
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = "* Name Required")]
        public string Name { get; set; }


        [Required(ErrorMessage ="* Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage ="* Please Provide A Subject Entry")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "*Message is required")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }


    }
}
