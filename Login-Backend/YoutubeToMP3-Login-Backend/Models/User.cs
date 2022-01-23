using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeToMP3_Login_Backend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public int ConvertedVideoAmmount { get; set; }
    }
}
