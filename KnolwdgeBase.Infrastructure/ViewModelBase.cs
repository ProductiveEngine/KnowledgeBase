using System.ComponentModel;
using System.Diagnostics;

namespace KnolwdgeBase.Infrastructure
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IView View { get; set; }

        public ViewModelBase() { }

        public ViewModelBase(IView view)
        {
            View = view;
            View.ViewModel = this;            
        }        

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}