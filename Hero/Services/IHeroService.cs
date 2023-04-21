using Hero.Models;

namespace Hero.Services
{
    public interface IHeroService
    {
        ICollection<Hero> getAllPowers();
        Hero getHero(int id);
        void addHero(Hero hero);
        void updateHero(Hero hero);
        void deleteHero(int id);
    }
}
