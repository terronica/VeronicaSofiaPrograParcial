namespace VeronicaSofiaPrograParcial.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int FoundedYear { get; set; }
        
        public ICollection<PlayerTeam> PlayerTeams { get; set; }
    }
}