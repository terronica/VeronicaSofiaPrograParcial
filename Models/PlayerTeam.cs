namespace VeronicaSofiaPrograParcial.Models
{
    public class PlayerTeam
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        
        public int TeamId { get; set; }
        public Team Team { get; set; }
        
        public bool IsCurrent { get; set; } = true;
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}