using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destinos.Data.Models
{
    [Table("Place")]
    public class Place
    {
        public int Id { get; set; }
        [Required]
        public string NamePlace { get; set; }
        [Required]
        public string LocationPlace { get; set; }
        public int Count { get; set; }
    }
}
