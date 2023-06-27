namespace Klooz3.Models
{
    public class TeamRegie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Emailadress { get; set; }

        public TeamRegie() { }
        public TeamRegie(string? name, string? emailadress)
        {
            Name = name;
            Emailadress = emailadress;
        }
    }
}
