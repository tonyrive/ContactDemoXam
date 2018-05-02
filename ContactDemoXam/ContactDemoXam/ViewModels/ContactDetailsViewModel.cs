using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactDemoXam.Annotations;
using ContactDemoXam.Models;
using ContactDemoXam.Services;
using Xamarin.Forms;

namespace ContactDemoXam.ViewModels
{
    class ContactDetailsViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;

        public ContactDetailsViewModel(INavigation navigation, Contact contact)
        {
            _navigation = navigation;
            ContactDetails = contact;
        }

        public Contact ContactDetails { get; set; }

        public bool CanDial => !string.IsNullOrEmpty(ContactDetails.Phone?.Trim());

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand _callPhoneCommand;

        public ICommand CallPhoneCommand =>
            _callPhoneCommand ?? (_callPhoneCommand = new Command(
                async () => await CallNumber()));

        private async Task CallNumber()
        {
            var dialer = DependencyService.Get<IDialer>();
            dialer?.Dial(ContactDetails.Phone);
        }
    }
}
