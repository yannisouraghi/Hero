using Hero.Models;

namespace Hero.Services
{
    public interface ISchoolService
    {
        ICollection<School> getAllSchool();
        School getSchool(int id);
        void addSchool(School school);
        void updateSchool(School school);
        void deleteSchool(int id);
    }
}
