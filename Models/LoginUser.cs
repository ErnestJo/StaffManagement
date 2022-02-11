using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MystaffTool.Models
{
    public class Loginuser
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
