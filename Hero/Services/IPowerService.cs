using Hero.Models;

namespace Hero.Services
{
    public interface IPowerService
    {
        ICollection<Power> getAllPowers();
        Power getPowers(int id);
        void addPower(Power power);
        void updatePower(Power power);
        void deletePower(Power power);
    }
}
