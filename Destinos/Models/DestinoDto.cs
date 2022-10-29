using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Destinos.Models
{
    [Table("Place")]
    public class DestinoDto
    {
        
        public int Id { get; set; }
        [Required]
        public string NamePlace { get; set; }
        [Required]
        public string LocationPlace { get; set; }
        public int Count { get; set; }
    }
}