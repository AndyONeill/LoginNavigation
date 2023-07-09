using CommunityToolkit.Mvvm.Messaging;
using LoginNavigation.Messages;
using System;
using System.CodeDom;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LoginNavigation
{
    /// <summary>
    /// Interaction logic for LoginNavigationWindow.xaml
    /// </summary>
    public partial class LoginNavigationWindow : Window
    {
        public Type ParentViewModel
        {
            get { return (Type)GetValue(ParentViewModelProperty); }
            set { SetValue(ParentViewModelProperty, value); }
        }

        public static readonly DependencyProperty ParentViewModelProperty =
            DependencyProperty.Register(name: "ParentViewModel",
            propertyType: typeof(Type),
            ownerType: typeof(LoginNavigationWindow),
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: null,
            propertyChangedCallback: new PropertyChangedCallback(ParentViewModelChanged)
          ));
        private static void ParentViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            var vm = Activator.CreateInstance((Type)e.NewValue);
            ((Window)d).DataContext = vm;
            Task.Run(((IInitiatedViewModel)vm).Initiate);
        }

        public LoginNavigationWindow()
        {
            InitializeComponent();

            //Binding binding = new Binding
            //{
            //    Path = new PropertyPath("NewParentViewModelType"),
            //};
            //BindingOperations.SetBinding(this, LoginNavigationWindow.ParentViewModelProperty, binding);

            WeakReferenceMessenger.Default.Register<ParentNavigate>(this, (r, pn) =>
            {
                this.SetValue(LoginNavigationWindow.ParentViewModelProperty, pn.ParentViewModelType);
            });
        }
    }
}
