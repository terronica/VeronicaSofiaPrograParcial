using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeronicaSofiaPrograParcial.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Range(16, 50)]
        public int Age { get; set; }
        
        [Required]
        public string Position { get; set; }
        
        public string Nationality { get; set; } = "Peru";
        
        public ICollection<PlayerTeam> PlayerTeams { get; set; }
    }
}