using _0_Framework.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Personality
{
    public class CreatePersonality
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Title { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long PersonalityTypeId { get; set; }
    }
}
