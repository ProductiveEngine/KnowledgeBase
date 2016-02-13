using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KnolwdgeBase.Infrastructure;

namespace KB.People.Views
{
    /// <summary>
    /// Interaction logic for PersonMasterView.xaml
    /// </summary>
    public partial class PersonMasterView : UserControl, IPersonMasterView
    {
        public PersonMasterView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
