using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginNavigation
{
    public partial class ChildViewModel : ObservableObject
    {
        public string DisplayName { get; set; }

        public Type ViewModelType { get; set; }

        public object Instance { get; set; }
    }
}
