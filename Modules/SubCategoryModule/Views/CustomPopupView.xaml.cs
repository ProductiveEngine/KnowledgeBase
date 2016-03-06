using System;
using System.Windows.Controls;
using Prism.Interactivity.InteractionRequest;

namespace SubCategoryModule.Views
{
    /// <summary>
    /// Interaction logic for CustomPopupView.xaml
    /// </summary>
    public partial class CustomPopupView : UserControl, IInteractionRequestAware
    {
        public CustomPopupView()
        {
            InitializeComponent();
        }

        public INotification Notification { get; set; }
        public Action FinishInteraction { get; set; }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FinishInteraction != null)
            {
                FinishInteraction();
            }
        }
    }
}
