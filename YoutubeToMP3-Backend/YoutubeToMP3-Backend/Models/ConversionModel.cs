using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeToMP3_Backend.Models
{
    public class ConversionModel
    {
        public int ConversionId { get; set; }
        public string ConversionName { get; set; }
        public string ConversionAuthor { get; set; }
        public DateTime ConversionLength { get; set; }
        public string ConversionType { get; set; }
        public int TimesConverted { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
