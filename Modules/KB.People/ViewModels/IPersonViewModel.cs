﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnolwdgeBase.Infrastructure;

namespace KB.People.ViewModels
{
    public interface IPersonViewModel : IViewModel
    {
        void CreatePerson(string firstName, string lastName);
    }
}