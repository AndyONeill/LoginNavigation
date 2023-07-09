using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation
{
    public partial class BaseParentViewModel : ObservableObject, IInitiatedViewModel
    {
        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        private Type? newParentViewModelType = null;

        virtual public async Task Initiate() { }
    }
}
