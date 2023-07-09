using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation
{
    public partial class MainViewModel : BaseParentViewModel
    {

        [ObservableProperty]
        private object currentChildViewModel;

        [ObservableProperty]
        private List<ChildViewModel> childViewModelList;

        [RelayCommand]
        private async Task ChildNavigation(ChildViewModel cvm)
        {
            if (cvm.Instance == null)
            {
                cvm.Instance = Activator.CreateInstance(cvm.ViewModelType);
                if (cvm.Instance is IInitiatedViewModel)
                {
                    Task.Run(((IInitiatedViewModel)cvm.Instance).Initiate);
                }
            }
            CurrentChildViewModel = cvm.Instance;
        }

        public override async Task Initiate()
        {
            ChildViewModelList = new List<ChildViewModel>()
            {
                new ChildViewModel{ DisplayName="Subjects", ViewModelType= typeof(SubjectsViewModel) },
                new ChildViewModel{ DisplayName="Results", ViewModelType= typeof(ResultViewModel) }
            };
        }
        public MainViewModel()
        {
            Title = "Quiz";
        }
    }
}
