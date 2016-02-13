using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB.Business;
using KnolwdgeBase.Infrastructure;

namespace KB.People.ViewModels
{
    public interface IPersonDetailsViewModel : IViewModel
    {
        Person SelectedPerson { get; set; }
    }
}
