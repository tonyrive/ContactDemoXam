using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using ContactDemoXam.Annotations;
using ContactDemoXam.Models;
using ContactDemoXam.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ContactDemoXam.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> ContactList { get; set; }

        private INavigation _navigation;

        public ContactsViewModel(INavigation navigation) => _navigation = navigation;

        #region Load Some Data

        public bool LoadData()
        {
            var assembly = typeof(ContactListPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ContactDemoXam.Models.Contacts.json");
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                ContactList = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(json);
            }

            return true;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
