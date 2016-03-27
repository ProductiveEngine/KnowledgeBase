using KnolwdgeBase.Infrastructure;

namespace KB.People.ViewModels
{
    public interface IPersonViewModel : IViewModel
    {
        void CreatePerson(string firstName, string lastName);
    }
}
