using KB.Business;

namespace KnolwdgeBase.Infrastructure
{
    public interface IPersonRepository
    {
        int SavePerson(Person person);
    }
}
