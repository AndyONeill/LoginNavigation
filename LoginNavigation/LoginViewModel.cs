using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LoginNavigation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation
{
    public partial class LoginViewModel : BaseParentViewModel
    {
        [RelayCommand]
        private async Task LoadMain()
        {
            //NewParentViewModelType = typeof(MainViewModel);
            var pn = new ParentNavigate { ParentViewModelType = typeof(MainViewModel) };
            WeakReferenceMessenger.Default.Send(pn);
        }
        public LoginViewModel()
        {
            Title = "Please Log In first";
        }

        public override async Task Initiate()
        {
            // Get any data for login here
        }
    }
}
