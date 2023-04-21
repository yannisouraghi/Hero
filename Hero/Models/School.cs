namespace Hero.Models
{
    public class School
    {
        public int Id { get; set; }
        public string? SchoolName { get; set;}
        public int HeroId { get; set; }
        public virtual ICollection<Hero>? Heroes { get; set; }

        public School()
        {
            
        }
        public School(string name)
        {
            SchoolName = name;
        }
    }

}
