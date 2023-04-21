using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Hero.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string PowerName { get; set; }

        public virtual ICollection<Hero>? ListHero { get; set; }
        public Power()
        {
            
        }
        public Power(string name)
        {
            PowerName = name;
        }
    }
}
