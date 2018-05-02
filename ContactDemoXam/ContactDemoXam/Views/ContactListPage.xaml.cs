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
    public partial class ContactListPage : ContentPage
    {
        private ContactsViewModel _vm;
        private ContactsViewModel ViewModel => _vm ?? (_vm = BindingContext as ContactsViewModel);

        public ContactListPage()
        {
            InitializeComponent();

            BindingContext = new ContactsViewModel(Navigation);

            ContactsListView.ItemTapped += (sender, args) => ContactsListView.SelectedItem = null;
            ContactsListView.ItemSelected += ContactsListView_ItemSelected;
        }

        private async void ContactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(ContactsListView.SelectedItem is Contact contact))
            {
                return;
            }

            await Navigation.PushAsync(new ContactDetailsPage { ContactDetails = contact }, true);

            ContactsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadData();
            ContactsListView.ItemsSource = ViewModel.ContactList;
        }
    }
}