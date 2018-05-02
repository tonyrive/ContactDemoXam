using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactDemoXam.Models;
using ContactDemoXam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactDemoXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {

        private ContactDetailsViewModel _vm;
        private ContactDetailsViewModel ViewModel => _vm ?? (_vm = BindingContext as ContactDetailsViewModel);

        public ContactDetailsPage() => InitializeComponent();

        public Contact ContactDetails
        {
            get => ViewModel.ContactDetails;
            set => BindingContext = new ContactDetailsViewModel(Navigation, value);
        }
    }
}