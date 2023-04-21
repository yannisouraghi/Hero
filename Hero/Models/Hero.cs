namespace Hero.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual School? School { get; set; }
        public virtual ICollection<Power>? ListPowers { get; set; }

        public Hero()
        {
            
        }
        public Hero( string nom)
        {
            Nom = nom;
        }
    }
}
