using Klooz3.Data;

namespace Klooz3.Models
{
    public class User
    {
        public int? userId {  get; set; }
        public string? userEmail { get; set; }
        public string? userVoornaam { get; set; }
        public string? userAchternaam { get; set; }
        public string? userAdressLine1 { get; set; }
        public string? userPostcode { get; set; }
        public string? userGemeente { get; set; }
        public string? userPhoneNumber { get; set; }
        public Roles? userrole { get; set; }
        public DateTime? userJoined { get; set; }
        public bool? userIsAccountActive { get; set; }

        public User(int? userId, string? userEmail, string? userVoornaam, string? userAchternaam, string? userAdressLine1, string? userPostcode, string? userGemeente, string? userPhoneNumber, Roles? userrole, DateTime? userJoined, bool? userIsAccountActive)
        {
            this.userId = userId;
            this.userEmail = userEmail;
            this.userVoornaam = userVoornaam;
            this.userAchternaam = userAchternaam;
            this.userAdressLine1 = userAdressLine1;
            this.userPostcode = userPostcode;
            this.userGemeente = userGemeente;
            this.userPhoneNumber = userPhoneNumber;
            this.userrole = userrole;
            this.userJoined = userJoined;
            this.userIsAccountActive = userIsAccountActive;
        }

        public User() { }
    }
}
