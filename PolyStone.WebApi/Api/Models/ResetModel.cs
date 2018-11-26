using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyStone.Api.Models
{
    class ResetModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
