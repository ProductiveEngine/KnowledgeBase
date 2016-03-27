using KB.Business;
using KnolwdgeBase.Infrastructure;

namespace KB.People.ViewModels
{
    public interface IPersonDetailsViewModel : IViewModel
    {
        Person SelectedPerson { get; set; }
    }
}
